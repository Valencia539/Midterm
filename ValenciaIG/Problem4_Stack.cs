using System;
using System.Collections.Generic;
class Problem4_Stack
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    struct Operation
    {
        public string Action;
        public string StudentNumber;
        public string StudentName;
    }

    static Student[] ArrayOfStudents = new Student[10];
    static int studentCount=0;
    
    static Stack<Operation> HistoryOfOperation = new Stack<Operation>();
    static void AddStudent()
    {   
        if(studentCount>=10){Console.WriteLine("\nThere cannot be more than 10 students!!!");}
        else
        {
            Console.Write("\nEnter Student Number: ");
            string newStudentNumber = Console.ReadLine();
            for(int i = 0; i < studentCount; i++)
            {
                if (ArrayOfStudents[i].StudentNumber==newStudentNumber)
                {
                    Console.WriteLine("Student Number Already Exists!!!");
                    return;
                }
            }
            Student student = new Student();
            student.StudentNumber = newStudentNumber;
            Console.Write("Enter Name of Student: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter Program of Student: ");
            student.Program = Console.ReadLine();
            Console.Write("Enter Year Level of Student: ");
            student.YearLevel = Convert.ToInt32(Console.ReadLine());

            Operation operation = new Operation
            {
                Action = "Added",
                StudentNumber = ArrayOfStudents[studentCount].StudentNumber,
                StudentName = ArrayOfStudents[studentCount].Name
            };
            HistoryOfOperation.Push(operation);
        
            ArrayOfStudents[studentCount] = student;
            Console.WriteLine("\nStudent Added!!!");
            studentCount++;
        }
    }

    static void DisplayAll()
    {   
        if(studentCount==0){Console.WriteLine("\nThere are no students");}
        else
        {
            for(int i = 0; i<studentCount; i++)
            {   
                Console.WriteLine($"Student Number: {ArrayOfStudents[i].StudentNumber}");
                Console.WriteLine($"Name: {ArrayOfStudents[i].Name}");
                Console.WriteLine($"Program: {ArrayOfStudents[i].Program}");
                Console.WriteLine($"Year Level: {ArrayOfStudents[i].YearLevel}\n");
            }
        }
    }

    static void SearchStudent()
    {   
        if(studentCount==0){Console.WriteLine("\nThere are no students");}
        else{
            Console.Write("\nEnter Student Number: ");
            string searchFor = Console.ReadLine();
            bool isFound = false;
            for(int i = 0; i < studentCount; i++)
            {
                if (ArrayOfStudents[i].StudentNumber==searchFor)
                {
                    Console.WriteLine("Student Found!!!\n");
                    Console.WriteLine($"Student Number: {ArrayOfStudents[i].StudentNumber}");
                    Console.WriteLine($"Name: {ArrayOfStudents[i].Name}");
                    Console.WriteLine($"Program: {ArrayOfStudents[i].Program}");
                    Console.WriteLine($"Year Level: {ArrayOfStudents[i].YearLevel}");
                    isFound = true;
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine("\nStudent Not Found!!!");
            }
        } 
    }
    static void DeleteStudent()
    {   
        if(studentCount==0){Console.WriteLine("\nThere are no students");}
        else
        {
            Console.Write("\nEnter Student Number: ");
            string searchFor = Console.ReadLine();
            bool isFound = false;
            for(int i = 0; i< studentCount; i++)
            {
                if (ArrayOfStudents[i].StudentNumber == searchFor)
                {
                    Operation operation = new Operation
                    {
                        Action = "Deleted",
                        StudentNumber = ArrayOfStudents[i].StudentNumber,
                        StudentName = ArrayOfStudents[i].Name
                    };
                HistoryOfOperation.Push(operation);
                    ArrayOfStudents[i].StudentNumber="";
                    ArrayOfStudents[i].Name="";
                    ArrayOfStudents[i].Program="";
                    ArrayOfStudents[i].YearLevel=0;
                    studentCount--;
                    Console.WriteLine("\nStudent Deleted!!!\n");
                    isFound = true;
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine("\nStudent Not Found!!!");
            }
        }
        
    }
    static void UpdateStudent()
    {   
        if(studentCount==0){Console.WriteLine("\nThere are no students");}
        else
        {
            Console.Write("\nEnter Student Number: ");
            string searchFor = Console.ReadLine();
            bool isFound = false;
            for(int i = 0; i<= studentCount; i++)
            {
                if (ArrayOfStudents[i].StudentNumber==searchFor)
                {
                    Console.Write("Enter Name of Student: ");
                    ArrayOfStudents[i].Name = Console.ReadLine();
                    Console.Write("Enter Program of Student: ");
                    ArrayOfStudents[i].Program = Console.ReadLine();
                    Console.Write("Enter Year Level of Student: ");
                    ArrayOfStudents[i].YearLevel = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("\nStudent Updated!!!");
                    Operation operation = new Operation
                    {
                        Action = "Updated",
                        StudentNumber = ArrayOfStudents[i].StudentNumber,
                        StudentName = ArrayOfStudents[i].Name
                    };
                HistoryOfOperation.Push(operation);
                    isFound = true;
                    break;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine("\nStudent Not Found!!!");
            }
        }
    }
    static void OperationMenu()
    {
        int choice;
        bool over = false;
        while (!over)
        {
            Console.WriteLine("\n===== OPERATION HISTORY =====\n1. View Operation History\n2. View Last Operation\n3. Remove Last Operation\n4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewOperationHistory();
                    break;
                case 2:
                    ViewLastOperation();
                    break;
                case 3:
                    RemoveLastOperation();
                    break;
                case 4:
                    Console.WriteLine("\nReturning to main menu...");
                    over = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid choice!!!");
                    break;
            }
        } 
    }
    
    static void ViewOperationHistory()
    {
        if (HistoryOfOperation.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
        }
        else
        {
            Console.WriteLine("\n===== OPERATION HISTORY =====");

            int counter = 1;

            foreach (Operation operation in HistoryOfOperation)
            {
                Console.WriteLine($"{counter}. {operation.Action} {operation.StudentName}");
                counter++;
            }
        }
    }
    static void ViewLastOperation()
    {
        if (HistoryOfOperation.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
        }
        else
        {
            Operation operation = HistoryOfOperation.Peek();
            Console.WriteLine($"\nLast Operation: {operation.Action} {operation.StudentName}");
        } 
    }
    static void RemoveLastOperation()
    {
        if (HistoryOfOperation.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
        }
        else
        {
            HistoryOfOperation.Pop();

            Console.WriteLine("Last operation removed successfully!");
        }
    }
    static void Main()
    {
        bool over = false;
        while (over == false)
        {
            Console.WriteLine("\n============================\nStudent Record Management\n============================\n1. Add Student\n2. Display All Students\n3. Search Student\n4. Update Student\n5. Delete Student\n6. Operation Menu\n7. Exit");
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
                    UpdateStudent();
                    break;
                case "5":
                    DeleteStudent();
                    break;
                case "6":
                    OperationMenu();
                    break;
                case "7":
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