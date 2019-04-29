using System;
using System.Diagnostics;

namespace CMD.CheckOptions
{
    class PROCESSES
    {
        static Process[] processes = processes = Process.GetProcesses();
        public static void Options(string Input)
        {
            string[] modifPath = InputEdit.Edit(Input, "process");
            if (modifPath[0] == "-kill")
            {
                for (int i = 0; i < processes.Length; i++)
                {
                    try
                    {


                        foreach (Process proc in Process.GetProcessesByName(processes[i].ProcessName))
                        {
                            if (!processes[i].ProcessName.Contains("CMD"))
                            {
                                proc.Kill();
                                Console.WriteLine($"{processes[i].ProcessName} killed");
                            }
                        }
                    }
                    catch (Exception) { Console.WriteLine("Error!"); }
                }
            }
            else if (modifPath[0] == "-info")
            {
                ProcessesInfo();
            }
            else
            {
                Console.WriteLine("A bug in the extension");
            }
        }
        private static void ProcessesInfo()
        {
            foreach (Process a in processes)
            {        
                Console.WriteLine(a.ProcessName);
            }
        }

    }
}
