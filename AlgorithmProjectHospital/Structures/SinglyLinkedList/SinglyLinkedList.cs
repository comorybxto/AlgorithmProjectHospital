using AlgorithmProjectHospital.Structures.BST;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorithmProjectHospital.Structures
{
    internal class SinglyLinkedList<T> : IEnumerable<T> where T : Patient
    {
        public SingleNode<T> Head { get; set; }

        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.AddLast(item);
        }

        private bool isHeadNull => Head == null;

        public void AddFirst(T value)
        {
            var newNode=new SingleNode<T>(value);
            newNode.Next=Head;
            Head = newNode;
        }

        public void AddFirst(SingleNode<T> newNode)
        {
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new SingleNode<T>(value);

            if(isHeadNull)
            {
                Head = newNode;
                return;
            }

            var current = Head;
            while(current.Next!=null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void AddAfter(SingleNode<T> node, T value)
        {

            if (node == null)
                throw new ArgumentNullException();
            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SingleNode<T>(value);
            var current = Head;
            while(current!=null) 
            {
                if(current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            ErrEmpty();
        }

        public void AddBefore(SingleNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
            if (isHeadNull || Head.Equals(node))
            {
                AddFirst(value);
                return;
            }

            var newNode = new SingleNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Next.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            ErrEmpty();
        }


        public void AddAfter(SingleNode<T> refNode, 
            SingleNode<T> newNode)
        {

            if (refNode == null || newNode == null)
                throw new ArgumentNullException();
            
            if (isHeadNull)
            {
                AddFirst(newNode);
                return;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            ErrEmpty();
        }

        public void AddBefore(SingleNode<T> refNode, SingleNode<T> newNode)
        {
            if (refNode == null || newNode == null)
                throw new ArgumentNullException();

            if (isHeadNull || Head.Equals(refNode))
            {
                AddFirst(newNode);
                return;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Next.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            ErrEmpty();
        }

        public bool RemoveByID(string id)
        {
            if (Head == null || id == null)
                return false;

            // Head is to be deleted
            if (Head.Value.IDno == id)
            {
                Head = Head.Next;
                return true;
            }

            // Traverse to find the node before the match
            var current = Head;
            while (current.Next != null)
            {
                if (current.Next.Value.IDno == id)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            Head = null;
        }

        private string ErrEmpty() => throw new InvalidOperationException("A node does not exist here.");

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
