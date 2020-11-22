using System;
using System.Collections.Generic;
using System.IO;
using PersonsLibrary;

namespace AnstalldasBank
{
    public class Program
    {
        public static bool running = true;
        private static List<Persons> _persons = new List<Persons>();
        private const string _path = "HanteringAvAnstallda.csv";

        public static void Main(string[] args)
        {
            AllPersons();
            Console.Title = "Employee Manager(Trial Version)";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the trial version of the Employee Manager with limited features");
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
            Console.WriteLine("1.Edit Employee(yourself)");
            Console.WriteLine("2.Save");
            Console.WriteLine("3.Exit.");
            Console.Write("\r\nSelect with numbers and click enter. PS. Don't forget to save.\n");

            switch (Console.ReadLine())
            {
                case "1":
                    EditPerson();
                    return true;
                case "2":
                    Save();
                    return true;
                case "3":
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
                Console.WriteLine("Id: " + everyPerson.EmployeeId + "Password: " + everyPerson.Password + "\nName: " + everyPerson.Name);
                i++;
            }
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
                    var person = new Persons(employeeNumber, rows[2], rows[3], isAdmin);
                    _persons.Add(person);

                }
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
    }
}