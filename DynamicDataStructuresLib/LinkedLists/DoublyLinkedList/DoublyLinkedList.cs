using System.Diagnostics;
using DynamicDataStructuresLib.LinkedLists.DoublyLinkedList;

namespace DynamicDataStructuresLib.LinkedLists
{
    public class DoublyLinkedList<T> : ILinkedList<T>
    {
        private DoublyLinkedListElement<T>? _first;
        private DoublyLinkedListElement<T>? _last;

        private bool CloserToStart(int index)
        {
            //if no elements or element is the only - iterate from start anyway.
            if (Length <= 1)
                return true;

            int endDiff = Length - index;

            //if diff between index and start less(<=) than diff between index and end, lets iterate from start. otherwise, from end. 
            return index <= endDiff;
        }

        private DoublyLinkedListElement<T> GetElementAtIndex(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();

            Debug.Assert(Length > 0);

            if (CloserToStart(index))
                return GetElementAtIndexFromStart(index);
            else
                return GetElementAtIndexFromEnd(index);
        }

        /// <summary>
        /// Returns element at specified index, iterating on elements chain from start.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private DoublyLinkedListElement<T> GetElementAtIndexFromStart(int index)
        {
            Debug.Assert(_first != null);

            var current = _first;
            for (int i = 0; i < index; i++)
            {
                Debug.Assert(current.Next != null);
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Returns element at specified index, iterating on elements chain from end.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private DoublyLinkedListElement<T> GetElementAtIndexFromEnd(int index)
        {
            Debug.Assert(_last != null);

            //set new index to iterate from end.
            index = Length - index - 1;

            var current = _last;
            for (int i = 0; i < index; i++)
            {
                Debug.Assert(current.Prev != null);
                current = current.Prev;
            }
            return current;
        }

        public DoublyLinkedList()
        {
            Length = 0;
        }

        public DoublyLinkedList(params T[] initialCollection)
        {
            (DoublyLinkedListElement<T>? first,
                DoublyLinkedListElement<T>? last,
                int newCollectionLength) = CreateRange(initialCollection);

            _first = first;
            _last = last;
            Length = newCollectionLength;
        }

        public T this[int index]
        {
            get
            {
                var element = GetElementAtIndex(index);
                return element.Value;
            }
            set
            {
                var element = GetElementAtIndex(index);
                element.Value = value;
            }
        }

        public int Length { get; private set; }

        public void AddFirst(T value)
        {
            var newElement = new DoublyLinkedListElement<T>(value);

            if (_first == null)
            {
                _first = _last = newElement;
            }
            else
            {
                _first.Prev = newElement;
                newElement.Next = _first;
                _first = newElement;
            }

            Length++;
        }

        public void AddLast(T value)
        {
            var newElement = new DoublyLinkedListElement<T>(value);
            if (_last == null)
            {
                _first = _last = newElement;
            }
            else
            {
                _last.Next = newElement;
                newElement.Prev = _last;
                _last = newElement;
            }

            Length++;
        }

        public T GetElement(int index)
        {
            return GetElementAtIndex(index).Value;
        }

        public T GetFirst()
        {
            if (_first == null)
                throw new IndexOutOfRangeException();

            return _first.Value;
        }

        public T GetLast()
        {
            if (_last == null)
                throw new IndexOutOfRangeException();

            return _last.Value;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Length)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            if (index == Length)
            {
                AddLast(value);
                return;
            }

            var newElement = new DoublyLinkedListElement<T>(value);

            DoublyLinkedListElement<T> next, prev;
            if (CloserToStart(index))
            {
                prev = GetElementAtIndexFromStart(index - 1);
                Debug.Assert(prev.Next != null);
                next = prev.Next;
            }
            else
            {
                next = GetElementAtIndexFromEnd(index + 1);
                Debug.Assert(next.Prev != null);
                prev = next.Prev;
            }

            prev.Next = newElement;
            newElement.Prev = prev;

            next.Prev = newElement;
            newElement.Next = next;

            Length++;
        }

        public void Print()
        {
            var elements = ToList().Select(c => c?.ToString() ?? "null").ToArray();

            var elemStr = "{ " + string.Join(", ", elements) + " }";

            var output = $"List Lenght property: {Length} | Elements count: {elements.Length}" +
                $"\r\nElements: {elemStr}\r\n";

            Console.WriteLine(output);
        }

        public List<T> ToList()
        {
            var list = new List<T>();

            for (var current = _first; current != null; current = current.Next)
            {
                list.Add(current.Value);
            }

            return list;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            if (index == Length - 1)
            {
                RemoveLast();
                return;
            }

            if (CloserToStart(index))
            {
                var prev = GetElementAtIndexFromStart(index - 1);
                Debug.Assert(prev.Next != null);

                var newNext = prev.Next.Next;

                prev.Next = newNext;
                if (newNext != null)
                    newNext.Prev = prev;
            }
            else
            {
                var next = GetElementAtIndexFromStart(index + 1);
                Debug.Assert(next.Prev != null);

                var newPrev = next.Prev.Prev;

                next.Prev = newPrev;
                if (newPrev != null)
                    newPrev.Next = next;
            }

            Length--;
        }

        private void RemoveFirst()
        {
            Debug.Assert(_first != null);
            _first = _first.Next;

            //if more than 0 elements left in list, remove prev link of new first element.
            if (_first?.Prev != null)
                _first.Prev = null;
            Length--;
        }

        private void RemoveLast()
        {
            Debug.Assert(_last != null);
            _last = _last.Prev;

            //if more than 0 elements left in list, remove next link of new last element.
            if (_last != null)
                _last.Next = null;

            Length--;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            (DoublyLinkedListElement<T> ? first,
                DoublyLinkedListElement<T>? last,
                int newCollectionLength) = CreateRange(collection);

            if (newCollectionLength == 0)
                return;

            Debug.Assert(first != null && last != null);

            if (Length == 0)
            {
                _first = first;
                _last = last;
                Length = newCollectionLength;
                return;
            }

            Debug.Assert(_last != null);
            //setting new collection to the end of prev list.
            _last.Next = first;
            _last = last;

            Length += newCollectionLength;
        }


        /// <summary>
        /// Creates new linked list of elements and returns its root.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private (DoublyLinkedListElement<T>? first, DoublyLinkedListElement<T>? last, int length)  CreateRange(IEnumerable<T> collection)
        {
            DoublyLinkedListElement<T>? newRoot = null,
                                        current = null;
            int length = 0;

            foreach (T element in collection)
            {
                length++;

                var newElement = new DoublyLinkedListElement<T>(element);

                //setting root of new collection at the first step
                if (newRoot == null)
                {
                    newRoot = current = newElement;
                    continue;
                }

                Debug.Assert(current != null);

                //setting next element and moving to it.
                newElement.Prev = current;
                current.Next = newElement;

                current = current.Next;
            }


            return (newRoot, current, length);
        }
    }
}
