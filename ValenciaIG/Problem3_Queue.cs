using System;
using System.Collections.Generic;


class Problem3_Queue
{

    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

    static void Main()
    {
        bool over = false;
        while (over == false)
        {
            Console.WriteLine("\n============================\nStudent Request Queue\n============================\n1. Add Request\n2. View Pending Requests\n3. Process Request\n4. Exit");
            Console.Write("\nEnter Here: ");
            string UserChoice = Console.ReadLine();

            switch (UserChoice)
            {
                case "1":
                    AddRequest();
                    break;
                case "2":
                    ViewRequests();
                    break;
                case "3":
                    ProcessRequest();
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
    static void AddRequest()
    {
        StudentRequest request = new StudentRequest();
        Console.Write("Enter Student Number: ");
        request.StudentNumber = Console.ReadLine();
        Console.Write("Enter Student Name: ");
        request.StudentName = Console.ReadLine();
        Console.WriteLine("\nRequest Types:\n1. Certificate of Enrollment\n2. Student ID\n3. Transcript Request");
        Console.Write("Choose Request Type: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        bool isValid = true;
        switch (choice)
        {
            case 1:
                request.RequestType = "Certificate of Enrollment";
                break;
            case 2:
                request.RequestType = "Student ID";
                break;
            case 3:
                request.RequestType = "Transcript Request\n";
                break;
            default:
                Console.WriteLine("\nInvalid request!!!");
                isValid = false;
                break;
        }
        if (isValid)
        {
            requestQueue.Enqueue(request);
            Console.WriteLine("Request added successfully!!!");
        }
    }
    static void ViewRequests()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("There are no pending requests.");
        }
        else
        {
            Console.WriteLine("\n===== REQUESTS =====");
            int number = 1;
            foreach (StudentRequest request in requestQueue)
            {
                Console.WriteLine($"{number}. {request.StudentName} ({request.RequestType})");
                number++;
            }

        }
    }
    static void ProcessRequest()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("There are no pending requests.");
        }
        else
        {
            StudentRequest request = requestQueue.Dequeue();
            Console.WriteLine($"\nProcessing Request: {request.StudentName} ({request.RequestType})\nRequest processed!!!");
        }
    }
}
