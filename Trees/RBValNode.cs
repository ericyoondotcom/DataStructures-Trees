using System;

namespace Trees
{
    class RBValNode<T> : RBNode<T>
    {



        public RBValNode(T val, RBNode<T> leftNode = null, RBNode<T> rightNode = null, RBNode<T> parent = null)
        {
            base.val = val;
            left = leftNode;
            if (leftNode == null) left = new RBNullNode<T>();
            right = rightNode;
            if (rightNode == null) right = new RBNullNode<T>();
            this.parent = parent;
        }


    }
}
