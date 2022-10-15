namespace DynamicDataStructuresLib.LinkedLists
{
    public interface ILinkedList<T>
    {
        /// <summary>
        /// Elements count.
        /// </summary>
        int Length { get; }

        T this[int index] { get; set; }

        /// <summary>
        /// Adds element to the list start.
        /// </summary>
        /// <param name="element"></param>
        void AddFirst(T element);

        /// <summary>
        /// Adds element to the list end.
        /// </summary>
        /// <param name="element"></param>
        void AddLast(T element);

        /// <summary>
        /// Adds element to specified position.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        void Insert(int index, T element);

        /// <summary>
        /// Returns List&lt;<typeparamref name="T"/>&gt; representation of current ILinkedList.
        /// </summary>
        /// <returns></returns>
        List<T> ToList();

        /// <summary>
        /// Returns first element of list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        T GetFirst();

        /// <summary>
        /// Returns last element of list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        T GetLast();

        /// <summary>
        /// Returns element from specified position of list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        T GetElement(int index);

        /// <summary>
        /// Removes element at specified position;
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        void RemoveAt(int index);

        /// <summary>
        /// Adds specified collection to the list end.
        /// </summary>
        /// <param name="collection"></param>
        void AddRange(IEnumerable<T> collection);

        /// <summary>
        /// Outputs content of this list to console.
        /// </summary>
        void Print();

    }
}
