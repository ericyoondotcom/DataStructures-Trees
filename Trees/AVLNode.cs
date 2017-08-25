using System;
namespace Trees
{
    public class AVLNode<T>
    {
        public AVLNode<T> left;
        public AVLNode<T> right;
        public T val;
        public AVLNode<T> parent;
        public int height;

        public AVLNode(T val, AVLNode<T> parent, AVLNode<T> leftNode = null, AVLNode<T> rightNode = null)
        {
            this.val = val;
            left = leftNode;
            right = rightNode;
            this.parent = parent;
        }
    }
}
