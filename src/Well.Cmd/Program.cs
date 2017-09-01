using System;
using Well.Algebra.Matrices;
using Well.Algebra.Vectors;
using Well.Algebra.Extensions;

namespace Well.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var vector = new Vector<int>(1, 2, 3);
            Console.WriteLine(vector);

            var matrix = new Matrix<int>(
                new[] {1, 2, 3},
                new[] {1, 2, 3},
                new[] {1, 2, 3});
            Console.WriteLine(vector.Dot(matrix));
            Console.WriteLine(matrix.Dot(vector));
        }
    }
}