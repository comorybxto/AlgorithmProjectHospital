using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital.Structures.BST
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; private set; }
        public BinarySearchTree() { } // O(1)

        private TreeNode<T> FindNode(T data) // O(log n)
        {
            if (Root != null)
            {
                return Root.Find(data);
            }
            return null;
        }

        public bool TryFind(T data, out T found) // O(log n)
        {
            var result = FindNode(data);
            if (result != null) { 
                found = result.Value;
                return true;
            }
            found = default;
            return false;
        }

        public void Insert(T data) // O(log n)
        {
            if (Root != null)
                Root.Insert(data);
            else
                Root = new TreeNode<T>(data);
        }

        public void Remove(T data) // O(log n)
        {
            TreeNode<T> current = Root;
            TreeNode<T> parent = Root;
            bool isLeftChild = false;

            if (current == null)
            {
                return;
            }

            while (current != null && !current.Equals(data))
            {
                parent = current;
                if (data.CompareTo(current.Value) < 0)
                {
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }

            if (current == null)
            {
                return;
            }

            if (current.RightNode == null && current.LeftNode == null)
            {
                if (current == Root)
                {
                    Root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = null;
                    }
                    else
                    {
                        parent.RightNode = null;
                    }
                }
            }
            else if (current.RightNode == null)
            {
                if (current == Root)
                {
                    Root = current.LeftNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.LeftNode == null)
            {
                if (current == Root)
                {
                    Root = current.RightNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else
            {
                TreeNode<T> successor = GetSuccessor(current);
                if (current == Root)
                {
                    Root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftNode = successor;
                }
                else
                {
                    parent.RightNode = successor;
                }

            }

        }

        private TreeNode<T> GetSuccessor(TreeNode<T> node)  // O(log n)
        {
            TreeNode<T> parentOfSuccessor = node;
            TreeNode<T> successor = node;
            TreeNode<T> current = node.RightNode;

            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;
            }

            if (successor != node.RightNode)
            {
                parentOfSuccessor.LeftNode = successor.RightNode;
                successor.RightNode = node.RightNode;
            }
            successor.LeftNode = node.LeftNode;
            return successor;
        }

        // Mark node as deleted
        public void SoftDelete(T data)  // O(log n)
        {
            TreeNode<T> toDelete = FindNode(data);
            if (toDelete != null)
            {
                toDelete.Delete();
            }
        }

    }
}
