namespace DynamicDataStructuresLib.LinkedLists.DoublyLinkedList
{
    internal class DoublyLinkedListElement<T>
    {
        /// <summary>
        /// Value of this element.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Link to the previous element.
        /// </summary>
        public DoublyLinkedListElement<T>? Prev { get; set; }


        /// <summary>
        /// Link to the next element.
        /// </summary>
        public DoublyLinkedListElement<T>? Next { get; set; }



        public DoublyLinkedListElement(T value)
        {
            Value = value;
        }
    }
}
