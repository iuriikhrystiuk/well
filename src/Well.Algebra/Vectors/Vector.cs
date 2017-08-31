using System;
using System.Linq;
using System.Text;
using Well.Algebra.Vectors.Exceptions;
using Well.Algebra.Vectors.Slots;

namespace Well.Algebra.Vectors
{
    public class Vector<T> where T : struct
    {
        private readonly Slot<T>[] _items;
        private readonly SlotFactory _factory = new SlotFactory();
        private readonly Direction _direction;

        private T this[long index] => _items[index].Item;

        private long Count => _items.Length;

        public Vector(Direction direction, params T[] items)
        {
            _direction = direction;
            _items = items?.Select(t => _factory.CreateSlot(t)).ToArray() ??
                     throw new ArgumentNullException(nameof(items));
        }

        public T Dot(Vector<T> other)
        {
            if (other.Count != Count)
            {
                throw new IncompatibleDimensionsException();
            }

            if (_direction == other._direction)
            {
                throw new IncompatibleDirectionsException();
            }

            var sum = default(T);
            for (var i = 0; i < Count; i++)
            {
                sum = _factory.CreateSlot(sum).Add(_items[i].Multiply(other[i]));
            }

            return sum;
        }

        public Vector<T> Plus(Vector<T> other)
        {
            if (other.Count != Count)
            {
                throw new IncompatibleDimensionsException();
            }
            
            if (_direction != other._direction)
            {
                throw new IncompatibleDirectionsException();
            }


            var items = new T[Count];
            for (var i = 0; i < Count; i++)
            {
                items[i] = _items[i].Add(other[i]);
            }

            return new Vector<T>(_direction, items);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("|");
            stringBuilder.Append(string.Join(" ", _items.Select(i => i.Item.ToString())));
            stringBuilder.Append("|");
            return stringBuilder.ToString();
        }
    }
}