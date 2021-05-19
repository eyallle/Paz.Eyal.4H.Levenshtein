using System;

namespace Paz.Eyal._4H.Levenshtein
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "miao";
            string t = "miao";
            Console.WriteLine($"La distanza tra {s} e {t} è {DistanzaLevenshtein(s, t)}");

        }
        static int DistanzaLevenshtein(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            if (n == 0)
                return m;

            if (m == 0)
                return n;
            int[,] distanze = new int[m + 1, n + 1];

            for (int i = 0; i < n + 1; i++)
                distanze[i, 0] = i;

            for (int j = 0; j < m + 1; j++)
                distanze[j, 0] = j;


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int costo;
                    if (t[j] == s[i])
                        costo = 0;
                    else
                        costo = 1;

                    distanze[j + 1, i + 1] = Minimo(distanze[j + 1, i] + 1, distanze[j, i + 1] + 1, distanze[j, i] + costo);
                }

            }
            return distanze[m, n];

        }
        static int Minimo(int a, int b, int c)
        {

            int ret = a;
            if (b < ret)
                ret = b;
            if (c < ret)
                ret = c;

            return ret;


        }
    }
}
