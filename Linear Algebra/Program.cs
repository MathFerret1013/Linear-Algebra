 using System;
 using System.Linq;

namespace Linear_Algebra
{
    using Matrices;

    class Program
    {
        static void Main(string[] args)
        {

            var A = new Matrix(new double[,] { { 1, 2, 3 }, { 0, 1, 4}, { 5, 6, 0} });
            var I = A.GetIdentity();

            var aug = new AugmentedMatrix(new Matrix[] {A, I});
            Console.WriteLine(aug);

            var augGE = aug.ReducedRowEchelonForm();
            Console.WriteLine(augGE);

            // Console.WriteLine(new Matrix(new double[,] { { 1, 2, 3 }, { 0, 1, 4 }, { 5, 6, 0 } }) * augGE[1]);

            Console.WriteLine();
            Console.Read();
        }
    }
}