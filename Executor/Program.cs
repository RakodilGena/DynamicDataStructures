﻿using DynamicDataStructuresLib.LinkedLists;

namespace Executor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dynamic Data Structures!\r\n\r\n");

            Console.WriteLine("Test of Single Linked List\r\n");
            var singleList = new SingleLinkedList<int>();
            LinkedListExecution(singleList);
        }


        private static void LinkedListExecution(ILinkedList<int> linkedList)
        {
            linkedList.Print();

            var newRange = new[] { 1, 2, 3, 4 };
            linkedList.AddRange(newRange);
            linkedList.Print();

            linkedList.RemoveAt(2);
            linkedList.Print();

            Console.WriteLine($"Elements[2] is {linkedList.GetElement(2)}\r\n");
            linkedList[2] = -80;
            Console.WriteLine($"Elements[2] is {linkedList.GetElement(2)}\r\n");

            linkedList = new SingleLinkedList<int>(5, 6, 7, 8);
            linkedList.Print();

            linkedList.AddFirst(1);
            linkedList.Print();

            linkedList.AddLast(20);
            linkedList.Print();

            linkedList.Insert(3, -55);
            linkedList.Print();

            linkedList.RemoveAt(2);
            linkedList.Print();

            linkedList.RemoveAt(2);
            linkedList.Print();

            Console.WriteLine("First = " + linkedList.GetFirst());
            Console.WriteLine("Last = " + linkedList.GetLast() + "\r\n");

            linkedList.AddRange(new[] { -56, 4, 45, 5243, 1312, 23, 23, 4444 });
            linkedList.Print();
        }
    }
}