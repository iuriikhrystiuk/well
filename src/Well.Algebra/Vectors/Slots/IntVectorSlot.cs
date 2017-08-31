namespace Well.Algebra.Vectors.Slots
{
    internal class IntVectorSlot : Slot<int>
    {
        public IntVectorSlot(int item) : base(item)
        {
        }

        public override int Multiply(int other)
        {
            return Item * other;
        }

        public override int Add(int other)
        {
            return Item + other;
        }
    }
}