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
                                        {
                                            { 1, 2, 3 },
                                            { 4, 5, 6 },
                                            { 7, 8, 9 }
                                        });


            // A.Transpose();

            var test2 = MatrixOperations.ReducedRowEchelonForm(new Matrix(new double[,] { { 1, 2, 3,  4, 5 }, { 6,  7, 8, 9, 10 } }));
            Console.WriteLine(test2);

            Console.WriteLine();
            Console.Read();
        }
    }
}