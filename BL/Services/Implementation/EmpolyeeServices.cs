using BL.Services.Abstraction;
using Dal.Entities;
using Dal.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementation
{
    public class EmpolyeeServices : IEmpolyeeServices
    {
        private readonly IEmpolyeeRepo _empolyeeRepo;

        public EmpolyeeServices(IEmpolyeeRepo empolyeeRepo)
        {
            _empolyeeRepo = empolyeeRepo;
        }
        public void AddEmployee(Employee employee)
        {
            _empolyeeRepo.AddEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            _empolyeeRepo.DeleteEmployee(employeeId);
        }

        public List<Employee> GetAllEmpolyees()
        {

            return _empolyeeRepo.GetAllEmpolyees();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _empolyeeRepo.GetEmployeeById(employeeId);
        }

        public void UpdateEmployee(Employee employee)
        {
            _empolyeeRepo.UpdateEmployee(employee);
        }
    }
}
