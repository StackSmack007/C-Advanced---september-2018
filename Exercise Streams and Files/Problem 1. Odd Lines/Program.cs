using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = "../../../../Resourses/";
        var streamReader = new StreamReader(Path.Combine(path, "text.txt"));
        using (streamReader)
        {
            string line = streamReader.ReadLine();
            int counter = -1;
            while (!string.IsNullOrEmpty(line))
            {
                if (++counter % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                line = streamReader.ReadLine();
            }
        }
    }
}