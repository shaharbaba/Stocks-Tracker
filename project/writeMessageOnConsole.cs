using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class writeMessageOnConsole
    {
        public static void WriteMessageOnConsole(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
