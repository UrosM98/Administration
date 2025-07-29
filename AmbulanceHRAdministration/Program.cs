using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationAPI;

namespace AmbulanceHRAdministration
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee doctor1 = new Doctor
            {
                
            };
        }
    }

    public class Doctor : EmployeeBase
    {
        
    }

    public class HeadOfDepartment : EmployeeBase
    {

    }

    public class DeputyHeadMaster : EmployeeBase
    {

    }

    public class HeadMaster : EmployeeBase
    {

    }
}
