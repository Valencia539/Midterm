using System;

class Problem1_Array
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    static Student[] ArrayOfStudents = new Student[10];
    static int studentCount=0;

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
                    for (int j = i; j < studentCount - 1; j++)
                    {
                    ArrayOfStudents[j] = ArrayOfStudents[j + 1];
                    }
                    studentCount--;
                    ArrayOfStudents[studentCount] = new Student();
                    
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
            for(int i = 0; i< studentCount; i++)
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
    static void Main()
    {
        bool over = false;
        while (over == false)
        {
            Console.WriteLine("\n============================\nStudent Record Management\n============================\n1. Add Student\n2. Display All Students\n3. Search Student\n4. Update Student\n5. Delete Student\n6. Exit");
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
