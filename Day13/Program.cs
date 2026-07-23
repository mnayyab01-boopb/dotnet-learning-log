using System;
using System.IO;
using System.Text.Json;
class Students
{
    public string Name {get; set;}
    public int Id {get;set;}
    public int Age {get; set;}
    public int Number {get; set;}
}
class Program
{
 static void Main(string[] args)
    {
        List<Students> students = new List<Students>();
        if (File.Exists("students.json"))
        {
        string json = File.ReadAllText("students.json");
        students = JsonSerializer.Deserialize<List<Students>>(json) ?? new List<Students>();
         }
        while (true)
        {
            Console.WriteLine("Students Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                string json = JsonSerializer.Serialize(students);
                File.WriteAllText("students.json", json);
                    Students s = new Students();
                    Console.Write("Enter ID: ");
                    s.Id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    s.Name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    s.Age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Number: ");
                    s.Number = Convert.ToInt32(Console.ReadLine());
                    students.Add(s);
                    Console.WriteLine("Student Added Successfully.");
                    break;
                case 2:
                string json = JsonSerializer.Serialize(students);
                File.WriteAllText("students.json", json);
                    if (students.Count == 0)
                    {
                        Console.WriteLine("No Students Found.");
                    }
                    else
                    {
                        Console.WriteLine("Students List");
                        foreach (Students student in students)
                        {
                            Console.WriteLine("ID : " + student.Id);
                            Console.WriteLine("Name : " + student.Name);
                            Console.WriteLine("Age : " + student.Age);
                            Console.WriteLine("Number : " + student.Number);
                        }
                    }
                    break;
                case 3:
                    Console.Write("Enter Student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string json = JsonSerializer.Serialize(students);
                     File.WriteAllText("students.json", json);
                    Students studentUpdate = students.Find(s => s.Id == id);
                    if (studentUpdate != null)
                    {
                        Console.Write("Enter New Name: ");
                        studentUpdate.Name = Console.ReadLine();
                        Console.Write("Enter New Age: ");
                        studentUpdate.Age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter New Number: ");
                        studentUpdate.Number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Student Updated Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter Student ID: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    string json = JsonSerializer.Serialize(students);
                    File.WriteAllText("students.json", json);
                    Students studentDelete = students.Find(s => s.Id == deleteId);
                    if (studentDelete != null)
                    {
                        students.Remove(studentDelete);
                        Console.WriteLine("Student Deleted Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found.");
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }
    }

