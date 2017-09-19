using System;
namespace Trees
{
    public class AVLNode<T>
    {
        public AVLNode<T> left;
        public AVLNode<T> right;
        public T val;

        public int Balance{
            get{
                int leftHeight = 0;
                int rightHeight = 0;
                if (left == null){
                    leftHeight = 0;
                }else{
                    leftHeight = left.Height;
                }
                if(right == null){
                    rightHeight = 0;
                }else{
                    rightHeight = right.Height;
                }

                return rightHeight - leftHeight;
            }
        }
        public int Height{
            get{
                if (left == null && right == null)
                    return 1;
                
				int leftHeight;
                if (left == null)
				{
					leftHeight = 0;
                }else{
                    leftHeight = left.Height;
                }
                int rightHeight;
                if(right == null){
                    rightHeight = 0;
                }else{
                    rightHeight = right.Height;
                }

                return ((leftHeight < rightHeight) ? rightHeight + 1 : leftHeight + 1);
            }
        }
        public AVLNode(T val, AVLNode<T> leftNode = null, AVLNode<T> rightNode = null)
        {
            this.val = val;
            left = leftNode;
            right = rightNode;
        }
    }
}
