﻿using System;

/*

*****************
* TO IMPLEMENT! *
*****************
*Done :)
*
*/

namespace Trees
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            RBTree<int> tree = new RBTree<int>();

            tree.Add(6);
            tree.Add(9);
            tree.Add(2);
            tree.Add(8);
            tree.Add(4);
            tree.Add(3);
            tree.Add(3);


        }
    }
}
