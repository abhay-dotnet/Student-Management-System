# Student Management System in C#

## 📌 Project Overview

The **Student Management System** is a console-based application developed in **C#** to demonstrate and practice important programming concepts and advanced features of the C# language. The project provides a simple way to manage student records while applying real-world software development principles such as **Object-Oriented Programming (OOP), interfaces, inheritance, abstraction, polymorphism, generics, collections, LINQ, exception handling, and file handling**.

This project was created as a learning and practice project to strengthen my understanding of **C# and .NET development** and to demonstrate how different programming concepts can work together in a single application.

---

## 🚀 Features

The application provides the following features:

* ➕ **Add Student** – Add a new student with ID, name, age, course, and marks.
* ❌ **Remove Student** – Remove an existing student using their unique ID.
* 🔍 **Find Student** – Search for a specific student using their ID.
* 📋 **Display All Students** – View complete information about all registered students.
* 🔎 **Search by Name** – Find students based on their name using LINQ.
* 📊 **Sort by Marks** – Sort students according to their marks in descending order.
* 🏆 **Find Topper** – Identify the student with the highest marks.
* 📈 **Calculate Average Marks** – Calculate the average marks of all students.
* 💾 **Save Data to File** – Store student information in a text file.
* 📂 **Load Data from File** – Retrieve previously saved student records.
* 🔢 **Display Student Count** – Show the total number of registered students.
* 🚪 **Exit Application** – Safely close the application.

---

## 🧠 Concepts Demonstrated

### 1. Object-Oriented Programming

The project follows OOP principles to organize the application into reusable and maintainable classes.

### 2. Encapsulation

Student-related data and operations are organized inside appropriate classes, making the code easier to manage and maintain.

### 3. Inheritance

The `Student` class inherits common properties and behavior from the abstract `Person` class.

```csharp
public class Student : Person
```

This allows common properties such as `Id`, `Name`, and `Age` to be reused.

### 4. Abstraction

The `Person` class is defined as an abstract class to provide a common base for people-related entities.

### 5. Interface

The `IStudentOperations` interface defines the operations that a student management system should support, such as adding, removing, finding, and displaying students.

### 6. Polymorphism

The `Student` class overrides the `DisplayInformation()` method from the base `Person` class, demonstrating method overriding and runtime polymorphism.

### 7. Generics

A generic `Repository<T>` class is used to manage different types of objects while maintaining type safety and code reusability.

### 8. Collections

The project uses `List<T>` to store and manage student records dynamically.

### 9. LINQ

LINQ is used for efficient data querying and processing, including:

* Searching students by name
* Sorting students by marks
* Finding the topper
* Calculating average marks

Examples include:

```csharp
Where()
OrderByDescending()
FirstOrDefault()
Average()
```

### 10. Exception Handling

The application uses `try-catch` blocks to handle invalid user input and unexpected runtime errors without crashing the application.

### 11. File Handling

Student data can be saved to and loaded from a text file using:

```csharp
StreamWriter
File.ReadAllLines()
```

This provides basic data persistence for the application.

### 12. Menu-Driven Application

The application uses a continuous `while` loop and `switch` statement to provide an interactive menu that allows users to select different operations.

---

## 🏗️ Project Structure

The project is divided into multiple components:

* **Person** – Abstract base class containing common person-related properties.
* **Student** – Derived class containing student-specific information and grade calculation.
* **IStudentOperations** – Interface defining student management operations.
* **Repository<T>** – Generic repository responsible for storing and managing data.
* **StudentManager** – Handles business logic and student-related operations.
* **Program** – Contains the `Main()` method and provides the console-based user interface.

---

## 📊 Student Information

Each student record contains:

* Student ID
* Student Name
* Age
* Course
* Marks
* Automatically calculated Grade

The grade is calculated based on the student's marks.

For example:

* **90+** → A+
* **80–89** → A
* **70–79** → B
* **60–69** → C
* **50–59** → D
* **Below 50** → F

---

## 🔄 Application Workflow

The application starts by displaying a menu with multiple options. The user can select an operation such as adding a student, searching for a student, viewing all records, sorting students, or calculating the average marks.

The program continues running until the user selects the **Exit** option.

The basic workflow is:

```text
Start Application
       ↓
Display Main Menu
       ↓
Select Operation
       ↓
Perform Selected Operation
       ↓
Display Result
       ↓
Return to Main Menu
       ↓
Exit Application
```

---

## 🛠️ Technologies Used

* **Programming Language:** C#
* **Application Type:** Console Application
* **Framework:** .NET
* **Concepts:** OOP, Generics, LINQ, Collections
* **Data Storage:** Text File
* **Development Environment:** Visual Studio

---

## 🎯 Learning Objectives

The main objective of this project is to gain practical experience with C# programming and understand how multiple concepts can be combined to create a functional application.

Through this project, I practiced:

* Writing clean and structured C# code
* Applying OOP principles
* Creating reusable classes and interfaces
* Working with generic classes
* Managing data using collections
* Using LINQ for data querying
* Handling exceptions
* Reading and writing files
* Building menu-driven console applications
* Implementing basic CRUD operations

---

## 🔮 Future Improvements

The project can be further enhanced by adding:

* SQL Server database integration
* Entity Framework Core
* ASP.NET Core Web API
* User authentication and authorization
* Student attendance management
* Subject-wise marks
* Advanced reporting
* GUI or web-based interface
* REST API integration
* Dependency Injection
* Repository and Service Layer architecture

---

## 📌 Conclusion

This **Student Management System** is a practical C# project designed to demonstrate fundamental and advanced programming concepts in a single application. It combines **Object-Oriented Programming, interfaces, inheritance, polymorphism, generics, collections, LINQ, exception handling, and file handling** to create a structured and interactive student management solution.

This project helped me improve my understanding of **C# programming and .NET development** while providing a strong foundation for building more advanced applications in the future.
