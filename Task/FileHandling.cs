using System;
using System.IO;

namespace EmployeeFileManagement;

class Program
{
    private static readonly string filePath = "employees.txt";

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("===== Employee File Management =====");
            Console.WriteLine("1. Create/Write Employees");
            Console.WriteLine("2. Display Employees");
            Console.WriteLine("3. Add Employee");
            Console.WriteLine("4. Search Employee");
            Console.WriteLine("5. Update Employee");
            Console.WriteLine("6. Delete Employee");
            Console.WriteLine("7. File Information");
            Console.WriteLine("8. Delete File");
            Console.WriteLine("9. Exit");
            Console.Write("\nEnter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("\nInvalid input! Please enter a number between 1 and 9.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateFile();
                    break;
                case 2:
                    DisplayFiles();
                    break;
                case 3:
                    AppendEmployee();
                    break;
                case 4:
                    SearchEmployee();
                    break;
                case 5:
                    UpdateEmployee();
                    break;
                case 6:
                    DeleteEmployee();
                    break;
                case 7:
                    ShowFileInfo();
                    break;
                case 8:
                    DeleteFile();
                    break;
                case 9:
                    Console.WriteLine("\nExiting application. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice! Please choose between 1 and 9.");
                    break;
            }

            if (choice != 9)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }

        } while (choice != 9);
    }

    // 1. Create / Write File
    static void CreateFile()
    {
        string[] initialEmployees = {
            "101,Arun,IT,35000",
            "102,Divya,HR,30000",
            "103,Kumar,Finance,40000",
            "104,Priya,IT,45000",
            "105,Ravi,Sales,28000"
        };

        File.WriteAllLines(filePath, initialEmployees);
        Console.WriteLine("\nFile created and initial 5 employee records written successfully!");
    }

    // 2. Read / Display File
    static void DisplayFiles()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile does not exist! Please create the file first (Option 1).");
            return;
        }

        string[] records = File.ReadAllLines(filePath);
        if (records.Length == 0)
        {
            Console.WriteLine("\nThe employee file is currently empty.");
            return;
        }

        Console.WriteLine("\n--- Employee Records ---");
        Console.WriteLine("ID\tName\tDepartment\tSalary");
        Console.WriteLine("-----------------------------------");

        foreach (string line in records)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4)
            {
                Console.WriteLine($"{parts[0]}\t{parts[1]}\t{parts[2]}\t\t{parts[3]}");
            }
        }
    }

    // 3. Append Data (Add Employees)
    static void AppendEmployee()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile does not exist! Creating file with default records first.");
            CreateFile();
        }

        string[] newEmployees = {
            "106,Sneha,Marketing,32000",
            "107,Rahul,Operations,38000"
        };

        File.AppendAllLines(filePath, newEmployees);
        Console.WriteLine("\n2 new employees added successfully!");
    }

    // 4. Search Employee
    static void SearchEmployee()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile does not exist!");
            return;
        }

        Console.Write("\nEnter Employee ID to search: ");
        string searchId = Console.ReadLine()?.Trim();

        string[] records = File.ReadAllLines(filePath);
        bool found = false;

        foreach (string line in records)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4 && parts[0] == searchId)
            {
                Console.WriteLine("\nEmployee Found");
                Console.WriteLine($"ID: {parts[0]}");
                Console.WriteLine($"Name: {parts[1]}");
                Console.WriteLine($"Department: {parts[2]}");
                Console.WriteLine($"Salary: {parts[3]}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("\nEmployee Not Found");
        }
    }

    // 5. Update Employee
    static void UpdateEmployee()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile does not exist!");
            return;
        }

        Console.Write("\nEnter Employee ID to update: ");
        string updateId = Console.ReadLine()?.Trim();

        string[] records = File.ReadAllLines(filePath);
        bool found = false;

        for (int i = 0; i < records.Length; i++)
        {
            string[] parts = records[i].Split(',');
            if (parts.Length == 4 && parts[0] == updateId)
            {
                Console.Write($"Current Department ({parts[2]}). Enter new Department: ");
                string newDept = Console.ReadLine()?.Trim() ?? parts[2];

                Console.Write($"Current Salary ({parts[3]}). Enter new Salary: ");
                string newSalary = Console.ReadLine()?.Trim() ?? parts[3];

                // Reconstruct the updated line
                records[i] = $"{parts[0]},{parts[1]},{newDept},{newSalary}";
                found = true;
                break;
            }
        }

        if (found)
        {
            File.WriteAllLines(filePath, records);
            Console.WriteLine("\nEmployee record updated successfully!");
        }
        else
        {
            Console.WriteLine("\nEmployee Not Found!");
        }
    }

    // 6. Delete Employee
    static void DeleteEmployee()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile does not exist!");
            return;
        }

        Console.Write("\nEnter Employee ID to delete: ");
        string deleteId = Console.ReadLine()?.Trim();

        string[] records = File.ReadAllLines(filePath);
        var updatedRecords = new System.Collections.Generic.List<string>();
        bool found = false;

        foreach (string line in records)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 4 && parts[0] == deleteId)
            {
                found = true; // Skip adding this record back
                continue;
            }
            updatedRecords.Add(line);
        }

        if (found)
        {
            File.WriteAllLines(filePath, updatedRecords);
            Console.WriteLine("\nEmployee deleted successfully!");
        }
        else
        {
            Console.WriteLine("\nEmployee Not Found!");
        }
    }

    // 7. Check File Information
    static void ShowFileInfo()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile does not exist!");
            return;
        }

        Console.WriteLine("\n===== File Information =====");
        Console.WriteLine($"File Exists: {File.Exists(filePath)}");
        Console.WriteLine($"Creation Time: {File.GetCreationTime(filePath)}");
        Console.WriteLine($"Last Write Time: {File.GetLastWriteTime(filePath)}");
        Console.WriteLine($"File Attributes: {File.GetAttributes(filePath)}");
    }

    // 8. Delete the File
    static void DeleteFile()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine("\nFile 'employees.txt' has been successfully deleted.");
        }
        else
        {
            Console.WriteLine("\nFile does not exist to delete.");
        }
    }
}