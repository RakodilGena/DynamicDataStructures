using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataStructuresLib.Queue
{
    public interface IQueue<T>
    {
        /// <summary>
        /// Length of queue.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        void Clear();

        /// <summary>
        /// Removes and returns element from the head of the queue.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        T Remove();

        /// <summary>
        /// Returns element from the head of the queue without removing.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        T Peek();
    }
}
