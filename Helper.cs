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
    }
}
