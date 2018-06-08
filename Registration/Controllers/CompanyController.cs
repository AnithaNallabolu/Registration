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
    [RoutePrefix("api")]
    public class CompanyController : ApiController
    {
        private Icompanyservice _service;
        public CompanyController( Icompanyservice companyservice )
        {
            _service = companyservice;
        }
        [Route("companies/mine")]
        [HttpGet]
        public IEnumerable<Company> Get()
        {
           return _service.GetAll();
        }

        // GET: api/Company/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Company
        public void Post(Company company)
        {
            _service.Add(company);
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
