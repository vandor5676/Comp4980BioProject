using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp4980BioProject
{
    static class Helper
    {


        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int GetValidNumber(MainWindow mw)
        {
             int num;
            try
            {
                 num = int.Parse(mw.LinearGapPenaltyTextBox.Text);
                if (num > 0)
                    num = num * -1;
            }
            catch
            {               
                mw.LinearGapPenaltyTextBox.Text = "-1";
                return -1;
            }
            mw.LinearGapPenaltyTextBox.Text = num.ToString();
            return num;
        }

        public static int GetMatrixNumber(MainWindow mainWindow, char matrixType)
        {
            if(matrixType == 'p')
            {
                if(mainWindow.PAM50Checkbox.IsChecked == true)
                {
                    return 50;
                }
                else if(mainWindow.PAM150Checkbox.IsChecked == true)
                {
                    return 150;
                }
                else if(mainWindow.PAM250Checkbox.IsChecked == true)
                {
                    return 250;
                }
            }
            else
            {
                if (mainWindow.blosum62Checkbox.IsChecked == true)
                {
                    return 62;
                }
                else if (mainWindow.blosum80Checkbox.IsChecked == true)
                {
                    return 80;
                }
                else if (mainWindow.blosum90Checkbox.IsChecked == true)
                {
                    return 90;
                }
            }
            return -1;
        }
    }
}
