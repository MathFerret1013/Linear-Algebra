namespace Matrices
{
    using System;
    using System.Collections.Generic;
    public class DoubleEqualityComparer : IEqualityComparer<double>
    {
        public bool Equals(double x, double y)
        {
            return Math.Abs(x - y) <= 1E-13;
        }

        public int GetHashCode(double obj)
        {
            return base.GetHashCode();
        }
    }
}