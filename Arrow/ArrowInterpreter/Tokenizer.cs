using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowEditor
{
    static class Tokenizer
    {
        //ASTree layers:
        public static string[,] Priorities = new string[,] { { "==", ">=", "<=", "", "", "", ""},
                                                            { "=", "", "", "", "", "", ""},
                                                           { "functions", "", "", "", "", "", "" },
                                                           { "", "", "", "", "", "", "" },
                                                           { ",", "", "", "", "", "", "" },
                                                           { "+", "-", "", "", "", "", "" },
                                                           { "*", "/", "%", "", "", "", "" },
                                                           { "numbers", "strings", "variables", "", "", "", ""},
                                                           { "datatypes", "", "", "", "", "", "" }};

                                                           //Prio of arrows and brackets doesnt matter since they all get added to PrioMap as -2 (have to be in here to be recognized as an operator), ] just in there for same reason, gets removed after splitting statements with prio -4 
        public static string[] Operators = new string[] { ">", "_", "+", "-", "*", "/", "<", "(", ")", "==", ">=", "<=", "]", "=", ","};
        public static string[] DataTypes = new string[] { "int", "bln", "dbl", "flt", "str", "lst"};

        public static string GetCodeReady(string Code)
        {
            Code = Code.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");
            Code = Code.Replace(" ", "`");
            List<int> OperatorIndexes = new List<int>();
            List<int> OpLengths = new List<int>();
            List<int> DataTypeIndexes = new List<int>();
            foreach(string a in Operators)
            {
                foreach(int b in Code.AllIndexesOf(a))
                {
                    Console.WriteLine(a);
                    OperatorIndexes.Add(b);
                    OpLengths.Add(a.Length);
                }
            }
            foreach (string a in DataTypes)
            {
                foreach (int b in Code.AllIndexesOf(a))
                {
                    DataTypeIndexes.Add(b);
                }
            }
            
            DataTypes.ToList().ForEach(x => Code.AllIndexesOf(x).ForEach(a => DataTypeIndexes.Add(a)));

            bool IsInString = false;
            int OpNum = 0;
            for(int i = 0; i < Code.Length; i++)
            {
                int AddNum = 0;
                if (Code[i] == '"')
                {
                    IsInString = !IsInString;
                }
                else if(OperatorIndexes.Contains(i) && !IsInString)
                {
                    if(i > 0 && i + OpLengths[OpNum] < Code.Length)
                    {
                        Code = Code.Insert(i, "~");
                        Code = Code.Insert(i+1 + OpLengths[OpNum], "~");
                        AddNum += 2;    
                    }
                    else if(i > 0)
                    {
                        Code = Code.Insert(i + OpLengths[OpNum], "~");
                        AddNum++;
                    }
                    else if(i < Code.Length)
                    {
                        Code = Code.Insert(i, "~");
                        AddNum++;
                    }
                    OpNum++;
                }
                else if(DataTypeIndexes.Contains(i) && !IsInString)
                {
                    if (i > 0 && i + 3 < Code.Length)
                    {
                        if (Code[i + 3] == '`' && Code[i - 1] == '`')
                        {
                            Code = Code.Insert(i, "~");
                            Code = Code.Insert(i + 1 + 3, "~");
                            AddNum += 2;
                        }
                    }
                    else if (i > 0)
                    {
                        if (Code[i - 1] == '`')
                        {
                            Code = Code.Insert(i + 3, "~");
                            AddNum++;
                        }
                    }
                    else if (i+3 < Code.Length)
                    {
                        if (Code[i + 3] == '`')
                        {
                            Code = Code.Insert(i+3, "~");
                            AddNum++;
                        }
                    }
                }

                for(int c = 0; c < OperatorIndexes.Count; c++)
                {
                    if (OperatorIndexes[c] > i)
                    {
                        OperatorIndexes[c] += AddNum;
                    }
                }
                for (int c = 0; c < DataTypeIndexes.Count; c++)
                {
                    if (DataTypeIndexes[c] > i)
                    {
                        DataTypeIndexes[c] += AddNum;
                    }
                }
                i += AddNum;
            }
            Code = Code.Replace("~~", "~");
            bool IsString = false;
            char[] CodeChars = Code.ToCharArray();
            for(int i = 0; i < CodeChars.Length; i++)
            {
                if(CodeChars[i]=='\"')
                {
                    IsString = !IsString;
                }
                else if(CodeChars[i] == '`')
                {
                    if (IsString)
                    { 
                        CodeChars[i] = ' ';
                    }
                    else
                    {
                        string TempCode = new string(CodeChars);
                        TempCode = TempCode.Remove(i, 1);
                        i--;
                        CodeChars = TempCode.ToCharArray();
                    }
                }
            }
            Code = new string(CodeChars);
            Console.WriteLine("NewCode: " + Code);
            return Code;
        }

        public static List<Token> CodeToTokens(string Code)
        {
            List<string> tokenStrings = Code.Split('~').ToList();
            tokenStrings.RemoveAll(x => x == "");

            List<Token> Tokens = new List<Token>();
            for(int i = 0; i < tokenStrings.Count; i++)
            {
                string tokenstring = tokenStrings[i];
                
                //Convert string to Token
                TokenType type = TokenType.id;
                if (tokenstring.Contains("\""))
                {
                    type = TokenType.str;
                }
                else if (IsDataType(tokenstring))
                {
                    type = TokenType.type;
                }
                else if (Operators.Contains(tokenstring))
                {
                    type = TokenType.op;

                    if (tokenstring == "-")
                    {
                        Tokens.Add(new Token(TokenType.op, "-", -100));
                        Tokens.Add(new Token(TokenType.num, "0", -100));
                    }
                } 
                else if (tokenstring.Any(char.IsDigit))
                {
                    type = TokenType.num;
                }
                else if (tokenstring.Any(char.IsLetter))
                {
                    type = TokenType.id;
                }
                else if (tokenstring.Contains("TREECALL"))
                {
                    type = TokenType.TreeCall;
                }
                else
                {
                    //ERROR: Could not identify TokenType
                    Console.WriteLine("Could not identify TokenType of " + tokenstring);
                    Error.Throw(0);
                }
                Tokens.Add(new Token(type, tokenstring, -100, i + 1 < tokenStrings.Count && tokenStrings[i + 1] == ">" && type == TokenType.id));
            }
            for(int i = 0; i < Tokens.Count; i++)
            {
                if(Tokens[i].String == "=" && Tokens[i+1].String == "=")
                {
                    Tokens[i] = new Token(TokenType.op, "==", -100);
                    Tokens.Remove(Tokens[i+1]);
                }
                else if(Tokens[i].String[0] == '"')
                {
                    Tokens[i].String = Tokens[i].String.Replace("\"", "");
                }
            }

            List<double> PrioMap = GetPrioMap(Tokens);
            //Set all the prios gotten from the PrioMap
            for (int i = 0; i < Tokens.Count; i++)
            {
                Tokens[i].Prio = PrioMap[i];
            }

            return Tokens;
        }
        //Convert token list to abstract syntax tree
        public static Node TokensToTree(List<Token> Tokens, Node Root = null)
        {
            List<Token> CurrentTokens = new List<Token>(Tokens);
            List<Token> TreeCallTokens = new List<Token>();
            //Seperate TreeCalls from the tokens
            TreeCallTokens = CurrentTokens.Where(b => b.Type == TokenType.TreeCall).ToList();
            CurrentTokens.RemoveAll(x => x.Type == TokenType.TreeCall);

            int RootNum = GetHighestPrioInArray(CurrentTokens.ToArray());
            Console.WriteLine("Root set to: " + CurrentTokens[RootNum].String + " type: " + CurrentTokens[RootNum].Type.ToString());
            Node CurrentNode = new Node(new List<Node>(), CurrentTokens[RootNum], -1, Root);
            string tkns = "";
            CurrentTokens.ForEach(x => tkns += x.String + " ");
            Console.WriteLine("Current Tokens start func: " + tkns);
            while (true)
            {
                tkns = "";
                CurrentTokens.ForEach(x => tkns += x.String + " ");
                Console.WriteLine("Current Tokens: " + tkns);
                if (CurrentTokens.Count == 1)
                {
                    Console.WriteLine("only one token, returned: " +  CurrentTokens[0].String);
                    return CurrentNode.GetRoot();
                }
                if (CurrentNode.Token.Type == TokenType.id && CurrentNode.Token.IsFunc)
                {
                    //remove the token that is now the node's base token
                    CurrentTokens.RemoveAt(RootNum);
                    tkns = "";
                    CurrentTokens.ForEach(x => tkns += x.String + " ");
                    Console.WriteLine("after remove Current Tokens: " + tkns);
                    
                    if (CurrentTokens.Count > 0)
                    {
                        int newhighest = GetHighestPrioInArray(CurrentTokens.ToArray());
                        Console.WriteLine("highest prio after func : " + CurrentTokens[newhighest].String);
                        Token HighestPrioTokenAfterFunc = CurrentTokens[newhighest];
                        CurrentNode.Branch.Add(TokensToTree(CurrentTokens));
                        return CurrentNode.GetRoot();
                    }
                    else
                    {
                        return CurrentNode.GetRoot();
                    }
                }
                else if (CurrentNode.Token.Type == TokenType.op)
                {
                    int TokenIndex = CurrentTokens.IndexOf(CurrentNode.Token);
                    if (TokenIndex == CurrentTokens.Count - 1 || TokenIndex == 0)
                    {
                        //ERROR: operator without input on both sides
                        Console.WriteLine("operator without input on both sides");
                        Error.Throw(0);
                    }
                    List<Token> LeftSide = CurrentTokens.GetRange(0, TokenIndex);
                    List<Token> RightSide = CurrentTokens.GetRange(TokenIndex + 1, CurrentTokens.Count - (TokenIndex + 1));
                    tkns = "";
                    LeftSide.ForEach(x => tkns += x.String + " ");
                    Console.WriteLine("left: " + tkns);
                    tkns = "";
                    RightSide.ForEach(x => tkns += x.String + " ");
                    Console.WriteLine("right: " + tkns);
                    Node LeftNode = TokensToTree(LeftSide);
                    Node RightNode = TokensToTree(RightSide);

                    //Only set root after function because TokensToTree returns root of node, so if I set the node to the current one it will return the whole current note as that is the root, instead of returning just the branch
                    LeftNode.Root = CurrentNode;
                    RightNode.Root = CurrentNode;

                    CurrentNode.Branch.Add(LeftNode);
                    CurrentNode.Branch.Add(RightNode);
                    TreeCallTokens.ForEach(TreeCall => CurrentNode.Branch.Add(new Node(new List<Node>(), TreeCall, TreeCall.GetTreeCallID())));
                    Console.WriteLine("returned operator");
                    return CurrentNode.GetRoot();
                }
                else if(CurrentNode.Token.Type == TokenType.type)
                {
                    int TokenIndex = CurrentTokens.IndexOf(CurrentNode.Token);
                    if (TokenIndex == CurrentTokens.Count - 1)
                    {
                        //ERROR: operator without input on both sides
                        Console.WriteLine("datatype decleration at end");
                        Error.Throw(0);
                    }
                    Node Added = new Node(new List<Node>(), CurrentTokens[TokenIndex + 1], -100, CurrentNode);
                    CurrentNode.Branch.Add(Added);
                    return CurrentNode.GetRoot();
                }
                else if (CurrentNode.Token.Type == TokenType.num || CurrentNode.Branch.Count == 0)
                {
                    //Add TreeCalls back (if any exist)
                    return CurrentNode.GetRoot();
                }
            }     
        }

        //Get highest priority index from token array
        public static int GetHighestPrioInArray(Token[] Tokens)
        {
            Console.WriteLine("//////");
            double highest = double.MinValue;
            for(int i = 0; i < Tokens.Length; i++)
            {
                if(Tokens[i].Prio >= highest)
                {
                    highest = Tokens[i].Prio;
                }
            }
            for(int i = Tokens.Length-1; i >= 0; i--)
            {
                if(Tokens[i].Prio == highest)
                {
                    //Cause for datatypes they need to be from left to right, cuz datatype needs higher prio than the var
                    if(Tokens[i].Type != TokenType.id)
                    {
                        return i;
                    }
                    ////// recheck for dataype
                    for (int a = 0; a < Tokens.Length; a++)
                    {
                        if (Tokens[a].Prio > highest)
                        {
                            highest = Tokens[a].Prio;
                        }
                    }
                    for (int a = 0; a < Tokens.Length; a++)
                    {
                        if (Tokens[a].Prio == highest)
                        {
                            if (Tokens[a].Type == TokenType.type)
                            {
                                return a;
                            }
                            return i;
                        }
                    }

                }
            }
            Console.WriteLine("return -1");
            return -1;
        }

        public static List<double> GetPrioMap(List<Token> Tokens)
        {
            List<double> PrioMap = new List<double>();
            int LayerMultNum = 0;
            //How many times > is in the tokenlist
            for (int i = 0; i < Tokens.Count; i++) { if (Tokens[i].String == ">" && i > 0 && Tokens[i-1].IsFunc) LayerMultNum++; }
            int UnclosedFuncArrows = 0;
            for(int i = 0; i < Tokens.Count; i++)
            {
                if(Tokens[i].String == ">" || Tokens[i].String == "<" || Tokens[i].String == "(" || Tokens[i].String == ")")
                {
                    bool NewCallTree = false;
                    if (Tokens[i].String == ">")
                    {
                        if (i == 0) 
                        { //ERROR: Function expected
                            Error.Throw(0);
                        }
                        if(Tokens[i-1].IsFunc)
                        {
                            LayerMultNum--;

                            //Also add the multiplyer to the last one
                            if (i > 0)
                            {
                                PrioMap[i - 1] = GetPrio(Tokens[i - 1].String, true) * (double)(Math.Pow(100, LayerMultNum));
                            }
                            UnclosedFuncArrows++;
                        }
                        else
                        {
                            NewCallTree = true;
                            LayerMultNum++;
                        } 
                    }
                    else if(Tokens[i].String == "(")
                    {
                        LayerMultNum--;
                    }
                    else if (Tokens[i].String == "<")
                    {
                        if (UnclosedFuncArrows > 0)
                        {
                            UnclosedFuncArrows--;
                            LayerMultNum++;
                        }
                        else
                        {
                            NewCallTree = true;
                            LayerMultNum--;
                        }
                    }
                    else if (Tokens[i].String == ")")
                    {
                        LayerMultNum++;
                    }

                    if (NewCallTree)
                    {
                        //Tokens with prio = -3 are around what should be a new tree
                        PrioMap.Add(-3);
                    }
                    else
                    {
                        //Tokens with prio = -2 are made to be removed after PrioMap generation
                        PrioMap.Add(-2);
                    }
                }
                else if(Tokens[i].String == "]")
                {
                    PrioMap.Add(-4);
                }
                else
                {
                    //New layers all have two extra zero's after the id per layer, 10 wasnt enough cause I might use 10 or more priolayers in my Priorities 2D array
                    bool IsFunction = false;
                    if(i + 1 < Tokens.Count)
                    {
                        IsFunction = Tokens[i + 1].String == ">";
                    }
                    PrioMap.Add(GetPrio(Tokens[i].String, IsFunction) * (double)(Math.Pow(100, LayerMultNum)));
                }
            }
            return PrioMap;
        }
        public static int GetPrio(string tokenstring, bool IsFunc)
        {
            if (tokenstring.Any(char.IsDigit))
            {
                tokenstring = "numbers";
            }
            else if(tokenstring.Any(char.IsLetter))
            {
                if (IsFunc)
                {
                    tokenstring = "functions";
                }
                else
                {
                    tokenstring = "variables";
                }
            }
            else if(IsDataType(tokenstring))
            {
                tokenstring = "datatypes";
            }

            for (int y = 0; y < Priorities.GetLength(1); y++)
            {
                for (int x = 0; x < Priorities.GetLength(0); x++)
                {
                    if (tokenstring == Priorities[x, y])
                    {
                        return Priorities.GetLength(0) - x;
                    }
                }
            }
            //ERROR: could not get priority
            Console.WriteLine("couldnt get prio of" + tokenstring);
            Error.Throw(0);
            return -1;
        }

        public static bool IsDataType(string a)
        {
            return DataTypes.Contains(a);
        }
    }
}
