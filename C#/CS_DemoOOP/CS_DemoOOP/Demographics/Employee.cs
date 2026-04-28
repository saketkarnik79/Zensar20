using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Demographics
{
    internal class Employee: Person
    {
        public int Age 
        {
            get 
            {
                // // You can add auth logic here if needed
                return DateTime.Now.Year - DateOfBirth.Year; 
            }
        }

        public int DeptNo { get; set; }

        public decimal Salary { get; set; }

        public Employee(): base() // Call the base class constructor (constructor chaining)
        {
            DeptNo = 0;
            Salary = 0;
        }

        public Employee(int id, string name, DateTime dateOfBirth, int deptNo, decimal salary): base(id, name, dateOfBirth) // Call the base class constructor (constructor chaining)
        {
            DeptNo = deptNo;
            Salary = salary;
        }

        public override string DisplayInfo()
        {
            return $"{base.DisplayInfo()}, Age: {Age}, DeptNo: {DeptNo}, Salary: {Salary}";
        }
    }
}
