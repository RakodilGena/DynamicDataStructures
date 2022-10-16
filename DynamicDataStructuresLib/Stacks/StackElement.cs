namespace DynamicDataStructuresLib.Stacks
{
    internal class StackElement<T>
    {
        internal T Value { get; set; }

        internal StackElement<T>? Prev { get; set; }


        internal StackElement(T value)
        {
            Value = value;
        }
    }
}
