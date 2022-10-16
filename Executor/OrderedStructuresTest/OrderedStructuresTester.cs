using System.Linq;
using System.Text;

namespace Executor.OrderedStructuresTest
{
    internal class OrderedStructuresTester
    {
        internal static void Test()
        {
            Console.WriteLine("Testing stack.\r\n");
            TestStack();
        }



        private static void TestStack()
        {
            var stack = new DynamicDataStructuresLib.Stacks.Stack<int>();

            var builder = new StringBuilder();
            builder.AppendLine("Filling stack.");

            var strings = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
                strings.Add(i.ToString());
            }
            builder.AppendLine($"Input is {string.Join(", ", strings)}");

            strings.RemoveRange(0, strings.Count);
            while (stack.Length > 0)
            {
                var top = stack.Pop();
                strings.Add(top.ToString());
            }
            builder.AppendLine($"Output from stack is {string.Join(", ", strings)}");
            Console.WriteLine(builder + "\r\n\r\n");
        }
    }
}