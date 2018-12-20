using System.IO;

class Program
{
    static void Main()
    {
        using (StreamReader strReader=new StreamReader(Path.Combine("../../../../Resourses","text.txt")))
        {
            using (StreamWriter strWriter=new StreamWriter(Path.Combine("../../../../Resourses/Results", "Problem2Result.txt")))
            {
                int count = 0;
                while (true)
                {
                    string line = strReader.Read;
                    if (line==null)
                    {
                        break;
                    }
                    strWriter.WriteLine($"Line {++count}: {line}");
                }
            }
        }
    }
}

