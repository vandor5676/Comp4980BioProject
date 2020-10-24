using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp4980BioProject
{
    public class Node
    {
        char topLetter { get; set; }
        char leftLetter { get; set; }
        
        public char valLetter { get; set; }
        public int value;
        
        Node left, top, diag;

        string description;

        public Node(int leftVal, int topVal, int diagVal)
        {
            int leftScore = leftVal;
            int stopint = 0;
        }

        //nullNode
        public Node()
        {
            this.value = 100;
        }


    }
}
