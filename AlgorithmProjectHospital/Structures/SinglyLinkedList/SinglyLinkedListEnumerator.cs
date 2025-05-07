using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmProjectHospital.Structures
{
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private SingleNode<T> Head;
        private SingleNode<T> _current;

        public SinglyLinkedListEnumerator(SingleNode<T> head) // O(1)
        {
            Head = head;
            _current = null;
        }
        public T Current => _current != null ? _current.Value : throw new InvalidOperationException("Enumerator is before the start or after the end of the collection.");

        object IEnumerator.Current => Current;

        public bool MoveNext() // O(1)
        {
            _current = _current == null ? Head : _current.Next;
            return _current != null;
        }
        public void Dispose() => Head = null; // O(1)

        public void Reset() => _current = null; // O(1)
    }
}