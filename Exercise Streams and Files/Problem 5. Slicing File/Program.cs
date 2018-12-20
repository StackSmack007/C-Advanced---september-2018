using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string command = Console.ReadLine();
        if (command.ToLower() == "slice")
        {
            Slice();
        }
        if (command.ToLower() == "combine")
        {
            Combine();
        }
    }
    static void Slice()
    {
        int parts = int.Parse(Console.ReadLine());
        byte[] buffer = new byte[1024];
        Console.Write("InsertNameOfFile:...");
        string[] nameOfFile = Console.ReadLine().Split('.');
        Console.WriteLine();
        using (FileStream sourse = new FileStream(Path.Combine("../../../../Resourses/", $"{string.Join(".", nameOfFile)}"), FileMode.Open))
        {
            long size = sourse.Length;
            long partSize = size / parts;
            int currentCounter = 1;
            while (currentCounter <= parts)
            {
                using (FileStream output = new FileStream(Path.Combine("../../../../Resourses/Results/ArchiveParts/", $"{string.Join(".", nameOfFile.Take(nameOfFile.Length - 1))}_Part{currentCounter}.{nameOfFile[nameOfFile.Length - 1]}"), FileMode.Create))
                {
                    if (currentCounter != parts)
                    {
                        for (int i = 0; i < partSize / buffer.Length; i++)
                        {
                            int read = sourse.Read(buffer, 0, buffer.Length);
                            output.Write(buffer, 0, read);
                        }
                    }
                    else
                    {
                        int read = sourse.Read(buffer, 0, buffer.Length);
                        while (read > 0)
                        {
                            output.Write(buffer, 0, read);
                            read = sourse.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
                currentCounter++;
            }
        }
    }

    static void Combine()
    {
        Console.Write("InsertNameOfFile:...");
        string nameOfFile = Console.ReadLine();
        int counter = 1;
        bool fileExists = File.Exists(Path.Combine("../../../../Resourses/Results/ArchiveParts/", nameOfFile));
        if (!nameOfFile.Contains("Part1."))
        {
            Console.WriteLine("No first part Error!");
            return;
        }
        string outputFileName = nameOfFile.Replace("Part1", "");
        using (FileStream targetFile = new FileStream(Path.Combine("../../../../Resourses/Results/Asembled/", outputFileName), FileMode.Append))
        {
            while (fileExists)
            {
                byte[] buffer = new byte[1024];
                using (FileStream sourseCurrent = new FileStream(Path.Combine("../../../../Resourses/Results/ArchiveParts/", nameOfFile), FileMode.Open))
                {
                    while (true)
                    {
                        int read = sourseCurrent.Read(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            break;
                        }
                        targetFile.Write(buffer, 0, read);
                    }
                    nameOfFile = nameOfFile.Replace($"Part{counter}.", $"Part{++counter}.");
                    fileExists = File.Exists(Path.Combine("../../../../Resourses/Results/ArchiveParts/", nameOfFile));
                }
            }
        }
    }
}