using System;
using System.Linq;
using System.Text;
using Well.Algebra.Vectors;

namespace Well.Algebra.Matrices
{
    public class Matrix<T> where T : struct
    {
        private readonly Vector<T>[] _items;

        public Matrix(params Vector<T>[] items)
        {
            _items = items;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(Environment.NewLine, _items.Select(i => i.ToString())));
            return stringBuilder.ToString();
        }
    }
}