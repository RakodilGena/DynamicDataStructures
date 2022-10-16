using DynamicDataStructuresLib.ArrayExtensions;
using DynamicDataStructuresLib.LinkedLists;
using System.Diagnostics;


namespace Executor.LinkedListPerformance
{
    internal class LinkedListPerformanceTester
    {
        const int ITERATIONS = 10,
                    COLLECTION_SIZE = 100000;

        const decimal INSERT_VALUE = 0;

        public static void Test()
        {
            //first run for cashing
            ExecuteTests();

            Console.Clear();

            Console.WriteLine("Testing Linked List Performance\r\n\r\n");
            ExecuteTests();
        }

        private static void ExecuteTests()
        {
            var initialCollection = Enumerable.Repeat(INSERT_VALUE, COLLECTION_SIZE).ToArray();

            Console.WriteLine(Pr("Type") + Pl("Init")
                + Pl("InsertStart") + Pl("InsertMid") + Pl("InsertEnd")
                + Pl("ReadStart") + Pl("ReadMid") + Pl("ReadEnd")
                + Pl("RemoveStart") + Pl("RemoveMid") + Pl("RemoveEnd"));

            GetArrayPerformance(initialCollection,
                out double initElapsed,
                out double startInsertElapsed,
                out double middleInsertElapsed,
                out double endInsertElapsed,
                out double startReadElapsed,
                out double middleReadElapsed,
                out double endReadElapsed,
                out double startRemoveElapsed,
                out double middleRemoveElapsed,
                out double endRemoveElapsed);

            Console.WriteLine(Pr("Array") + Pl(initElapsed)
                + Pl(startInsertElapsed) + Pl(middleInsertElapsed) + Pl(endInsertElapsed)
                + Pl(startReadElapsed) + Pl(middleReadElapsed) + Pl(endReadElapsed)
                + Pl(startRemoveElapsed) + Pl(middleRemoveElapsed) + Pl(endRemoveElapsed));


            ILinkedList<decimal> list = new SingleLinkedList<decimal>();
            GetLinkedListPerformance(
                list, initialCollection,
                out initElapsed,
                out startInsertElapsed,
                out middleInsertElapsed,
                out endInsertElapsed,
                out startReadElapsed,
                out middleReadElapsed,
                out endReadElapsed,
                out startRemoveElapsed,
                out middleRemoveElapsed,
                out endRemoveElapsed);

            Console.WriteLine(Pr("SingleLL") + Pl(initElapsed)
                + Pl(startInsertElapsed) + Pl(middleInsertElapsed) + Pl(endInsertElapsed)
                + Pl(startReadElapsed) + Pl(middleReadElapsed) + Pl(endReadElapsed)
                + Pl(startRemoveElapsed) + Pl(middleRemoveElapsed) + Pl(endRemoveElapsed));


            list = new DoublyLinkedList<decimal>();
            GetLinkedListPerformance(
                list, initialCollection,
                out initElapsed,
                out startInsertElapsed,
                out middleInsertElapsed,
                out endInsertElapsed,
                out startReadElapsed,
                out middleReadElapsed,
                out endReadElapsed,
                out startRemoveElapsed,
                out middleRemoveElapsed,
                out endRemoveElapsed);

            Console.WriteLine(Pr("DoublyLL") + Pl(initElapsed)
                + Pl(startInsertElapsed) + Pl(middleInsertElapsed) + Pl(endInsertElapsed)
                + Pl(startReadElapsed) + Pl(middleReadElapsed) + Pl(endReadElapsed)
                + Pl(startRemoveElapsed) + Pl(middleRemoveElapsed) + Pl(endRemoveElapsed));
        }

        static string Pr(string name)
        {
            return name.PadRight(10);
        }

        static string Pl(string value)
        {
            return (value + "|").PadLeft(14);
        }

        static string Pl(double value)
        {
            return (value.ToString("0.00000") + "|").PadLeft(14);
        }



        private static void GetArrayPerformance(
            decimal[] initialCollection,
            out double initElapsed,
            out double startInsertElapsed,
            out double middleInsertElapsed,
            out double endInsertElapsed,
            out double startReadElapsed,
            out double middleReadElapsed,
            out double endReadElapsed,
            out double startRemoveElapsed,
            out double middleRemoveElapsed,
            out double endRemoveElapsed)
        {
            var clock = new Stopwatch();

            clock.Start();
            decimal[] array = initialCollection.ToArray();
            clock.Stop();
            initElapsed = clock.Elapsed.TotalMilliseconds;

            //inserting elements
            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                array = array.Insert(0, INSERT_VALUE);
            clock.Stop();
            startInsertElapsed = clock.Elapsed.TotalMilliseconds;

            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                array = array.Insert(array.Length / 2, INSERT_VALUE);
            clock.Stop();
            middleInsertElapsed = clock.Elapsed.TotalMilliseconds;


            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                array = array.Insert(array.Length, INSERT_VALUE);
            clock.Stop();
            endInsertElapsed = clock.Elapsed.TotalMilliseconds;



            //getting element value
            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
            {
                var value = array[0];
            }
            clock.Stop();
            startReadElapsed = clock.Elapsed.TotalMilliseconds;

            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
            {
                var value = array[array.Length / 2];
            }
            clock.Stop();
            middleReadElapsed = clock.Elapsed.TotalMilliseconds;


            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
            {
                var value = array[array.Length - 1];
            }
            clock.Stop();
            endReadElapsed = clock.Elapsed.TotalMilliseconds;


            //removing elements
            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                array = array.RemoveAt(0);
            clock.Stop();
            startRemoveElapsed = clock.Elapsed.TotalMilliseconds;

            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                array = array.RemoveAt(array.Length / 2);
            clock.Stop();
            middleRemoveElapsed = clock.Elapsed.TotalMilliseconds;


            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                array = array.RemoveAt(array.Length - 1);
            clock.Stop();
            endRemoveElapsed = clock.Elapsed.TotalMilliseconds;
        }


        private static void GetLinkedListPerformance(
            ILinkedList<decimal> list,
            decimal[] initialCollection,
            out double initElapsed,
            out double startInsertElapsed,
            out double middleInsertElapsed,
            out double endInsertElapsed,
            out double startReadElapsed,
            out double middleReadElapsed,
            out double endReadElapsed,
            out double startRemoveElapsed,
            out double middleRemoveElapsed,
            out double endRemoveElapsed)
        {
            var clock = new Stopwatch();

            clock.Start();
            list.AddRange(initialCollection);
            clock.Stop();
            initElapsed = clock.Elapsed.TotalMilliseconds;

            //inserting elements
            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                list.AddFirst(INSERT_VALUE);
            clock.Stop();
            startInsertElapsed = clock.Elapsed.TotalMilliseconds;

            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                list.Insert(list.Length / 2, INSERT_VALUE);
            clock.Stop();
            middleInsertElapsed = clock.Elapsed.TotalMilliseconds;


            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                list.AddLast(INSERT_VALUE);
            clock.Stop();
            endInsertElapsed = clock.Elapsed.TotalMilliseconds;



            //getting element value
            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
            {
                var value = list.GetFirst();
            }
            clock.Stop();
            startReadElapsed = clock.Elapsed.TotalMilliseconds;

            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
            {
                var value = list[list.Length / 2];
            }
            clock.Stop();
            middleReadElapsed = clock.Elapsed.TotalMilliseconds;


            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
            {
                var value = list.GetLast();
            }
            clock.Stop();
            endReadElapsed = clock.Elapsed.TotalMilliseconds;


            //removing elements
            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                list.RemoveAt(0);
            clock.Stop();
            startRemoveElapsed = clock.Elapsed.TotalMilliseconds;

            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                list.RemoveAt(list.Length / 2);
            clock.Stop();
            middleRemoveElapsed = clock.Elapsed.TotalMilliseconds;


            clock.Restart();
            for (int i = 0; i < ITERATIONS; i++)
                list.RemoveAt(list.Length - 1);
            clock.Stop();
            endRemoveElapsed = clock.Elapsed.TotalMilliseconds;
        }
    }
}
