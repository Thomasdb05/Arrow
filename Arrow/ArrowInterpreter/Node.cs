using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowEditor
{
    //Abstract Syntax Tree
    class Node
    {
        public Node(List<Node> branch, Token token, int id, Node root = null)
        {
            Branch = branch;
            Token = token;
            ID = id;
        }
        //root of this branch, not root of entire tree
        public Node Root { get; set; }

        public List<Node> Branch { get; set; }
        public Token Token { get; set; }
        public int ID { get; set; }

        public Node GetRoot()
        {
            Node currentRoot = this;
            while(true)
            {
                if(currentRoot.Root != null)
                {
                    currentRoot = currentRoot.Root;
                }
                else
                {
                    return currentRoot;
                }
            }
        }
        //Get tree as string
        public string GetString(bool WithPrio = false)
        {
            string final = Token.GetString(WithPrio) + " ID:" + ID +"\n { \n";

            foreach (Node n in Branch)
            {
                final += n.GetString();
            }
            final += "\n } \n";
            return final;
        }

        public void Print()
        {
            Console.WriteLine(GetString());
        }

        public Node Clone()
        {
            return new Node(new List<Node>(Branch), Token, ID, Root);
        }
    }
    public class Nodes
    {

    }


}
