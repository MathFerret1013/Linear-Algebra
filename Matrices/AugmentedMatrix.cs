using System;
namespace Matrices
{
    using System.Text;

    /// <summary>
    /// Represents and augmented matrix
    /// </summary>
    public class AugmentedMatrix
    {
        public Matrix[] Matricies { get; }

        public AugmentedMatrix(Matrix[] matrices)
        {
            this.Matricies = matrices;
        }

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

        public int Count => this.Matricies.Length;

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
