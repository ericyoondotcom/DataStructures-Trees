using System;

namespace Trees
{
    class RBValNode<T> : RBNode<T>
    {

        public RBNode<T> left { get; set; }

        public RBNode<T> right { get; set; }
        public T val { get; set; }
        public RBNode<T> parent { get; set; }
        public Enums.Colors color { get; set; }



        public RBValNode(T val, RBNode<T> leftNode = null, RBNode<T> rightNode = null, RBNode<T> parent = null)
        {
            this.val = val;
            left = leftNode;
            if (leftNode == null) left = new RBNullNode<T>();
            right = rightNode;
            if (rightNode == null) right = new RBNullNode<T>();
            this.parent = parent;
        }


    }
}
