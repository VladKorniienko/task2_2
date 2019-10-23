using System;
using System.Collections.Generic;

namespace Korniienko_Task4
{
    class CustomList<T> : IEnumerable<T>
    {
        private T[] _contents;
        private int _count = 0;
        private readonly int _firstIndex;
        private const int DefaultCapacity = 4;
        private const int MaxArrayLength = 0X7FEFFFFF;

        public CustomList()
        {
            _firstIndex = 1;
            _contents = new T[DefaultCapacity + _firstIndex];
        }

        public CustomList(int firstIndex)
        {
            _firstIndex = firstIndex;
            _contents = new T[DefaultCapacity + _firstIndex];
        }

        public CustomList(int firstIndex, int size)
        {
            _firstIndex = firstIndex;
            _contents = new T[size];
        }

        public int Count
        {
            get { return _count; }
        }

        public int Capacity

        {
            get
            {
                return _contents.Length;
            }
            set
            {
                if (value == _contents.Length) return;
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    if (Capacity > 0)
                    {
                        Array.Copy(_contents, _firstIndex, newItems, _firstIndex, _count);
                    }
                    _contents = newItems;
                }
                else
                {
                    _contents = null;
                }
            }
        }

        public void Add(T value)
        {

            if (_count == 0)
            {
                _contents[_firstIndex] = value;
                _count++;
            }
            else
            {
                if (_count + _firstIndex == _contents.Length)
                    EnsureCapacity(Capacity + _firstIndex + 1);
                _contents[++_count] = value;
            }

        }

        public void Clear()
        {
            if (_contents.Length > 0)
            {
                Array.Clear(_contents, 0, _contents.Length);
                Capacity = 0;
            }

        }

        public bool Contains(T value)
        {
            if (value == null)
            {
                for (int i = _firstIndex; i <= Count + _firstIndex; i++)
                    if (_contents[i] == null)
                        return true;
                return false;
            }
            else
            {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (int i = _firstIndex; i <= Count + _firstIndex; i++)
                {
                    if (c.Equals(_contents[i], value)) return true;
                }
                return false;
            }
        }

        public int IndexOf(T value)
        {
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            for (int i = _firstIndex; i <= Count + _firstIndex; i++)
            {
                if (c.Equals(_contents[i], value)) return i;
            }
            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if ((index > 0) && (index <= Count + _firstIndex) && (index >= _firstIndex))
            {
                for (int i = index; i <= Count + _firstIndex; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                Capacity--;
            }
        }

        public T this[int index]
        {


            get
            {

                if (index > Capacity || index < _firstIndex)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                    return _contents[index];
            }

            set
            {
                if (index > Capacity || index < _firstIndex)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                    _contents[index] = value;
            }

        }

        public void CopyTo(Array array, int index)
        {
            for (int i = _firstIndex; i <= Count + _firstIndex; i++)
            {
                array.SetValue(_contents[i], index++);
            }
        }

        private void EnsureCapacity(int min)
        {
            if (_contents.Length < min)
            {
                int newCapacity = _contents.Length == 0 ? DefaultCapacity : _contents.Length * 2;

                if ((uint)newCapacity > MaxArrayLength) newCapacity = MaxArrayLength;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var value in _contents)
            {
                yield return value;
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void PrintContents()
        {
            if (_contents != null)
            {
                Console.WriteLine(
                    $"List has a capacity of {_contents.Length},firstIndex is {_firstIndex} and contains {_count} elements.");
                Console.WriteLine("List content");
                for (int i = _firstIndex; i < Count + _firstIndex; i++)
                {
                    Console.WriteLine($"[{i}]:{_contents[i]}");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("List is empty!");
            }
        }

    }
}
