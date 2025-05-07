using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital.Structures.BST
{
    internal class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public TreeNode<T> RightNode { get; set; }
        public TreeNode<T> LeftNode { get; set; }
        public bool IsDeleted { get; private set; }

        public TreeNode(T value) // O(1)
        {
            IsDeleted = false;
            this.Value = value;
        }
        public void Delete() => IsDeleted = true; // O(1)

        public TreeNode<T> Find(T value) // O(log n)
        {
            TreeNode<T> currentNode = this;
            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) == 0)
                {
                    if (currentNode.IsDeleted)
                        return null;
                    else
                        return currentNode;
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                    currentNode = currentNode.LeftNode;
            }
            return null;
        }

        public void Insert(T value) // O(log n)
        { 
            TreeNode<T> currentNode = this;
            if (value.CompareTo(currentNode.Value) >= 0)
            {
                if (RightNode == null)
                {
                    RightNode = new TreeNode<T>(value);
                }
                else
                {
                    RightNode.Insert(value);
                }
            }
            else
            {
                if (LeftNode == null)
                {
                    LeftNode = new TreeNode<T>(value);
                }
                else
                {
                    LeftNode.Insert(value);
                }
            }
        }

    }
}
