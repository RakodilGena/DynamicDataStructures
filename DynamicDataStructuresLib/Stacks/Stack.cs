using System.Diagnostics;

namespace DynamicDataStructuresLib.Stacks
{
    /// <summary>
    /// Represents Stack Data Structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        private StackElement<T>? _top;

        /// <summary>
        /// Count of elements stored at the stack.
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Clears the stack.
        /// </summary>
        public void Clear()
        {
            _top = null;
            Length = 0;
        }

        /// <summary>
        /// Removes and returns element from the top of the stack.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T value = Peek();

            Debug.Assert(_top != null);

            _top = _top.Prev;
            Length--;

            return value;
        }

        /// <summary>
        /// Returns element from the top of the stack without removing.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {
            if (Length == 0)
                throw new InvalidOperationException("Stack is empty");

            Debug.Assert(_top != null);

            return _top.Value;
        }

        /// <summary>
        /// Adds element to the top of the stack.
        /// </summary>
        /// <param name="value"></param>

        public void Push(T value)
        {
            var newTop = new StackElement<T>(value);
            
            if (Length != 0)            
                newTop.Prev = _top;            

            _top = newTop;
            Length++;
        }
    }
}
