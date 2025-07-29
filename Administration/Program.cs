using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AdministrationAPI;
using Administration;

namespace AmbulanceHRAdministration
{   
    public enum EmployeeType
    {
        Doctor,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }

    class Program
    {
        static void Main(string[] args)
        {

            decimal TotalSalaries = 0;

            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            Console.WriteLine($"Total Annual Salaries with Bonuses: {employees.Sum(e => e.Salary)}");
            
            Console.ReadKey();
        }

        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee doctor1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Doctor, 1, "Uros", "Markovic", 85000);
            

            employees.Add(doctor1);


            IEmployee doctor2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Doctor, 2, "Milena", "Stankovic", 120000);


            employees.Add(doctor2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Milan", "Stankovic", 140000);


            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Jovana", "Stankovic", 180000);

            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Mina", "Markovic", 200000);

        }
    }

    public class Doctor : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.2m); }
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.3m); }

    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.4m); }

    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.5m); }

    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                case EmployeeType.Doctor:
                    employee = FactoryPattern<IEmployee,Doctor>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee,HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee,DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }

            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;
            } else
            {
                 throw new NullReferenceException();
            }

                return employee;
        }
    }
}
