using System;
using System.IO;

namespace reading_files_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1: File and FileInfo\n2:");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    FileAndFileInfo();
                    break;
                case 2:
                    break;
                case 3:

                    break;
            }
        }
        public static void FileAndFileInfo()
        {
            string sourcePath = @"C:\CSharp\reading-files-csharp\reading-files-csharp\file1.txt";
            //string sourcePath = "C:\\temp\\file1.txt";

            string targetPath = @"C:/CSharp/reading-files-csharp/reading-files-csharp/file2.txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
                string[] lines = File.ReadAllLines(sourcePath);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Um erro ocorreu");
                Console.WriteLine(e.Message);
            }
        }
    }
}
