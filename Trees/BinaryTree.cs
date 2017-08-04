﻿using System;
namespace Trees
{
    public class BinaryTree<T> where T : IComparable 
    {
        public BinaryNode<T> topNode;

		public BinaryTree()
		{
            topNode = null;
		}

        public BinaryTree(T firstNodeVal)
        {
            
            topNode = new BinaryNode<T>(firstNodeVal);

        }

        public void Add(T newItem)
        {
            if(topNode == null){
                topNode = new BinaryNode<T>(newItem);
                return;
            }
                
            AddLoop(new BinaryNode<T>(newItem), topNode);
        }
        void AddLoop(BinaryNode<T> newItem, BinaryNode<T> curr){
            int comparison = newItem.val.CompareTo(curr.val);

            if(comparison < 0){
                //left
                if (curr.left == null){
                    curr.left = newItem;
                    return;
                }
                AddLoop(newItem, curr.left);
            }else{
				//right
				if (curr.right == null)
				{
					curr.right = newItem;
					return;
				}
				AddLoop(newItem, curr.right);
            }
        }


    }
}