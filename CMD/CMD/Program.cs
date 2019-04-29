using System;
using CMD.Scripts;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CMD";
            CommandChecker commandChecker = new CommandChecker();
            bool isFirst = true;
            while(true)
            {
                if(!isFirst)
                {
                    commandChecker = new CommandChecker();
                }
                commandChecker.CommandCheck();
                isFirst = false;
            }
        }
    }
}