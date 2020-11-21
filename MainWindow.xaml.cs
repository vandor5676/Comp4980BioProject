using MoreLinq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace Comp4980BioProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //sequences
        string seq1, seq2;
        //linear gap penalty
        public int lgp = -1;

        //default background color
        SolidColorBrush defaultBrush = Brushes.LightGray;

        //holds the table values
        List<List<Node>> grid;

        //strings holding the paiwise alignment information
        string alignmentTop, alignmentLeft, alignmentBars;

        public class DataObject
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
        }

        //create matrix
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            //get sequences
            seq1 = seq1TextBox.Text.ToUpper();
            seq2 = seq2TextBox.Text.ToUpper();

            //get alighnment type
            bool localAlighnment = (bool)localAlignmentRB.IsChecked;

            lgp = -1;//linear gap penalty

            //Declare Grid List
            grid = new List<List<Node>>();

            //clear previous pairwise alignment 
            alignmentTop = ""; alignmentLeft = ""; alignmentBars = "";

            //first 2 blanks in grid
            grid.Add(new List<Node>());//new line
            grid[0].Add(new Node("blank"));
            grid[0].Add(new Node("blank"));

            //Write first sequence
            foreach (char letter in seq1)
            {
                grid[0].Add(new Node { valLetter = letter });
            }

            //Add the second lines blank and zero
            grid.Add(new List<Node>());//new line
            grid[1].Add(new Node("blank"));
            grid[1].Add(new Node { value = 0, topLetter = '-', leftLetter = '-' });

            //write first linear gap penalty line 
            foreach (char letter in seq1)
            {
                //if local alignment make all negatives equal to zero
                if (localAlighnment)
                    grid[1].Add(new Node { value = 0, topLetter = letter, leftLetter = '-', cameFrom = grid[1].Last() });
                else
                    grid[1].Add(new Node { value = grid[1].Last().value + lgp, topLetter = letter, leftLetter = '-', cameFrom = grid[1].Last() });//each linear gap penalty is the previus square + the penalty
            }

            Node bigestNode = new Node { value = -1 };
            //add each line untill the end
            foreach (char letter in seq2)
            {
                List<Node> tempLine = new List<Node>();// line to be added to the grid once filed
                int previusLine = grid.IndexOf(grid.Last());

                tempLine.Add(new Node { valLetter = letter });//add a letter to the start of the line

                //if local alignment make all negatives equal to zero //----sets the vertical linear gap penalty boxes
                tempLine.Add((localAlighnment) ?
                    (new Node { value = 0, leftLetter = letter, topLetter = '-', cameFrom = grid.Last()[1] }) :
                    (new Node { value = (grid.Last()[1].value + (lgp)), leftLetter = letter, topLetter = '-', cameFrom = grid.Last()[1] }));

                foreach (char letter2 in seq1)//inner matrix
                {
                    int curentIndex = tempLine.IndexOf(tempLine.Last()) + 1;
                    Node left = tempLine[curentIndex - 1];
                    Node top = grid[previusLine][curentIndex];
                    Node diag = grid[previusLine][curentIndex - 1];

                    //get best choice
                    Node cameFrom = GetBestNode(left, top, diag, localAlighnment, letter, letter2);
                    tempLine.Add(new Node { value = cameFrom.calcScore, leftLetter =letter , topLetter = letter2, cameFrom = cameFrom, cameFromDirection = cameFrom.directionPasser });
                    //keep track of bigest node
                    if (tempLine.Last().value > bigestNode.value) bigestNode = tempLine.Last();
                }
                grid.Add(tempLine);
            }
            //--
            //create traceback
            if (localAlighnment)
                createLocalTraceback(bigestNode);
            else
                createGlobalTraceback();

            //display grid and pairwise alignment
            DisplayGrid();
            DisplayPairwiseAlignment();



        }
        public void createLocalTraceback(Node workingNode)
        {
            workingNode.backColor = Brushes.LightBlue;
            do
            {
                createPairwiseAlignment(workingNode);
                workingNode = workingNode.cameFrom;
                workingNode.backColor = Brushes.LightBlue;//traceback color               
            }
            while (workingNode.value != 0);
        }
        public void createGlobalTraceback()
        {
            Node workingNode = grid.Last().Last();
            workingNode.backColor = Brushes.LightBlue;
            do
            {
                createPairwiseAlignment(workingNode);
                workingNode = workingNode.cameFrom;
                workingNode.backColor = Brushes.LightBlue;//traceback color  

            }
            while (workingNode.cameFrom != null);
        }
        // alignmentTop, alignmentLeft, alignmentBars;
        public void createPairwiseAlignment(Node workingNode)
        {
            if (workingNode.cameFrom != null)
                if (workingNode.cameFromDirection == "left")
                {
                    // MessageBox.Show("left");
                    alignmentTop += workingNode.topLetter;
                    alignmentLeft += "-";
                    alignmentBars += " ";
                }
                else if (workingNode.cameFromDirection == "up")
                {
                    // MessageBox.Show("up");
                    alignmentTop += "-";
                    alignmentLeft += workingNode.leftLetter;
                    alignmentBars += " ";
                }
                else if (workingNode.cameFromDirection == "diagonal")
                {
                    //MessageBox.Show("diagonal");
                    alignmentLeft += workingNode.leftLetter;
                    alignmentTop += workingNode.topLetter;
                    alignmentBars += (workingNode.leftLetter == workingNode.topLetter) ? "|" : " ";
                }
        }


        public Node GetBestNode(Node leftNode, Node topNode, Node diagNode, bool isLocalAlignment, char l1, char l2)
        {
            //give each node a score
            leftNode.calcScore = leftNode.value + lgp;
            topNode.calcScore = topNode.value + lgp;
            diagNode.calcScore = diagNode.value + matchMissmatchScore(l1, l2); //subMatrixLookup();

            //describe potental next node location, used for pairwise alignment
            leftNode.directionPasser = "left";
            topNode.directionPasser = "up";
            diagNode.directionPasser = "diagonal";

            List<Node> Nodes = new List<Node> { leftNode, topNode, diagNode };
            var bestNode = Nodes.MaxBy(x => x.calcScore).First();

            if (isLocalAlignment && bestNode.calcScore < 0)
                bestNode.calcScore = 0;

            return bestNode;
        }

        private int subMatrixLookup(char matrix, int matNum char c1, char c2) // -----this is where the matrix lookup 
        {
            
            if(matrix =='p')
                if(matNum==50)
                    return pam50(c1,c2);
                else if(matNum==150)
                    return pam150(c1,c2);
                else if(matNum==250)
                    return pam250(c1, c2);
            else if (matrix == 'b')
                    if(matNum==62)
                        return blosum62(c1, c2);
                    else if(matNum==80)
                        return blosum80(c1,c2);
                    else if(matNum==90)
                        return blosum90(c1,c2);
            else
                return 0;
         
        }

        public int pam50(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 5,  -5,  -2,  -2,  -5,  -3,  -1,  -1,  -5,  -3,  -5,  -5,  -4,  -7,   0,   0,   0, -11,  -6,  -1,  -2,  -2,  -2 };
            int[] r = { -5,   8,  -4,  -7,  -6,   0,  -7,  -7,   0,  -4,  -7,   1,  -3,  -8,  -3,  -2,  -5,  -1,  -8,  -6,  -5,  -2,  -4 };
            int[] n = { -2,  -4,   7,   2,  -8,  -2,  -1,  -2,   1,  -4,  -6,   0,  -6,  -7,  -4,   1,  -1,  -7,  -3,  -6,   5,  -1,  -2 };
            int[] d = { -2,  -7,   2,   7, -11,  -1,   3,  -2,  -2,  -6, -10,  -3,  -8, -12,  -6,  -2,  -3, -12,  -9,  -6,   6,   2,  -4 };
            int[] c = { -5,  -6,  -8, -11,   9, -11, -11,  -7,  -6,  -5, -12, -11, -11, -10,  -6,  -2,  -6, -13,  -3,  -5,  -9, -11,  -7 };
            int[] q = { -3,   0,  -2,  -1, -11,   8,   2,  -5,   2,  -6,  -4,  -2,  -3, -10,  -2,  -4,  -4, -10,  -9,  -5,  -2,   6,  -3 };
            int[] e = { -1,  -7,  -1,   3, -11,   2,   7,  -3,  -3,  -4,  -7,  -3,  -5, -11,  -4,  -3,  -4, -13,  -7,  -5,   2,   6,  -3 };
            int[] g = { -1,  -7,  -2,  -2,  -7,  -5,  -3,   6,  -7,  -8,  -9,  -6,  -7,  -8, -4,  -1,  -4, -12, -11,  -4,  -2,  -4,  -4 };
            int[] h = { -5,   0,   1,  -2,  -6,   2 , -3,  -7,   9,  -7,  -5,  -4,  -8 , -5 , -3 , -4 , -5 , -6 , -2 , -5 ,  0 ,  0,  -4 };
            int[] i = { -3,  -4,  -4,  -6,  -5,  -6,  -4,  -8 , -7,   8,   0,  -5 ,  0,  -1,  -7,  -5 , -1, -11,  -5,   3,  -5,  -5,  -3 };
            int[] l = { -5,  -7,  -6, -10, -12,  -4 , -7,  -9,  -5,   0,   6,  -6 ,  2 , -1 , -6,  -7,  -5,  -5,  -5,  -1,  -7,  -5,  -5 };
            int[] k = { -5,   1,   0,  -3, -11,  -2,  -3,  -6 , -4,  -5,  -6,   6,  -1, -11,  -5 , -3,  -2,  -9,  -8,  -7,  -1,  -2,  -4 };
            int[] m = { -4 , -3,  -6,  -8, -11,  -3,  -5,  -7,  -8,   0,   2,  -1,  10 , -3,  -6,  -4,  -3 ,-10 , -8,   0,  -7,  -4,  -4 };
            int[] f = { -7,  -8,  -7, -12, -10, -10, -11,  -8,  -5,  -1,  -1, -11,  -3,   9,  -8 , -5,  -7,  -3,   3,  -6,  -9, -11,  -6 };
            int[] p = { 0,  -3,  -4,  -6,  -6,  -2,  -4,  -4,  -3,  -7,  -6,  -5,  -6,  -8,   8,  -1,  -3, -11, -11,  -4,  -5,  -3,  -4 };
            int[] s = { 0,  -2,   1,  -2,  -2,  -4,  -3,  -1 , -4 , -5,  -7,  -3,  -4,  -5,  -1,   6,   1 , -4,  -5,  -4,  -1,  -3,  -2 };
            int[] t = { 0,  -5,  -1,  -3,  -6,  -4,  -4,  -4,  -5,  -1,  -5,  -2,  -3,  -7,  -3,   1,   6, -10,  -5,  -2,  -2,  -4,  -2 };
            int[] w = { -11,  -1,  -7, -12, -13, -10, -13, -12,  -6, -11,  -5,  -9, -10,  -3, -11,  -4, -10,  13,  -4, -12,  -8, -11,  -9 };
            int[] y = { -6,  -8,  -3,  -9,  -3,  -9,  -7, -11,  -2,  -5 , -5,  -8,  -8,   3, -11,  -5,  -5,  -4,   9,  -6,  -5,  -8,  -6 };
            int[] v = { -1,  -6,  -6,  -6,  -5,  -5,  -5,  -4,  -5,   3,  -1,  -7,   0,  -6,  -4,  -4,  -2, -12,  -6,   7,  -6,  -5,  -3 };

            char[] xAxis = {'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v'};

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);
            
            switch(yIndex)
            {
                case 0:
                    return a[xIndex];

                case 1:
                    return r[xIndex];

                case 2:
                    return n[xIndex];

                case 3:
                    return d[xIndex];

                case 4:
                    return c[xIndex];

                case 5:
                    return q[xIndex];

                case 6:
                    return e[xIndex];

                case 7:
                    return g[xIndex];

                case 8:
                    return h[xIndex];

                case 9:
                    return i[xIndex];

                case 10:
                    return l[xIndex];

                case 11:
                    return k[xIndex];

                case 12:
                    return m[xIndex];

                case 13:
                    return f[xIndex];

                case 14:
                    return p[xIndex];

                case 15:
                    return s[xIndex];

                case 16:
                    return t[xIndex];

                case 17:
                    return w[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return v[xIndex];   
            }
            return 0;
        }

        public int pam150(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 3, -2,  0,  0, -2, -1,  0,  1, -2, -1, -2, -2, -1, -4,  1,  1,  1, -6, -3,  0,  0,  0, -1 };
            int[] r = { -2,  6, -1, -2, -4,  1, -2, -3,  1, -2, -3,  3, -1, -4, -1, -1, -2,  1, -4, -3, -2,  0, -1 };
            int[] n = { 0, -1,  3,  2, -4,  0,  1,  0 , 2 ,-2 ,-3,  1, -2, -4, -1,  1,  0, -4, -2, -2,  3,  1, -1 };
            int[] d = { 0, -2,  2,  4, -6,  1,  3,  0,  0, -3, -5, -1, -3, -6, -2,  0, -1, -7, -4 ,-3,  3,  2, -1 };
            int[] c = { -2, -4, -4, -6,  9, -6, -6, -4, -3, -2, -6 ,-6, -5, -5, -3,  0, -3, -7,  0, -2, -5, -6, -3 };
            int[] q = { -1,  1,  0,  1, -6,  5,  2, -2,  3, -3, -2,  0, -1, -5,  0, -1, -1, -5, -4, -2,  1,  4, -1 };
            int[] e = { 0, -2,  1,  3, -6,  2,  4, -1,  0, -2, -4, -1, -2, -6, -1, -1, -1, -7, -4, -2,  2,  4, -1 };
            int[] g = { 1, -3,  0,  0, -4, -2, -1,  4, -3, -3, -4, -2, -3, -5, -1,  1, -1, -7, -5, -2,  0, -1, -1 };
            int[] h = { -2,  1,  2,  0, -3,  3,  0, -3,  6, -3, -2, -1, -3, -2, -1, -1, -2, -3,  0, -3,  1,  1, -1 };
            int[] i = { -1, -2, -2, -3, -2, -3, -2, -3, -3,  5,  1, -2,  2,  0, -3, -2,  0, -5, -2,  3, -2, -2, -1 };
            int[] l = { -2, -3, -3, -5, -6, -2, -4, -4, -2,  1,  5, -3,  3 , 1, -3, -3, -2, -2, -2,  1, -4, -3, -2 };
            int[] k = { -2,  3,  1, -1, -6,  0, -1, -2, -1, -2, -3,  4,  0, -6, -2, -1,  0, -4, -4, -3,  0,  0, -1 };
            int[] m = { -1, -1, -2, -3, -5, -1, -2, -3, -3,  2,  3,  0,  7, -1, -3, -2, -1, -5, -3,  1, -3, -2, -1 };
            int[] f = { -4, -4, -4, -6, -5, -5, -6, -5, -2,  0,  1, -6, -1,  7, -5, -3, -3, -1,  5, -2, -5, -5, -3 };
            int[] p = { 1, -1, -1, -2, -3,  0, -1, -1, -1, -3, -3, -2, -3, -5,  6,  1,  0, -6, -5, -2 ,-2 ,-1, -1 };
            int[] s = { 1, -1,  1,  0,  0, -1, -1,  1, -1, -2, -3, -1, -2, -3,  1,  2,  1, -2, -3, -1,  0, -1,  0 };
            int[] t = { 1, -2,  0, -1, -3, -1, -1, -1, -2,  0, -2,  0, -1, -3,  0,  1,  4, -5, -3,  0,  0, -1, -1 };
            int[] w = { -6,  1, -4, -7, -7, -5, -7, -7, -3, -5, -2, -4, -5, -1, -6, -2, -5, 12, -1, -6, -5, -6, -4 };
            int[] y = { -3, -4, -2, -4,  0, -4, -4, -5,  0, -2, -2, -4, -3,  5, -5, -3, -3, -1,  8, -3, -3, -4, -3 };
            int[] v = { 0, -3, -2, -3, -2, -2, -2, -2, -3,  3,  1, -3,  1, -2, -2, -1,  0, -6, -3,  4, -2, -2, -1 };

            char[] xAxis = {'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v'};

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);
            
            switch(yIndex)
            {
                case 0:
                    return a[xIndex];

                case 1:
                    return r[xIndex];

                case 2:
                    return n[xIndex];

                case 3:
                    return d[xIndex];

                case 4:
                    return c[xIndex];

                case 5:
                    return q[xIndex];

                case 6:
                    return e[xIndex];

                case 7:
                    return g[xIndex];

                case 8:
                    return h[xIndex];

                case 9:
                    return i[xIndex];

                case 10:
                    return l[xIndex];

                case 11:
                    return k[xIndex];

                case 12:
                    return m[xIndex];

                case 13:
                    return f[xIndex];

                case 14:
                    return p[xIndex];

                case 15:
                    return s[xIndex];

                case 16:
                    return t[xIndex];

                case 17:
                    return w[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return v[xIndex];   
            }
            return 0;
        }

        public int pam250(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 2, -2,  0,  0, -2,  0,  0,  1, -1, -1, -2, -1, -1, -3,  1,  1,  1, -6, -3,  0,  0,  0,  0 };
            int[] r = { -2,  6,  0, -1, -4,  1, -1, -3,  2, -2, -3,  3,  0, -4,  0,  0, -1,  2, -4, -2, -1,  0, -1 };
            int[] n = { 0,  0,  2,  2, -4,  1,  1,  0,  2, -2, -3,  1, -2, -3,  0,  1,  0, -4, -2, -2,  2,  1,  0 };
            int[] d = { 0, -1,  2,  4, -5,  2,  3,  1,  1, -2, -4,  0, -3, -6, -1,  0,  0, -7, -4, -2,  3,  3, -1 };
            int[] c = { -2, -4, -4, -5, 12, -5, -5, -3, -3, -2, -6, -5, -5, -4, -3,  0, -2, -8,  0, -2, -4, -5, -3 };
            int[] q = { 0,  1,  1,  2, -5,  4,  2, -1,  3, -2, -2,  1, -1, -5,  0, -1, -1, -5, -4, -2,  1,  3, -1 };
            int[] e = { 0, -1,  1,  3, -5,  2,  4,  0,  1, -2, -3,  0, -2, -5, -1,  0,  0, -7, -4, -2,  3,  3, -1 };
            int[] g = { 1, -3,  0,  1, -3, -1,  0,  5, -2, -3, -4, -2, -3, -5,  0,  1,  0, -7, -5, -1,  0,  0, -1 };
            int[] h = { -1,  2,  2,  1, -3,  3,  1, -2,  6, -2, -2,  0, -2, -2,  0, -1, -1, -3,  0, -2,  1,  2, -1 };
            int[] i = { -1, -2, -2, -2, -2, -2, -2, -3, -2,  5,  2, -2,  2,  1, -2, -1,  0, -5, -1,  4, -2, -2, -1 };
            int[] l = { -2, -3, -3, -4, -6, -2, -3, -4, -2,  2,  6, -3,  4,  2, -3, -3, -2, -2, -1,  2, -3, -3, -1 };
            int[] k = { -1,  3,  1,  0, -5,  1,  0, -2,  0, -2, -3,  5,  0, -5, -1,  0,  0, -3, -4, -2,  1,  0, -1 };
            int[] m = { -1,  0, -2, -3, -5, -1, -2, -3, -2,  2,  4,  0,  6,  0, -2, -2, -1, -4, -2,  2, -2, -2, -1 };
            int[] f = { -3, -4, -3, -6, -4, -5, -5, -5, -2,  1,  2, -5,  0,  9, -5, -3, -3,  0,  7, -1, -4, -5, -2 };
            int[] p = { 1,  0,  0, -1, -3,  0, -1,  0,  0, -2, -3, -1, -2, -5,  6,  1,  0, -6, -5, -1, -1,  0, -1 };
            int[] s = { 1,  0,  1,  0,  0, -1,  0,  1, -1, -1, -3,  0, -2, -3,  1,  2,  1, -2, -3, -1,  0,  0,  0 };
            int[] t = { 1, -1,  0,  0, -2, -1,  0,  0, -1,  0, -2,  0, -1, -3,  0,  1,  3, -5, -3,  0,  0, -1,  0 };
            int[] w = { -6,  2, -4, -7, -8, -5, -7, -7, -3, -5, -2, -3, -4,  0, -6, -2, -5, 17,  0, -6, -5, -6, -4 };
            int[] y = { -3, -4, -2, -4,  0, -4, -4, -5,  0, -1, -1, -4, -2,  7, -5, -3, -3,  0, 10, -2, -3, -4, -2 };
            int[] v = { 0, -2, -2, -2, -2, -2, -2, -1, -2,  4,  2, -2,  2, -1, -1, -1,  0, -6, -2,  4, -2, -2, -1 };

            char[] xAxis = {'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v'};

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);
            
            switch(yIndex)
            {
                case 0:
                    return a[xIndex];

                case 1:
                    return r[xIndex];

                case 2:
                    return n[xIndex];

                case 3:
                    return d[xIndex];

                case 4:
                    return c[xIndex];

                case 5:
                    return q[xIndex];

                case 6:
                    return e[xIndex];

                case 7:
                    return g[xIndex];

                case 8:
                    return h[xIndex];

                case 9:
                    return i[xIndex];

                case 10:
                    return l[xIndex];

                case 11:
                    return k[xIndex];

                case 12:
                    return m[xIndex];

                case 13:
                    return f[xIndex];

                case 14:
                    return p[xIndex];

                case 15:
                    return s[xIndex];

                case 16:
                    return t[xIndex];

                case 17:
                    return w[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return v[xIndex];   
            }
            return 0;
        }

        

        public int blosum62(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 4, -1, -2, -2,  0, -1, -1,  0, -2, -1, -1, -1, -1, -2, -1,  1,  0, -3, -2,  0, -2, -1,  0 };
            int[] r = { -1, 5, 0, -2, -3,  1,  0, -2,  0, -3, -2,  2, -1, -3, -2, -1, -1, -3, -2, -3, -1,  0, -1 };
            int[] n = { -2, 0, 6, 1, -3,  0,  0,  0,  1, -3, -3,  0, -2, -3, -2,  1,  0, -4, -2, -3,  3,  0, -1 };
            int[] d = { -2, -2, 1, 6, -3,  0,  2, -1, -1, -3, -4, -1, -3, -3, -1,  0, -1, -4, -3, -3,  4,  1, -1 };
            int[] c = { 0, -3, -3, -3, 9, -3, -4, -3, -3, -1, -1, -3, -1, -2, -3, -1, -1, -2, -2, -1, -3, -3, -2 };
            int[] q = { -1, 1, 0, 0, -3, 5, 2, -2,  0, -3, -2,  1,  0, -3, -1,  0, -1, -2, -1, -2,  0,  3, -1 };
            int[] e = { -1, 0, 0, 2, -4, 2, 5, -2,  0, -3, -3,  1, -2, -3, -1,  0, -1, -3, -2, -2,  1,  4, -1 };
            int[] g = { 0, -2, 0, -1, -3, -2, -2, 6, -2, -4, -4, -2, -3, -3, -2,  0, -2, -2, -3, -3, -1, -2, -1 };
            int[] h = { -2, 0, 1, -1, -3, 0, 0, -2, 8, -3, -3, -1, -2, -1, -2, -1, -2, -2,  2, -3,  0,  0, -1 };
            int[] i = { -1, -3, -3, -3, -1, -3, -3, -4, -3, 4, 2, -3,  1,  0, -3, -2, -1, -3, -1,  3, -3, -3, -1 };
            int[] l = { -1, -2, -3, -4, -1, -2, -3, -4, -3, 2, 4, -2,  2,  0, -3, -2, -1, -2, -1,  1, -4, -3, -1 };
            int[] k = { -1, 2, 0, -1, -3, 1, 1, -2, -1, -3, -2, 5, -1, -3, -1,  0, -1, -3, -2, -2,  0,  1, -1 };
            int[] m = { -1, -1, -2, -3, -1, 0, -2, -3, -2, 1, 2, -1, 5, 0, -2, -1, -1, -1, -1,  1, -3, -1, -1 };
            int[] f = { -2, -3, -3, -3, -2, -3, -3, -3, -1, 0, 0, -3, 0, 6, -4, -2, -2,  1,  3, -1, -3, -3, -1 };
            int[] p = { -1, -2, -2, -1, -3, -1, -1, -2, -2, -3, -3, -1, -2, -4, 7, -1, -1, -4, -3, -2, -2, -1, -2 };
            int[] s = { 1, -1, 1, 0, -1, 0, 0, 0, -1, -2, -2, 0, -1, -2, -1, 4, 1, -3, -2, -2,  0,  0,  0 };
            int[] t = { 0, -1, 0, -1, -1, -1, -1, -2, -2, -1, -1, -1, -1, -2, -1, 1, 5, -2, -2,  0, -1, -1,  0 };
            int[] w = { -3, -3, -4, -4, -2, -2, -3, -2, -2, -3, -2, -3, -1, 1, -4, -3, -2, 11, 2, -3, -4, -3, -2 };
            int[] y = { -2, -2, -2, -3, -2, -1, -2, -3, 2, -1, -1, -2, -1, 3, -3, -2, -2, 2, 7, -1, -3, -2, -1 };
            int[] v = { 0, -3, -3, -3, -1, -2, -2, -3, -3, 3, 1, -2, 1, -1, -2, -2, 0, -3, -1, 4, -3, -2, -1 };
            

            char[] xAxis = { 'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v'};

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);

            switch (yIndex)
            {
                case 0:
                    return a[xIndex];

                case 1:
                    return r[xIndex];

                case 2:
                    return n[xIndex];

                case 3:
                    return d[xIndex];

                case 4:
                    return c[xIndex];

                case 5:
                    return q[xIndex];

                case 6:
                    return e[xIndex];

                case 7:
                    return g[xIndex];

                case 8:
                    return h[xIndex];

                case 9:
                    return i[xIndex];

                case 10:
                    return l[xIndex];

                case 11:
                    return k[xIndex];

                case 12:
                    return m[xIndex];

                case 13:
                    return f[xIndex];

                case 14:
                    return p[xIndex];

                case 15:
                    return s[xIndex];

                case 16:
                    return t[xIndex];

                case 17:
                    return w[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return v[xIndex];
            }
            return 0;
        }

        public int blosum80(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 7, -3, -3, -3, -1, -2, -2,  0, -3, -3, -3, -1, -2 ,-4 ,-1 , 2 , 0, -5, -4, -1, -3, -2, -1 };
            int[] r = { -3,  9, -1, -3, -6,  1, -1, -4,  0, -5, -4,  3, -3, -5, -3, -2, -2, -5, -4, -4 ,-2,  0, -2 };
            int[] n = { -3, -1,  9,  2, -5,  0, -1, -1,  1, -6, -6,  0, -4, -6, -4,  1,  0, -7, -4, -5,  5, -1, -2 };
            int[] d = { -3, -3,  2, 10, -7, -1,  2, -3, -2, -7, -7, -2, -6, -6, -3, -1, -2, -8, -6, -6,  6,  1, -3 };
            int[] c = { -1, -6, -5, -7, 13 ,-5 ,-7 ,-6 ,-7 ,-2, -3, -6, -3, -4, -6, -2, -2, -5, -5, -2, -6, -7, -4 };
            int[] q = { -2,  1,  0, -1, -5,  9,  3, -4,  1, -5, -4,  2, -1, -5, -3, -1, -1, -4, -3, -4, -1,  5, -2 };
            int[] e = { -2, -1, -1,  2, -7,  3,  8, -4,  0, -6, -6,  1, -4, -6, -2, -1, -2, -6, -5, -4,  1,  6, -2 };
            int[] g = { 0, -4, -1, -3, -6, -4, -4,  9, -4, -7, -7, -3, -5, -6, -5, -1, -3, -6, -6, -6, -2, -4, -3 };
            int[] h = { -3,  0,  1, -2, -7,  1,  0, -4, 12, -6, -5, -1, -4, -2, -4, -2, -3, -4,  3, -5, -1,  0, -2 };
            int[] i = { -3, -5, -6, -7, -2, -5, -6, -7, -6,  7,  2, -5,  2, -1, -5, -4, -2, -5, -3,  4, -6, -6, -2 };
            int[] l = { -3, -4, -6, -7, -3, -4, -6, -7, -5,  2,  6, -4,  3,  0, -5, -4, -3, -4, -2,  1, -7, -5, -2 };
            int[] k = { -1,  3,  0, -2, -6,  2,  1, -3, -1, -5, -4,  8, -3, -5, -2, -1, -1, -6, -4, -4, -1,  1, -2 };
            int[] m = { -2, -3, -4, -6, -3, -1, -4, -5, -4,  2,  3, -3,  9,  0, -4, -3, -1, -3, -3,  1, -5, -3, -2 };
            int[] f = { -4, -5, -6, -6, -4, -5, -6, -6, -2, -1,  0, -5,  0, 10, -6, -4, -4,  0,  4, -2, -6, -6, -3 };
            int[] p = { -1, -3, -4, -3, -6, -3, -2, -5, -4, -5, -5, -2, -4, -6, 12, -2, -3, -7, -6, -4, -4, -2 ,-3 };
            int[] s = { 2, -2,  1, -1, -2, -1, -1, -1, -2, -4, -4, -1, -3, -4, -2,  7,  2, -6, -3, -3,  0, -1, -1 };
            int[] t = { 0, -2,  0, -2, -2, -1, -2, -3, -3, -2, -3, -1, -1, -4, -3,  2,  8, -5, -3,  0, -1, -2, -1 };
            int[] w = { -5, -5, -7, -8, -5, -4, -6, -6, -4, -5, -4, -6, -3,  0, -7, -6, -5, 16,  3, -5, -8, -5, -5 };
            int[] y = { -4, -4, -4, -6, -5, -3, -5, -6,  3, -3, -2, -4, -3,  4, -6, -3, -3,  3, 11, -3, -5, -4, -3 };
            int[] v = { -4, -4, -4, -6, -5, -3, -5, -6,  3, -3, -2, -4, -3,  4, -6, -3, -3,  3, 11, -3, -5, -4, -3 };
            

            char[] xAxis = { 'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v'};

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);

            switch (yIndex)
            {
                case 0:
                    return a[xIndex];

                case 1:
                    return r[xIndex];

                case 2:
                    return n[xIndex];

                case 3:
                    return d[xIndex];

                case 4:
                    return c[xIndex];

                case 5:
                    return q[xIndex];

                case 6:
                    return e[xIndex];

                case 7:
                    return g[xIndex];

                case 8:
                    return h[xIndex];

                case 9:
                    return i[xIndex];

                case 10:
                    return l[xIndex];

                case 11:
                    return k[xIndex];

                case 12:
                    return m[xIndex];

                case 13:
                    return f[xIndex];

                case 14:
                    return p[xIndex];

                case 15:
                    return s[xIndex];

                case 16:
                    return t[xIndex];

                case 17:
                    return w[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return v[xIndex];
            }
            return 0;
        }

        public int blosum90(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 5, -2, -2, -3, -1, -1, -1,  0, -2, -2, -2, -1, -2, -3, -1,  1,  0, -4, -3, -1, -2, -1, -1 };
            int[] r = { -2,  6, -1, -3, -5,  1, -1, -3,  0, -4, -3,  2, -2, -4, -3, -1, -2, -4, -3, -3, -2,  0, -2 };
            int[] n = { -2, -1,  7,  1, -4,  0, -1, -1,  0, -4, -4,  0, -3, -4, -3,  0,  0, -5, -3, -4,  4, -1, -2 };
            int[] d = { -3, -3,  1,  7, -5, -1,  1, -2, -2, -5, -5, -1, -4, -5, -3, -1, -2, -6, -4, -5,  4,  0, -2 };
            int[] c = { -1, -5, -4, -5,  9, -4, -6, -4, -5, -2, -2, -4, -2, -3 ,-4 ,-2 ,-2, -4, -4, -2, -4, -5, -3 };
            int[] q = { -1,  1,  0, -1, -4,  7,  2 ,-3,  1, -4, -3,  1,  0, -4, -2, -1, -1, -3, -3, -3, -1,  4, -1 };
            int[] e = { -1, -1, -1,  1, -6,  2,  6, -3, -1, -4, -4,  0, -3, -5, -2, -1, -1, -5, -4, -3,  0,  4, -2 };
            int[] g = { 0, -3, -1, -2, -4, -3, -3,  6, -3, -5, -5, -2, -4 ,-5, -3, -1, -3, -4, -5, -5, -2, -3, -2 };
            int[] h = { -2,  0,  0, -2, -5,  1, -1, -3,  8, -4, -4, -1, -3, -2, -3, -2, -2, -3,  1, -4, -1,  0, -2 };
            int[] i = { -2, -4, -4, -5, -2, -4, -4, -5, -4,  5,  1, -4,  1, -1, -4, -3, -1, -4, -2,  3, -5, -4, -2 };
            int[] l = { -2, -3, -4, -5, -2, -3, -4, -5, -4,  1,  5, -3,  2,  0, -4, -3, -2, -3, -2,  0, -5, -4, -2 };
            int[] k = { -1,  2,  0, -1, -4,  1,  0, -2, -1, -4, -3,  6, -2, -4, -2, -1, -1, -5, -3, -3, -1,  1, -1 };
            int[] m = { -2, -2, -3, -4, -2,  0, -3, -4, -3,  1,  2, -2,  7, -1, -3, -2, -1, -2, -2,  0, -4, -2, -1 };
            int[] f = { -3, -4, -4, -5, -3, -4, -5, -5, -2, -1,  0, -4, -1,  7, -4, -3, -3,  0,  3, -2, -4, -4, -2 };
            int[] p = { -1, -3, -3, -3, -4, -2, -2, -3, -3, -4, -4, -2, -3, -4,  8, -2, -2, -5, -4, -3, -3, -2, -2 };
            int[] s = { 1, -1,  0, -1, -2, -1, -1, -1, -2, -3, -3, -1, -2, -3, -2,  5,  1, -4, -3, -2,  0, -1, -1 };
            int[] t = { 0, -2,  0, -2, -2, -1, -1, -3, -2, -1, -2, -1, -1, -3, -2,  1,  6, -4, -2, -1, -1, -1, -1 };
            int[] w = { -4, -4, -5, -6, -4, -3, -5, -4, -3, -4, -3, -5, -2,  0, -5, -4, -4, 11,  2, -3, -6, -4, -3 };
            int[] y = { -3, -3, -3, -4, -4, -3, -4, -5,  1, -2, -2, -3, -2,  3, -4, -3, -2,  2,  8, -3, -4, -3, -2 };
            int[] v = { -1, -3, -4, -5, -2, -3, -3, -5, -4,  3,  0, -3,  0, -2, -3, -2, -1, -3, -3,  5, -4, -3, -2 };
            

            char[] xAxis = { 'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v'};

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);

            switch (yIndex)
            {
                case 0:
                    return a[xIndex];

                case 1:
                    return r[xIndex];

                case 2:
                    return n[xIndex];

                case 3:
                    return d[xIndex];

                case 4:
                    return c[xIndex];

                case 5:
                    return q[xIndex];

                case 6:
                    return e[xIndex];

                case 7:
                    return g[xIndex];

                case 8:
                    return h[xIndex];

                case 9:
                    return i[xIndex];

                case 10:
                    return l[xIndex];

                case 11:
                    return k[xIndex];

                case 12:
                    return m[xIndex];

                case 13:
                    return f[xIndex];

                case 14:
                    return p[xIndex];

                case 15:
                    return s[xIndex];

                case 16:
                    return t[xIndex];

                case 17:
                    return w[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return v[xIndex];
            }
            return 0;
        }

        public int matchMissmatchScore(char l1, char l2) //---for testing
        {
            if (l1 == l2)
                return 1;
            else
                return 0;

        }
        public void DisplayGrid()
        {
            //clear and reset variables
            table1.RowGroups.Clear();
            int cols = seq1.Length + 2;
            int rows = seq2.Length + 2;
            flowDoc.Width = cols * 30;


            //add the rowGroup (holds the rows)
            table1.RowGroups.Add(new TableRowGroup());

            table1.Padding = new System.Windows.Thickness(1);

            //populate the table
            for (int r = 0; r < rows; r++)
            {
                TableRow tr = new TableRow();


                for (int c = 0; c < cols; c++)
                {
                    tr.Cells.Add(new TableCell(new Paragraph(new Run(grid[r][c].valLetter != '0' ? grid[r][c].valLetter.ToString() : grid[r][c].value.ToString()))));
                    tr.Cells[c].TextAlignment = TextAlignment.Center;
                    tr.Cells[c].LineHeight = 20;
                    tr.Cells[c].Background = grid[r][c].backColor ?? defaultBrush;

                    //tr.Cells[c]
                    //if (c == 1 && r == 1)
                    //{
                    //    int stophere = 1;
                    //}

                }
                TableRowGroup trg = new TableRowGroup();
                trg.Rows.Add(tr);
                table1.RowGroups.Add(trg);
            }
        }
        // string alignmentTop, alignmentLeft, alignmentBars;
        public void DisplayPairwiseAlignment()
        {
            topAlignmentLable.Content = Helper.Reverse( alignmentTop);
            pairwiseBarsLable.Content = Helper.Reverse(alignmentBars);
            leftAlignmentLable.Content = Helper.Reverse(alignmentLeft); 
        }

        public MainWindow()
        {
            InitializeComponent();


            // for testing

            int cols = 48;
            int rows = 60;

            // for (int c = 0; c < cols; c++)


            // Set some global formatting properties for the table.
            table1.CellSpacing = 1;
            table1.FontSize = 12;
            //table1.
            //table1.Background = Brushes.Blue;

            for (int r = 0; r < rows; r++)
            {
                TableRow tr = new TableRow();

                for (int c = 0; c < cols; c++)
                {
                    tr.Cells.Add(new TableCell(new Paragraph(new Run("12"))));
                    tr.Cells[c].TextAlignment = TextAlignment.Center;

                    //tr.Cells[c]
                    if (c == 4 && r == 4)
                        tr.Cells[4].Background = Brushes.Red;


                }


                TableRowGroup trg = new TableRowGroup();
                trg.Rows.Add(tr);
                table1.RowGroups.Add(trg);
            }

        }


    }
}
