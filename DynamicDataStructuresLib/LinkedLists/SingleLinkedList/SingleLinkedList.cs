using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDataStructuresLib.LinkedLists.SingleLinkedList;

namespace DynamicDataStructuresLib.LinkedLists
{
    /// <summary>
    /// Represents Single Linked List Data Structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleLinkedList<T> : ILinkedList<T>
    {
        /// <summary>
        /// First element of list.
        /// </summary>
        private SingleLinkedListElement<T>? _root;

        public int Length { get; private set; }

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();

                return GetElementAtIndex(index).Value;
            }
            set
            {
                GetElementAtIndex(index).Value = value;
            }
        }

        public SingleLinkedList()
        {
            Length = 0;
        }

        public SingleLinkedList(params T[] initialCollection)
        {
            _root = CreateRange(initialCollection, out int length);
            Length = length;
        }

        public void AddFirst(T element)
        {
            var newElement = new SingleLinkedListElement<T>(element);

            if (_root != null)
                newElement.Next = _root;

            _root = newElement;
            Length++;
        }

        public void AddLast(T element)
        {
            var newElement = new SingleLinkedListElement<T>(element);

            if (_root == null)
            {
                _root = newElement;
                Length = 1;
                return;
            }

            SingleLinkedListElement<T> last = GetLastListElement();
            last.Next = newElement;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            SingleLinkedListElement<T>? newRoot = 
                                        CreateRange(collection, out int newCollectionLength);
            if (newRoot == null)
                return;

            if (_root == null)
            {
                _root = newRoot;
                Length = newCollectionLength;
                return;
            }

            var last = GetLastListElement();
            last.Next = newRoot;
            Length += newCollectionLength;
        }

        public T GetElement(int index)
        {
            if (index >= Length || index < 0)
                throw new IndexOutOfRangeException();

            var current = GetElementAtIndex(index);

            return current.Value;
        }

        public T GetFirst()
        {
            return GetElement(0);
        }

        public T GetLast()
        {
            if (_root == null)
                throw new IndexOutOfRangeException();

            var last = GetLastListElement();
            return last.Value;
        }

        public void Insert(int index, T element)
        {
            if (index > Length || index < 0)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(element);
                return;
            }

            var newElement = new SingleLinkedListElement<T>(element);

            var elementAtPrevIndex = GetElementAtIndex(index - 1);

            if (elementAtPrevIndex.Next != null)
                newElement.Next = elementAtPrevIndex.Next;

            elementAtPrevIndex.Next = newElement;
            Length++;
        }

        public void RemoveAt(int index)
        {
            if (index >= Length || index < 0)
                throw new IndexOutOfRangeException();

            Debug.Assert(_root != null);
            if (index == 0)
            {
                _root = _root.Next;
                Length--;
                return;
            }

            var elementAtPrevIndex = GetElementAtIndex(index - 1);

            //element at index to remove is not null
            Debug.Assert(elementAtPrevIndex.Next != null);

            //if removed element has next element, connect next element of removed with prev. element of removed.
            elementAtPrevIndex.Next = elementAtPrevIndex.Next.Next;
            Length--;
        }

        public List<T> ToList()
        {
            var list = new List<T>();

            for (var current = _root; current != null; current = current.Next)
            {
                list.Add(current.Value);
            }

            return list;
        }

        public void Print()
        {
            var elements = ToList().Select(c => c?.ToString() ?? "null").ToArray();

            var elemStr = "{ " + string.Join(", ", elements) + " }";

            var output = $"List Lenght property: {Length} | Elements count: {elements.Length}" +
                $"\r\nElements: {elemStr}\r\n";

            Console.WriteLine(output);
        }




        /// <summary>
        /// Returns element of list at specified index;
        /// </summary>
        /// <returns></returns>
        private SingleLinkedListElement<T> GetElementAtIndex(int index)
        {
            Debug.Assert(_root != null);

            var current = _root;
            for (int i = 1; i <= index; i++)
            {
                Debug.Assert(current?.Next != null);
                current = current.Next;
            }

            return current;
        }

        /// <summary>
        /// Returns last element of list;
        /// </summary>
        /// <returns></returns>
        private SingleLinkedListElement<T> GetLastListElement()
        {
            Debug.Assert(_root != null);

            SingleLinkedListElement<T> current = _root;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Creates new linked list of elements and returns its root.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private SingleLinkedListElement<T>? CreateRange(IEnumerable<T> collection, out int length)
        {
            SingleLinkedListElement<T>? newRoot = null, 
                                        current = null;
            length = 0;

            foreach (T element in collection)
            {
                length++;

                var newElement = new SingleLinkedListElement<T>(element);

                //setting root of new collection at the first step
                if (newRoot == null)
                {
                    newRoot = current = newElement;
                    continue;
                }

                Debug.Assert(current != null);

                //setting next element and moving to it.
                current.Next = newElement;
                current = current.Next;
            }

            //new root is null means collection was empty
            return newRoot;
        }
    }
}
