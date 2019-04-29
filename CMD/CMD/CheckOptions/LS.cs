using CMD.Scripts;
using System;

namespace CMD.CheckOptions
{
    class LS
    {
        public static void Options(string Input)
        {
            string[] modifPath = InputEdit.Edit(Input, "ls");
            if (modifPath.Length > 1)
            {
                if (modifPath[0] == "-a")
                {
                    Searcher.SearchDirectories(modifPath[1]);
                }
                else
                {
                    Console.WriteLine("A bug in the extension");
                }
            }
            else
            {
                Searcher.SearchFiles(modifPath[0]);
                Searcher.Display();
            }
        }
    }
}
