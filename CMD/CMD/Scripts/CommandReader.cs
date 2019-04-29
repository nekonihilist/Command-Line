using System;

namespace CMD.Scripts
{
    #region CommandRead block
    class CommandReader
    {
        public static string ReadCommand()
        {
            return new ReadCommand().GetInfo();
        }
    }
    interface IReader
    {
        string GetInfo();
    }
    class ReadCommand : IReader
    {
        public string GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string _command;
            while (true)
            {
                Console.Write("Command:");
                _command = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(_command))
                    break;
                Console.WriteLine("Value was empty!");
            }
            return _command;
        }
    }
    #endregion
}