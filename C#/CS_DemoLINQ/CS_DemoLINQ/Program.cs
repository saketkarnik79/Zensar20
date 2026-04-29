using System.Linq;

namespace CS_DemoLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQDemo1();
            //LINQDemo2();
            //LINQToObjectsDemo1();
            //LINQToObjectsDemo2();
            //LINQToObjectsDemo3();
            LINQToObjectsDemo4();

            Console.WriteLine();
            Console.WriteLine("Program finished. Press any key to exit...");
            Console.ReadKey();
        }

        private static void LINQToObjectsDemo1()
        {
            var employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
                new Employee { Id = 3, Name = "Charlie", Department = "HR", Salary = 55000 },
                new Employee { Id = 4, Name = "David", Department = "IT", Salary = 65000 },
                new Employee { Id = 5, Name = "Eve", Department = "Finance", Salary = 70000 }
            };

            // Using method syntax
            //var highPaidITEmployees = employees
            //                    .Where(e => e.Department == "IT" && e.Salary > 60000)
            //                    .Select(e => new { e.Name, e.Salary });

            // Using query syntax
            var highPaidITEmployees = from e in employees
                                     where e.Department == "IT" && e.Salary > 60000
                                     select new { e.Name, e.Salary };

            foreach (var e in highPaidITEmployees)
            {
                Console.WriteLine($"Name: {e.Name}, Salary: {e.Salary}");
            }
        }

        private static void LINQToObjectsDemo2()
        {
            var employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
                new Employee { Id = 3, Name = "Charlie", Department = "HR", Salary = 55000 },
                new Employee { Id = 4, Name = "David", Department = "IT", Salary = 65000 },
                new Employee { Id = 5, Name = "Eve", Department = "Finance", Salary = 70000 }
            };

            // Using method syntax
            //var grouped = employees
            //                .GroupBy(e => e.Department);

            // Using query syntax
            var grouped = from e in employees
                          group e by e.Department into deptGroup
                          select deptGroup;

            // Iterating over groups and print results
            foreach (var group in grouped)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var e in group)
                {
                    Console.WriteLine($"\tName: {e.Name}, Salary: {e.Salary}");
                }
                Console.WriteLine(); // Blank line for separation & readability
            }
        }

        private static void LINQToObjectsDemo3()
        {
            var employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
                new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
                new Employee { Id = 3, Name = "Charlie", Department = "HR", Salary = 55000 },
                new Employee { Id = 4, Name = "David", Department = "IT", Salary = 65000 },
                new Employee { Id = 5, Name = "Eve", Department = "Finance", Salary = 70000 }
            };

            // Aggregations
            var totalSalary = employees.Sum(e => e.Salary);
            var avgSalary = employees.Average(e => e.Salary);
            var minSalary = employees.Min(e => e.Salary);
            var maxSalary = employees.Max(e => e.Salary);
            var numberOfEmployees = employees.Count();

            Console.WriteLine($"Total Salary: {totalSalary}");
            Console.WriteLine($"Average Salary: {avgSalary}");
            Console.WriteLine($"Minimum Salary: {minSalary}");
            Console.WriteLine($"Maximum Salary: {maxSalary}");
            Console.WriteLine($"Number of Employees: {numberOfEmployees}");
        }

        private static void LINQToObjectsDemo4()
        {
            var departments = new List<Department>()
            {
                new Department { Id = 1, Name = "HR" },
                new Department { Id = 2, Name = "IT" },
                new Department { Id = 3, Name = "Finance" },
                new Department { Id = 4, Name = "Marketing" }
            };

            var employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Alice", Department = "1", Salary = 50000 },
                new Employee { Id = 2, Name = "Bob", Department = "2", Salary = 60000 },
                new Employee { Id = 3, Name = "Charlie", Department = "1", Salary = 55000 },
                new Employee { Id = 4, Name = "David", Department = "2", Salary = 65000 },
                new Employee { Id = 5, Name = "Eve", Department = "3", Salary = 70000 },
                new Employee { Id = 6, Name = "Frank", Department = "5", Salary = 45000 } // No matching department
            };

            // Inner Join using query syntax
            //var employeeDepartments = from e in employees
            //                          join d in departments on e.Department equals d.Id.ToString()
            //                          select new { EmployeeName = e.Name, DepartmentName = d.Name };

            // Inner Join using method syntax
            //var employeeDepartments = employees
            //                            .Join(departments,
            //                                  e => e.Department,
            //                                  d => d.Id.ToString(),
            //                                  (e, d) => new { EmployeeName = e.Name, DepartmentName = d.Name });

            // Left Outer Join using query syntax
            //var employeeDepartments = from e in employees
            //                          join d in departments on e.Department equals d.Id.ToString() into deptGroup
            //                          from d in deptGroup.DefaultIfEmpty()
            //                          select new { EmployeeName = e.Name, DepartmentName = d != null ? d.Name : "No Department" };

            // Left Outer Join using method syntax
            //var employeeDepartments = employees
            //                            .GroupJoin(departments,
            //                                       e => e.Department,
            //                                       d => d.Id.ToString(),
            //                                       (e, deptGroup) => new { Employee = e, Departments = deptGroup })
            //                            .SelectMany(ed => ed.Departments.DefaultIfEmpty(), (ed, d) => new
            //                            {
            //                                EmployeeName = ed.Employee.Name,
            //                                DepartmentName = d != null ? d.Name : "No Department"
            //                            });

            // Right Outer Join using query syntax
            //var employeeDepartments = from d in departments
            //                          join e in employees on d.Id.ToString() equals e.Department into empGroup
            //                          from e in empGroup.DefaultIfEmpty()
            //                          select new { EmployeeName = e != null ? e.Name : "No Employee", DepartmentName = d.Name };

            // Right Outer Join using method syntax
            //var employeeDepartments = departments
            //                            .GroupJoin(employees,
            //                                       d => d.Id.ToString(),
            //                                       e => e.Department,
            //                                       (d, empGroup) => new { Department = d, Employees = empGroup })
            //                            .SelectMany(de => de.Employees.DefaultIfEmpty(), (de, e) => new
            //                            {
            //                                EmployeeName = e != null ? e.Name : "No Employee",
            //                                DepartmentName = de.Department.Name
            //                            });

            // Full Outer Join using query syntax
            //var employeeDepartments = (from e in employees
            //                           join d in departments on e.Department equals d.Id.ToString() into deptGroup
            //                           from d in deptGroup.DefaultIfEmpty()
            //                           select new { EmployeeName = e.Name, DepartmentName = d != null ? d.Name : "No Department" })
            //                          .Union
            //                          (from d in departments
            //                           join e in employees on d.Id.ToString() equals e.Department into empGroup
            //                           from e in empGroup.DefaultIfEmpty()
            //                           select new { EmployeeName = e != null ? e.Name : "No Employee", DepartmentName = d.Name });

            // Full Outer Join using method syntax
            var employeeDepartments = employees
                                        .GroupJoin(departments,
                                                   e => e.Department,
                                                   d => d.Id.ToString(),
                                                   (e, deptGroup) => new { Employee = e, Departments = deptGroup })
                                        .SelectMany(ed => ed.Departments.DefaultIfEmpty(), (ed, d) => new
                                        {
                                            EmployeeName = ed.Employee.Name,
                                            DepartmentName = d != null ? d.Name : "No Department"
                                        })
                                        .Union(
                                            departments
                                            .GroupJoin(employees,
                                                       d => d.Id.ToString(),
                                                       e => e.Department,
                                                       (d, empGroup) => new { Department = d, Employees = empGroup })
                                            .SelectMany(de => de.Employees.DefaultIfEmpty(), (de, e) => new
                                            {
                                                EmployeeName = e != null ? e.Name : "No Employee",
                                                DepartmentName = de.Department.Name
                                            })
                                        );



            // Display results
            foreach (var ed in employeeDepartments)
            {
                Console.WriteLine($"Employee: {ed.EmployeeName}, Department: {ed.DepartmentName}");
            }
        }

        private static void LINQDemo1()
        {
            var numbers = new List<int>() { 10, 25, 3, 80, 42, 7 };

            var result = numbers
                            .Where(n => n > 20)
                            .OrderByDescending(n => n)
                            .Select(n => n * 2);
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }

        private static void LINQDemo2()
        {
            var numbers = new List<int>() { 10, 25, 3, 80, 42, 7 };

            var result = from n in numbers
                         where n > 20
                         orderby n descending
                         select n * 2;

            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }
    }
}
