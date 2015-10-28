namespace Matrices
{
    using System;
    using System.Linq;

    public static class MatrixOperations
    {
        private const double TOLERANCE = 1E-15;

        /// <summary>
        /// Multiplies two maricies together
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>The product of the matrices</returns>
        public static Matrix Multiply(this Matrix A, Matrix B)
        {
            var matrix = new Matrix(A.Rows, B.Columns);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Columns; j++)
                {
                    matrix[i, j] = DotProduct(A.GetRow(i), B.GetColumn(j));
                }
            }

            /*
            for (int i = 0; i < A.Rows; i++)
            {
                for (int k = 0; k < A.Columns; k++)
                {
                    for (int j = 0; j < B.Columns; j++)
                    {
                        array[i * A.Columns + j] += A.internalArray[i * A.Columns + k]
                                                    * B.internalArray[k * B.Columns + j];
                    }
                }
            } */

            return matrix;
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <returns>The sum of the wo matrices</returns>
        public static Matrix Sum(this Matrix A, Matrix B)
        {
            var matrix = new Matrix(A.Rows, A.Columns);
            for (int i = 0; i < A.internalArray.Length; i++)
            {
                matrix.internalArray[i] = A.internalArray[i] + B.internalArray[i];
            }
            return matrix;
        }


        /// <summary>
        /// Computes the dot product of two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double DotProduct(this double[] a, double[] b)
        {
            var sum = 0.0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i] * b[i];
            }

            return sum;
        }



        #region Elementary Row Operations

        public static Matrix SwapRows(Matrix matrix, int row1, int row2)
        {
            var identity = matrix.GetIdentity();

            identity[row1, row1] = 0;
            identity[row1, row2] = 1;

            identity[row2, row2] = 0;
            identity[row2, row1] = 1;

            return identity * matrix;
        }

        public static Matrix MultiplyRowByScalar(Matrix matrix, int row, double scalar, int startColumn = 0)
        {
            // TODO: This method should not modify the original matrix
            for (int i = startColumn; i < matrix.Columns; i++)
            {
                matrix[row, i] = scalar * matrix[row, i];
            }

            return matrix;
        }

        /// <summary>
        /// Performs the elementary row operation of assing two rows.
        /// The <paramref name="addendRow"/> is the  row which is updated.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="augendRow"></param>
        /// <param name="addendRow"></param>
        /// <returns></returns>
        public static Matrix AddRows(Matrix matrix, int augendRow, int addendRow)
        {
            for (int i = 0; i < matrix.Columns; i++)
            {
                matrix[addendRow, i] = matrix[addendRow, i] + matrix[augendRow, i];
            }

            return matrix;
        }

        /// <summary>
        /// Performs the elementary row operation of assing two rows.
        /// The <paramref name="addendRow"/> is the  row which is updated.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="augendRow"></param>
        /// <param name="addendRow"></param>
        /// <returns></returns>
        public static Matrix AddRows(Matrix matrix, double[] augendRow, int addendRow)
        {
            for (int i = 0; i < matrix.Columns; i++)
            {
                matrix[addendRow, i] += augendRow[i];
            }

            return matrix;
        }

        #endregion

        #region Gaussian Elimination

        /// <summary>
        /// Performs gaussian elimination on the given matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix GaussianElimination(Matrix matrix)
        {
            // Derived from ref [1] Theorem 3.5

            // identify the row with the first non zero element
            int nonZeroRowIndex = 0;
            bool run = true;
            int nonZeroColumnIndex = 0;
            while (run && nonZeroColumnIndex < matrix.Columns)
            {
                // Check if columns has non-zero entry
                var col = matrix.GetColumn(nonZeroColumnIndex);
                for (int j = 0; j < col.Length; j++)
                {
                    if (Math.Abs(col[j]) > TOLERANCE)
                    {
                        nonZeroRowIndex = j;
                        run = false;
                        break;
                    }
                }

                if (run)
                {
                    nonZeroColumnIndex++;
                }
            }

            // Move this row into the top position
            if (nonZeroRowIndex != 0)
            {
                matrix = MatrixOperations.SwapRows(matrix, nonZeroRowIndex, 0);
            }

            // If the first non zero row does not equal 1 then normalize the 
            if (Math.Abs(matrix[0, nonZeroColumnIndex] - 1.0) > TOLERANCE)
            {

                matrix = MatrixOperations.MultiplyRowByScalar(
                    matrix,
                    0,
                    1.0 / matrix[0, nonZeroColumnIndex]);
            }

            int iMax = Math.Min(matrix.Columns, matrix.Rows);
            // Zero-wise columns
            for (int i = 0, currentCol = 0; i < iMax && currentCol < matrix.Columns; i++, currentCol++)
            {
                var currentStartElement = matrix[i, currentCol];

                if (Math.Abs(currentStartElement) > TOLERANCE)
                {
                    for (int j = i + 1; j < iMax; j++)
                    {
                        var modifiedRow = matrix.GetRow(i).Select(m => -1 * m * (matrix[j, currentCol] / currentStartElement)).ToArray();
                        matrix = MatrixOperations.AddRows(matrix, modifiedRow, j);
                    }
                }
                else
                {
                    i--; // The test element was zero, do not increment the row
                }
            }

            return matrix;
        }

        /// <summary>
        /// Computes the reduced row echelon form of the matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static Matrix ReducedRowEchelonForm(Matrix matrix)
        {
            var gaussElimResult = MatrixOperations.GaussianElimination(matrix);

            int iMax = Math.Min(gaussElimResult.Columns, gaussElimResult.Rows);
            for (int i = 0, currentCol = 0; i < iMax && currentCol < gaussElimResult.Columns; i++, currentCol++)
            {
                var currentStartElement = gaussElimResult[i, currentCol];

                if (Math.Abs(currentStartElement) > TOLERANCE) 
                {
                    // If the current start element does not equal 1 then fix it
                    if (Math.Abs(currentStartElement - 1) > TOLERANCE)
                    {
                        gaussElimResult = MatrixOperations.MultiplyRowByScalar(gaussElimResult, i, 1.0 / currentStartElement);
                    }

                    for (int j = 0; j <= i - 1; j++)
                    {
                        var modifiedRow =
                            gaussElimResult.GetRow(i)
                                .Select(m => -1 * m * (gaussElimResult[j, currentCol] * gaussElimResult[i, currentCol]))
                                .ToArray();
                        gaussElimResult = MatrixOperations.AddRows(gaussElimResult, modifiedRow, j);
                    }
                }
                else
                {
                    i--; // The test element was zero, do not increment the row
                }

            }

            return gaussElimResult;
        }

        #endregion
    }
}
