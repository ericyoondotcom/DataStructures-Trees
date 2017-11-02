using System;

namespace Trees
{
    class RBValNode<T>
    {

        public RBNode<T> left { get; set; }

        public RBNode<T> right { get; set; }
        public T val { get; set; }
        public RBNode<T> parent { get; set; }
        public Enums.Colors color { get; set; }



        public RBNode(T val, RBNode<T> leftNode = null, RBNode<T> rightNode = null, RBNode<T> parent = null)
        {
            this.val = val;
            left = leftNode;
            right = rightNode;
            this.parent = parent;
        }



        public int Balance
        {
            get
            {
                int leftHeight = 0;
                int rightHeight = 0;
                if (left == null)
                {
                    leftHeight = 0;
                }
                else
                {
                    leftHeight = left.Height;
                }
                if (right == null)
                {
                    rightHeight = 0;
                }
                else
                {
                    rightHeight = right.Height;
                }

                return rightHeight - leftHeight;
            }
        }
        public int Height
        {
            get
            {
                if (left == null && right == null)
                    return 1;

                int leftHeight;
                if (left == null)
                {
                    leftHeight = 0;
                }
                else
                {
                    leftHeight = left.Height;
                }
                int rightHeight;
                if (right == null)
                {
                    rightHeight = 0;
                }
                else
                {
                    rightHeight = right.Height;
                }

                return ((leftHeight < rightHeight) ? rightHeight + 1 : leftHeight + 1);
            }
        }


    }
}
