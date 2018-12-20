using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, decimal>> extFullNameSize = new Dictionary<string, Dictionary<string, decimal>>();
        DirectoryInfo directory = new DirectoryInfo("../../../../Resourses/");
        FileInfo[] files = directory.GetFiles("*.*"SearchOption.AllDirectories);
        foreach (FileInfo file in files)
        {
            string extension = file.Extension;
            string name = file.FullName.Split('\\').Last();
            decimal size = (decimal)file.Length / 1024;
            if (!extFullNameSize.ContainsKey(extension))
            {
                extFullNameSize[extension] = new Dictionary<string, decimal>();
            }
            extFullNameSize[extension][name] = size;
        }
        using (StreamWriter output = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Report.txt"))
        {

            foreach (var kvp in extFullNameSize.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                output.WriteLine(kvp.Key);
                foreach (var pair in kvp.Value.OrderBy(x => x.Value))
                {
                    output.WriteLine($"--{pair.Key} - {pair.Value:F2}kb");
                }
            }
        }
    }
}