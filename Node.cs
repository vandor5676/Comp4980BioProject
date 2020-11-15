using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
        //color for traceback matrix
        public SolidColorBrush backColor { get; set; }

        public Node cameFrom { get; set; } = null;
        
        //describes the direction that this node came from, used to create the pairwise alignment
        public string cameFromDirection { get; set; }

        //used when calculating best option(left top diag)
        public int calcScore { get; set; }

        //describes the direction of the next node in the traceback matrix, used to create the pairwise alignment
        public string directionPasser { get; set; }


        //nullNode
        public Node()
        {
            this.value = 100;
        }

        //create a blank node 
        public Node(string value)
        {
            if (value == "blank")
                this.valLetter = '-';
        }


    }
}
