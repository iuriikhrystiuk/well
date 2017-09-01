using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Well.Algebra.Exceptions;
using Well.Algebra.Vectors;

namespace Well.Algebra.Matrices
{
    public class Matrix<T> where T : struct
    {
        private readonly Vector<T>[] _items;

        public Matrix(params T[][] items)
        {
            if (items == null)
            {
                throw new ArgumentException(nameof(items));
            }

            if (items.GroupBy(i => i.Length).Count() > 1)
            {
                throw new IncompatibleDimensionsException();
            }

            _items = items.Select(i=>new Vector<T>(i)).ToArray();
        }

        public long Rows => _items.Length;

        public long Columns => _items.First().Count;

        public Vector<T> Row(long index) => _items[index];

        public Vector<T> Column(long index)
        {
            var collection = new List<T>();
            for (int i = 0; i < Rows; i++)
            {
                collection.Add(_items[i][index]);
            }
            
            return new Vector<T>(collection.ToArray());
        }
        
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(Environment.NewLine, _items.Select(i => i.ToString())));
            return stringBuilder.ToString();
        }
    }
}