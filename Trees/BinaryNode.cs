using System;
namespace Trees
{
    public class BinaryNode<T>
    {
        /// <summary>
        /// The left node.
        /// </summary>
        public BinaryNode<T> left;
        /// <summary>
        /// The right node.
        /// </summary>
        public BinaryNode<T> right;
        /// <summary>
        /// The value of this node.
        /// </summary>
        public T val;

        /// <summary>
        /// Makes a new node.
        /// </summary>
        /// <param name="val">The value of the new node.</param>
        /// <param name="leftNode">The left of the new node.</param>
        /// <param name="rightNode">The right of the new node.</param>
        public BinaryNode(T val, BinaryNode<T> leftNode = null, BinaryNode<T> rightNode = null)
        {
            this.val = val;
            left = leftNode;
            right = rightNode;
        }
    }
}