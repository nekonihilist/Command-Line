using System;
using System.Text;
using System.IO;

namespace CMD.Scripts
{
    class Writer
    {
        #region Info Write
        public static string Write(params string [] pathToFile)
        {
            string text = null;
            int i;
            for (i = 0; i < pathToFile.Length;i++)
            {
                try
                {
                    using (FileStream fs = File.OpenRead(pathToFile[i]))
                    {
                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, data.Length);
                        text += Encoding.Default.GetString(data);
                    }
                }
                catch(FileNotFoundException ex)
                {
                    Console.WriteLine($"File {pathToFile[i]} doesn't exist!");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"[{pathToFile[i]}] Access error");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Incorrect path");
                }
            }
            return text;
        }
        #endregion
    }
}