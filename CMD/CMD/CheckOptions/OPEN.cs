using System;
using System.Diagnostics;
using System.IO;

namespace CMD.CheckOptions
{
    class OPEN
    {
        public static void Options(string Input)
        {
            string[] modifPath = InputEdit.Edit(Input, "open");
            if(modifPath[0]!="")
            {
                if (modifPath[0] == "notepad")
                {
                    using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\New Notepad.txt"))
                    {
                        Process.Start("notepad.exe", fs.Name);
                        fs.Close();
                    }
                }
                else if(modifPath[0] == "paint")
                {
                    using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Noname.png"))
                    {
                        Process.Start("mspaint.exe", fs.Name);
                        fs.Close();
                    }
                }
                else
                {
                    Console.WriteLine("A bug in the extension");
                }
            }
            else
            {
                Console.WriteLine("Choose a program!");
            }
        }
    }
}
