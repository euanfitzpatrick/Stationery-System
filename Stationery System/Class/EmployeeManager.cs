using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationery_System.Class
{
    public class EmployeeManager
    {
        public static Employee[] Employees
        {
            get
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Employees.csv";
                if (!File.Exists(path)) return null;
                List<Employee> employees = new List<Employee>();
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Employee employee = new Employee();
                    string[] parts = line.Split(';');
                    employee.EmployeeID = int.Parse(parts[0]);
                    employee.EmployeeName = parts[1];
                    employees.Add(employee);
                }
                return employees.ToArray();
            }
            set
            {
                string path = $"{AppDomain.CurrentDomain.BaseDirectory}Employees.csv";
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Employee employee in value)
                {
                    string line = $"{employee.EmployeeID};{employee.EmployeeName}";
                    stringBuilder.AppendLine(line);
                }
                File.WriteAllText(path, stringBuilder.ToString());
            }
        }

        public void AddEmployee(string employeeName)
        {
            Employee[] employeeArray = Employees;
            List<Employee> employees = employeeArray != null ? employeeArray.ToList() : new List<Employee>();
            if (!employees.Any(x => x.EmployeeName == employeeName))
            {
                Employee newEmployee = new Employee();
                int nextID = 1;
                if (employees.Any())
                {
                    nextID = employees.OrderBy(x => x.EmployeeID).Last().EmployeeID + 1;
                }
                newEmployee.EmployeeID = nextID;
                newEmployee.EmployeeName = employeeName;
                employees.Add(newEmployee);
            }
            Employees = employees.ToArray();
        }

        public Employee[] GetAllEmployees()
        {
            return Employees;
        }
    }
}
