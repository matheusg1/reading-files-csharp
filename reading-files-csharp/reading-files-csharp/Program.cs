using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace reading_files_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: File and FileInfo\n2:FileStream and StreamReader\n3: Bloco using\n4: StreamWriter\n5: Directory and DirectoryInfo\n6: Path\n7: Solved exercise");
            int escolha = int.Parse(Console.ReadLine());
            
            switch (escolha)
            {
                case 1:
                    FileAndFileInfo();
                    break;
                case 2:
                    FileStreamAndStreamReader();
                    break;
                case 3:
                    BlocoUsing();
                    break;
                case 4:
                    StreamWriter();
                    break;
                case 5:
                    DirectoryAndDirectoryInfo();
                    break;
                case 6:
                    PathMethod();
                    break;
                default:
                    SolvedExercise();
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
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }

        public static void FileStreamAndStreamReader()
        {

            /*
            "o Stream Reader tem a função de converter os dados pra texto e de texto pra binário 
            Criamos um arquivo FileStream e o StreamReader associado cuida das operações
            encapsulando essa questão do arquivo ser binário"  
            https://imasters.com.br/back-end/c-lendo-e-escrevendo-em-arquivos-textos-streamreaderstreamwriter
             */


            //FileStream fs = null;
            StreamReader sr = null;
            string path = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\file1.txt";

            try
            {
                sr = File.OpenText(path); //abre um StreamReader
                //fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                //sr = new StreamReader(fs);


                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                /*if(fs != null)
                    fs.Close();*/
                if (sr != null)
                    sr.Close();
            }
        }

        public static void BlocoUsing()
        {
            string path = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\file1.txt";
            //using FileStream fs = new(path, FileMode.Open); #outra forma, menos explícita
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
                /*
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                }*/
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public static void StreamWriter()
        {
            //Grava o conteúdo do source no final do target + em letras maiúsculas
            string sourcePath = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\file1.txt";
            string targetPath = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\file2.txt";

            string[] lines = File.ReadAllLines(sourcePath);
            try
            {
                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach(string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    } 
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"ERROR { e.Message }");
            }
        }

        public static void DirectoryAndDirectoryInfo()
        {
            string path = @"c:\temp";
            //DirectoryInfo dirInfo = new DirectoryInfo(path);

            try{
                //Listar pastas
                IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("Folders");
                foreach (string folder in folders)
                {
                    Console.WriteLine(folder);
                }

                //Listar arquivos
                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("Files:");
                foreach(string file in files)
                {
                    Console.WriteLine(file);
                }

                //Criar pasta
                Directory.CreateDirectory(path + @"\newFolder");
                //Directory.CreateDirectory(path + "\\newFolder");
                //Directory.CreateDirectory(path + "/newFolder");


            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR" + e.Message);
            }
        }

        public static void PathMethod()
        {
            string path = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\file1.txt";
            
            Console.WriteLine("Directory separator char: " + Path.DirectorySeparatorChar);
            Console.WriteLine("Path separator: " + Path.PathSeparator);
            Console.WriteLine("Get file name: " + Path.GetFileName(path));
            Console.WriteLine("Get file name w/o extension: " + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine("GetExtension " + Path.GetExtension(path));
            Console.WriteLine("Get full path " + Path.GetFullPath(path));
            Console.WriteLine("Get temp path " + Path.GetTempPath());


            //Diretorio onde fica o arquivo file1
            Console.WriteLine("GetDirectoryName " + Path.GetDirectoryName(path));
        }

        public static void SolvedExercise()
        {
            string sourcePath = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\produtos.csv";
            Directory.CreateDirectory(@"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\out");
            string targetPath = @"C:\Users\matheus.silva\Documents\ProjetosPessoais\reading-files-csharp\reading-files-csharp\reading-files-csharp\out\result.csv";


            string[] lines = File.ReadAllLines(sourcePath);
            try
            {
                using (StreamWriter sw = File.CreateText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        string[] tempLines = line.Split(",");
                        string name = tempLines[0];
                        //decimal valor = decimal.Parse(tempLines[1]); Sem o InvariantCulture, formata errado
                        decimal price = decimal.Parse(tempLines[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(tempLines[2]);

                        decimal totalValueOfProduct = price * quantity;

                        sw.Write((name + "," + totalValueOfProduct.ToString("n2") + "\n"), CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Finished");
        }
    }
}