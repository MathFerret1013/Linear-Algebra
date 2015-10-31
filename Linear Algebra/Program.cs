 using System;
 using System.Linq;

namespace Linear_Algebra
{
    using Matrices;

    class Program
    {
        static void Main(string[] args)
        {

            var A = new Matrix(new double[,] { { 0, 0, 2 }, { 1, -1, 1}, { -1, 1, 4} });


            // A.Transpose();

            var test2 = MatrixOperations.Rank(A);
            Console.WriteLine(test2);

            Console.WriteLine();
            Console.Read();
        }
    }
}