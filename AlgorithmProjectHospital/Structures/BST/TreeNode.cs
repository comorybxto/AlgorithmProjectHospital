using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProjectHospital.Structures.BST
{
    internal class TreeNode<T> where T : IComparable<T>
    {
        public T Value;

        public TreeNode<T> RightNode;
        public TreeNode<T> LeftNode;
        public bool IsDeleted;

        public TreeNode(T value){
            IsDeleted = false;
            this.Value = value;
        }
        public void Delete()
        {
            IsDeleted = true;
        }

        public TreeNode<T> Find(T value) {
            TreeNode<T> currentNode = this;
            while (currentNode != null) {
                if (value.CompareTo(currentNode.Value)==0 && IsDeleted == false)
                {
                    return currentNode;
                }
                else if (value.CompareTo(currentNode.Value) > 0 )
                {
                    currentNode = currentNode.RightNode;
                }
                else
                    currentNode = currentNode.LeftNode;
            }
            return null;
            //throw new InvalidOperationException("A node does not exist here.");
        }

        public void Insert(T value) {
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
