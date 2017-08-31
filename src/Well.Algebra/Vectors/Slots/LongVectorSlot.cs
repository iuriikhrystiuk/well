namespace Well.Algebra.Vectors.Slots
{
    internal class LongVectorSlot : Slot<long>
    {
        public LongVectorSlot(long item) : base(item)
        {
        }

        public override long Multiply(long other)
        {
            return Item * other;
        }

        public override long Add(long other)
        {
            return Item + other;
        }
    }
}