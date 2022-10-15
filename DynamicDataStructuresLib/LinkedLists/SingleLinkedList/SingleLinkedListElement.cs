using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataStructuresLib.LinkedLists.SingleLinkedList
{
    internal class SingleLinkedListElement<T>
    {
        /// <summary>
        /// Value of this element.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Link to next element.
        /// </summary>
        public SingleLinkedListElement<T>? Next { get; set; }

        public SingleLinkedListElement(T value)
        {
            Value = value;
        }
    }
}
