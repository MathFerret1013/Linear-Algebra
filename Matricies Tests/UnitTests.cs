using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricies_Tests
{
    using Matrices;

    using NUnit.Framework;

    public class UnitTests
    {

        [Test]
        public void GaussianEliminationTest()
        {
            // Examples from: 
            // Basic Linear  Algebra, 2nd ed.
            // Blyth and Robertson

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
