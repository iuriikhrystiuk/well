using System;
using Well.Algebra.Matrices;
using Well.Algebra.Vectors;

namespace Well.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix<int>(new Vector<int>(Direction.Horizontal, 1, 2, 3));
            Console.WriteLine(matrix);
            
            var matrix2 = new Matrix<int>(new Vector<int>(Direction.Vertical, 1, 2, 3));
            Console.WriteLine(matrix2);
        }
    }
}