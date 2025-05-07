using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital.Structures
{
    public class Stack<T> : IEnumerable<T>
    {
        public SingleNode<T> Head = null;

        public Stack()
        {
        }

        public Stack(IEnumerable<T> collection) // O(n)
        {
            foreach (var item in collection)
                this.Push(item);
        }

        public void Push(T value)  // O(1)
        {
            var newNode = new SingleNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }
   
        public T Pop() // O(1)
        {
            if (IsEmpty())
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

        public Stack<T> Clone() => new Stack<T>(this); // O(n)

        public bool IsEmpty() => Head == null; // O(1)

        private string ErrEmpty() => throw new InvalidOperationException("This stack is empty!"); // O(1)

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
