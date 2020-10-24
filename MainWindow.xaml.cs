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

namespace Comp4980BioProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private FlowDocument flowDoc;
        // private Table table1;
        public int lgp = -1;
        public class DataObject
        {
            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }
        }
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            //get sequences
            string seq1, seq2;
            seq1 = seq1TextBox.Text.ToUpper();
            seq2 = seq2TextBox.Text.ToUpper();

            lgp = -1;//linear gap penalty

            //Declare Grid List
            List<List<Node>> grid = new List<List<Node>>();
            List<Node> nodeList = new List<Node>();

            //first 2 blanks in grid
            grid.Add(new List<Node>());//new line
            grid[0].Add(new Node());
            grid[0].Add(new Node());

            //Write first sequence
            foreach (char letter in seq1)
            {                
                grid[0].Add(new Node { valLetter = letter });
            }

            //Add the second lines blank and zero
            grid.Add(new List<Node>());//new line
            grid[1].Add(new Node());
            grid[1].Add(new Node {value = 0 });
            
            //write first linear gap penalty line 
            foreach(char letter in seq1)
            {
                grid[1].Add(new Node { value = grid[1].Last().value + lgp });//each linear gap penalty is the previus square + the penalty
            }

            //add each line untill the end
            foreach(char letter in seq2)
            {
                List<Node> tempLine = new List<Node>();// line to be added to the grid once filed
                int previusLine = grid.IndexOf(grid.Last()) ;

                tempLine.Add(new Node { valLetter = letter });//add a letter to the start of the line
                tempLine.Add(new Node { value = (grid.Last()[1].value + (lgp)) });//sets the vertical linear gap penalty boxes

                foreach (char letter2 in seq1)
                {
                    int curentIndex = tempLine.IndexOf(tempLine.Last()) + 1;
                    int left = tempLine[curentIndex-1].value;
                    int top =grid[previusLine][curentIndex].value;
                    int diag=grid[previusLine][curentIndex-1].value;

                    tempLine.Add(CalculateScore(left, top , diag));
                }
                grid.Add(tempLine);
            }

            //nodeList.Add(new Node());
            //grid.Add(nodeList);

            //Node listOfNodes= grid[0][0]


        }

        public Node CalculateScore(int leftVal, int topVal, int diagVal)
        {
            int leftScore, topScore, diagScore;
            leftScore = leftVal + lgp;
            topScore = topVal + lgp;
            diagScore = diagVal + 1; //subMatrixLookup();

            //get the bigest score
            int bigest = leftScore > topScore ? leftScore : topScore;
            bigest = bigest > diagScore ? bigest : diagScore;

            return new Node {value = bigest };
        }

        private int subMatrixLookup()
        {
            throw new NotImplementedException();
        }

        public void DisplayGrid()
        {

        }

        public MainWindow()
        {
            InitializeComponent();

            //var list = new ObservableCollection<DataObject>();
            //list.Add(new DataObject() { A = 6, B = 7, C = 5 });
            //list.Add(new DataObject() { A = 5, B = 8, C = 4 });
            //list.Add(new DataObject() { A = 4, B = 3, C = 0 });
            //this.dataGrid1.ItemsSource = list;

            // Create the parent FlowDocument...
            //flowDoc = new FlowDocument();


            //// Create the Table...
            //table1 = new Table();
            //flowDoc.Document.Blocks.Add(table1);

            //// ...and add it to the FlowDocument Blocks collection.
            ////flowDoc.Blocks.Add(table1);

            //// Set some global formatting properties for the table.
            //table1.CellSpacing = 10;
            //table1.Background = Brushes.Blue;


            //// Create 6 columns and add them to the table's Columns collection.
            //int numberOfColumns = 6;
            //for (int x = 0; x < numberOfColumns; x++)
            //{
            //    table1.Columns.Add(new TableColumn());

            //    // Set alternating background colors for the middle colums.
            //    if (x % 2 == 0)
            //        table1.Columns[x].Background = Brushes.Beige;
            //    else
            //        table1.Columns[x].Background = Brushes.LightSteelBlue;
            //}


            //// Create and add an empty TableRowGroup to hold the table's Rows.
            //table1.RowGroups.Add(new TableRowGroup());

            //// Add the first (title) row.
            //table1.RowGroups[0].Rows.Add(new TableRow());

            //// Alias the current working row for easy reference.
            //TableRow currentRow = table1.RowGroups[0].Rows[0];

            //// Global formatting for the title row.
            //currentRow.Background = Brushes.Silver;
            //currentRow.FontSize = 40;
            //currentRow.FontWeight = System.Windows.FontWeights.Bold;

            //// Add the header row with content,
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;

            //// Add the second (header) row.
            //table1.RowGroups[0].Rows.Add(new TableRow());
            //currentRow = table1.RowGroups[0].Rows[1];

            //// Global formatting for the header row.
            //currentRow.FontSize = 18;
            //currentRow.FontWeight = FontWeights.Bold;

            //// Add cells with content to the second row.
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Product"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 1"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 2"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 3"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 4"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("TOTAL"))));




            //// Add the third row.
            //table1.RowGroups[0].Rows.Add(new TableRow());
            //currentRow = table1.RowGroups[0].Rows[2];

            //// Global formatting for the row.
            //currentRow.FontSize = 12;
            //currentRow.FontWeight = FontWeights.Normal;

            //// Add cells with content to the third row.
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Widgets"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$50,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$55,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$60,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$65,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$230,000"))));

            //// Bold the first cell.
            //currentRow.Cells[0].FontWeight = FontWeights.Bold;


            //// Add the header row with content,
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Projected 2004 Revenue: $810,000"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;


            ////
            ///
            int cols = 60;
            int rows = 60;

            // for (int c = 0; c < cols; c++)
            table1.RowGroups.Add(new TableRowGroup());

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
