using System;
using CMD.Scripts;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CMD";
            while(true)
            {
                new CommandChecker().CommandCheck();
            }
        }
    }
}
