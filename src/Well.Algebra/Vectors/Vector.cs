using System;
using System.Linq;
using System.Text;
using Well.Algebra.Exceptions;
using Well.Algebra.Vectors.Slots;

namespace Well.Algebra.Vectors
{
    public class Vector<T> where T : struct
    {
        private readonly Slot<T>[] _items;
        private readonly SlotFactory _factory = new SlotFactory();

        public Vector(Direction direction, params T[] items)
        {
            Direction = direction;
            _items = items?.Select(t => _factory.CreateSlot(t)).ToArray() ??
                     throw new ArgumentNullException(nameof(items));
        }

        public T this[long index] => _items[index].Item;

        public long Count => _items.Length;

        public Direction Direction { get; }
        
        public T Dot(Vector<T> other)
        {
            if (other.Count != Count)
            {
                throw new IncompatibleDimensionsException();
            }

            if (Direction == other.Direction)
            {
                throw new IncompatibleDirectionsException();
            }

            if (Direction == Direction.Vertical)
            {
                throw new InvalidOperationException();
            }

            var sum = default(T);
            for (var i = 0; i < Count; i++)
            {
                sum = _factory.CreateSlot(sum).Add(_items[i].Multiply(other[i]));
            }

            return sum;
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