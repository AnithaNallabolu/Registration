using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface Icompanyservice
    {
        void Add(Company company);
        List<Company> GetAll();
    }
}
