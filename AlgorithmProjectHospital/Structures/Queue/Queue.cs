using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital.Structures
{
    internal class Queue<T> : IEnumerable<T>
    {
        public SingleNode<T> Head { get; set; }
        public SingleNode<T> Tail { get; set; }

        public Queue() // O(1)
        {
        }

        public Queue(IEnumerable<T> collection) // O(n)
        {
            foreach (var item in collection)
                this.Enqueue(item);
        }
        public void Enqueue(T value) // O(1)
        {
            var data = new SingleNode<T>(value);
            if (Head == null)
            {
                Head = Tail = data;
            }
            else
            {
                Tail.Next = data;
                Tail = data;
            }
        }

        public T Dequeue() // O(1)
        {
            if (Head == null)
                ErrEmpty();
            T data = Head.Value;
            Head = Head.Next;
            return data;
        }

        public T Peek() // O(1)
        {
            if (IsEmpty())
                ErrEmpty();
            return Head.Value;
        }

        public Queue<T> Clone() // O(n)
        {
            return new Queue<T>(this);
        }

        public void Clear() // O(1)
        {
            Head = Tail = null;
        }

        public bool IsEmpty() => Head == null; // O(1)
        private string ErrEmpty() => throw new InvalidOperationException("This queue is empty!");

        public IEnumerator<T> GetEnumerator() // O(n)
        {
            SingleNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator(); // O(n)
    }

}
