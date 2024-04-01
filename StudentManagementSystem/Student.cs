using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Class { get; set; }
        public List<string> Subjects { get; set; }
        public Dictionary<string, int> Marks { get; set; }
        public string Address { get; set; }
        public List<string> Hobbies { get; set; }
        public DateTime AddedDateTime { get; set; }

        public Student(string firstName, string middleName, string lastName, int age, int rollNo, string clas, List<string> subjects, Dictionary<string, int> marks, string address, List<string> hobbies)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            RollNo = rollNo;
            Class = clas;
            Subjects = subjects;
            Marks = marks;
            Address = address;
            Hobbies = hobbies;
            AddedDateTime = DateTime.Now;
        }
    }

    class StudentManagementSystem
    {
        private static List<Student> students = new List<Student>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nStudent Management System Menu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Get All Students");
                Console.WriteLine("3. Filter Students");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        //GetAllStudents();
                        break;
                    case "3":
                        //FilterStudents();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void AddStudent()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Enter Middle Name (optional): ");
            string middleName = Console.ReadLine()!;

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Roll Number: ");
            int rollNo = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Class: ");
            string clas = Console.ReadLine()!;

            List<string> subjects = new List<string>();
            string subject;
            do
            {
                Console.Write("Enter Subject (or leave blank to finish): ");
                subject = Console.ReadLine()!.Trim();
                if (!string.IsNullOrEmpty(subject))
                {
                    subjects.Add(subject);
                }
            } while (!string.IsNullOrEmpty(subject));

            Dictionary<string, int> marks = new Dictionary<string, int>();
            foreach (string sub in subjects)
            {
                Console.Write($"Enter Marks for {sub}: ");
                int mark = int.Parse(Console.ReadLine()!);
                marks.Add(sub, mark);
            }
            Console.Write("Enter Address: ");
            string address = Console.ReadLine()!;
            List<string> hobbies = new List<string>();
            string hobby;
            int hobbyCount = 0;
            do
            {
                Console.Write("Enter Hobby {hobbyCount + 1} (or leave blank to finish): ");
                hobby = Console.ReadLine()!.Trim();
                if (!string.IsNullOrEmpty(hobby))
                {
                    hobbies.Add(hobby);
                    hobbyCount++;
                }
            } while (hobbyCount < 7 && !string.IsNullOrEmpty(hobby));

            Student student = new Student(firstName, middleName, lastName, age, rollNo, clas, subjects, marks, address, hobbies);
            students.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        private static void GetAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found in the system.");
                return;
            }

            Console.WriteLine("\nAll Students:");
            foreach (Student student in students)
            {
                Console.WriteLine($"\nFirst Name: {student.FirstName}");
                Console.WriteLine($"Middle Name: {student.MiddleName ?? "N/A"}"); // Null-conditional operator for optional middle name
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Age: {student.Age}");
                Console.WriteLine($"Roll Number: {student.RollNo}");
                Console.WriteLine($"Class: {student.Class}");

                Console.WriteLine("Subjects:");
                foreach (string subject in student.Subjects)
                {
                    Console.WriteLine($"- {subject}");
                }

                Console.WriteLine("Marks:");
                foreach (KeyValuePair<string, int> mark in student.Marks)
                {
                    Console.WriteLine($"- {mark.Key}: {mark.Value}");
                }

                Console.WriteLine($"Address: {student.Address}");

                Console.WriteLine("Hobbies:");
                if (student.Hobbies.Count > 0)
                {
                    for (int i = 0; i < student.Hobbies.Count; i++)
                    {
                        Console.WriteLine($"- {student.Hobbies[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("- No hobbies listed.");
                }

                Console.WriteLine($"Added Date Time: {student.AddedDateTime}");
                Console.WriteLine("-----------------------");
            }
        }

            private static void FilterStudents()
            {
                Console.WriteLine("\nFilter Students By:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Class");
                Console.WriteLine("3. Subjects");
                Console.WriteLine("4. Address");
                Console.WriteLine("5. Hobbies");
                Console.WriteLine("6. Added Date Time");
                Console.WriteLine("7. Back to Main Menu");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FilterByName();
                        break;
                    case "2":
                        FilterByClass();
                        break;
                    case "3":
                        FilterBySubjects();
                        break;
                    case "4":
                        FilterByAddress();
                        break;
                    case "5":
                        FilterByHobbies();
                        break;
                    case "6":
                        FilterByAddedDateTime();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            private static void FilterByName()
            {
                Console.Write("Enter student name (first, middle, or last name): ");
                string name = Console.ReadLine();

                List<Student> filteredStudents = students.FindAll(student =>
                    student.FirstName.ToLower().Contains(name.ToLower()) ||
                    (student.MiddleName != null && student.MiddleName.ToLower().Contains(name.ToLower())) ||
                    student.LastName.ToLower().Contains(name.ToLower()));

                DisplayFilteredStudents(filteredStudents);
            }

            private static void FilterByClass()
            {
                Console.Write("Enter class name: ");
                string clas = Console.ReadLine();

                List<Student> filteredStudents = students.FindAll(student => student.Class == clas);

                DisplayFilteredStudents(filteredStudents);
            }

            private static void FilterBySubjects()
            {
                Console.Write("Enter subject name: ");
                string subject = Console.ReadLine();

                List<Student> filteredStudents = students.FindAll(student => student.Subjects.Contains(subject));

                DisplayFilteredStudents(filteredStudents);
            }

            private static void FilterByAddress()
            {
                Console.Write("Enter address keyword (e.g., street name, city): ");
                string keyword = Console.ReadLine();

                List<Student> filteredStudents = students.FindAll(student => student.Address.ToLower().Contains(keyword.ToLower()));

                DisplayFilteredStudents(filteredStudents);
            }

            private static void FilterByHobbies()
            {
                Console.Write("Enter hobby name: ");
                string hobby = Console.ReadLine();

                List<Student> filteredStudents = students.FindAll(student => student.Hobbies.Contains(hobby));

                DisplayFilteredStudents(filteredStudents);
            }

            private static void FilterByAddedDateTime()
            {
                Console.WriteLine("Filter by:");
                Console.WriteLine("1. Students added before a specific date");
                Console.WriteLine("2. Students added after a specific date");
                Console.WriteLine("3. Students added between two dates");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter date (YYYY-MM-DD): ");
                        DateTime beforeDate = DateTime.Parse(Console.ReadLine());
                        List<Student> filteredStudents = students.FindAll(student => student.AddedDateTime < beforeDate);
                        DisplayFilteredStudents(filteredStudents);
                        break;
                    case "2":
                        Console.Write("Enter date (YYYY-MM-DD): ");
                        DateTime afterDate = DateTime.Parse(Console.ReadLine());
                        filteredStudents = students.FindAll(student => student.AddedDateTime > afterDate);
                        DisplayFilteredStudents(filteredStudents);
                        break;
                    case "3":
                        Console.Write("Enter start date (YYYY-MM-DD): ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter end date (YYYY-MM-DD): ");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());
                        filteredStudents = students.FindAll(student => student.AddedDateTime >= startDate && student.AddedDateTime <= endDate);
                        DisplayFilteredStudents(filteredStudents);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }

            private static void DisplayFilteredStudents(List<Student> filteredStudents)
            {
                if (filteredStudents.Count == 0)
                {
                    Console.WriteLine("No students found matching the criteria.");
                    return;
                }

                Console.WriteLine("\nFiltered Students:");
           
            foreach (Student student in students)
            {
                Console.WriteLine($"\nFirst Name: {student.FirstName}");
                Console.WriteLine($"Middle Name: {student.MiddleName ?? "N/A"}"); 
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Age: {student.Age}");
                Console.WriteLine($"Roll Number: {student.RollNo}");
                Console.WriteLine($"Class: {student.Class}");

                Console.WriteLine("Subjects:");
                foreach (string subject in student.Subjects)
                {
                    Console.WriteLine($"- {subject}");
                }

                Console.WriteLine("Marks:");
                foreach (KeyValuePair<string, int> mark in student.Marks)
                {
                    Console.WriteLine($"- {mark.Key}: {mark.Value}");
                }

                Console.WriteLine($"Address: {student.Address}");

                Console.WriteLine("Hobbies:");
                if (student.Hobbies.Count > 0)
                {
                    for (int i = 0; i < student.Hobbies.Count; i++)
                    {
                        Console.WriteLine($"- {student.Hobbies[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("- No hobbies listed.");
                }

                Console.WriteLine($"Added Date Time: {student.AddedDateTime}");
                Console.WriteLine("-----------------------");
            }
        }
    }
}
