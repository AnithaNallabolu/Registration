using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Services.Controllers
{
    public class EmployeeController : ApiController
    {
        private Iemployeeservicee _service;
        public EmployeeController( Iemployeeservicee employeeservice)
        {
            _service = employeeservice;
        }
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return _service.GetAllEmp();
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public void Post(Employee employee)
        {
            _service.AddEmp(employee);
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
