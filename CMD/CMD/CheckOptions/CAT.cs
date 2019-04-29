using System;
using System.Collections.Generic;
using System.Linq;
using CMD.Scripts;

namespace CMD.CheckOptions
{
    class CAT
    {
        public static void Options(string Input)
        {
            string[] modifPath = InputEdit.Edit(Input, "cat");

            string modifier = null;
            if (modifPath[0].Length == 2) 
            {
                modifier = modifPath[0];
                List<string> list = modifPath.ToList();
                list.RemoveAt(0);
                modifPath = list.ToArray();
                if(modifier == "-d")
                {
                    Searcher.SearchFiles(modifPath[0]);
                    modifPath = Searcher.files;
                }
                else
                {
                    Console.WriteLine("A bug in the extension");
                }
            }
            string text = Writer.Write(modifPath);
            if(text != null)
                Console.WriteLine(text);
        }
    }
}
