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
                if (curr.left is RBNullNode<T>)
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
                
                if (curr.right is RBNullNode<T>)
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

            if(me != topNode && me.parent.color != Enums.Colors.black) //If x is root, change color to BLACK
            {
                //Do the following if x's parent is not Black AND x is not root

                RBNode<T> uncle = (me.parent.parent.left == me.parent) ? me.parent.parent.right : me.parent.parent.left;

                if(uncle.color == Enums.Colors.red){ //if x's uncle is red
                    me.parent.color = Enums.Colors.black; //change color of parent to black
                    uncle.color = Enums.Colors.black; //change color of uncle to black
                    me.parent.parent.color = Enums.Colors.red; //make grandparent red
                    InsertCheck(me.parent.parent); //rule check my grandparent
                }else{ //if x's uncle is black (OR NULLNODE: Nullnodes are black!)
                    if (me.parent.right == me){ //if i'm a right child
						if (me.parent.parent.right == me.parent)
						{
							//right-right case
							RotateNodeLeft(me.parent.parent); //rotate grandparent left
                            //and swap grandparent and parent colors
							var swapColor = me.parent.color;
							me.parent.color = me.parent.parent.color;
							me.parent.parent.color = swapColor;

						}
						else if (me.parent.parent.left == me.parent)
						{
                            //left-right case
                            RotateNodeLeft(me.parent); //rotate parent left
							if (me.parent.parent.left == me.parent) //and check left-left case
							{
								//left-left case
								RotateNodeRight(me.parent.parent); //rotate grandparent right
								//and swap grandparent and parent colors
								var swapColor = me.parent.color;
								me.parent.color = me.parent.parent.color;
								me.parent.parent.color = swapColor;
							}

						}
						else
						{
							throw new Exception("AAH! My grandparent disowned my parent!");
						}
                    }else if (me.parent.left == me){ //if i'm a left child
						if (me.parent.parent.right == me.parent)
						{
                            //right-left case
                            RotateNodeRight(me.parent);
							if (me.parent.parent.right == me.parent)
							{
								//right-right case
								RotateNodeLeft(me.parent.parent); //rotate grandparent left
								//and swap grandparent and parent colors
								var swapColor = me.parent.color;
								me.parent.color = me.parent.parent.color;
								me.parent.parent.color = swapColor;

							}

						}
						else if (me.parent.parent.left == me.parent)
						{
                            //left-left case
                            RotateNodeRight(me.parent.parent); //rotate grandparent right
                            //and swap grandparent and parent colors
                            var swapColor = me.parent.color;
                            me.parent.color = me.parent.parent.color;
                            me.parent.parent.color = swapColor;
						}
						else
						{
							throw new Exception("AAH! My grandparent disowned my parent!");
						}
                    }else{
                        throw new Exception("AAH! The parents disowned the added node!");
                    }
                }
            }
            topNode.color = Enums.Colors.black;
        }



        void RotateNodeLeft(RBNode<T> node){
			Console.WriteLine("Doing a left rotation!");

            node.right.left = node;
            if (node.parent != null)
            {
                node.right.parent = node.parent;

                if(node.parent.left == node){
                    node.parent.left = node.right;
                }else if(node.parent.right == node){
                    node.parent.right = node.right;
                }else{
                    throw new Exception("I'm not your parent");
                }
            }else{
                topNode = node.right;
            }
            node.parent = node.right;

        }

        void RotateNodeRight(RBNode<T> node){
			Console.WriteLine("Doing a right rotation!");

            node.left.right = node;
			if (node.parent != null)
			{
                node.left.parent = node.parent;

				if (node.parent.left == node)
				{
                    node.parent.left = node.left;
				}
				else if (node.parent.right == node)
				{
                    node.parent.right = node.left;
				}
				else
				{
					throw new Exception("I'm not your parent");
				}
			}
			else
			{
                topNode = node.left;
			}
            node.parent = node.left;

		}



    }
}
