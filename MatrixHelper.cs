using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp4980BioProject
{
     static class MatrixHelper
    {

        public static int pam250(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] c = { 12 };
            int[] s = { 0, 2 };
            int[] t = { -2, 1, 3 };
            int[] p = { -3, 1, 0, 5 };
            int[] a = { -2, 1, 1, 1, 2 };
            int[] g = { -3, 1, 0, -1, 1, 5 };
            int[] n = { -4, 1, 0, -1, 0, 0, 2 };
            int[] d = { -5, 0, 0, -1, 1, 2, 2, 4 };
            int[] e = { -5, 0, 0, -1, 0, 0, 1, 3, 4 };
            int[] q = { -5, -1, -1, 0, 0, -1, 1, 2, 2, 4 };
            int[] h = { -3, -1, -1, 0, -1, -2, 2, 1, 1, 3, 6 };
            int[] r = { -4, 0, -1, 0, -2, -3, 0, -1, -1, 1, 2, 6 };
            int[] k = { -5, 0, 0, -1, -1, -2, 1, 0, 0, 1, 0, 3, 5 };
            int[] m = { -5, -2, -1, -2, -1, -3, -2, -3, -2, -1, -2, 0, 0, 6 };
            int[] i = { -2, -1, 0, -2, -1, -3, -2, -2, -2, -2, -2, -2, -2, 2, 5 };
            int[] l = { -6, -3, -2, -3, -2, -4, -3, -4, -3, -2, -2, -3, -3, 4, 2, 6 };
            int[] v = { -2, -1, 0, -1, 0, -1, -2, -2, -2, -2, -2, -2, -2, 2, 4, 2, 4 };
            int[] f = { -4, -3, -3, -5, -4, -5, -4, -6, -5, -5, -2, -4, -5, 0, 1, 2, -1, 9 };
            int[] y = { 0, -3, -3, -5, -3, -5, -2, -4, -4, -4, 0, -4, -4, -2, -1, -1, -2, 7, 10 };
            int[] w = { -8, -2, -5, -6, -6, -7, -4, -7, -7, -5, -3, 2, -3, -4, -5, -2, -6, 0, 0, 17 };
            int[] b = { -4, 0, 0, -1, 0, 0, 2, 3, 2, 1, 1, -1, 1, -2, -2, -3, -2, -5, -3, -5, 2 };
            int[] z = { -5, 0, -1, 0, 0, -1, 1, 3, 3, 3, 2, 0, 0, -2, -2, -3, -2, -5, -3, -6, 2, 3 };

            char[] xAxis = { 'c', 's', 't', 'p', 'a', 'g', 'n', 'd', 'e', 'q', 'h', 'r', 'k', 'm', 'i', 'l', 'v', 'f', 'y', 'w', 'b', 'z' };

            yIndex = Array.IndexOf(xAxis, c2);
            xIndex = Array.IndexOf(xAxis, c1);

            switch (yIndex)
            {
                case 0:
                    return c[xIndex];

                case 1:
                    return s[xIndex];

                case 2:
                    return t[xIndex];

                case 3:
                    return p[xIndex];

                case 4:
                    return a[xIndex];

                case 5:
                    return g[xIndex];

                case 6:
                    return n[xIndex];

                case 7:
                    return d[xIndex];

                case 8:
                    return e[xIndex];

                case 9:
                    return q[xIndex];

                case 10:
                    return h[xIndex];

                case 11:
                    return r[xIndex];

                case 12:
                    return k[xIndex];

                case 13:
                    return m[xIndex];

                case 14:
                    return i[xIndex];

                case 15:
                    return l[xIndex];

                case 16:
                    return v[xIndex];

                case 17:
                    return f[xIndex];

                case 18:
                    return y[xIndex];

                case 19:
                    return w[xIndex];

                case 20:
                    return b[xIndex];

                case 21:
                    return z[xIndex];
            }
            return 0;
        }
        public static int blosum62(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 4 };
            int[] r = { -1, 5 };
            int[] n = { -2, 0, 6 };
            int[] d = { -2, -2, 1, 6 };
            int[] c = { 0, -3, -3, -3, 9 };
            int[] q = { -1, 1, 0, 0, -3, 5 };
            int[] e = { -1, 0, 0, 2, -4, 2, 5 };
            int[] g = { 0, -2, 0, -1, -3, -2, -2, 6 };
            int[] h = { -2, 0, 1, -1, -3, 0, 0, -2, 8 };
            int[] i = { -1, -3, -3, -3, -1, -3, -3, -4, -3, 4 };
            int[] l = { -1, -2, -3, -4, -1, -2, -3, -4, -3, 2, 4 };
            int[] k = { -1, 2, 0, -1, -3, 1, 1, -2, -1, -3, -2, 5 };
            int[] m = { -1, -1, -2, -3, -1, 0, -2, -3, -2, 1, 2, -1, 5 };
            int[] f = { -2, -3, -3, -3, -2, -3, -3, -3, -1, 0, 0, -3, 0, 6 };
            int[] p = { -1, -2, -2, -1, -3, -1, -1, -2, -2, -3, -3, -1, -2, -4, 7 };
            int[] s = { 1, -1, 1, 0, -1, 0, 0, 0, -1, -2, -2, 0, -1, -2, -1, 4 };
            int[] t = { 0, -1, 0, -1, -1, -1, -1, -2, -2, -1, -1, -1, -1, -2, -1, 1, 5 };
            int[] w = { -3, -3, -4, -4, -2, -2, -3, -2, -2, -3, -2, -3, -1, 1, -4, -3, -2, 11 };
            int[] y = { -2, -2, -2, -3, -2, -1, -2, -3, 2, -1, -1, -2, -1, 3, -3, -2, -2, 2, 7 };
            int[] v = { 0, -3, -3, -3, -1, -2, -2, -3, -3, 3, 1, -2, 1, -1, -2, -2, 0, -3, -1, 4 };


            char[] xAxis = { 'a', 'r', 'n', 'd', 'c', 'q', 'e', 'g', 'h', 'i', 'l', 'k', 'm', 'f', 'p', 's', 't', 'w', 'y', 'v' };

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
    }
}
