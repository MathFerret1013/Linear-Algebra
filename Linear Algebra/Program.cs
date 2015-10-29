 using System;
 using System.Linq;

namespace Linear_Algebra
{
    using System.Diagnostics;
    using System.Numerics;
    using System.Runtime.InteropServices;

    using Matrices;

    class Program
    {
        static void Main(string[] args)
        {
            /*
            {
                { 0, 0, 2 },
                                            { 1, -1, 1},
                                            { -1, 1, 4}
            });*/

            var A = new Matrix(new double[,]
                                   { { 0, 0, 2 }, { 1, -1, 1}, { -1, 1, 4} });


            // A.Transpose();

            var test2 = MatrixOperations.Rank(A);
            Console.WriteLine(test2);

            Console.WriteLine();
            Console.Read();
        }
    }
}