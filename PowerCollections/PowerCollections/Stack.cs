using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PowerCollections
{
    public class Stack_new<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        public int Capacity { get; set; }
        public List<T> array;
        public Stack_new(int capacity){
           if(capacity<1)
                throw new StackException("Размер стека не может быть меньше, чем 1");
           Capacity = capacity;
           List<T> Array = new List<T>(capacity);
           array = Array;
        }
        public Stack_new()
        {
            Capacity = 100;
            List<T> Array = new List<T>(100);
            array = Array;
        }
        public void Push(T value)
        {
            //Console.WriteLine("push at " + Count);
            if(Count < array.Capacity) {
                array.Add(value);
                Count++;
            }
            else throw new StackException("Push: Заполнение области стека вне диапазона");
        }
         public T Pop()
        {
            if(Count <= 0 || Count > array.Capacity)
                throw new StackException("Pop: Обращение к области вне диапазона");
            Count--;
            //Console.WriteLine("Pop at " + Count + " result " + array[Count]);
            T current = array[Count];
            //T current = Current;
            array.RemoveAt(Count);
            return current;
        }
         public T Top()
        {
            if (Count <= 0 || Count > array.Capacity)
                throw new StackException("Top: Обращение к области вне диапазона");
            //Console.WriteLine("Top at " + (Count-1) + " result " + array[Count-1]);
            return array[Count - 1];
        }

        private IEnumerator<T> Enumerator()
        {
            for(int i = array.Count-1; i >= 0; i--) yield return array[i];
        }
        public IEnumerator<T> GetEnumerator()
        {
            return Enumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enumerator();
        }
    }
    class StackException : Exception
    {
        public StackException(string message)
            : base(message) { }
    }

}
