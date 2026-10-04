using System;
using System.Collections.Generic;
class Problem2_Dictionary
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    static Dictionary<string, Student> ArrayOfStudents = new Dictionary<string, Student>();
    static void AddStudent()
    {   
        if(ArrayOfStudents.Count>=10){Console.WriteLine("\nThere cannot be more than 10 students!!!");}
        else
        {
            
            Console.Write("\nEnter Student Number: ");
            string newStudentNumber = Console.ReadLine();
            if(ArrayOfStudents.ContainsKey(newStudentNumber))
            {
                Console.WriteLine("Student Number Already Exists!!!");
            }
            else
            {
                Student student = new Student();
                student.StudentNumber = newStudentNumber;
                Console.Write("Enter Name of Student: ");
                student.Name = Console.ReadLine();
                Console.Write("Enter Program of Student: ");
                student.Program = Console.ReadLine();
                Console.Write("Enter Year Level of Student: ");
                student.YearLevel = Convert.ToInt32(Console.ReadLine());
        
                ArrayOfStudents.Add(newStudentNumber, student);
                Console.WriteLine("\nStudent Added!!!");
            }
        }
    }

    static void DisplayAll()
    {
        if(ArrayOfStudents.Count==0){Console.WriteLine("\nThere are no students");}
        else
        {
            foreach(Student student in ArrayOfStudents.Values)
            {
                Console.WriteLine($"Student Number: {student.StudentNumber}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Program: {student.Program}");
                Console.WriteLine($"Year Level: {student.YearLevel}\n");
            }
        }
    }

    static void SearchStudent()
    {   
        if(ArrayOfStudents.Count==0){Console.WriteLine("\nThere are no students");}
        else{
            Console.Write("\nEnter Student Number: ");
            string searchFor = Console.ReadLine();
            if (ArrayOfStudents.ContainsKey(searchFor))
            {
                Console.WriteLine("Student Found!!!\n");
                Console.WriteLine($"Student Number: {ArrayOfStudents[searchFor].StudentNumber}");
                Console.WriteLine($"Name: {ArrayOfStudents[searchFor].Name}");
                Console.WriteLine($"Program: {ArrayOfStudents[searchFor].Program}");
                Console.WriteLine($"Year Level: {ArrayOfStudents[searchFor].YearLevel}");
            }
            else
            {
                Console.WriteLine("\nStudent Not Found!!!");
            }
        } 
    }
    static void Main()
    {
        bool over = false;
        while (over == false)
        {
            Console.WriteLine("\n============================\nStudent Record Management\n============================\n1. Add Student\n2. Display All Students\n3. Search Student\n4. Exit");
            Console.Write("\nEnter Here: ");
            string UserChoice = Console.ReadLine();

            switch (UserChoice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    DisplayAll();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    over = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid Input!!!");
                    break;
            }
        }
        Console.Write("\nProgram Exited.");
    }
}