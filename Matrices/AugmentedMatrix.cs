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
    using System.Text;

    /// <summary>
    ///     Represents and augmented matrix
    /// </summary>
    public class AugmentedMatrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AugmentedMatrix"/> class representing an augmented matrix. All elementary row operations on an augmented matrix must be performed on the first
        /// element of the <paramref name="matrices"/> array. In order to ensure that elementary row operations are erformed correctly, you must use the row operation methods for an <see cref="AugmentedMatrix"/> only.
        /// </summary>
        /// <param name="matrices">An array of <see cref="Matrix"/> objects.</param>
        public AugmentedMatrix(Matrix[] matrices)
        {
            this.Matricies = matrices;
        }

        public int Count => this.Matricies.Length;

        public Matrix[] Matricies { get; }

        public Matrix this[int i]
        {
            get
            {
                return this.Matricies[i];
            }

            set
            {
                this.Matricies[i] = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            // foreach row
            for (int i = 0; i < this[0].Rows; i++)
            {
                // foreach matrix
                for (int index = 0; index < this.Matricies.Length; index++)
                {
                    var m = this.Matricies[index];
                    // print row
                    for (int j = 0; j < m.GetRow(i).Length; j++)
                    {
                        var e = m.GetRow(i)[j];
                        if (j == m.GetRow(i).Length - 1)
                        {
                            sb.Append(e);
                        }
                        else
                        {
                            sb.Append(e + "\t");
                        }
                    }

                    if (index != this.Matricies.Length - 1)
                    {
                        // print augment sign
                        sb.Append(" | ");
                    }
                }

                // new line for next row
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}