using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinant
{
    class Program
    {
        public static Random rnd = new Random();
        public static int[,] red(int[,] old, int lin, int col)
        {
            int n = old.GetLength(0);
            int[,] tor = new int[n - 1, n - 1];
            for (int i = 0; i < lin; i++)
                for (int j = 0; j < col; j++)
                    tor[i, j] = old[i, j];
            for (int i = lin + 1; i < n; i++)
                for (int j = 0; j < col; j++)
                    tor[i - 1, j] = old[i, j];
            for (int i = 0; i < lin; i++)
                for (int j = col + 1; j < n; j++)
                    tor[i, j - 1] = old[i, j];
            for (int i = lin + 1; i < n; i++)
                for (int j = col + 1; j < n; j++)
                    tor[i - 1, j - 1] = old[i, j];
            for (int i = lin + 1; i < n; i++)
                for (int j = col + 1; j < n; j++)
                    tor[i - 1, j - 1] = old[i, j];
            return tor;
        }

        public static int det(int[,] a)
        {
            int n = a.GetLength(0);
            if (n == 1)
                return a[0, 0];
            else
            {
                int s = 0;
                for (int i = 0; i < n; i++)
                    s += (int)Math.Pow(-1, i) * a[0, i] * det(red(a, 0, i));
                return s;
            }
        }

        public static void view(int[,] a)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int n ;
            Console.WriteLine("Introduceti n-dimensiunea matricii (intre 2 si 5)");
            n= int.Parse(Console.ReadLine());
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(10);

            view(a);
            Console.WriteLine($"Determinantul este: {det(a)}");

            Console.ReadKey();
        }
    }
}
