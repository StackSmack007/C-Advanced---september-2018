using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Patients> patients = new List<Patients>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "Output")
            {
                break;
            }
            string department = input[0];
            string doctor = input[1] + " " + input[2];
            string patient = input[3];
            if (patients.Count(x => x.Department == department) > 20 * 3)
            {
                continue;
            }
            Patients current = new Patients
            {
                Name = patient,
                Doctor = doctor,
                Department = department
            };
            patients.Add(current);
        }

        string commandInput = Console.ReadLine().Trim();

        while (commandInput != "End")
        {
            string[] command = commandInput.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
            string[] results = new string[1];
            if (patients.Any(x => x.Department == command[0]))
            {
                results = patients.Where(x => x.Department == command[0]).Select(x => x.Name).ToArray();
                if (command.Length == 2)
                {
                    int roomNumber = int.Parse(command.Last());
                    if (results.Length >= roomNumber * 3)
                    {
                        results = results.Skip(roomNumber * 3 - 3).Take(3).OrderBy(x => x).ToArray();
                    }
                }
            }
            else if (patients.Any(x => x.Doctor == commandInput))
            {
                results = patients.Where(x => x.Doctor == commandInput).Select(x => x.Name).OrderBy(x => x).ToArray();
            }
            Print(results);
            commandInput=Console.ReadLine();
        }
    }
    static void Print(string[] arr)
    {
        foreach (var item in arr)
        {
            Console.WriteLine(item);
        }
    }


}
class Patients
{
    public string Name { get; set; }
    public string Doctor { get; set; }
    public string Department { get; set; }
}