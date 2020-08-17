using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new decimal[]{ 0.000985M, 2.97849M, 3.91042M, 4.7168M };
            var y = new decimal[] { 0M, 1.219M, 2.51M, 4.85M };
            var ks = InterpolateRational4(x, y);
            foreach( var k in ks)
            {
                Console.WriteLine(k);
            }
            return;

        }

        public static decimal[] InterpolateRational4(decimal[] x, decimal[] y)
        {
            var matrix = new decimal[4, 5];
            for (int i = 0; i < 4; i++)
            {
                matrix[i, 0] = 1;
                matrix[i, 1] = x[i];
                matrix[i, 2] = -1M * x[i] * y[i];
                matrix[i, 3] = -1M * x[i] * x[i] * y[i];
                matrix[i, 4] = y[i];
            }
            return Solv(4, matrix).Take(4).ToArray();

        }

        public static decimal[] Solv(int n, decimal[,] A)
        {
            decimal R;
            decimal s = 0m;
            int i;
            int j;
            int k;
            int k1;
            int n1;
            n1 = n + 1;
            for (k = 1; k <= n; k++)
            {
                k1 = k + 1;
                s = A[k-1, k-1];
                j = k;
                for (i = k + 1; i <= n; i++)
                {
                    R = A[i-1, k-1];
                    if (Math.Abs(R) > Math.Abs(s))
                    {
                        s = R;
                        j = i;
                    }
                }
                if (s == 0)
                {
                    return new decimal[0];
                }
                if (j != k)
                {
                    for (i = k; i <= n1; i++)
                    {
                        R = A[k-1, i-1];
                        A[k-1, i-1] = A[j-1, i-1];
                        A[j-1, i-1] = R;
                    }
                }
                for (j = k1; j <= n1; j++)
                {
                    A[k-1, j-1] = A[k-1, j-1] / s;
                }
                for (i = k1; i <= n; i++)
                {
                    R = A[i-1, k-1];
                    for (j = k1; j <= n1; j++)
                    {
                        A[i-1, j-1] = A[i-1, j-1] - A[k-1, j-1] * R;
                    }
                }
            }
            
            if (s == 0)
            {
                return new decimal[0];
            }
            else
            {
                var X = new decimal[n + 2];
                for (i = n; i >= 1; i--)
                {
                    s = A[i-1, n1-1];
                    for (j = i + 1; j <= n; j++)
                    {
                        s = s - A[i-1, j-1] * X[j-1];
                    }
                    X[i-1] = s;
                }
                return X;
            }
        }
    }
}
