using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp4980BioProject
{
    public class Node
    {
        
       public char topLetter { get; set; }
       public char leftLetter { get; set; }

        //for elements with letters
        public char valLetter { get; set; } = '0';
        // for elements with numbers
        public int value;


        public Node cameFrom { get; set; } = null;

        //used when calculating best option(left top diag)
       public int calcScore { get; set; }

        //nullNode
        public Node()
        {
            this.value = 100;
        }

        //create a blank node 
        public Node(string value)
        {
            if(value == "blank")
            this.valLetter = '-';
        }


    }
}
