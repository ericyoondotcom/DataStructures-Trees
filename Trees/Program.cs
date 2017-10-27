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
		//This is painstakingly coding trees: https://www.youtube.com/watch?v=z1KDRTKpPZw

		public static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            var tree = new AVLTree<int>();
            /* tree.Add(10);
             tree.Add(8);
             tree.Add(15);
             tree.Add(16);
             tree.Add(13);
             tree.Add(14);
             tree.Add(12);
             *//*
            tree.Add(10);
            tree.Add(7);
            tree.Add(8);
            tree.Add(6);
            tree.Add(5);
            tree.Add(4);*/
            /*tree.Add(10);
            tree.Add(1);
            tree.Add(13);*/
            /*tree.Add(14);
            tree.Add(16);
            tree.Add(15);*/

            Random randy = new Random();
            Console.WriteLine("Running the AlexTester machine!");
            for (int i = 0; i < 15; i++){
                var rando = randy.Next(0, 20);
                Console.WriteLine(rando);
                tree.Add(rando);
            }
        }
    }
}
