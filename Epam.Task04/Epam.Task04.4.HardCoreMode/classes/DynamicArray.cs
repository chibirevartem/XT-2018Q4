using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04._4.HardCoreMode
{
    class DynamicArray<T> : IEnumerable<T>, IEnumerable
    {

        internal T[] arr;
        private int position;
        public int Count { get; internal set; }
        public int Capacity { get; internal set; }



        public DynamicArray()
        {
            arr = new T[8];
            Count = 0;
            Capacity = arr.Length;
        }

        public DynamicArray(int length)
        {
            if (length > 0)
            {
                arr = new T[length];
                Count = 0;
                Capacity = length;
            }
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection != null)
            {
                Count = Capacity = collection.Count();
                arr = (T[])collection;
            }
            else
            {
                throw new Exception("Null-argument error");
            }
        }

        public void Add(T new_element)
        {
            if (Count + 1 < Capacity)
            {
                if (Count == 0)
                {
                    arr[0] = new_element;
                }
                else
                {
                    arr[Count] = new_element;
                }

                Count++;
            }

            else
            {
                T[] buffer = new T[2 * Capacity];
                Capacity = 2 * Capacity;
                for (int i = 0; i < Count; i++)
                {
                    buffer[i] = arr[i];
                }
                buffer[Count] = new_element;
                arr = buffer;

                Count++;
            }

        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (Capacity < (Count + collection.Count()))
            {
                Capacity = Count + collection.Count();
                T[] buffer = new T[Capacity];

                for (int i = 0; i < Count; i++)
                {
                    buffer[i] = arr[i];
                }
                for (int i = Count; i < Capacity; i++)
                {
                    buffer[i] = ((T[])collection)[i - Count];
                }

                arr = buffer;
                Count = Capacity;
            }
            else
            {

                T[] buffer = new T[Capacity];


                for (int i = 0; i < Count; i++)
                {
                    buffer[i] = arr[i];
                }
                for (int i = Count; i < Count + collection.Count(); i++)
                {
                    buffer[i] = ((T[])collection)[i - Count];
                }

                arr = buffer;
                Count = Count + collection.Count();
            }


        }

        public bool RemoveAt(int index)
        {
            bool success = false;

            if (index > 0 & index < Count)
            {
                T[] buffer = new T[Capacity];
                for (int i = 0; i < index; i++)
                {
                    buffer[i] = arr[i];
                }
                for (int i = index; i < Count; i++)
                {
                    buffer[i] = arr[i + 1];
                }

                arr = buffer;

                Count--;
                success = true;
            }

            return success;

        }

        public bool Insert(T new_element, int index)
        {
            bool success = false;

            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException($"index:{index}", "Index is out of array's range");
            }

            else if (index == Count & Count < Capacity)
            {
                arr[index] = new_element;
                Count++;
            }

            else if (index == Capacity - 1 & index == Count - 1)
            {
                T[] buffer = new T[Capacity + 1];
                for (int i = 0; i < Count - 1; i++)
                {
                    buffer[i] = arr[i];
                }
                buffer[index] = new_element;
                buffer[index + 1] = arr[index];
                arr = buffer;
                Capacity++;
                Count++;
                success = true;

            }

            else if (index < Count & Count == Capacity)
            {
                T[] buffer = new T[Capacity + 1];
                for (int i = 0; i < index; i++)
                {
                    buffer[i] = arr[i];
                }
                buffer[index] = new_element;
                for (int i = index + 1; i < Count + 1; i++)
                {
                    buffer[i] = arr[i - 1];
                }
                arr = buffer;
                Capacity++;
                Count++;
                success = true;

            }

            else if (index < Count & Count < Capacity)
            {
                T[] buffer = new T[Capacity];
                for (int i = 0; i < index; i++)
                {
                    buffer[i] = arr[i];
                }
                buffer[index] = new_element;
                for (int i = index + 1; i < Count + 1; i++)
                {
                    buffer[i] = arr[i - 1];
                }
                arr = buffer;

                Count++;
                success = true;

            }

            return success;
        }

        private T Current
        {
            get
            {
                if (position == -1 || position >= Count)
                { throw new InvalidOperationException(); }

                else
                { return arr[position]; }
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < Count)
            {
                position++;
                return true;
            }
            else
                Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        public virtual T this[int index]
        {
            get
            {
                if (!IsOutOfRange(index)) return (arr[index]);
                else throw new ArgumentOutOfRangeException("Index is out of range");

            }

            set
            {
                if (!IsOutOfRange(index))
                {
                    arr[index] = value;
                }

            }
        }

        private bool IsOutOfRange(int index)
        {
            bool result = true;
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
