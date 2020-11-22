using System;
using System.Collections.Generic;
using System.IO;
using PersonsLibrary;

namespace AdminsBank
{
    public class Program
    {
        public static bool running = true;
        private static List<Persons> _persons = new List<Persons>();
        private const string _path = "HanteringAvAnstallda.csv";

        public static void Main(string[] args)
        {
            AllPersons();
            Console.Title = "Employee/Admin Manager(Trial Version)";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the trial version of the Employee/Admin Manager with limited features");
            Console.WriteLine("Purchase the Premium Plan for Full Version(only $9000.99 per year).\n\r");
            if (!File.Exists(_path))
            {
                using StreamWriter stream = File.CreateText(_path);
            }
            while (running)
            {
                running = MainMenu();
            }
        }
        public static bool MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Main Menu");
            Console.WriteLine("1.Print list over Employee/Admin");
            Console.WriteLine("2.Add Employee/Admin");
            Console.WriteLine("3.Edit Employee/Admin");
            Console.WriteLine("4.See Employees");
            Console.WriteLine("5.See Admins");
            Console.WriteLine("6.Change status of Employee/Admin");
            Console.WriteLine("7.Save");
            Console.WriteLine("8.Exit.");
            Console.Write("\r\nSelect with numbers and click enter. PS. Don't forget to save.\n");

            switch (Console.ReadLine())
            {
                case "1":
                    PrintListOfAll();
                    return true;
                case "2":
                    AddPerson();
                    return true;
                case "3":
                    EditPerson();
                    return true;
                case "4":
                    SeeEmployees();
                    return true;
                case "5":
                    SeeAdmins();
                    return true;
                case "6":
                    ChangeStatusOfPerson();
                    return true;
                case "7":
                    Save();
                    return true;
                case "8":
                    return false;
                default:
                    return true;
            }
        }
        public static void PrintListOfAll()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            var i = 0;
            foreach (var everyPerson in _persons)
            {
                Console.WriteLine("Id: " + everyPerson.EmployeeId + "\nPassword: " + everyPerson.Password + "\nName: " + everyPerson.Name + "\nAdmin?: " + everyPerson.Admin);
                i++;
            }
        }

        public static void EditPerson()
        {
            Console.Clear();
            PrintListOfAll();
            Console.WriteLine("\n\rSelect which person to edit:");
            //var id = int.Parse(Console.ReadLine());
            //_persons[id].Admin = !Admin[id].Admin;
            Console.WriteLine("Info edited.\n\r");

        }

        public static void AllPersons()
        {
            {
                using StreamReader sr = File.OpenText(_path);
                string row;
                while ((row = sr.ReadLine()) != null)
                {
                    var rows = row.Split(", ");
                    var isAdmin = bool.Parse(rows[4]);
                    var employeeNumber = Int32.Parse(rows[0]);
                    var person = new Persons(employeeNumber, rows[1], rows[2], rows[3], isAdmin);
                    _persons.Add(person);

                }
            }
        }
        public static void AddPerson()
        {
            Console.Clear();

            Console.WriteLine("Enter Employee/Admin ID(numbers):");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            password = password.Trim();

            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            name = name.Trim();

            Console.WriteLine("Enter adress:");
            string adress = Console.ReadLine();
            adress = adress.Trim();

            Console.WriteLine("Enter true for Admins and false for Employee:");
            bool adminOrEmployee = Convert.ToBoolean(Console.ReadLine());

            var person = new Persons(employeeId, password, name, adress, adminOrEmployee);
            _persons.Add(person);
        }

        static void SeeAdmins()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Admins working here are:");
            var i = 0;

            foreach (var admins in _persons)
            {
                if (admins.Admin == true)
                {
                    Console.WriteLine("Id: " + admins.EmployeeId + "\nName: " + admins.Name + "\n\r");
                }
                i++;
            }
        }

        public static void ChangeStatusOfPerson()
        {
            Console.Clear();
            PrintListOfAll();
            Console.WriteLine("\n\rSelect which person to change status of:");
            var id = int.Parse(Console.ReadLine());
            _persons[id].Admin = !_persons[id].Admin;
            Console.WriteLine("This person has changed status.\n\r");

        }
        public static void Save()
        {
            using (StreamWriter stream = File.CreateText(_path))
            {
                foreach (var todo in _persons)
                {
                    stream.WriteLine(todo.ToCsv());
                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You saved.\n\r");
        }

        public static void SeeEmployees()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Employees working here are:");
            var i = 0;

            foreach (var employees in _persons)
            {
                if (employees.Admin == false)
                {
                    Console.WriteLine("Id: " + employees.EmployeeId + "\nName: " + employees.Name + "\n\r");
                }
                i++;
            }

        }
    }
}