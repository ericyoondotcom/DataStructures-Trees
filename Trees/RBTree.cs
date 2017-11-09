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
            topNode = new RBValNode<T>(firstNodeVal);
        }

        public void Add(T newItem)
        {
            AddWithNode(new RBValNode<T>(newItem));

        }
        public void AddWithNode(RBValNode<T> newItem)
        {
            if (topNode == null)
            {
                topNode = newItem;
                newItem.left = new RBNullNode<T>();
                InsertCheck(newItem);
                return;
            }
            AddLoop(newItem, topNode);
        }
        void AddLoop(RBValNode<T> newItem, RBNode<T> curr)
        {
            int comparison = newItem.val.CompareTo(curr.val);

            if (comparison < 0)
            {
                if (curr.left.val == null)
                {
                    curr.left = newItem;
                    newItem.parent = curr;
                    newItem.color = Enums.Colors.red;
                    InsertCheck(newItem);
                    return;
                }
                AddLoop(newItem, curr.left);
            }
            else
            {
                if (curr.right.val == null)
                {
                    curr.right = newItem;
                    newItem.parent = curr;
                    newItem.color = Enums.Colors.red;
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
                RBNode<T> uncle = (me.parent.parent.left == me.parent) ? me.parent.parent.right : me.parent.parent.left;

                if(uncle.color == Enums.Colors.red){
                    me.parent.color = Enums.Colors.black;
                    uncle.color = Enums.Colors.black;
                    me.parent.parent.color = Enums.Colors.red;
                    InsertCheck(me.parent.parent);
                }else{
                    
                }
            }
            topNode.color = Enums.Colors.black;
        }
    }
}
