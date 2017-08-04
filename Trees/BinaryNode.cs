using System;
namespace Trees
{
    public class BinaryNode<T>
    {
        public BinaryNode<T> left;
        public BinaryNode<T> right;
        public T val;

        public BinaryNode(T val, BinaryNode<T> leftNode = null, BinaryNode<T> rightNode = null)
        {
            this.val = val;
            left = leftNode;
            right = rightNode;
        }
    }
}