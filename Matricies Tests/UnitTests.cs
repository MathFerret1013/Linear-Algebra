namespace Matrix_Tests
{
    using Matrices;
    using NUnit.Framework;

    [TestFixture]
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
        /// Tests matrix addition and subtraction.
        /// </summary>
        [Test]
        public void MatrixAdditionSubtractionTest()
        {
            // Addition
            var add_A = new Matrix(new double[,]
                   {
                                            { 2, 0 },
                                            { 1, 2 },
                                            { 1, 1 }
                   });

            var add_B = new Matrix(new double[,]
                         {
                                            { 5, -1 },
                                            { 1, 1 },
                                            { 9, 0 }
                         });

            var add_Result = new Matrix(new double[,]
             {
                                            { 7, -1 },
                                            { 2, 3 },
                                            { 10, 1 }
             });

            // Subtraction
            var subtract_A = new Matrix(new double[,]
                             {
                                            { 2, 0 },
                                            { 1, 2 },
                                            { 1, 1 }
                             });

            var subtract_B = new Matrix(new double[,]
                         {
                                            { 5, -1 },
                                            { 1, 1 },
                                            { 9, 0 }
                         });

            var subtract_Result = new Matrix(new double[,]
             {
                                            { -3, 1 },
                                            { 0, 1 },
                                            { -8, 1 }
             });

            Assert.That(add_A + add_B, Is.EqualTo(add_Result));
            Assert.That(subtract_A - subtract_B, Is.EqualTo(subtract_Result));
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

        /// <summary>
        /// Tests calculating the reduced row echelon form.
        /// 
        /// Results are compared against Mathematica RowReduce function
        /// </summary>
        [Test]
        public void ReducedRowEchelonFormTest()
        {
            var test_1 = new Matrix(new double[,]
                            {
                                            { 1, 2, 3 },
                                            { 4, 5, 6 },
                                            { 7, 8, 9 }
                            });

            var test_1_Result = new Matrix(new double[,]
                {
                                            { 1, 0, -1 },
                                            { 0, 1, 2 },
                                            { 0, 0, 0 }
                });

            var test_2 = new Matrix(new double[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } });
            var test_2_Result = new Matrix(new double[,] { { 1, 0, -1, -2, -3}, { 0, 1, 2, 3, 4} });


            var test_3 = new Matrix(new double[,] { { 1, 2, 1, 2, 1 }, { 2, 4, 4, 8, 4 }, { 3, 6, 5, 7, 7 } });
            var test_3_Result = new Matrix(new double[,] { { 1, 2, 0, 0, 0 }, { 0, 0, 1, 0, 7.0 / 3.0 }, { 0, 0, 0, 1, -2.0 / 3.0 } } );

            Assert.That(MatrixOperations.ReducedRowEchelonForm(test_1), Is.EqualTo(test_1_Result));
            Assert.That(MatrixOperations.ReducedRowEchelonForm(test_2), Is.EqualTo(test_2_Result));
            Assert.That(MatrixOperations.ReducedRowEchelonForm(test_3), Is.EqualTo(test_3_Result));
        }

        /// <summary>
        /// Tests calculating the rank of a matrix.
        /// 
        /// Results are compared against Mathematica MatrixRank function
        /// </summary>
        [Test]
        public void RankTest()
        {

            var test1 = new Matrix(new double[,] { { 0, 0, 2 }, { 1, -1, 1 }, { -1, 1, 4} });
            var test2 = new Matrix(new double[,] { { 1, -2, 1 }, { 2, -4, 2 }, { -1, 2, -1 } });
            var test3 = new Matrix(new double[,] { { 1, 2, 3 }, { 1, 3, 0 }, { 7, 8, 9 } });

            Assert.That(MatrixOperations.Rank(test1), Is.EqualTo(2));
            Assert.That(MatrixOperations.Rank(test2), Is.EqualTo(1));
            Assert.That(MatrixOperations.Rank(test3), Is.EqualTo(3));
        }

        /// <summary>
        /// Tests getting the transpose of a matrix
        /// </summary>
        [Test]
        public void TransposeTest()
        {
            var a = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            var aTranspose = new Matrix(new double[,] { { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 } });

            var b = new Matrix(new double[,] { { 1, 2, 3, 4 } });
            var bTranspose = new Matrix(new double[,] { { 1 }, { 2}, { 3}, { 4 } });

            Assert.That(a.GetTranspose(), Is.EqualTo(aTranspose));
            Assert.That(b.GetTranspose(), Is.EqualTo(bTranspose));
        }

        /// <summary>
        /// Tests the IsSymmetric property if a matrix.
        /// </summary>
        [Test]
        public void SymmetryTest()
        {
            var a = new Matrix(new double[,] { { 1, 2, 3 }, { 2, 5, 6 }, { 3, 6, 9 } });
            var b = new Matrix(new double[,] { { 1, 2, 3, 4 } });

            Assert.That(a.IsSymmetric, Is.EqualTo(true));
            Assert.That(b.IsSymmetric, Is.EqualTo(false));


        }
    }
}
