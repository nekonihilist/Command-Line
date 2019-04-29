using System;
using System.Diagnostics;

namespace CMD.CheckOptions
{
    class SYSTEM
    {
        public static void Options(string Input)
        {
            string[] modifPath = InputEdit.Edit(Input, "system");
            if(modifPath[0] == "-rload")
            {
                Reload();
            }
            else if(modifPath[0] == "-off")
            {
                Off();
            }
            else
            {
                Console.WriteLine("A bug in the extension");
            }
        }
        private static void Reload()
        {
            Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c restart -s -t 00";
            p.Start();
        }
        private static void Off()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c shutdown -s -t 00";
            p.Start();
        }
    }
}
