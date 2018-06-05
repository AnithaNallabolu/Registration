using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CompanyService
    {
        public void Add(Company company)
        {
            var repo = new CompanyRepository();
            repo.Add(company) ;
        }

        public List<Company> GetAll()
        {
            var repo = new CompanyRepository();
            return repo.GetAll();
        }
    }
}
