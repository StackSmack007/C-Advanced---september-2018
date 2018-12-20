using System.IO;
class Program
{
    static void Main()
    {
        byte[] buffer = new byte[64];
        using (FileStream sourse=new FileStream("../../../../Resourses/copyMe.png",FileMode.Open))
        {
            using (FileStream destination = new FileStream("../../../../Resourses/Results/copiedPictureProblem4.png", FileMode.Create))
            {
                int read = sourse.Read(buffer, 0, buffer.Length);
                while (read>0)
                {
                    destination.Write(buffer, 0, read);
                    read = sourse.Read(buffer, 0, buffer.Length);
                }
            }
        }
    }
}