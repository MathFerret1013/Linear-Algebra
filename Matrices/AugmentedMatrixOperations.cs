// Copyright 2015 Eric Regina
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//  
//     http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Matrices
{
    using System;

    public static class AugmentedMatrixOperations
    {
        private const double TOLERANCE = 1E-15;

        public static AugmentedMatrix SwapRows(this AugmentedMatrix augMatrix, int row1, int row2)
        {
            var identity = augMatrix[0].GetIdentity();

            identity[row1, row1] = 0;
            identity[row1, row2] = 1;

            identity[row2, row2] = 0;
            identity[row2, row1] = 1;

            for (int i = 0; i < augMatrix.Count; i++)
            {
                augMatrix[i] = identity * augMatrix[i];
            }

            return augMatrix;
        }

        public static AugmentedMatrix MultiplyRowByScalar(
            this AugmentedMatrix augMatrix,
            int row,
            double scalar,
            int startColumn = 0)
        {
            for (int i = 0; i < augMatrix.Count; i++)
            {
                // TODO: This method should not modify the original augMatrix
                for (int j = startColumn; j < augMatrix[i].Columns; j++)
                {
                    augMatrix[i][row, j] = scalar * augMatrix[i][row, j];
                }
            }

            return augMatrix;
        }

        /// <summary>
        ///     Performs the elementary row operation of assing two rows.
        ///     The <paramref name="addendRow" /> is the  row which is updated.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="augendRow"></param>
        /// <param name="addendRow"></param>
        /// <returns></returns>
        public static AugmentedMatrix AddRows(
            this AugmentedMatrix augMatrix,
            int augendRow,
            int addendRow,
            double scalarMultiple = 1.0)
        {
            for (int i = 0; i < augMatrix.Count; i++)
            {
                for (int j = 0; j < augMatrix[i].Columns; j++)
                {
                    augMatrix[i][addendRow, j] = augMatrix[i][addendRow, j]
                                                 + (scalarMultiple * augMatrix[i][augendRow, j]);
                }
            }

            return augMatrix;
        }

        /// <summary>
        ///     Performs the elementary row operation of assing two rows.
        ///     The <paramref name="addendRow" /> is the  row which is updated.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="augendRow"></param>
        /// <param name="addendRow"></param>
        /// <returns></returns>
        public static AugmentedMatrix AddRows(
            this AugmentedMatrix augMatrix,
            double[] augendRow,
            int addendRow,
            int matrixIndex)
        {
            for (int j = 0; j < augMatrix[matrixIndex].Columns; j++)
            {
                augMatrix[matrixIndex][addendRow, j] += augendRow[j];
            }

            return augMatrix;
        }

        /// <summary>
        ///     Performs gaussian elimination on the given matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static AugmentedMatrix GaussianElimination(this AugmentedMatrix augMatrix)
        {
            // Derived from ref [1] Theorem 3.5

            // identify the row with the first non zero element
            int nonZeroRowIndex = 0;
            bool run = true;
            int nonZeroColumnIndex = 0;
            while (run && nonZeroColumnIndex < augMatrix[0].Columns)
            {
                // Check if columns has non-zero entry
                var col = augMatrix[0].GetColumn(nonZeroColumnIndex);
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
                augMatrix = augMatrix.SwapRows(nonZeroRowIndex, 0);
            }

            // If the first non zero row does not equal 1 then normalize the 
            if (Math.Abs(augMatrix[0][0, nonZeroColumnIndex] - 1.0) > TOLERANCE)
            {
                augMatrix = augMatrix.MultiplyRowByScalar(0, 1.0 / augMatrix[0][0, nonZeroColumnIndex]);
            }

            int iMax = Math.Min(augMatrix[0].Columns, augMatrix[0].Rows);
            // Zero-wise columns
            for (int i = 0, currentCol = 0; i < iMax && currentCol < augMatrix[0].Columns; i++, currentCol++)
            {
                var currentStartElement = augMatrix[0][i, currentCol];

                if (Math.Abs(currentStartElement) > TOLERANCE)
                {
                    for (int j = i + 1; j < iMax; j++)
                    {
                        var ratio = -1.0 * (augMatrix[0][j, currentCol] / currentStartElement);
                        augMatrix = augMatrix.AddRows(i, j, ratio);
                    }
                }
                else
                {
                    i--; // The test element was zero, do not increment the row
                }
            }

            return augMatrix;
        }

        /// <summary>
        ///     Computes the reduced row echelon form of the matrix.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static AugmentedMatrix ReducedRowEchelonForm(this AugmentedMatrix augMatrix)
        {
            augMatrix = augMatrix.GaussianElimination();
            var gaussElimResult = augMatrix[0];

            int iMax = Math.Min(gaussElimResult.Columns, gaussElimResult.Rows);
            for (int i = 0, currentCol = 0; i < iMax && currentCol < gaussElimResult.Columns; i++, currentCol++)
            {
                var currentStartElement = gaussElimResult[i, currentCol];

                if (Math.Abs(currentStartElement) > TOLERANCE)
                {
                    // If the current start element does not equal 1 then fix it
                    if (Math.Abs(currentStartElement - 1) > TOLERANCE)
                    {
                        augMatrix = augMatrix.MultiplyRowByScalar(i, 1.0 / currentStartElement);
                    }

                    for (int j = 0; j <= i - 1; j++)
                    {
                        var ratio = -1.0 * gaussElimResult[j, currentCol] * gaussElimResult[i, currentCol];
                        augMatrix = augMatrix.AddRows(i, j, ratio);
                    }
                }
                else
                {
                    i--; // The test element was zero, do not increment the row
                }
            }

            return augMatrix;
        }
    }
}