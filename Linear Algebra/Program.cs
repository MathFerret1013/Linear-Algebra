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

            /*var A = new Matrix(new double[,]
                                        {
                                            { 0, 0, 2 },
                                            { 1, -1, 1},
                                            { -1, 1, 4}
                                        });*/

            var A = new Matrix(new double[,]
                            {
                                            { 1, 0, 1, 0, 1},
                                            { 1, 1, 0, 0, 2},
                                            { 3, 1, 1, 1, 1},
                                            { 0, 1, 2, 1, 2},
                            });

            // A.Transpose();
            Console.WriteLine(A);
            // var test = MatrixOperations.GaussianElimination(A);
            // Console.WriteLine(test);

            var test2 = MatrixOperations.GaussianElimination(A);
            Console.WriteLine(test2);

            Console.WriteLine();
            Console.Read();
        }
    }
}