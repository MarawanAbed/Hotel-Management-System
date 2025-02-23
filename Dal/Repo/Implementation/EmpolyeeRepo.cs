using Dal.Entities;
using Dal.Repo.Abstraction;
using HotelManagementSystem.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repo.Implementation
{
    public class EmpolyeeRepo : IEmpolyeeRepo
    {
        private readonly ApplicationDbContext _context;


        public EmpolyeeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
           
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<Employee> GetAllEmpolyees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Position = employee.Position;
                emp.Salary = employee.Salary;
                _context.SaveChanges();
            }
        }
    }
}
