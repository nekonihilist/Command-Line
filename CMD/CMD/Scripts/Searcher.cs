using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace CMD.Scripts
{
    class Searcher
    {
        #region Search Directories
        public static void SearchDirectories(string nameOfDirectory)
        {
            Console.WriteLine("Wait . . .");
            try
            {
                TraverseTreeParallelForEach(nameOfDirectory, (f) =>
                {
                    // Exceptions are no-ops.
                    try
                    {
                        // Do nothing with the data except read it.
                        byte[] data = File.ReadAllBytes(f);
                    }
                    catch (FileNotFoundException) { }
                    catch (IOException) { }
                    catch (UnauthorizedAccessException) { }
                    catch (SecurityException) { }
                    Console.WriteLine(f);
                });
            }
            catch (ArgumentException)
            {
                Console.WriteLine($@"The directory {nameOfDirectory} does not exist.");
            }
        }

        private static void TraverseTreeParallelForEach(string root, Action<string> action)
        {
            int fileCount = 0;
            var sw = Stopwatch.StartNew();
            int procCount = System.Environment.ProcessorCount;
            Stack<string> dirs = new Stack<string>();

            if (!Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = { };
                string[] files = { };
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                try
                {
                    if (files.Length < procCount)
                    {
                        foreach (var file in files)
                        {
                            action(file);
                            fileCount++;
                        }
                    }
                    else
                    {
                        Parallel.ForEach(files, () => 0, (file, loopState, localCount) =>
                        {
                            action(file);
                            return ++localCount;
                        },
                                         (c) => {
                                             Interlocked.Add(ref fileCount, c);
                                         });
                    }
                }
                catch (AggregateException ae)
                {
                    ae.Handle((ex) => {
                        if (ex is UnauthorizedAccessException)
                        {
                            Console.WriteLine(ex.Message);
                            return true;
                        }
                        return false;
                    });
                }
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
            Console.WriteLine("Processed {0} files in {1} milliseconds", fileCount, sw.ElapsedMilliseconds);
        }
        #endregion

        #region Search Files
        public static string [] files { get; set; }
        public static void Display()
        {
            if (files != null)
            {
                for (int i = 0; i < files.Length; i++)
                    Console.WriteLine(files[i]);
            }
        }
        public static string [] SearchFiles(string nameOfDirectory)
        {
            try
            {
                files = Directory.GetFiles(nameOfDirectory);
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("The specified folder does not exist");
                files = null;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access error");
                files = null;
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Incorrect path");
            }
            return files;
        }
        #endregion
    }
}