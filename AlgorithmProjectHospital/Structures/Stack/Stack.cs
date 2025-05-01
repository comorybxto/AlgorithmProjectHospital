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

        public Stack(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.Push(item);
        }

        public void Push(T value)
        {
            var newNode = new SingleNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }
   
        public T Pop() {
            if (IsEmpty())
                ErrEmpty();
            T data = Head.Value;
            Head = Head.Next;
            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
                ErrEmpty();
            return Head.Value;
        }

        public Stack<T> Clone()
        {
            return new Stack<T>(this);
        }

        public bool IsEmpty() => Head == null;

        private string ErrEmpty() => throw new InvalidOperationException("This stack is empty!");

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
