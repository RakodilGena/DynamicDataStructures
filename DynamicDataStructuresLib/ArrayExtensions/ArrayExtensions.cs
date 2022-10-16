using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDataStructuresLib.ArrayExtensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Returns new array, extended with new value at specified index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T[] Insert<T>(this T[] array, int index, T value)
        {
            if (index < 0 || index > array.Length)
                throw new IndexOutOfRangeException();

            var lenght = array.Length;

            var newArray = new T[lenght + 1];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }

            newArray[index] = value;

            for (int i = index; i < lenght; i++)
            {
                newArray[i + 1] = array[i];
            }

            return newArray;
        }

        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException();

            var lenght = array.Length;

            var newArray = new T[lenght - 1];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = index + 1; i < lenght; i++)
            {
                newArray[i - 1] = array[i];
            }

            return newArray;
        }
    }
}
