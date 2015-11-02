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
    using System.Collections.Generic;

    public static class ArrayUtilities
    {
        /// <summary>
        ///     Creates an array from  a 2D rectangular array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rectangularArray"></param>
        /// <returns></returns>
        public static T[] ToArray<T>(this T[,] rectangularArray)
        {
            // 33% faster than foreach
            // 85% faster than rectangularArray.Cast<T>().ToArray();

            var list = new List<T>();
            var rows = rectangularArray.GetLength(0);
            var columns = rectangularArray.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    list.Add(rectangularArray[i, j]);
                }
            }

            return list.ToArray();
        }
    }
}