using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CompanyRepository
    {
        public void Add(Company company)
        {
            string connectionString = @"server=(local)\SQLExpress;database=Registration;integrated Security=SSPI;";

            
                string query = "INSERT INTO dbo.Company (Name) " +
                   "VALUES (@Name) ";

                // create connection and command
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = company.Name;
                    // open connection, execute INSERT, close connection
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }            
        }

        public List<Company> GetAll()
        {
            string connectionString = @"server=(local)\SQLExpress;database=Registration;integrated Security=SSPI;";
            DataTable customerTable;
            var companyList = new List<Company>();
            // create connection and command
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * FROM dbo.Company ORDER BY CompanyId";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    customerTable = new DataTable("Company");

                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(customerTable);
                    _con.Close();
                }
            }
            foreach (DataRow row in customerTable.Rows)
            {
                var selectedCompany = new Company();
                selectedCompany.Name = row["Name"].ToString();
                selectedCompany.CompanyId = Convert.ToInt32(row["CompanyId"]);
                companyList.Add(selectedCompany);
            }
            return companyList;
        }                       
        }
}
