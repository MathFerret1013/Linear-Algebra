namespace Matrix_Tests
{
    using Matrices;

    using NUnit.Framework;

    public class UnitTests
    {
        /// <summary>
        /// Tests Matrix Multiplication
        /// 
        /// Examples from: 
        /// Basic Linear  Algebra, 2nd ed.
        /// Blyth and Robertson
        /// </summary>
        [Test]
        public void MatrixMultiplicationTest()
        {
            // Example 1.4, pg 7
            var ex14_A = new Matrix(new double[,]
                             {
                                            { 0, 1, 0 },
                                            { 2, 3, 1 }
                             });

            // Example 1.4, pg 7
            var ex14_B = new Matrix(new double[,]
                             {
                                            { 2, 0 },
                                            { 1, 2 },
                                            { 1, 1 }
                             });

            var ex14_Result = new Matrix(new double[,]
                             {
                                            { 1, 2 },
                                            { 8, 7 }
                             });

            // Exercise 1.12
            var ex112_A = new Matrices.Matrix(new double[,]
                                            {
                                                {  3, 1, -2 },
                                                { 2, -2, 0 },
                                                { -1, 1, 2 }
                                            });

            var ex112_B = new Matrices.Matrix(new double[,]
                                {
                                                {  1, 1, 1 },
                                                { 1, -1, 1 },
                                                { 0, 1, 2 }
                                });

            var ex112_Result = new Matrices.Matrix(new double[,]
                      {
                                                { 4, 0, 0 },
                                                { 0, 4, 0 },
                                                { 0, 0, 4 }
                      });


            // Exercise 1.13
            var ex113_A = new Matrices.Matrix(new double[,]
                                            {
                                                { 1, 1, 1 },
                                                { 0, 1, 1 },
                                                { 0, 0, 1 }
                                            });
            var ex113_Result = new Matrices.Matrix(new double[,]
                                {
                                                { 3, 2, 1 },
                                                { 2, 2, 1 },
                                                { 1, 1, 1 }
                                });

            var ex113_B = new Matrices.Matrix(new double[,]
                      {
                                                { 1, 0, 0 },
                                                { 1, 1, 0 },
                                                { 1, 1, 1 }
                      });

            Assert.That(ex14_A * ex14_B, Is.EqualTo(ex14_Result));
            Assert.That(ex112_A * ex112_B, Is.EqualTo(ex112_Result));
            Assert.That(ex113_A * ex113_B, Is.EqualTo(ex113_Result));

        }

        /// <summary>
        /// Tests GaussianElimination
        /// 
        /// Examples from: 
        /// Basic Linear  Algebra, 2nd ed.
        /// Blyth and Robertson
        /// </summary>
        [Test]
        public void GaussianEliminationTest()
        {
            // Example 3.11, pg 35
            var ex311 = new Matrix(new double[,]
                             {
                                            { 1, 0, 1, 0, 1},
                                            { 1, 1, 0, 0, 2},
                                            { 3, 1, 1, 1, 1},
                                            { 0, 1, 2, 1, 2}
                             });

            var ex311Result = new Matrix(new double[,]
                 {
                                            { 1, 0, 1, 0, 1},
                                            { 0, 1, -1, 0, 1},
                                            { 0, 0, -1, 1, -3},
                                            { 0, 0, 0, 4, -8},
                 });

            // Example 3.12, pg. 36
            var ex312 = new Matrix(new double[,]
                                        {
                                            { 0, 0, 2 },
                                            { 1, -1, 1},
                                            { -1, 1, 4}
                                        });
            var ex312Result = new Matrix(new double[,]
                            {
                                            { 1, -1, 1 },
                                            { 0, 0, 2 },
                                            { 0, 0, 0 }
                            });

            // Example 3.13, pg. 36
            var ex313 = new Matrix(new double[,]
                                        {
                                            { 1, -2, 1 },
                                            { 2, -4, 2 },
                                            { -1, 2, -1}
                                        });
            var ex313Result = new Matrix(new double[,]
                            {
                                            { 1, -2, 1 },
                                            { 0, 0, 0 },
                                            { 0, 0, 0 }
                            });


            Assert.That(MatrixOperations.GaussianElimination(ex311), Is.EqualTo(ex311Result));
            Assert.That(MatrixOperations.GaussianElimination(ex312), Is.EqualTo(ex312Result));
            Assert.That(MatrixOperations.GaussianElimination(ex313), Is.EqualTo(ex313Result));

        }

    }
}
