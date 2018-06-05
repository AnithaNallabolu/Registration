using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Registration.Controllers
{
    public class CompanyController : ApiController
    {
        // GET: api/Company
        public IEnumerable<Company> Get()
        {
            var service = new CompanyService();
            return service.GetAll();
        }

        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Company
        public void Post(Company company)
        {
            var service = new CompanyService();
            service.Add(company);
        }

        // PUT: api/Company/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Company/5
        public void Delete(int id)
        {
        }
    }
}
