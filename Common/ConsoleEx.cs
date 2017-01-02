using System;

namespace NullReferencesDemo.Common
{
    public static class ConsoleEx
    {
        public static void WriteAndHighlight(string value, ConsoleColor color)
        {
            WriteAndHighlight((object)value, color);
        }

        public static void WriteAndHighlight(char value, ConsoleColor color)
        {
            WriteAndHighlight((object)value, color);
        }

        private static void WriteAndHighlight(object value, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = prevColor;
        }
    }
}