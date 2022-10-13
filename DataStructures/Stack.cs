﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataStructures
{
    public class Stack<T> : IEnumerable<T>, IEnumerable
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] items;


        public Stack()
        {
            items = new T[INITIAL_CAPACITY];
        }



        public Stack(int capacity)
        {
            items = new T[capacity];
        }

        public Stack(IEnumerable<T> collection)
        {
            //TODO: check if given to reference
            items = collection.ToArray();
        }



        public T this[int i] => items[i];
        public int  Length => items.Length;



        public int Count { get; private set; }


        public void Push(T element)
        {
            if (items.Length == Count)
            {
                Grow();
            }
            items[Count++] = element;
        }

        public T Peek() => items[Count - 1];

        public bool Contains(T element) => items.Contains(element);

        public void Clear()
        {
            items = new T[INITIAL_CAPACITY];
        }

        public T[] ToArray()
        {
            T[] array = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                array[i] = items[i];
            }
            return array;
        }
        public T Pop()
        {

            T element = items[Count - 1];
            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }
            return element;
        }

        public void TrimExcess()
        {
            int num = (int)(items.Length * 0.9);
            if (Count >= num)
            {
                return;
            }
            else
            {

                T[] copyItems = new T[num];
                for (int i = 0; i < Count; i++)
                {
                    copyItems[i] = items[i];
                }

                items = copyItems;
            }
        }
        private void Shrink()
        {
            T[] copyItems = new T[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copyItems[i] = items[i];
            }
            items = copyItems;
        }

        private void Grow()
        {
            T[] copyItems = new T[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                copyItems[i] = items[i];
            }
            items = copyItems;
            //second way
            //Array.Copy(items, copyItems, items.Length*2);
            //items=copyItems;
        }

        public IEnumerator<T> GetEnumerator()
        {

            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
