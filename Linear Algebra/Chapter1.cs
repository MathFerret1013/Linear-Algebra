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

namespace Linear_Algebra
{
    using System;

    using Matrices;

    public static class Chapter1
    {
        public static void Execute()
        {
            // 1.12
            var A = new Matrix(new double[,] { { 3, 1, -2 }, { 2, -2, 0 }, { -1, 1, 2 } });
            var B = new Matrix(new double[,] { { 1, 1, 1 }, { 1, -1, 1 }, { 0, 1, 2 } });

            Console.WriteLine(A.Multiply(B));
            Console.WriteLine();

            // 1.13
            A = new Matrix(new double[,] { { 1, 1, 1 }, { 0, 1, 1 }, { 0, 0, 1 } });
            B = new Matrix(new double[,] { { 1, 0, 0 }, { 1, 1, 0 }, { 1, 1, 1 } });

            Console.WriteLine(A.Multiply(B));
            Console.WriteLine();

            // 1.14
            A = new Matrix(new double[,] { { 1 }, { 2 }, { 3 }, { 4 } });

            B = new Matrix(new double[,] { { 1, 2, 3, 4 } });

            Console.WriteLine(A.Multiply(B));
            Console.WriteLine();
            Console.WriteLine(B.Multiply(A));
            Console.WriteLine();

            // 1.15
            A = new Matrix(new double[,] { { 3, 0 }, { -1, 2 }, { 1, 1 } });

            B = new Matrix(new double[,] { { 4, -1 }, { 0, 2 } });
            var C = new Matrix(new double[,] { { 1, 4, 2 }, { 3, 1, 5 } });

            var test = A.Multiply(B);

            Console.WriteLine(A.Multiply(B).Multiply(C));
            Console.WriteLine();
            Console.WriteLine(A.Multiply(B.Multiply(C)));
            Console.WriteLine();
        }
    }
}