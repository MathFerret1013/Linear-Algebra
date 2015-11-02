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
    using System.Linq;
    using System.Text;

    /// <summary>
    ///     Represents a matrix of real numbers
    /// </summary>
    public class Matrix : IEquatable<Matrix>
    {
        public Matrix(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.internalArray = new double[rows * columns];
        }

        /// <summary>
        ///     Creates a matrix from a 2D rectangular array.
        /// </summary>
        /// <param name="matrix"></param>
        public Matrix(double[,] matrix)
        {
            this.Rows = matrix.GetLength(0);
            this.Columns = matrix.GetLength(1);

            this.internalArray = matrix.ToArray();
        }

        /// <summary>
        ///     Creates a matrix from an array and given dimensions
        /// </summary>
        /// <param name="rows">The number of rows the matrix will have.</param>
        /// <param name="columns">The number of columns the matrix will have.</param>
        /// <param name="array">The array containing the matrix elements.</param>
        public Matrix(int rows, int columns, double[] array)
        {
            if (rows * columns != array.Length)
            {
                throw new ArgumentException("There is an error in the dimensions. rows * columns != array.Length!");
            }

            this.Rows = rows;
            this.Columns = columns;
            this.internalArray = array;
        }

        /// <summary>
        ///     Returns <see langword="true" /> if the matrix is square.
        /// </summary>
        public bool IsSquare => this.Columns == this.Rows;

        /// <summary>
        ///     Returns <see langword="true" /> if the matrix is square and equal to its transpose.
        /// </summary>
        public bool IsSymmetric => this.IsSquare && this.Equals(this.GetTranspose());

        /// <summary>
        ///     Number of rows the matrix has
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        ///     Number of columns the matrix has
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        ///     The internal single dimensional array that represents the matrix
        /// </summary>
        public double[] internalArray { get; private set; }

        /// <summary>
        ///     Gets or sets the element  at rowIndex i, column j.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get
            {
                return this.internalArray[this.Columns * i + j];
            }
            set
            {
                this.internalArray[this.Columns * i + j] = value;
            }
        }

        /// <summary>
        ///     Implements <see cref="IEquatable" /> of <see cref="Matrix" />.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Matrix other)
        {
            // Note that elements fo the internal array are compared with a custom EqualityComparer
            return this.Columns == other.Columns && this.Rows == other.Rows
                   && this.internalArray.SequenceEqual(other.internalArray, new DoubleEqualityComparer());
        }

        /// <summary>
        ///     Computer the specified power of the matrix.
        /// </summary>
        /// <param name="m">The matrix</param>
        /// <param name="x">The power of the exponent</param>
        /// <returns></returns>
        public static Matrix Pow(Matrix m, int x)
        {
            var matrix = m;
            for (int i = 0; i < x - 1; i++)
            {
                matrix = matrix * m;
            }
            return matrix;
        }

        /// <summary>
        ///     Returns the transpose of this matrix as a new matrix.
        /// </summary>
        /// <returns>The transposition of the matix.</returns>
        public Matrix GetTranspose()
        {
            var transposeMatrix = new Matrix(this.Columns, this.Rows);
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    transposeMatrix[j, i] = this[i, j];
                }
            }

            return transposeMatrix;
        }

        /// <summary>
        ///     Returns a square identity matrix with a diagonal length equal to the max of the row and columns.
        /// </summary>
        /// <returns>The identity matrix</returns>
        public Matrix GetIdentity()
        {
            var minDimension = this.Rows;
            var identity = new Matrix(minDimension, minDimension);
            for (int i = 0; i < minDimension; i++)
            {
                identity[i, i] = 1;
            }
            return identity;
        }

        /// <summary>
        ///     Transposes the matrix. If you want the transpose of the matrix without modifying the current matrix then use
        ///     GetTranspose().
        /// </summary>
        public void Transpose()
        {
            var transposeMatrix = new Matrix(this.Columns, this.Rows);
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    transposeMatrix[j, i] = this[i, j];
                }
            }

            this.Rows = transposeMatrix.Rows;
            this.Columns = transposeMatrix.Columns;
            this.internalArray = transposeMatrix.internalArray;
        }

        /// <summary>
        ///     Adds the specificed number of rows
        /// </summary>
        /// <param name="rows">The number of rows to add</param>
        public void AddRows(int rows)
        {
            // Each rowIndex is as wide as the number of columns
            var newRows = new double[this.Columns * rows];
            this.internalArray = this.internalArray.Concat(newRows).ToArray();
            this.Rows += rows;
        }

        /// <summary>
        ///     Adds the specified number of row
        /// </summary>
        /// <param name="columns"></param>
        public void AddColumns(int columns)
        {
            // Each columns is as long as the number of rows
            var newColumns = new double[columns];
            var internalList = this.internalArray.ToList();
            for (int i = 0; i < this.Rows; i++)
            {
                internalList.InsertRange((i + 1) * this.Columns + (i * columns), newColumns);
            }

            this.internalArray = internalList.ToArray();
            this.Columns += columns;
        }

        /// <summary>
        ///     Multiplies two maricies together
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>The product of the matricies</returns>
        public static Matrix operator *(Matrix A, Matrix B)
        {
            var matrix = new Matrix(A.Rows, B.Columns);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Columns; j++)
                {
                    matrix[i, j] = A.GetRow(i).DotProduct(B.GetColumn(j));
                }
            }

            return matrix;
        }

        /// <summary>
        ///     Multiplies a matrix by a scalar
        /// </summary>
        /// <param name="scalar">The scalar</param>
        /// <param name="B">tThe Matrix</param>
        /// <returns>The product of the matrix and the scalar</returns>
        public static Matrix operator *(double scalar, Matrix B)
        {
            var array = new double[B.Rows * B.Columns];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = scalar * array[i];
            }

            return new Matrix(B.Rows, B.Columns, array);
        }

        /// <summary>
        ///     Adds two matrices together.
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <returns>The sum of the two matrices</returns>
        public static Matrix operator +(Matrix A, Matrix B)
        {
            return A.Sum(B);
        }

        /// <summary>
        ///     Subtracts two matrices.
        /// </summary>
        /// <param name="A">The first matrix</param>
        /// <param name="B">The second matrix</param>
        /// <returns>The difference of the two matrices</returns>
        public static Matrix operator -(Matrix A, Matrix B)
        {
            return A.Difference(B);
        }

        /// <summary>
        ///     Gets the specified rowIndex as an array.
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the rowIndex.</param>
        /// <returns>An array containing the elements of the rowIndex.</returns>
        public double[] GetRow(int rowIndex)
        {
            if (rowIndex > this.Rows || rowIndex < 0)
            {
                throw new ArgumentException("The rowIndex must be between 0 and the number of matix rows.");
            }

            // Each rowIndex is as wide as the number of columns
            var returnArray = new double[this.Columns];
            var startIndex = rowIndex * this.Columns;
            for (int i = 0; i < this.Columns; i++)
            {
                returnArray[i] = this.internalArray[startIndex + i];
            }

            return returnArray;
        }

        /// <summary>
        ///     Gets the specified rowIndex as an array.
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the rowIndex.</param>
        /// <returns>An array containing the elements of the rowIndex.</returns>
        public double[] GetColumn(int columnIndex)
        {
            if (columnIndex > this.Columns || columnIndex < 0)
            {
                throw new ArgumentException("The columnIndex must be between 0 and the number of matix columnIndex.");
            }

            // Each rowIndex is as wide as the number of columns
            var returnArray = new double[this.Rows];

            for (int i = 0; i < this.Rows; i++)
            {
                returnArray[i] = this.internalArray[i * this.Columns + columnIndex];
            }

            return returnArray;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                foreach (var e in this.GetRow(i))
                {
                    sb.Append(e + "\t");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}