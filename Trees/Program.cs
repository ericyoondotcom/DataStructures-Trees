using System;

/*

*****************
* TO IMPLEMENT! *
*****************

                                        ---
* Rotate Left/Rotate Right                | 
* Rotate Left-Right/Rotate Right-Left      >  Should probably be all in Add()...
* FindBalance                             |
                                        ---    

*/

namespace Trees
{
    class MainClass
    {
		//This is painstakingly coding trees: https://www.youtube.com/watch?v=z1KDRTKpPZw

		public static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            var tree = new AVLTree<int>();
            tree.Add(10);
            tree.Add(8);
            tree.Add(15);
            tree.Add(16);
            tree.Add(13);
            tree.Add(14);
            tree.Add(12);
            Console.WriteLine(tree.Search(15).Balance);
           /* var tree = new BinaryTree<int>();
            tree.Add(256);
            tree.Add(512);
            tree.Add(128);
            tree.Add(64);
            tree.Add(32);
            tree.Add(1024);
            tree.Add(2048);
            tree.Add(16);
            tree.Add(4096);
            tree.Add(8);
            tree.Add(4);
            tree.Add(8192);
            tree.Add(16384);
            tree.Add(2);
            tree.Add(32768);
            tree.Add(1);

//            tree.Add(100);
            Console.WriteLine(tree.FindMin());
            Console.WriteLine(tree.FindMax());
            Console.WriteLine(tree.IsEmpty);
            //tree.TraverseInOrder();
            //tree.TraversePreOrder();*/
           /*var newTree = new BinaryTree<string>();
            newTree.Add("F");
			newTree.Add("G");
            newTree.Add("I");
            newTree.Add("H");
            newTree.Add("B");
            newTree.Add("D");
            newTree.Add("C");
            newTree.Add("E");
            newTree.Add("A");
            newTree.Traverse(BinaryTree<string>.TraverseMethods.postOrder);
            newTree.Delete(newTree.Search("D"));*/
            }
    }
}
