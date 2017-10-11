using System.Collections.Generic;
using System.Linq;
using Well.Algebra.Exceptions;
using Well.Algebra.Matrices;
using Well.Algebra.Vectors;

namespace Well.Algebra.Extensions
{
    public static class MatrixExtensions
    {
        public static Vector<T> Dot<T>(this Vector<T> left, Matrix<T> matrix) where T : struct
        {
            if (left.Direction != Direction.Horizontal)
            {
                throw new IncompatibleDirectionsException();
            }
            
            if (left.Count != matrix.Rows)
            {
                throw new IncompatibleDimensionsException();
            }
            
            var collection = new List<T>();
            for (long i = 0; i < matrix.Columns; i++)
            {
                collection.Add(left.Dot(matrix.Column(i)));
            }
            
            return new Vector<T>(Direction.Horizontal, collection.ToArray());
        }
        
        public static Vector<T> Dot<T>(this Matrix<T> matrix, Vector<T> right) where T : struct
        {
            if (right.Direction != Direction.Vertical)
            {
                throw new IncompatibleDirectionsException();
            }
            
            if (right.Count != matrix.Columns)
            {
                throw new IncompatibleDimensionsException();
            }
            
            var collection = new List<T>();
            for (long i = 0; i < matrix.Rows; i++)
            {
                collection.Add(right.Dot(matrix.Row(i)));
            }
            
            return new Vector<T>(Direction.Vertical, collection.ToArray());
        }
        
        public static Matrix<T> Dot<T>(this Matrix<T> left, Matrix<T> right) where T : struct
        {
            if (left.Columns != right.Rows)
            {
                throw new IncompatibleDimensionsException();
            }

            var vectors = new List<T[]>();
            for (int i = 0; i < left.Rows; i++)
            {
                var collection = new List<T>();
                for (long j = 0; j < left.Rows; j++)
                {
                    collection.Add(left.Row(i).Dot(right.Column(j)));
                }
            
                vectors.Add(collection.ToArray());
            }
            
            return new Matrix<T>(vectors.ToArray());
        }
    }
}