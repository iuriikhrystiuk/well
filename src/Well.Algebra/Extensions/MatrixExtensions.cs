using System.Collections.Generic;
using Well.Algebra.Exceptions;
using Well.Algebra.Matrices;
using Well.Algebra.Vectors;

namespace Well.Algebra.Extensions
{
    public static class MatrixExtensions
    {
        public static Vector<T> Dot<T>(this Vector<T> vector, Matrix<T> matrix) where T : struct
        {
            if (vector.Count != matrix.Rows)
            {
                throw new IncompatibleDimensionsException();
            }
            
            var collection = new List<T>();
            for (long i = 0; i < matrix.Columns; i++)
            {
                collection.Add(vector.Dot(matrix.Column(i)));
            }
            
            return new Vector<T>(collection.ToArray());
        }
        
        public static Vector<T> Dot<T>(this Matrix<T> matrix, Vector<T> vector) where T : struct
        {
            if (vector.Count != matrix.Columns)
            {
                throw new IncompatibleDimensionsException();
            }
            
            var collection = new List<T>();
            for (long i = 0; i < matrix.Rows; i++)
            {
                collection.Add(vector.Dot(matrix.Row(i)));
            }
            
            return new Vector<T>(collection.ToArray());
        }
    }
}