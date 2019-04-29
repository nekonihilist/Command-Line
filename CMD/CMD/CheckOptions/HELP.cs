using System;

namespace CMD.CheckOptions
{
    class HELP
    {
        public HELP()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ls way_to_file     gives all files in the folder;\nls -a way_to_file     outputs all files from the current folder and subfolders;");
            LineWrite();
            Console.WriteLine("cat ways_to_file     displays the contents of files;\ncat -d way_to_folder     displays the contents of all files in the folder;");
            LineWrite();
            Console.WriteLine("os     information about operating system;\nos -hd     information about hard drives;");
            Console.WriteLine("os -vd     information about video card;\nos -p     information about processor;");
            Console.WriteLine("os -ip     information about ip;\nos -ram     information about RAM;");
            LineWrite();
            Console.WriteLine("system -rload     reload the computer;\nsystem -off     off the computer");
            LineWrite();
            Console.WriteLine("process -kill     terminates all processes except system ones;\nprocess -info     displays a list of processes;");
            LineWrite();
            Console.WriteLine("open notepad     opens Notepad;\nopen paint     opens MSPaint;\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void LineWrite()
        {
            string line = "\n--------------------------------\n";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
