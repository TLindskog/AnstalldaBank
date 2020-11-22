namespace PersonsLibrary
{
    class Persons
    {
        public Persons(int employeeId, string password, string name, string adress, bool adminOrEmployee)
        {
            EmployeeId = employeeId;
            Password = password;
            Name = name;
            Adress = adress;
            Admin = adminOrEmployee;
        }

        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public bool Admin { get; set; }

        public string ToCsv()
        {
            return $"{EmployeeId}, {Password}, {Name}, {Adress}, {Admin}";
        }

    }
}
//    //public class Persons
//    //{
//    //    public Persons(int employeeId, string password, string name, string adress, bool AdminOrEmployee)
//    //    {
//    //        EmployeeId = employeeId;
//    //        Password = password;
//    //        Name = name;
//    //        Adress = adress;
//    //        Admin = AdminOrEmployee;
//    //    }

//    //    //public int EmployeeId { get; set; }
//    //    //public string Password { get; set; }
//    //    //public string Name { get; set; }
//    //    //public string Adress { get; set; }
//    //    //public bool Admin { get; set; }

//    //    public string ToCsv()
//    //    {
//    //        return $"{EmployeeId}, {Password}, {Name}, {Adress}, {Admin}";
//    //    }
//    //}
//}