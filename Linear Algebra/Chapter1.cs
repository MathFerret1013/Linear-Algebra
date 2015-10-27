using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Algebra
{
    using Matrices;

    public static class Chapter1
    {
        public static void Execute()
        {
            // 1.12
            var A = new Matrices.Matrix(new double[,]
                                            {
                                                {  3, 1, -2 },
                                                { 2, -2, 0 },
                                                { -1, 1, 2 }
                                            });
            var B = new Matrices.Matrix(new double[,]
                                {
                                                {  1, 1, 1 },
                                                { 1, -1, 1 },
                                                { 0, 1, 2 }
                                });

            Console.WriteLine(A.Multiply(B));
            Console.WriteLine();


            // 1.13
            A = new Matrices.Matrix(new double[,]
                                            {
                                                { 1, 1, 1 },
                                                { 0, 1, 1 },
                                                { 0, 0, 1 }
                                            });
            B = new Matrices.Matrix(new double[,]
                                {
                                                { 1, 0, 0 },
                                                { 1, 1, 0 },
                                                { 1, 1, 1 }
                                });

            Console.WriteLine(A.Multiply(B));
            Console.WriteLine();

            // 1.14
            A = new Matrices.Matrix(new double[,]
                                            {
                                                { 1 },
                                                { 2 },
                                                { 3 },
                                                { 4 }
                                            });

            B = new Matrices.Matrix(new double[,]
                                {
                                                {  1, 2, 3, 4 }
                                });

            Console.WriteLine(A.Multiply(B));
            Console.WriteLine();
            Console.WriteLine(B.Multiply(A));
            Console.WriteLine();

            // 1.15
            A = new Matrices.Matrix(new double[,]
                                {
                                                { 3, 0 },
                                                { -1, 2 },
                                                { 1, 1 }
                                });

            B = new Matrices.Matrix(new double[,]
                                {
                                                {  4, -1 },
                                                {  0, 2 }
                                });
            var C = new Matrices.Matrix(new double[,]
                    {
                                                {  1, 4, 2 },
                                                {  3, 1, 5 }
                    });

            var test = A.Multiply(B);

            Console.WriteLine(A.Multiply(B).Multiply(C));
            Console.WriteLine();
            Console.WriteLine(A.Multiply(B.Multiply(C)));
            Console.WriteLine();

        }
    }
}
