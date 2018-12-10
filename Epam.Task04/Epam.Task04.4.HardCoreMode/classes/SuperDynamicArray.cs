using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._4.HardCoreMode
{
    class SuperDynamicArray<T> : DynamicArray<T>, ICloneable
    {
        public new int Capacity
        {
            get { return base.Capacity; }
            set
            {
                if (value > 0 & value < base.Capacity)
                {
                    T[] buffer = new T[value];
                    for (int i = 0; i < value; i++)
                    {
                        buffer[i] = arr[i];
                    }
                    base.arr = buffer;
                    base.Capacity = value;
                    base.Count = base.Capacity;
                }
                else if (value > 0 & value > base.Capacity)
                {
                    T[] buffer = new T[value];

                    for (int i = 0; i < base.Count; i++)
                    {
                        buffer[i] = arr[i];
                    }
                    base.arr = buffer;
                    base.Capacity = value;
                }
                else if (value < 1)
                {
                    throw new Exception("The capacity can't be less than 1");
                }
            }
        }
        public SuperDynamicArray() : base()
        { }
        public SuperDynamicArray(int length) : base(length)
        { }

        public SuperDynamicArray(IEnumerable<T> collection) : base(collection)
        { }


        public override T this[int index]
        {
            get
            {
                if (index > 0 & index < base.Count) { return base[index]; }

                else if (index < 0 & Math.Abs(index) <= Count)
                {
                    return base[Count + index];
                }

                else throw new ArgumentOutOfRangeException("Index is out of range");
            }

            set
            {
                if (index > 0 & index < base.Count) { base[index] = value; }

                else if (index < 0 & Math.Abs(index) <= Count)
                {
                    base[Count + index] = value;
                }

                else throw new ArgumentOutOfRangeException("Index is out of range");
            }
        }

        public object Clone()
        {
            T[] buffer = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                buffer[i] = arr[i];
            }
            return buffer;
        }

        public T[] ToArray()
        {
            T[] buffer = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                buffer[i] = arr[i];
            }
            return buffer;
        }
    }
}
