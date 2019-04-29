using System;
using CMD.CheckOptions;
namespace CMD.Scripts
{
        class CommandChecker
        {
            string Input { get; set; }

            public CommandChecker()
            {
                Input = CommandReader.ReadCommand();
            }
            public void CommandCheck()
            {
                Input = Input.ToLower();
                if (Input.StartsWith("ls"))
                {
                    LS.Options(Input);
                }
                else if (Input.StartsWith("cat"))
                {
                    CAT.Options(Input);
                }
                else if (Input.StartsWith("os"))
                {
                    OS.Options(Input);
                }
                else if (Input.StartsWith("help"))
                {
                    new HELP();
                }
                else if (Input.StartsWith("system"))
                {
                    SYSTEM.Options(Input);
                }
                else if (Input.StartsWith("process"))
                {
                    PROCESSES.Options(Input);
                }
                else if (Input.StartsWith("open"))
                {
                    OPEN.Options(Input);
                }
                else if (Input == "exit")
                    Environment.Exit(0);
                else
                {
                    Console.WriteLine("Non-existent command");
                }

            }
        }
}
