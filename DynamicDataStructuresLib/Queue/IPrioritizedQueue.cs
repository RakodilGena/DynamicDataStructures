using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataStructuresLib.Queue
{

    public interface IPrioritizedQueue<T>: IQueue<T>
    {
        /// <summary>
        /// Adds item at the certain position of the queue, depending on it's priority.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="priority"></param>
        void Add(T item, int priority);
    }
}
