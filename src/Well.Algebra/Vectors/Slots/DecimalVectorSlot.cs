namespace Well.Algebra.Vectors.Slots
{
    internal class DecimalVectorSlot: Slot<decimal>
    {
        public DecimalVectorSlot(decimal item) : base(item)
        {
        }

        public override decimal Multiply(decimal other)
        {
            return Item * other;
        }

        public override decimal Add(decimal other)
        {
            return Item + other;
        }
    }
}