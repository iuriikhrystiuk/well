using System;
using Well.Algebra.Vectors.Slots;

namespace Well.Algebra.Vectors
{
    internal class SlotFactory
    {
        public Slot<T> CreateSlot<T>(T item)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int32:
                    return new IntVectorSlot(Convert.ToInt32(item)) as Slot<T>;
                case TypeCode.Int64:
                    return new LongVectorSlot(Convert.ToInt64(item)) as Slot<T>;
                case TypeCode.Decimal:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}