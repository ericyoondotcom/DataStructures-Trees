using System;

namespace Trees
{
    class MainClass
    {
		//This is making red-black trees: https://www.youtube.com/watch?v=z1KDRTKpPZw

		public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var tree = new BinaryTree<int>();
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
            tree.Add(100);
        }
    }
}
