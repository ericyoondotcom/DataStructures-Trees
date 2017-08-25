using System;
using System.Collections.Generic;
namespace Trees
{
    /// <summary>
    /// Your good ol' Binary Search Tree!
    /// </summary>
    public class BinaryTree<T> where T : IComparable
    {
        /// <summary>
        /// The first node in the tree.
        /// </summary>
        public BinaryNode<T> topNode;

        /// <summary>
        /// Checks whether the tree is empty.
        /// </summary>
        /// <value><c>true</c> if is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty {
            get {
                return topNode == null;
            }
        }

        /// <summary>
        /// Creates a new, empty <see cref="T:Trees.BinaryTree"/> class. Like a sapling!
        /// </summary>
        public BinaryTree()
        {
            topNode = null;
        }

        /// <summary>
        /// Creates a new <see cref="T:Trees.BinaryTree"/> class with the first nodze. Like a sapling!
        /// </summary>
        /// <param name="firstNodeVal">Top/first node value.</param>
        public BinaryTree(T firstNodeVal)
        {

            topNode = new BinaryNode<T>(firstNodeVal);

        }

        /// <summary>
        /// Add a new node, automatically finding where it should go with its CompareTo function.
        /// </summary>
        /// <param name="newItem">Value of the new node.</param>
        public void Add(T newItem)
        {
            if (topNode == null)
            {
                topNode = new BinaryNode<T>(newItem);
                return;
            }

            AddLoop(new BinaryNode<T>(newItem), topNode);
        }

        /// <summary>
        /// Helper to Add function. Recursive.
        /// </summary>
        /// <param name="newItem">New node.</param>
        /// <param name="curr">Current node, used for recursion.</param>
        void AddLoop(BinaryNode<T> newItem, BinaryNode<T> curr)
        {
            int comparison = newItem.val.CompareTo(curr.val);

            if (comparison < 0)
            {
                //left
                if (curr.left == null)
                {
                    curr.left = newItem;
                    return;
                }
                AddLoop(newItem, curr.left);
            }
            else
            {
                //right
                if (curr.right == null)
                {
                    curr.right = newItem;
                    return;
                }
                AddLoop(newItem, curr.right);
            }
        }

        /// <summary>
        /// Finds the node with the minimum value.
        /// </summary>
        /// <returns>The value of the minimum node.</returns>
        public T FindMin()
        {
            return FindMinLoop(topNode);
        }
        /// <summary>
        /// Helper function to FindMin(). Recursive.
        /// </summary>
        /// <returns>Value of the minimum node</returns>
        /// <param name="curr">Current node, used for recursion.</param>
        T FindMinLoop(BinaryNode<T> curr)
        {
            if (curr.left == null)
            {
                return curr.val;
            }
            return FindMinLoop(curr.left);

        }

        /// <summary>
        /// Finds the minimum node.
        /// </summary>
        /// <returns>The minimum node.</returns>
        /// <param name="curr">The current node. If calling, this is usually topNode</param>
        BinaryNode<T> FindMinNodeLoop(BinaryNode<T> curr)
		{
			if (curr.left == null)
			{
				return curr;
			}
			return FindMinNodeLoop(curr.left);

		}

        /// <summary>
        /// Find the node with the maximum value.
        /// </summary>
        /// <returns>The value of the maximum node.</returns>
        public T FindMax()
        {
            return FindMaxLoop(topNode);
        }
        /// <summary>
        /// Helper function to FindMax(). Recursive.
        /// </summary>
        /// <returns>The value of the maximum node.</returns>
        /// <param name="curr">The current node, used for recursion</param>
        T FindMaxLoop(BinaryNode<T> curr)
        {
            if (curr.right == null)
            {
                return curr.val;
            }
            return FindMaxLoop(curr.right);

        }
        /// <summary>
        /// Traverses the tree in order. Logs the output to console.
        /// </summary>
        [Obsolete("Please use Traverse(TraverseMethods.inOrder) instead.")]
        public void TraverseInOrder(){
            Console.Write("In-Order: ");
            if (topNode == null)
                return;


            TraverseInOrderLoop(topNode);
            Console.Write("\n");
        }

        /// <summary>
        /// Helper function to TraverseInOrder. Recursive.
        /// </summary>
        /// <param name="current">The current node</param>
        void TraverseInOrderLoop(BinaryNode<T> current){
            if (current.left != null)
                TraverseInOrderLoop(current.left);

            Console.Write(current.val + ", ");

            if (current.right != null)
                TraverseInOrderLoop(current.right);
        }


        /// <summary>
        /// Traverses the tree pre-order. Logs the output to console.
        /// </summary>
        [Obsolete("Please use Traverse(TraverseMethods.preOrder) instead.")]
        public void TraversePreOrder(){
            Console.Write("Pre-Order: ");
            if (topNode == null) return;
            TraversePreOrderLoop(topNode);
            Console.Write("\n");
        }

        /// <summary>
        /// Helper function to TraversePreOrder. Recursive.
        /// </summary>
        /// <param name="curr">The current node.</param>
        void TraversePreOrderLoop(BinaryNode<T> curr){
            Console.Write(curr.val + ", ");
            if (curr.left != null)
                TraversePreOrderLoop(curr.left);
            if (curr.right != null)
                TraversePreOrderLoop(curr.right);
        }

        /// <summary>
        /// Traversal methods.
        /// </summary>
        public enum TraverseMethods {
            inOrder,
            preOrder,
            postOrder
        }

        /// <summary>
        /// Traverse the tree.
        /// </summary>
        /// <param name="method">The method for the traversal.</param>
        public void Traverse(TraverseMethods method){
            Console.Write("Traversing tree " + method.ToString() + ": ");
            if (topNode == null) return;
            TraverseLoop(topNode, method);
            Console.Write("\n");
        }
        /// <summary>
        /// Helper function to Traverse. Recursive.
        /// </summary>
        /// <param name="current">The current node.</param>
        /// <param name="method">The traversal method.</param>
        void TraverseLoop(BinaryNode<T> current, TraverseMethods method){
            //Sorry, the writer of this function is allergic to curly braces!!
            if (method == TraverseMethods.preOrder)
                Console.Write(current.val + ", ");

			if (current.left != null)
                TraverseLoop(current.left, method);

            if(method == TraverseMethods.inOrder)
                Console.Write(current.val + ", ");

			if (current.right != null)
                TraverseLoop(current.right, method);

            if (method == TraverseMethods.postOrder)
				Console.Write(current.val + ", ");

		}

        /// <summary>
        /// Search for the specified value, and get the topmost node with the value.
        /// </summary>
        /// <returns>The topmost node with the value.</returns>
        /// <param name="val">The value to search for.</param>
        public BinaryNode<T> Search(T val){
            if(topNode == null){
                return null;
            }
            return SearchLoop(val, topNode);

        }

        /// <summary>
        /// Helper function to Search. Recursive.
        /// </summary>
        /// <returns>The node with the val.</returns>
        /// <param name="val">The value to search for.</param>
        /// <param name="curr">The current node being searched.</param>
        BinaryNode<T> SearchLoop(T val, BinaryNode<T> curr){

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

        /// <summary>
        /// Searches for the specified value, and returns the topmost node.
        /// </summary>
        /// <returns>The topmost node with the specified value.</returns>
        /// <param name="valToFind">The value to find.</param>
        // This is literally copypasta from my recursive search, with some minor changes...
        public BinaryNode<T> SearchIterative(T valToFind){
            BinaryNode<T> current = topNode;
            while(true){
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
                    continue; //this is a result of literally copying my code from recursive find... I was too lazy to put in else's
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

        /// <summary>
        /// Delete the specified node.
        /// </summary>
        /// <param name="node">The node to be deleted.</param>
        public void Delete(BinaryNode<T> node){
            if (topNode == null)
                return;

            if(node == topNode){
                if (topNode.left == null && topNode.right == null)
                {
                    topNode = null;
                    return;
                }
                if(topNode.left == null){
                    topNode = topNode.right;
                    return;
                }
                if(topNode.right == null){
                    topNode = topNode.left;
                    return;
                }
                topNode.val = DeleteFindLargestLeft(topNode.left);
            }
            DeleteTraversal(node, topNode);
        }

        /// <summary>
        /// Helper function to Delete, traverses in order then calls DeleteCases.
        /// </summary>
        /// <param name="node">The node to be deleted.</param>
        /// <param name="curr">The current node.</param>
        void DeleteTraversal(BinaryNode<T> node, BinaryNode<T> curr){

			if (curr.left != null)
                DeleteTraversal(node, curr.left);

            if (node == curr.left){
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

        /// <summary>
        /// Calculates how to delete the node. Helper to Delete.
        /// </summary>
        /// <param name="node">The node to be deleted.</param>
        /// <param name="parent">The parent of the node to be deleted.</param>
        /// <param name="right">The direction of the link from the parent to this node. If <c>true</c>, right, else if <c>false</c>, left.</param>
        void DeleteCases(BinaryNode<T> node, BinaryNode<T> parent, bool right){ 
            if(node.left == null && node.right == null){
                if(right){
                    parent.right = null;
                }else{
                    parent.left = null;
                }
                return;
            }
            if (node.left == null){
                if(right){
                    parent.right = node.right;
                }
                else{
                    parent.left = node.right;
                }
                return;
            }
			if (node.right == null)
			{
				if (right)
				{
                    parent.right = node.left;
				}
				else
				{
                    parent.left = node.left;
				}
                return;
			}
            node.val = DeleteFindLargestLeft(node.left);
        }


        /// <summary>
        /// Only called from DeleteCases, when the node has both left and right children. Finds the largest node, deletes it, and returns it's value.
        /// </summary>
        /// <returns>The value of the largest node.</returns>
        /// <param name="curr">The current node.</param>
        T DeleteFindLargestLeft(BinaryNode<T> curr){
            if(curr.right == null){
                T val = curr.val;
                Delete(curr);
                return val;
            }
            else{
                return DeleteFindLargestLeft(curr.right);
            }
        }
        
    }
}