﻿using System;
using System.Collections.Generic;

namespace Trees
{
    public class AVLTree<T> where T : IComparable
    {

        public AVLNode<T> topNode;

        public bool IsEmpty
        {
            get
            {
                return topNode == null;
            }
        }

        public AVLTree()
        {
            topNode = null;
        }


        public AVLTree(T firstNodeVal)
        {

            topNode = new AVLNode<T>(firstNodeVal);

        }

        public void Add(T newItem)
        {
            if (topNode == null)
            {
                topNode = new AVLNode<T>(newItem);
                return;
            }

            AddLoop(new AVLNode<T>(newItem), topNode);
        }

        void AddLoop(AVLNode<T> newItem, AVLNode<T> curr)
        {
            int comparison = newItem.val.CompareTo(curr.val);

            if (comparison < 0)
            {
                //left
                if (curr.left == null)
                {
                    newItem.parent = curr;
                    curr.left = newItem;
                    RotationLoop(curr.left);
                    return;
                }
                AddLoop(newItem, curr.left);


            }
            else
            {
                //right
                if (curr.right == null)
                {
                    newItem.parent = curr;
                    curr.right = newItem;
                    RotationLoop(curr.right);
                    return;
                }
                AddLoop(newItem, curr.right);
            }
        }

        void RotationLoop(AVLNode<T> newItem)
        {
            var me = newItem;
            while(me != null){
                
                if (me.Balance > 1)
                {
                    var child = me.right;
                    
                    if (child.Balance >= 0)      
                    {


                        //left rot!
                        Console.WriteLine("Doing a left rotation!");
                        child.right = me.right?.right;

                        if (me.right.right != null)
                        {
                            me.right.right.parent = child;
                        }

                        me.right = child.left;
                        if (child.left != null)
                        {
                            child.left.parent = me;
                        }

                        if (me.parent == null)
                        {
                            topNode = child;

                        }
                        else
                        {
                            
                            if (me.parent.left == me)
                            {
                                me.parent.left = child;
                            }
                            else if (me.parent.right == me)
                            {
                                me.parent.right = child;
                            }
                            else
                            {
                                throw new Exception("Luke... I'm... Not... Your... Father!");
                            }
                        }
                        child.parent = me.parent;

                        child.left = me;
                        me.parent = child;

                    }
                    else
                    {
                        //left right rot!
                        Console.WriteLine("Doing a left right rot!");
                        var grandchild = child.left;
						var greatchildright = grandchild.right;
						grandchild.right = child;
                        child.parent = grandchild;
                        child.left = greatchildright;
                        if(greatchildright != null)
                        greatchildright.parent = child;
						child = grandchild;
						me.right = child;
                        child.parent = me;

						//now rotate left

						child.right = me.right?.right;
                        if(me.right.right != null)
                        me.right.right.parent = child;

                        me.right = child.left;
                        if (child.left != null)
                        child.left.parent = me;

						if (me.parent == null)
						{
							topNode = child;
						}
						else
						{
							
							if (me.parent.left == me)
							{
								me.parent.left = child;
							}
							else if (me.parent.right == me)
							{
								me.parent.right = child;
							}
							else
							{
								throw new Exception("Luke... I'm... Not... Your... Father!");
							}
						}
                        child.parent = me.parent;
						child.left = me;
                        me.parent = child;
					}
                  


                }
                if (me.Balance < -1)
                {


                    var child = me.left; 


                    if (child.Balance <= 0) {
                        //right rot!
                        Console.WriteLine("Doing a right rotation!");
                       
                        child.left = me.left?.left;
                        if (me.left.left != null){
                            me.left.left.parent = child; 
                        }
                        me.left = child.right;
                        if(child.right != null)
                        child.right.parent = me;


                        if (me.parent == null)
                        {
                            topNode = child;
                        }
                        else
                        {
                            
                            if (me.parent.left == me)
                            {
                                me.parent.left = child;
                            }
                            else if (me.parent.right == me)
                            {
                                me.parent.right = child;
                            }
                            else
                            {
                                throw new Exception("Luke... I'm... Not... Your... Father!");
                            }
                        }
                        child.parent = me.parent;
                        child.right = me;
                        me.parent = child;
                    }
                    else
                    {
                        //right left rot!
                        Console.WriteLine("Doing a right left rot!");

						var grandchild = child.right;
						var greatchildleft = grandchild.left;
						grandchild.left = child;
                        child.parent = grandchild;
                        child.right = greatchildleft;
                        if(greatchildleft != null)
                        greatchildleft.parent = child;
						child = grandchild;

                        me.left = child;
                        child.parent = me;

						//now rotate right
						child.left = me.left?.left;
						if (me.left.left != null)
						{
							me.left.left.parent = child;
						}
						me.left = child.right;
                        if(child.right != null)
						child.right.parent = me;

						if (me.parent == null)
						{
							topNode = child;
						}
						else
						{
							
							if (me.parent.left == me)
							{
								me.parent.left = child;
							}
							else if (me.parent.right == me)
							{
								me.parent.right = child;
							}
							else
							{
								throw new Exception("Luke... I'm... Not... Your... Father!");
							}
						}
                        child.parent = me.parent;
						child.right = me;
                        me.parent = child;


					}
                }
                me = me.parent;
            }
        }
        public T FindMin()
        {
            return FindMinLoop(topNode);
        }

        T FindMinLoop(AVLNode<T> curr)
        {
            if (curr.left == null)
            {
                return curr.val;
            }
            return FindMinLoop(curr.left);

        }

        AVLNode<T> FindMinNodeLoop(AVLNode<T> curr)
        {
            if (curr.left == null)
            {
                return curr;
            }
            return FindMinNodeLoop(curr.left);

        }

        public T FindMax()
        {
            return FindMaxLoop(topNode);
        }

        T FindMaxLoop(AVLNode<T> curr)
        {
            if (curr.right == null)
            {
                return curr.val;
            }
            return FindMaxLoop(curr.right);

        }


        public enum TraverseMethods
        {
            inOrder,
            preOrder,
            postOrder
        }

        public void Traverse(TraverseMethods method)
        {
            Console.Write("Traversing tree " + method.ToString() + ": ");
            if (topNode == null) return;
            TraverseLoop(topNode, method);
            Console.Write("\n");
        }

        void TraverseLoop(AVLNode<T> current, TraverseMethods method)
        {

            if (method == TraverseMethods.preOrder)
                Console.Write(current.val + ", ");

            if (current.left != null)
                TraverseLoop(current.left, method);

            if (method == TraverseMethods.inOrder)
                Console.Write(current.val + ", ");

            if (current.right != null)
                TraverseLoop(current.right, method);

            if (method == TraverseMethods.postOrder)
                Console.Write(current.val + ", ");

        }


        public AVLNode<T> Search(T val)
        {
            if (topNode == null)
            {
                return null;
            }
            return SearchLoop(val, topNode);

        }


        AVLNode<T> SearchLoop(T val, AVLNode<T> curr)
        {

            int comparison = curr.val.CompareTo(val);
            if (comparison == 0)
            {
                return curr;
            }
            if (comparison > 0)
            {
                if (curr.left == null)
                    return null;
                return SearchLoop(val, curr.left);
            }
            if (comparison < 0)
            {
                if (curr.right == null)
                    return null;
                return SearchLoop(val, curr.right);
            }

            throw new Exception("Something went really wrong!");
        }



        public AVLNode<T> SearchIterative(T valToFind)
        {
            AVLNode<T> current = topNode;
            while (true)
            {
                int comparison = current.val.CompareTo(valToFind);
                if (comparison == 0)
                {
                    return current;
                }
                if (comparison > 0)
                {
                    if (current.left == null)
                        return null;

                    current = current.left;
                    continue;
                }
                if (comparison < 0)
                {
                    if (current.right == null)
                        return null;

                    current = current.right;
                    continue;
                }

                throw new Exception("Something went really wrong!");
            }
        }


        public void Delete(AVLNode<T> node)
        {
            if (topNode == null)
                return;

            if (node == topNode)
            {
                if (topNode.left == null && topNode.right == null)
                {
                    topNode = null;
                    return;
                }
                if (topNode.left == null)
                {
                    topNode = topNode.right;
                    topNode.parent = null;
                    return;
                }
                if (topNode.right == null)
                {
                    topNode = topNode.left;
                    topNode.parent = null;
                    return;
                }
                topNode.val = DeleteFindLargestLeft(topNode.left);
            }
            DeleteTraversal(node, topNode);
        }


        void DeleteTraversal(AVLNode<T> node, AVLNode<T> curr)
        {

            if (curr.left != null)
                DeleteTraversal(node, curr.left);

            if (node == curr.left)
            {
                DeleteCases(curr.left, curr, false);
                Console.WriteLine("Found the node!");
                return;
            }
            if (node == curr.right)
            {
                DeleteCases(curr.right, curr, true);
                Console.WriteLine("Found the node!");
                return;
            }

            if (curr.right != null)
                DeleteTraversal(node, curr.right);


        }

        void DeleteCases(AVLNode<T> node, AVLNode<T> parent, bool right)
        {
            if (node.left == null && node.right == null)
            {
                if (right)
                {
                    parent.right = null;
                }
                else
                {
                    parent.left = null;
                }
                return;
            }
            if (node.left == null)
            {
                if (right)
                {
                    parent.right = node.right;
                    node.right.parent = parent;
                }
                else
                {
                    parent.left = node.right;
                    node.right.parent = parent;
                }
                return;
            }
            if (node.right == null)
            {
                if (right)
                {
                    parent.right = node.left;
                    node.left.parent = parent;
                }
                else
                {
                    parent.left = node.left;
                    node.left.parent = parent;
                }
                return;
            }
            node.val = DeleteFindLargestLeft(node.left);
        }


        T DeleteFindLargestLeft(AVLNode<T> curr)
        {
            if (curr.right == null)
            {
                T val = curr.val;
                Delete(curr);
                return val;
            }
            else
            {
                return DeleteFindLargestLeft(curr.right);
            }
        }

    }
}
