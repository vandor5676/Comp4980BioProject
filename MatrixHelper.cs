﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp4980BioProject
{
     static class MatrixHelper
    {

        public static int pam50(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 5, -5, -2, -2, -5, -3, -1, -1, -5, -3, -5, -5, -4, -7, 0, 0, 0, -11, -6, -1, -2, -2, -2 };
            int[] r = { -5, 8, -4, -7, -6, 0, -7, -7, 0, -4, -7, 1, -3, -8, -3, -2, -5, -1, -8, -6, -5, -2, -4 };
            int[] n = { -2, -4, 7, 2, -8, -2, -1, -2, 1, -4, -6, 0, -6, -7, -4, 1, -1, -7, -3, -6, 5, -1, -2 };
            int[] d = { -2, -7, 2, 7, -11, -1, 3, -2, -2, -6, -10, -3, -8, -12, -6, -2, -3, -12, -9, -6, 6, 2, -4 };
            int[] c = { -5, -6, -8, -11, 9, -11, -11, -7, -6, -5, -12, -11, -11, -10, -6, -2, -6, -13, -3, -5, -9, -11, -7 };
            int[] q = { -3, 0, -2, -1, -11, 8, 2, -5, 2, -6, -4, -2, -3, -10, -2, -4, -4, -10, -9, -5, -2, 6, -3 };
            int[] e = { -1, -7, -1, 3, -11, 2, 7, -3, -3, -4, -7, -3, -5, -11, -4, -3, -4, -13, -7, -5, 2, 6, -3 };
            int[] g = { -1, -7, -2, -2, -7, -5, -3, 6, -7, -8, -9, -6, -7, -8, -4, -1, -4, -12, -11, -4, -2, -4, -4 };
            int[] h = { -5, 0, 1, -2, -6, 2, -3, -7, 9, -7, -5, -4, -8, -5, -3, -4, -5, -6, -2, -5, 0, 0, -4 };
            int[] i = { -3, -4, -4, -6, -5, -6, -4, -8, -7, 8, 0, -5, 0, -1, -7, -5, -1, -11, -5, 3, -5, -5, -3 };
            int[] l = { -5, -7, -6, -10, -12, -4, -7, -9, -5, 0, 6, -6, 2, -1, -6, -7, -5, -5, -5, -1, -7, -5, -5 };
            int[] k = { -5, 1, 0, -3, -11, -2, -3, -6, -4, -5, -6, 6, -1, -11, -5, -3, -2, -9, -8, -7, -1, -2, -4 };
            int[] m = { -4, -3, -6, -8, -11, -3, -5, -7, -8, 0, 2, -1, 10, -3, -6, -4, -3, -10, -8, 0, -7, -4, -4 };
            int[] f = { -7, -8, -7, -12, -10, -10, -11, -8, -5, -1, -1, -11, -3, 9, -8, -5, -7, -3, 3, -6, -9, -11, -6 };
            int[] p = { 0, -3, -4, -6, -6, -2, -4, -4, -3, -7, -6, -5, -6, -8, 8, -1, -3, -11, -11, -4, -5, -3, -4 };
            int[] s = { 0, -2, 1, -2, -2, -4, -3, -1, -4, -5, -7, -3, -4, -5, -1, 6, 1, -4, -5, -4, -1, -3, -2 };
            int[] t = { 0, -5, -1, -3, -6, -4, -4, -4, -5, -1, -5, -2, -3, -7, -3, 1, 6, -10, -5, -2, -2, -4, -2 };
            int[] w = { -11, -1, -7, -12, -13, -10, -13, -12, -6, -11, -5, -9, -10, -3, -11, -4, -10, 13, -4, -12, -8, -11, -9 };
            int[] y = { -6, -8, -3, -9, -3, -9, -7, -11, -2, -5, -5, -8, -8, 3, -11, -5, -5, -4, 9, -6, -5, -8, -6 };
            int[] v = { -1, -6, -6, -6, -5, -5, -5, -4, -5, 3, -1, -7, 0, -6, -4, -4, -2, -12, -6, 7, -6, -5, -3 };

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

        public static int pam150(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 3, -2, 0, 0, -2, -1, 0, 1, -2, -1, -2, -2, -1, -4, 1, 1, 1, -6, -3, 0, 0, 0, -1 };
            int[] r = { -2, 6, -1, -2, -4, 1, -2, -3, 1, -2, -3, 3, -1, -4, -1, -1, -2, 1, -4, -3, -2, 0, -1 };
            int[] n = { 0, -1, 3, 2, -4, 0, 1, 0, 2, -2, -3, 1, -2, -4, -1, 1, 0, -4, -2, -2, 3, 1, -1 };
            int[] d = { 0, -2, 2, 4, -6, 1, 3, 0, 0, -3, -5, -1, -3, -6, -2, 0, -1, -7, -4, -3, 3, 2, -1 };
            int[] c = { -2, -4, -4, -6, 9, -6, -6, -4, -3, -2, -6, -6, -5, -5, -3, 0, -3, -7, 0, -2, -5, -6, -3 };
            int[] q = { -1, 1, 0, 1, -6, 5, 2, -2, 3, -3, -2, 0, -1, -5, 0, -1, -1, -5, -4, -2, 1, 4, -1 };
            int[] e = { 0, -2, 1, 3, -6, 2, 4, -1, 0, -2, -4, -1, -2, -6, -1, -1, -1, -7, -4, -2, 2, 4, -1 };
            int[] g = { 1, -3, 0, 0, -4, -2, -1, 4, -3, -3, -4, -2, -3, -5, -1, 1, -1, -7, -5, -2, 0, -1, -1 };
            int[] h = { -2, 1, 2, 0, -3, 3, 0, -3, 6, -3, -2, -1, -3, -2, -1, -1, -2, -3, 0, -3, 1, 1, -1 };
            int[] i = { -1, -2, -2, -3, -2, -3, -2, -3, -3, 5, 1, -2, 2, 0, -3, -2, 0, -5, -2, 3, -2, -2, -1 };
            int[] l = { -2, -3, -3, -5, -6, -2, -4, -4, -2, 1, 5, -3, 3, 1, -3, -3, -2, -2, -2, 1, -4, -3, -2 };
            int[] k = { -2, 3, 1, -1, -6, 0, -1, -2, -1, -2, -3, 4, 0, -6, -2, -1, 0, -4, -4, -3, 0, 0, -1 };
            int[] m = { -1, -1, -2, -3, -5, -1, -2, -3, -3, 2, 3, 0, 7, -1, -3, -2, -1, -5, -3, 1, -3, -2, -1 };
            int[] f = { -4, -4, -4, -6, -5, -5, -6, -5, -2, 0, 1, -6, -1, 7, -5, -3, -3, -1, 5, -2, -5, -5, -3 };
            int[] p = { 1, -1, -1, -2, -3, 0, -1, -1, -1, -3, -3, -2, -3, -5, 6, 1, 0, -6, -5, -2, -2, -1, -1 };
            int[] s = { 1, -1, 1, 0, 0, -1, -1, 1, -1, -2, -3, -1, -2, -3, 1, 2, 1, -2, -3, -1, 0, -1, 0 };
            int[] t = { 1, -2, 0, -1, -3, -1, -1, -1, -2, 0, -2, 0, -1, -3, 0, 1, 4, -5, -3, 0, 0, -1, -1 };
            int[] w = { -6, 1, -4, -7, -7, -5, -7, -7, -3, -5, -2, -4, -5, -1, -6, -2, -5, 12, -1, -6, -5, -6, -4 };
            int[] y = { -3, -4, -2, -4, 0, -4, -4, -5, 0, -2, -2, -4, -3, 5, -5, -3, -3, -1, 8, -3, -3, -4, -3 };
            int[] v = { 0, -3, -2, -3, -2, -2, -2, -2, -3, 3, 1, -3, 1, -2, -2, -1, 0, -6, -3, 4, -2, -2, -1 };

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

        public static int pam250(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 2, -2, 0, 0, -2, 0, 0, 1, -1, -1, -2, -1, -1, -3, 1, 1, 1, -6, -3, 0, 0, 0, 0 };
            int[] r = { -2, 6, 0, -1, -4, 1, -1, -3, 2, -2, -3, 3, 0, -4, 0, 0, -1, 2, -4, -2, -1, 0, -1 };
            int[] n = { 0, 0, 2, 2, -4, 1, 1, 0, 2, -2, -3, 1, -2, -3, 0, 1, 0, -4, -2, -2, 2, 1, 0 };
            int[] d = { 0, -1, 2, 4, -5, 2, 3, 1, 1, -2, -4, 0, -3, -6, -1, 0, 0, -7, -4, -2, 3, 3, -1 };
            int[] c = { -2, -4, -4, -5, 12, -5, -5, -3, -3, -2, -6, -5, -5, -4, -3, 0, -2, -8, 0, -2, -4, -5, -3 };
            int[] q = { 0, 1, 1, 2, -5, 4, 2, -1, 3, -2, -2, 1, -1, -5, 0, -1, -1, -5, -4, -2, 1, 3, -1 };
            int[] e = { 0, -1, 1, 3, -5, 2, 4, 0, 1, -2, -3, 0, -2, -5, -1, 0, 0, -7, -4, -2, 3, 3, -1 };
            int[] g = { 1, -3, 0, 1, -3, -1, 0, 5, -2, -3, -4, -2, -3, -5, 0, 1, 0, -7, -5, -1, 0, 0, -1 };
            int[] h = { -1, 2, 2, 1, -3, 3, 1, -2, 6, -2, -2, 0, -2, -2, 0, -1, -1, -3, 0, -2, 1, 2, -1 };
            int[] i = { -1, -2, -2, -2, -2, -2, -2, -3, -2, 5, 2, -2, 2, 1, -2, -1, 0, -5, -1, 4, -2, -2, -1 };
            int[] l = { -2, -3, -3, -4, -6, -2, -3, -4, -2, 2, 6, -3, 4, 2, -3, -3, -2, -2, -1, 2, -3, -3, -1 };
            int[] k = { -1, 3, 1, 0, -5, 1, 0, -2, 0, -2, -3, 5, 0, -5, -1, 0, 0, -3, -4, -2, 1, 0, -1 };
            int[] m = { -1, 0, -2, -3, -5, -1, -2, -3, -2, 2, 4, 0, 6, 0, -2, -2, -1, -4, -2, 2, -2, -2, -1 };
            int[] f = { -3, -4, -3, -6, -4, -5, -5, -5, -2, 1, 2, -5, 0, 9, -5, -3, -3, 0, 7, -1, -4, -5, -2 };
            int[] p = { 1, 0, 0, -1, -3, 0, -1, 0, 0, -2, -3, -1, -2, -5, 6, 1, 0, -6, -5, -1, -1, 0, -1 };
            int[] s = { 1, 0, 1, 0, 0, -1, 0, 1, -1, -1, -3, 0, -2, -3, 1, 2, 1, -2, -3, -1, 0, 0, 0 };
            int[] t = { 1, -1, 0, 0, -2, -1, 0, 0, -1, 0, -2, 0, -1, -3, 0, 1, 3, -5, -3, 0, 0, -1, 0 };
            int[] w = { -6, 2, -4, -7, -8, -5, -7, -7, -3, -5, -2, -3, -4, 0, -6, -2, -5, 17, 0, -6, -5, -6, -4 };
            int[] y = { -3, -4, -2, -4, 0, -4, -4, -5, 0, -1, -1, -4, -2, 7, -5, -3, -3, 0, 10, -2, -3, -4, -2 };
            int[] v = { 0, -2, -2, -2, -2, -2, -2, -1, -2, 4, 2, -2, 2, -1, -1, -1, 0, -6, -2, 4, -2, -2, -1 };

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



        public static int blosum62(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 4, -1, -2, -2, 0, -1, -1, 0, -2, -1, -1, -1, -1, -2, -1, 1, 0, -3, -2, 0, -2, -1, 0 };
            int[] r = { -1, 5, 0, -2, -3, 1, 0, -2, 0, -3, -2, 2, -1, -3, -2, -1, -1, -3, -2, -3, -1, 0, -1 };
            int[] n = { -2, 0, 6, 1, -3, 0, 0, 0, 1, -3, -3, 0, -2, -3, -2, 1, 0, -4, -2, -3, 3, 0, -1 };
            int[] d = { -2, -2, 1, 6, -3, 0, 2, -1, -1, -3, -4, -1, -3, -3, -1, 0, -1, -4, -3, -3, 4, 1, -1 };
            int[] c = { 0, -3, -3, -3, 9, -3, -4, -3, -3, -1, -1, -3, -1, -2, -3, -1, -1, -2, -2, -1, -3, -3, -2 };
            int[] q = { -1, 1, 0, 0, -3, 5, 2, -2, 0, -3, -2, 1, 0, -3, -1, 0, -1, -2, -1, -2, 0, 3, -1 };
            int[] e = { -1, 0, 0, 2, -4, 2, 5, -2, 0, -3, -3, 1, -2, -3, -1, 0, -1, -3, -2, -2, 1, 4, -1 };
            int[] g = { 0, -2, 0, -1, -3, -2, -2, 6, -2, -4, -4, -2, -3, -3, -2, 0, -2, -2, -3, -3, -1, -2, -1 };
            int[] h = { -2, 0, 1, -1, -3, 0, 0, -2, 8, -3, -3, -1, -2, -1, -2, -1, -2, -2, 2, -3, 0, 0, -1 };
            int[] i = { -1, -3, -3, -3, -1, -3, -3, -4, -3, 4, 2, -3, 1, 0, -3, -2, -1, -3, -1, 3, -3, -3, -1 };
            int[] l = { -1, -2, -3, -4, -1, -2, -3, -4, -3, 2, 4, -2, 2, 0, -3, -2, -1, -2, -1, 1, -4, -3, -1 };
            int[] k = { -1, 2, 0, -1, -3, 1, 1, -2, -1, -3, -2, 5, -1, -3, -1, 0, -1, -3, -2, -2, 0, 1, -1 };
            int[] m = { -1, -1, -2, -3, -1, 0, -2, -3, -2, 1, 2, -1, 5, 0, -2, -1, -1, -1, -1, 1, -3, -1, -1 };
            int[] f = { -2, -3, -3, -3, -2, -3, -3, -3, -1, 0, 0, -3, 0, 6, -4, -2, -2, 1, 3, -1, -3, -3, -1 };
            int[] p = { -1, -2, -2, -1, -3, -1, -1, -2, -2, -3, -3, -1, -2, -4, 7, -1, -1, -4, -3, -2, -2, -1, -2 };
            int[] s = { 1, -1, 1, 0, -1, 0, 0, 0, -1, -2, -2, 0, -1, -2, -1, 4, 1, -3, -2, -2, 0, 0, 0 };
            int[] t = { 0, -1, 0, -1, -1, -1, -1, -2, -2, -1, -1, -1, -1, -2, -1, 1, 5, -2, -2, 0, -1, -1, 0 };
            int[] w = { -3, -3, -4, -4, -2, -2, -3, -2, -2, -3, -2, -3, -1, 1, -4, -3, -2, 11, 2, -3, -4, -3, -2 };
            int[] y = { -2, -2, -2, -3, -2, -1, -2, -3, 2, -1, -1, -2, -1, 3, -3, -2, -2, 2, 7, -1, -3, -2, -1 };
            int[] v = { 0, -3, -3, -3, -1, -2, -2, -3, -3, 3, 1, -2, 1, -1, -2, -2, 0, -3, -1, 4, -3, -2, -1 };


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

        public static int blosum80(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 7, -3, -3, -3, -1, -2, -2, 0, -3, -3, -3, -1, -2, -4, -1, 2, 0, -5, -4, -1, -3, -2, -1 };
            int[] r = { -3, 9, -1, -3, -6, 1, -1, -4, 0, -5, -4, 3, -3, -5, -3, -2, -2, -5, -4, -4, -2, 0, -2 };
            int[] n = { -3, -1, 9, 2, -5, 0, -1, -1, 1, -6, -6, 0, -4, -6, -4, 1, 0, -7, -4, -5, 5, -1, -2 };
            int[] d = { -3, -3, 2, 10, -7, -1, 2, -3, -2, -7, -7, -2, -6, -6, -3, -1, -2, -8, -6, -6, 6, 1, -3 };
            int[] c = { -1, -6, -5, -7, 13, -5, -7, -6, -7, -2, -3, -6, -3, -4, -6, -2, -2, -5, -5, -2, -6, -7, -4 };
            int[] q = { -2, 1, 0, -1, -5, 9, 3, -4, 1, -5, -4, 2, -1, -5, -3, -1, -1, -4, -3, -4, -1, 5, -2 };
            int[] e = { -2, -1, -1, 2, -7, 3, 8, -4, 0, -6, -6, 1, -4, -6, -2, -1, -2, -6, -5, -4, 1, 6, -2 };
            int[] g = { 0, -4, -1, -3, -6, -4, -4, 9, -4, -7, -7, -3, -5, -6, -5, -1, -3, -6, -6, -6, -2, -4, -3 };
            int[] h = { -3, 0, 1, -2, -7, 1, 0, -4, 12, -6, -5, -1, -4, -2, -4, -2, -3, -4, 3, -5, -1, 0, -2 };
            int[] i = { -3, -5, -6, -7, -2, -5, -6, -7, -6, 7, 2, -5, 2, -1, -5, -4, -2, -5, -3, 4, -6, -6, -2 };
            int[] l = { -3, -4, -6, -7, -3, -4, -6, -7, -5, 2, 6, -4, 3, 0, -5, -4, -3, -4, -2, 1, -7, -5, -2 };
            int[] k = { -1, 3, 0, -2, -6, 2, 1, -3, -1, -5, -4, 8, -3, -5, -2, -1, -1, -6, -4, -4, -1, 1, -2 };
            int[] m = { -2, -3, -4, -6, -3, -1, -4, -5, -4, 2, 3, -3, 9, 0, -4, -3, -1, -3, -3, 1, -5, -3, -2 };
            int[] f = { -4, -5, -6, -6, -4, -5, -6, -6, -2, -1, 0, -5, 0, 10, -6, -4, -4, 0, 4, -2, -6, -6, -3 };
            int[] p = { -1, -3, -4, -3, -6, -3, -2, -5, -4, -5, -5, -2, -4, -6, 12, -2, -3, -7, -6, -4, -4, -2, -3 };
            int[] s = { 2, -2, 1, -1, -2, -1, -1, -1, -2, -4, -4, -1, -3, -4, -2, 7, 2, -6, -3, -3, 0, -1, -1 };
            int[] t = { 0, -2, 0, -2, -2, -1, -2, -3, -3, -2, -3, -1, -1, -4, -3, 2, 8, -5, -3, 0, -1, -2, -1 };
            int[] w = { -5, -5, -7, -8, -5, -4, -6, -6, -4, -5, -4, -6, -3, 0, -7, -6, -5, 16, 3, -5, -8, -5, -5 };
            int[] y = { -4, -4, -4, -6, -5, -3, -5, -6, 3, -3, -2, -4, -3, 4, -6, -3, -3, 3, 11, -3, -5, -4, -3 };
            int[] v = { -4, -4, -4, -6, -5, -3, -5, -6, 3, -3, -2, -4, -3, 4, -6, -3, -3, 3, 11, -3, -5, -4, -3 };


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

        public static int blosum90(char c1, char c2)
        {
            int xIndex, yIndex;

            int[] a = { 5, -2, -2, -3, -1, -1, -1, 0, -2, -2, -2, -1, -2, -3, -1, 1, 0, -4, -3, -1, -2, -1, -1 };
            int[] r = { -2, 6, -1, -3, -5, 1, -1, -3, 0, -4, -3, 2, -2, -4, -3, -1, -2, -4, -3, -3, -2, 0, -2 };
            int[] n = { -2, -1, 7, 1, -4, 0, -1, -1, 0, -4, -4, 0, -3, -4, -3, 0, 0, -5, -3, -4, 4, -1, -2 };
            int[] d = { -3, -3, 1, 7, -5, -1, 1, -2, -2, -5, -5, -1, -4, -5, -3, -1, -2, -6, -4, -5, 4, 0, -2 };
            int[] c = { -1, -5, -4, -5, 9, -4, -6, -4, -5, -2, -2, -4, -2, -3, -4, -2, -2, -4, -4, -2, -4, -5, -3 };
            int[] q = { -1, 1, 0, -1, -4, 7, 2, -3, 1, -4, -3, 1, 0, -4, -2, -1, -1, -3, -3, -3, -1, 4, -1 };
            int[] e = { -1, -1, -1, 1, -6, 2, 6, -3, -1, -4, -4, 0, -3, -5, -2, -1, -1, -5, -4, -3, 0, 4, -2 };
            int[] g = { 0, -3, -1, -2, -4, -3, -3, 6, -3, -5, -5, -2, -4, -5, -3, -1, -3, -4, -5, -5, -2, -3, -2 };
            int[] h = { -2, 0, 0, -2, -5, 1, -1, -3, 8, -4, -4, -1, -3, -2, -3, -2, -2, -3, 1, -4, -1, 0, -2 };
            int[] i = { -2, -4, -4, -5, -2, -4, -4, -5, -4, 5, 1, -4, 1, -1, -4, -3, -1, -4, -2, 3, -5, -4, -2 };
            int[] l = { -2, -3, -4, -5, -2, -3, -4, -5, -4, 1, 5, -3, 2, 0, -4, -3, -2, -3, -2, 0, -5, -4, -2 };
            int[] k = { -1, 2, 0, -1, -4, 1, 0, -2, -1, -4, -3, 6, -2, -4, -2, -1, -1, -5, -3, -3, -1, 1, -1 };
            int[] m = { -2, -2, -3, -4, -2, 0, -3, -4, -3, 1, 2, -2, 7, -1, -3, -2, -1, -2, -2, 0, -4, -2, -1 };
            int[] f = { -3, -4, -4, -5, -3, -4, -5, -5, -2, -1, 0, -4, -1, 7, -4, -3, -3, 0, 3, -2, -4, -4, -2 };
            int[] p = { -1, -3, -3, -3, -4, -2, -2, -3, -3, -4, -4, -2, -3, -4, 8, -2, -2, -5, -4, -3, -3, -2, -2 };
            int[] s = { 1, -1, 0, -1, -2, -1, -1, -1, -2, -3, -3, -1, -2, -3, -2, 5, 1, -4, -3, -2, 0, -1, -1 };
            int[] t = { 0, -2, 0, -2, -2, -1, -1, -3, -2, -1, -2, -1, -1, -3, -2, 1, 6, -4, -2, -1, -1, -1, -1 };
            int[] w = { -4, -4, -5, -6, -4, -3, -5, -4, -3, -4, -3, -5, -2, 0, -5, -4, -4, 11, 2, -3, -6, -4, -3 };
            int[] y = { -3, -3, -3, -4, -4, -3, -4, -5, 1, -2, -2, -3, -2, 3, -4, -3, -2, 2, 8, -3, -4, -3, -2 };
            int[] v = { -1, -3, -4, -5, -2, -3, -3, -5, -4, 3, 0, -3, 0, -2, -3, -2, -1, -3, -3, 5, -4, -3, -2 };


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
