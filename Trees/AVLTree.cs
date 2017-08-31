using System;
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
					return;
				}
				if (topNode.right == null)
				{
					topNode = topNode.left;
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
				}
				else
				{
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
