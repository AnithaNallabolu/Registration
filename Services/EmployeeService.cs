using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService :Iemployeeservicee
    {
        public void AddEmp(Employee employee)
        {
            var repo = new EmployeeRepository();
            repo.AddEmp(employee);

        }
        public List<Employee> GetAllEmp()
        {
            var repo = new EmployeeRepository();
            return repo.GetAllEmp();
        }

    }
}
