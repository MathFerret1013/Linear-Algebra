namespace Matrices
{
    using System;
    using System.Linq;
    using System.Numerics;
    using System.Threading.Tasks;

    /// <summary>
    /// Represent an 2-dimensional matrix. Currently all numerical
    /// </summary>
    public static class Class1
    {

        public static Matrix Multiply(Matrix A, Matrix B)
        {
            
            var array = new double[A.Rows * B.Columns];

            for (int i = 0; i < A.Rows; i++)
            {
                for (int k = 0; k < A.Columns; k++)
                {
                    for (int j = 0; j < B.Columns; j++)
                    {
                        array[i * A.Rows + j] += A.internalArray[i * A.Columns + k]
                                                    * B.internalArray[k * B.Columns + j];
                    }
                }
            }

            return new Matrix(A.Rows, B.Columns, array);
        }


        public static void Multiply(double[] A, int A_ROWS, int A_COLS, double[] B, int B_COLS, double[] C)
        {
            // var C = new double[A_ROWS * B_COLS ];

            for (int i = 0; i < A_ROWS; i++)
            {
                for (int k = 0; k < A_COLS; k++)
                {
                    for (int j = 0; j < B_COLS; j++)
                    {
                        C[i * A_ROWS + j] += A[i * A_COLS + k] * B[k * B_COLS + j];
                    }
                }
            }

            // return C;
        }

        public static double[] Multiply_SIMD_2(Matrix A, Matrix B)
        {
            // Abour 50% fateser when matrix size >= 8x8

            var vecSize = Vector<double>.Count;
            var bRemainer = B.Columns % Vector<double>.Count;
            if (B.Columns % Vector<double>.Count != 0)
            {
                B.AddColumns(bRemainer);
            }

            var C = new double[A.Rows * B.Columns];

            for (int i = 0; i < A.Rows; i++)
            {
                for (int k = 0; k < A.Columns; k++)
                {
                    for (int j = 0; j < B.Columns; j += vecSize)
                    {
                        var vC = new Vector<double>(C, i * A.Rows + j);
                        var vB = new Vector<double>(B.internalArray, k * B.Columns + j);
                        var vA = new Vector<double>(A.internalArray[i * A.Columns + k]);
                        vC += vA * vB;
                        vC.CopyTo(C, i * A.Rows + j);
                    }
                }
            }

            return C.ToArray();
        }
        }
}
