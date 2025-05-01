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

        public Queue()
        {
        }

        public Queue(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.Enqueue(item);
        }
        public void Enqueue(T value)
        {
            var data = new SingleNode<T>(value);
            if (Head == null)
            {
                Head = Tail = data;
            }
            else {
                Tail.Next = data;
                Tail = data;
            }
        }

        public T Dequeue() {
            if (Head == null)
                ErrEmpty();
            T data = Head.Value;
            Head = Head.Next;
            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
                ErrEmpty();
            return Tail.Value;
        }

        public Queue<T> Clone()
        {
            return new Queue<T>(this);
        }

        public void Clear()
        {
            Head = Tail = null;
        }

        public bool IsEmpty() => Head == null;
        private string ErrEmpty() => throw new InvalidOperationException("This queue is empty!");

        public IEnumerator<T> GetEnumerator()
        {
            SingleNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    }
