using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ArrowEditor
{
    static class Interpreter
    {
        public static List<Variable> Variables = new List<Variable>();

        public static void Interpret(List<List<Node>> Nodes)
        {
            int StatementNum = 0;
            int TreeNum = 0;
            List<int> LastTreeNum = new List<int>(); //Last tree so it can return to said tree after for example finishing an if statement
            List<int> LastStatementNum = new List<int>(); //Number of on which statement it was
            while (true)
            {
                if (Nodes[TreeNum].Count != 0)
                {
                    Tuple<Node, int> returnval = SolveTree(Nodes[TreeNum][StatementNum], null);
                    if (returnval.Item2 != -1)
                    {
                        if (Nodes[returnval.Item2].Count > 0 && Nodes[returnval.Item2] != null)
                        {
                            LastTreeNum.Add(TreeNum);
                            TreeNum = returnval.Item2;
                            LastStatementNum.Add(StatementNum + 1);
                            StatementNum = 0;
                        }
                    }
                    else
                    {
                        StatementNum++;
                        if (StatementNum >= Nodes[TreeNum].Count)
                        {
                            if (LastTreeNum.Count == 0)
                            {
                                //If it's here, the program has finished running
                                return;
                            }
                            bool IsEnd = false;
                            for (int i = LastTreeNum.Count - 1; i >= 0; i--)
                            {
                                StatementNum = LastStatementNum[i];
                                LastStatementNum.RemoveAt(i);
                                TreeNum = LastTreeNum[i];
                                LastTreeNum.RemoveAt(i);
                                if (StatementNum < Nodes[TreeNum].Count)
                                {
                                    IsEnd = false;
                                    break;
                                }
                                if (LastTreeNum.Count == 0)
                                {
                                    //If it's here, the program has finished running
                                    return;
                                }
                            }
                            if(IsEnd)
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (LastTreeNum.Count == 0)
                    {
                        return;
                    }
                    StatementNum = LastStatementNum[LastStatementNum.Count - 1];
                    LastStatementNum.RemoveAt(LastStatementNum.Count - 1);
                    TreeNum = LastTreeNum[LastTreeNum.Count - 1];
                    LastTreeNum.RemoveAt(LastTreeNum.Count - 1);
                }
            }
        }

        //null node is move to other tree, -1 int is just return node
        public static Tuple<Node, int> SolveTree(Node Tree, Node Root)
        {
            //Seperate TreeCalls
            List<Node> TreeCalls = new List<Node>();
            TreeCalls = Tree.Branch.Where(n => n.Token.Type == TokenType.TreeCall).ToList();
            Tree.Branch.RemoveAll(n => n.Token.Type == TokenType.TreeCall);
            Node CurrentTree = Tree.Clone();

            for(int i = 0; i < CurrentTree.Branch.Count; i++)
            {
                CurrentTree.Branch[i] = SolveTree(CurrentTree.Branch[i], CurrentTree).Item1;
            }
            if(CurrentTree.Token.Type == TokenType.TreeCall)
            {
                return new Tuple<Node, int>(null, CurrentTree.Token.GetTreeCallID());
            }
            else if(CurrentTree.Token.IsFunc)
            {
                object returnval;
                if (CurrentTree.Branch.Count > 0)
                {
                    Token token = CurrentTree.Branch[0].Token;
                    if(token.String == "LISTVALUE")
                    {
                        returnval = Call(CurrentTree.Token.String, token.List);
                    }
                    else
                    {
                        returnval = Call(CurrentTree.Token.String, FormatValToType(token.String, token.Type));
                    }

                }
                else
                {
                    returnval = Call(CurrentTree.Token.String, null);
                }
                if (returnval != null)
                {
                    if (LibTools.CheckIfList(returnval, false))
                    {
                        CurrentTree.Token.String = "LISTVALUE";
                        CurrentTree.Token.List = (List<object>)returnval;
                        CurrentTree.Token.Type = TokenType.list;
                    }
                    else
                    {
                        CurrentTree.Token.String = returnval.ToString();
                    }
                    if (returnval.GetType() == typeof(string))
                    {
                        CurrentTree.Token.Type = TokenType.str;
                    }
                    else if (returnval.GetType() == typeof(bool))
                    {
                        CurrentTree.Token.Type = TokenType.bln;
                    }
                    else if (double.TryParse(returnval.ToString(), out _))
                    {
                        CurrentTree.Token.Type = TokenType.num;
                    }

                    CurrentTree.Token.IsFunc = false;

                    return new Tuple<Node, int>(CurrentTree, -1);
                }
                else
                {
                    return new Tuple<Node, int>(null, -1);
                }
                
            }
            else if (CurrentTree.Token.Type == TokenType.id)
            {
                if (Root.Token.Type != TokenType.type && Root.Token.String != "=")
                {
                    object val = GetVarValue(CurrentTree.Token.String);

                    if (LibTools.CheckIfList(val, false))
                    {
                        CurrentTree.Token = new Token(TokenType.list, "LISTVALUE", CurrentTree.Token.Prio, false, (List<object>)val);
                    }
                    else
                    {
                        CurrentTree.Token = new Token(TokenType.str, val.ToString(), CurrentTree.Token.Prio);
                    }
                }
                return new Tuple<Node, int>(CurrentTree, -1);
            }
            else if(CurrentTree.Branch.Count == 0)
            {
                return new Tuple<Node, int>(CurrentTree, -1);
            }
            else
            {
                //TEMP: only adding datatypes
                if (CurrentTree.Token.Type == TokenType.op)
                {
                    ////////numbers
                    //TEMP: CHECK IF YOU CAN EVEN USE OPERATOR ON THESE VARIABLES!!!
                    if (double.TryParse(CurrentTree.Branch[0].Token.String, out double number1) & double.TryParse(CurrentTree.Branch[1].Token.String, out double number2))
                    {
                        CurrentTree.Token.Type = TokenType.num;
                    }

    
                    switch(CurrentTree.Token.String)
                    {
                        case "=":
                            //TEMP: everything is technically a string at the moment
                            if(CurrentTree.Branch[0].Token.Type == TokenType.type)
                            {
                                string VarName = CurrentTree.Branch[0].Branch[0].Token.String;
                                if (Variables.Any(x => x.Name == VarName))
                                {
                                    Console.WriteLine("Variable with same name already exists");
                                    Error.Throw(0);
                                }
                                if (CurrentTree.Branch[1].Token.String == "LISTVALUE")
                                {
                                    Variables.Add(new Variable(CurrentTree.Branch[1].Token.List, VarName));
                                }
                                else
                                {
                                    Variables.Add(new Variable(CurrentTree.Branch[1].Token.String, VarName));
                                }
                            }
                            else
                            {
                                string VarName = CurrentTree.Branch[0].Token.String;
                                int VarIndex = Variables.FindIndex(x => x.Name == VarName);
                                if (VarIndex != -1)
                                {
                                    Variables[VarIndex].Val = CurrentTree.Branch[1].Token.String;
                                }
                                else
                                {
                                    Console.WriteLine($"Variable: {VarName} doesn't exist");
                                    Error.Throw(0);
                                }
                            }
                            break;
                        case "+":
                            if (CurrentTree.Token.Type == TokenType.num)
                            {
                                CurrentTree.Token.String = (number1 + number2).ToString();
                            }
                            else
                            {
                                CurrentTree.Token.String = (CurrentTree.Branch[0].Token.String + CurrentTree.Branch[1].Token.String).ToString();
                            }
                            break;
                        case "-":
                            CurrentTree.Token.String = (number1 - number2).ToString();
                            break;
                        case "*":
                            CurrentTree.Token.String = (number1 * number2).ToString();
                            break;
                        case "/":
                            CurrentTree.Token.String = (number1 / number2).ToString();
                            break;
                        case ",":
                            CurrentTree.Token.String = "LISTVALUE";
                            List<object> Values = new List<object>();
                            for (int i = 0; i < 2; i++)
                            {
                                if (CurrentTree.Branch[i].Token.String == "LISTVALUE")
                                {
                                    Values.AddRange(CurrentTree.Branch[i].Token.List);
                                }
                                else
                                {
                                    Values.Add(FormatValToType(CurrentTree.Branch[i].Token.String, CurrentTree.Branch[i].Token.Type));
                                }
                            }
                            CurrentTree.Token.List = Values;
                            CurrentTree.Token.Type = TokenType.list;
                            break;
                        case "==":
                            CurrentTree.Token.String = (CurrentTree.Branch[0].Token.String == CurrentTree.Branch[1].Token.String).ToString();
                            CurrentTree.Token.Type = TokenType.bln;
                            //TEMP: only calls first if statement now
                            if (CurrentTree.Branch[0].Token.String == CurrentTree.Branch[1].Token.String)
                            {
                                return new Tuple<Node, int>(null, TreeCalls[0].Token.GetTreeCallID());
                            }
                            break;
                        default:
                            Console.WriteLine("Don't recognize operator: " + CurrentTree.Token.String);
                            Error.Throw(0);
                            break;
                    }
                }
                return new Tuple<Node, int>(CurrentTree, -1);

            }
            
        }

        public static object Call(string tokenstring, object InputValues)
        {
            //TEMP: will make it call from other libraries than FUNCsystem
            //Console.WriteLine("Called: " + tokenstring);
            MethodInfo Method = typeof(FUNCsystem).GetMethod(tokenstring);
            Console.WriteLine("Called: " + tokenstring);
            if (InputValues != null)
            {
                if (InputValues.GetType() == typeof(List<object>))
                {
                    List<object> arr = (List<object>)InputValues;
                    return Method.Invoke(null, new object[] { arr.ToArray() });
                }
                else
                {
                    return Method.Invoke(null, new object[] { InputValues });
                }
            }
            else
            {
                return Method.Invoke(null, new object[] {});
            }

        }

        public static object FormatValToType(string val, TokenType type)
        {
            switch(type)
            {
                case TokenType.num:
                    if(val.Contains("."))
                    {
                        return float.Parse(val);
                    }
                    return int.Parse(val);
                case TokenType.bln:
                    return bool.Parse(val);
                default:
                    return val;
            }
        }

        public static object GetVarValue(string VarName)
        {
            
            int Index = Variables.FindIndex(x => x.Name == VarName);
            if (Index != -1)
            {
                return Variables[Index].Val;
            }
            return "UNDEFINEDVAR";
        }
        //////////////////////////////////////////////////////PREPERATION 
        
        public static void Run(string Code)
        {
            Interpreter.Variables = new List<Variable>();
            string ReadyCode = Tokenizer.GetCodeReady(Code);
            List<Token> Tokens = Tokenizer.CodeToTokens(ReadyCode);

            Tokens.RemoveAll(x => x.Prio == -2);
            Tokens.RemoveAll(x => x.Prio == -5);
            Console.WriteLine("///////////////////////Starting Tokens :");
            Tokens.ForEach(x => x.Print(true));
            Console.WriteLine("///////////////////////");

            List<List<Token>> SplitTokens = SplitTokenList(Tokens); //Sorted by brackets
            Console.WriteLine(SplitTokens.Count + "<<<<<<");

            List<List<List<Token>>> StatementSortedTokens = new List<List<List<Token>>>(); //Sorted by brackets, then by statements

            for (int i = 0; i < SplitTokens.Count; i++)
            {
                StatementSortedTokens.Add(SortByStatement(SplitTokens[i]));
            }
            foreach (var a in StatementSortedTokens)
            {
                //Here we are in a specific bracket's list of statements
                Console.WriteLine("");
                foreach (var b in a)
                {
                    //Here we are in a specific statement
                    string s = "";
                    b.ForEach(c => s += c.String);
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("Finish!");
            //Here it's Done sorting tokens by bracket and statement, everything has priorities and all removables are gone, it's now time for the tokenizer to convert individual tokens to nodes

            List<List<Node>> Nodes = new List<List<Node>>();
            for (int a = 0; a < StatementSortedTokens.Count; a++)
            {
                Nodes.Add(new List<Node>());
                for (int b = 0; b < StatementSortedTokens[a].Count; b++)
                {
                    Nodes[a].Add(Tokenizer.TokensToTree(StatementSortedTokens[a][b]));
                }
            }
            Nodes.ForEach(x => x.ForEach(a => a.Print()));
            Console.WriteLine("////////");

            Interpreter.Interpret(Nodes);
        }

        public static List<List<Token>> SortByStatement(List<Token> Tokens)
        {
            List<List<Token>> Final = new List<List<Token>>();

            List<Token> CurrentStatement = new List<Token>();
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].String == "]" || Tokens[i].Type == TokenType.TreeCall)
                {
                    if (Tokens[i].Type == TokenType.TreeCall)
                    {
                        CurrentStatement.Add(Tokens[i]);
                    }
                    Final.Add(CurrentStatement);
                    CurrentStatement = new List<Token>();
                }
                else
                {
                    CurrentStatement.Add(Tokens[i]);
                }
            }
            return Final;
        }

        ///Splits list of token by arrows, adds TreeCalls
        public static List<List<Token>> SplitTokenList(List<Token> Tokens)
        {
            List<List<Token>> TokenTrees = new List<List<Token>>();
            List<bool> OpenBrackets = new List<bool>(); //if true then the brackter layer number is closed
            OpenBrackets.Add(true);
            int CurrentTreeNum = 0;
            int CurrentMax = 0;
            int CurrentID = 1;


            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].String == "<")
                {
                    for (int p = TokenTrees.Count - 1; p <= CurrentTreeNum; p++) { TokenTrees.Add(new List<Token>()); }
                    TokenTrees[CurrentTreeNum].Add(new Token(TokenType.TreeCall, "TREECALL" + CurrentID, 0));
                    CurrentID++;

                    CurrentTreeNum++;
                    if (CurrentMax >= CurrentTreeNum)
                    {
                        CurrentTreeNum = CurrentMax + 1;
                    }
                    CurrentMax = CurrentTreeNum;
                    OpenBrackets.Add(true);
                }
                else if (Tokens[i].String == ">")
                {
                    OpenBrackets[CurrentTreeNum] = false;
                    //find nearest below layer that isnt closed
                    int NewLayer = -1;
                    for (int a = CurrentTreeNum; a >= 0; a--)
                    {
                        if (OpenBrackets[a])
                        {
                            NewLayer = a;
                            break;
                        }
                    }
                    CurrentTreeNum = NewLayer;
                }
                else
                {
                    for (int p = TokenTrees.Count - 1; p <= CurrentTreeNum; p++) { TokenTrees.Add(new List<Token>()); }
                    TokenTrees[CurrentTreeNum].Add(Tokens[i]);
                }
            }

            Console.WriteLine("///////////////////////Starting Tokens after TreeCall sorting:");
            for (int i = 0; i < TokenTrees.Count; i++)
            {
                List<Token> a = TokenTrees[i];
                if (a.Count > 0)
                {
                    Console.WriteLine($"//////// {i} \n");
                    a.ForEach(x => x.Print(true));
                }
            }
            Console.WriteLine("///////////////////////");

            return TokenTrees;
        }

    }
}