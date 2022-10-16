using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataStructuresLib.Queue
{
    public interface IUnprioritizedQueue<T> : IQueue<T>
    {
        /// <summary>
        /// Adds element to the tail of the queue.
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);
    }
}
