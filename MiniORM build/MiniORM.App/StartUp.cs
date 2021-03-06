﻿namespace MiniORM.App
{
    using Data;
    using Data.Entities;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var connectionString = "Server=.;Database=MiniORM;Integrated Security=true";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
