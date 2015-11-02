﻿// Copyright 2015 Eric Regina
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

    internal class Program
    {
        private static void Main(string[] args)
        {
            var A = new Matrix(new double[,] { { 1, 2, 3 }, { 0, 1, 4 }, { 5, 6, 0 } });
            var I = A.GetIdentity();

            var aug = new AugmentedMatrix(new Matrix[] { A, I });
            Console.WriteLine(aug);

            var augGE = aug.ReducedRowEchelonForm();
            Console.WriteLine(augGE);

            // Console.WriteLine(new Matrix(new double[,] { { 1, 2, 3 }, { 0, 1, 4 }, { 5, 6, 0 } }) * augGE[1]);

            Console.WriteLine();
            Console.Read();
        }
    }
}