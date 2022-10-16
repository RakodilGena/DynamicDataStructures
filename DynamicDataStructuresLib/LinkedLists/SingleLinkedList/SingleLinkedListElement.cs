namespace DynamicDataStructuresLib.LinkedLists.SingleLinkedList
{
    internal class SingleLinkedListElement<T>
    {
        /// <summary>
        /// Value of this element.
        /// </summary>
        internal T Value { get; set; }

        /// <summary>
        /// Link to the next element.
        /// </summary>
        internal SingleLinkedListElement<T>? Next { get; set; }

        internal SingleLinkedListElement(T value)
        {
            Value = value;
        }
    }
}
