using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentManagementSystem
{
    // =========================
    // INTERFACE
    // =========================
    public interface IStudentOperations
    {
        void AddStudent(Student student);
        void RemoveStudent(int id);
        Student FindStudent(int id);
        void DisplayAllStudents();
    }

    // =========================
    // ABSTRACT CLASS
    // =========================
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        protected Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public virtual void DisplayInformation()
        {
            Console.WriteLine($"ID   : {Id}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Age  : {Age}");
        }
    }

    // =========================
    // STUDENT CLASS
    // INHERITANCE
    // =========================
    public class Student : Person
    {
        public string Course { get; set; }
        public double Marks { get; set; }

        public Student(
            int id,
            string name,
            int age,
            string course,
            double marks)
            : base(id, name, age)
        {
            Course = course;
            Marks = marks;
        }

        // POLYMORPHISM
        public override void DisplayInformation()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Student ID : {Id}");
            Console.WriteLine($"Name       : {Name}");
            Console.WriteLine($"Age        : {Age}");
            Console.WriteLine($"Course     : {Course}");
            Console.WriteLine($"Marks      : {Marks}");
            Console.WriteLine($"Grade      : {GetGrade()}");
            Console.WriteLine("--------------------------------");
        }

        public string GetGrade()
        {
            if (Marks >= 90)
                return "A+";
            else if (Marks >= 80)
                return "A";
            else if (Marks >= 70)
                return "B";
            else if (Marks >= 60)
                return "C";
            else if (Marks >= 50)
                return "D";
            else
                return "F";
        }
    }

    // =========================
    // GENERIC REPOSITORY
    // =========================
    public class Repository<T> where T : Person
    {
        private readonly List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(int id)
        {
            T item = items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                items.Remove(item);
            }
        }

        public T Find(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return items;
        }

        public int Count()
        {
            return items.Count;
        }
    }

    // =========================
    // STUDENT MANAGER
    // =========================
    public class StudentManager : IStudentOperations
    {
        private readonly Repository<Student> repository;

        public StudentManager()
        {
            repository = new Repository<Student>();
        }

        public void AddStudent(Student student)
        {
            if (repository.Find(student.Id) != null)
            {
                Console.WriteLine("Student ID already exists.");
                return;
            }

            repository.Add(student);

            Console.WriteLine(
                "Student added successfully."
            );
        }

        public void RemoveStudent(int id)
        {
            Student student = repository.Find(id);

            if (student == null)
            {
                Console.WriteLine(
                    "Student not found."
                );

                return;
            }

            repository.Remove(id);

            Console.WriteLine(
                "Student removed successfully."
            );
        }

        public Student FindStudent(int id)
        {
            return repository.Find(id);
        }

        public void DisplayAllStudents()
        {
            List<Student> students =
                repository.GetAll();

            if (students.Count == 0)
            {
                Console.WriteLine(
                    "No students available."
                );

                return;
            }

            foreach (Student student in students)
            {
                student.DisplayInformation();
            }
        }

        // =========================
        // LINQ SEARCH
        // =========================
        public void SearchByName(string name)
        {
            var result = repository
                .GetAll()
                .Where(s =>
                    s.Name.Contains(
                        name,
                        StringComparison.OrdinalIgnoreCase
                    ))
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine(
                    "No matching students found."
                );

                return;
            }

            foreach (var student in result)
            {
                student.DisplayInformation();
            }
        }

        // =========================
        // SORT BY MARKS
        // =========================
        public void SortByMarks()
        {
            var sortedStudents = repository
                .GetAll()
                .OrderByDescending(s => s.Marks)
                .ToList();

            Console.WriteLine(
                "\nStudents Sorted By Marks:"
            );

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(
                    $"{student.Name} - {student.Marks}"
                );
            }
        }

        // =========================
        // SHOW TOPPER
        // =========================
        public void ShowTopper()
        {
            Student topper = repository
                .GetAll()
                .OrderByDescending(s => s.Marks)
                .FirstOrDefault();

            if (topper == null)
            {
                Console.WriteLine(
                    "No students available."
                );

                return;
            }

            Console.WriteLine(
                "\nTopper Information:"
            );

            topper.DisplayInformation();
        }

        // =========================
        // AVERAGE MARKS
        // =========================
        public void ShowAverageMarks()
        {
            if (repository.Count() == 0)
            {
                Console.WriteLine(
                    "No students available."
                );

                return;
            }

            double average =
                repository
                    .GetAll()
                    .Average(s => s.Marks);

            Console.WriteLine(
                $"Average Marks: {average:F2}"
            );
        }

        // =========================
        // SAVE DATA TO FILE
        // =========================
        public void SaveToFile()
        {
            string filePath =
                "students.txt";

            using (StreamWriter writer =
                new StreamWriter(filePath))
            {
                foreach (
                    Student student
                    in repository.GetAll())
                {
                    writer.WriteLine(
                        $"{student.Id}," +
                        $"{student.Name}," +
                        $"{student.Age}," +
                        $"{student.Course}," +
                        $"{student.Marks}"
                    );
                }
            }

            Console.WriteLine(
                "Data saved successfully."
            );
        }

        // =========================
        // LOAD DATA FROM FILE
        // =========================
        public void LoadFromFile()
        {
            string filePath =
                "students.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine(
                    "File does not exist."
                );

                return;
            }

            string[] lines =
                File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                try
                {
                    string[] data =
                        line.Split(',');

                    int id =
                        int.Parse(data[0]);

                    string name =
                        data[1];

                    int age =
                        int.Parse(data[2]);

                    string course =
                        data[3];

                    double marks =
                        double.Parse(data[4]);

                    if (repository.Find(id) == null)
                    {
                        Student student =
                            new Student(
                                id,
                                name,
                                age,
                                course,
                                marks
                            );

                        repository.Add(student);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Error: {ex.Message}"
                    );
                }
            }

            Console.WriteLine(
                "Data loaded successfully."
            );
        }

        public int GetStudentCount()
        {
            return repository.Count();
        }
    }

    // =========================
    // MAIN PROGRAM
    // =========================
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentManager manager =
                new StudentManager();

            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine(
                    "================================"
                );

                Console.WriteLine(
                    "     STUDENT MANAGEMENT SYSTEM"
                );

                Console.WriteLine(
                    "================================"
                );

                Console.WriteLine(
                    "1. Add Student"
                );

                Console.WriteLine(
                    "2. Remove Student"
                );

                Console.WriteLine(
                    "3. Find Student"
                );

                Console.WriteLine(
                    "4. Display All Students"
                );

                Console.WriteLine(
                    "5. Search By Name"
                );

                Console.WriteLine(
                    "6. Sort By Marks"
                );

                Console.WriteLine(
                    "7. Show Topper"
                );

                Console.WriteLine(
                    "8. Show Average Marks"
                );

                Console.WriteLine(
                    "9. Save Data"
                );

                Console.WriteLine(
                    "10. Load Data"
                );

                Console.WriteLine(
                    "11. Show Student Count"
                );

                Console.WriteLine(
                    "12. Exit"
                );

                Console.WriteLine(
                    "================================"
                );

                Console.Write(
                    "Enter your choice: "
                );

                string input =
                    Console.ReadLine();

                try
                {
                    int choice =
                        int.Parse(input);

                    switch (choice)
                    {
                        case 1:

                            Console.Write(
                                "Enter Student ID: "
                            );

                            int id =
                                int.Parse(
                                    Console.ReadLine()
                                );

                            Console.Write(
                                "Enter Student Name: "
                            );

                            string name =
                                Console.ReadLine();

                            Console.Write(
                                "Enter Age: "
                            );

                            int age =
                                int.Parse(
                                    Console.ReadLine()
                                );

                            Console.Write(
                                "Enter Course: "
                            );

                            string course =
                                Console.ReadLine();

                            Console.Write(
                                "Enter Marks: "
                            );

                            double marks =
                                double.Parse(
                                    Console.ReadLine()
                                );

                            Student student =
                                new Student(
                                    id,
                                    name,
                                    age,
                                    course,
                                    marks
                                );

                            manager.AddStudent(
                                student
                            );

                            break;


                        case 2:

                            Console.Write(
                                "Enter Student ID: "
                            );

                            int removeId =
                                int.Parse(
                                    Console.ReadLine()
                                );

                            manager.RemoveStudent(
                                removeId
                            );

                            break;


                        case 3:

                            Console.Write(
                                "Enter Student ID: "
                            );

                            int searchId =
                                int.Parse(
                                    Console.ReadLine()
                                );

                            Student found =
                                manager.FindStudent(
                                    searchId
                                );

                            if (found != null)
                            {
                                found.DisplayInformation();
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Student not found."
                                );
                            }

                            break;


                        case 4:

                            manager
                                .DisplayAllStudents();

                            break;


                        case 5:

                            Console.Write(
                                "Enter name to search: "
                            );

                            string searchName =
                                Console.ReadLine();

                            manager
                                .SearchByName(
                                    searchName
                                );

                            break;


                        case 6:

                            manager
                                .SortByMarks();

                            break;


                        case 7:

                            manager
                                .ShowTopper();

                            break;


                        case 8:

                            manager
                                .ShowAverageMarks();

                            break;


                        case 9:

                            manager
                                .SaveToFile();

                            break;


                        case 10:

                            manager
                                .LoadFromFile();

                            break;


                        case 11:

                            Console.WriteLine(
                                $"Total Students: " +
                                $"{manager.GetStudentCount()}"
                            );

                            break;


                        case 12:

                            running = false;

                            Console.WriteLine(
                                "Program exited."
                            );

                            break;


                        default:

                            Console.WriteLine(
                                "Invalid choice."
                            );

                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(
                        "Please enter valid input."
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Unexpected Error: " +
                        $"{ex.Message}"
                    );
                }

                if (running)
                {
                    Console.WriteLine(
                        "\nPress any key to continue..."
                    );

                    Console.ReadKey();
                }
            }
        }
    }
}