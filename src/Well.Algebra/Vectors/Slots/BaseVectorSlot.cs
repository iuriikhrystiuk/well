namespace Well.Algebra.Vectors.Slots
{
    internal abstract class Slot<T>
    {
        public T Item { get; }

        protected Slot(T item)
        {
            Item = item;
        }

        public abstract T Multiply(T other);

        public abstract T Add(T other);
    }
}