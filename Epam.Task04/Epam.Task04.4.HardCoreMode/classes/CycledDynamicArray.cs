using Epam.Task04._4.HardCoreMode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._4
{
    class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>, IEnumerable
    {
        public CycledDynamicArray() : base()
        { }
        public CycledDynamicArray(int length) : base(length)
        { }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection)
        { }

        public new IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return arr[i];
                }
            }

        }
    }
}
