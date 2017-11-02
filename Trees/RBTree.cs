using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class RBTree<T> where T : IComparable
    {
        public RBNode<T> topNode;



        public bool IsEmpty
        {
            get
            {
                return topNode == null;
            }
        }

        public RBTree()
        {
            topNode = null;
        }

        public RBTree(T firstNodeVal)
        {
            topNode = new RBNode<T>(firstNodeVal);
        }

        public void Add(T newItem)
        {
            AddWithNode(new RBNode<T>(newItem));

        }
        public void AddWithNode(RBNode<T> newItem)
        {
            if (topNode == null)
            {
                topNode = newItem;
                newItem.left = new RBNode<T>(null, null, null, newItem);
                InsertCheck(newItem);
                return;
            }
            AddLoop(newItem, topNode);
        }
        void AddLoop(RBNode<T> newItem, RBNode<T> curr)
        {
            int comparison = newItem.val.CompareTo(curr.val);

            if (comparison < 0)
            {
                if (curr.left == null)
                {
                    curr.left = newItem;
                    newItem.parent = curr;
                    newItem.color = Colors.red;
                    InsertCheck(newItem);
                    return;
                }
                AddLoop(newItem, curr.left);
            }
            else
            {
                if (curr.right == null)
                {
                    curr.right = newItem;
                    newItem.parent = curr;
                    newItem.color = Colors.red;
                    InsertCheck(newItem);
                    return;
                }
                AddLoop(newItem, curr.right);
            }
        }
        
        void InsertCheck(RBNode<T> me)
        {
            if(me != topNode)
            {

            }
            topNode.color = Colors.black;
        }
    }
}
