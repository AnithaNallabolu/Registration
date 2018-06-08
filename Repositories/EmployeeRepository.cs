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
    public class EmployeeRepository
    {
        public void AddEmp( Employee employee)
        {
          string connectionString = @"server=(local)\SQLExpress;database=Registration;integrated Security=SSPI;";

            string query = "INSERT INTO dbo.Employee (Ename,CompanyId) " +
                   "VALUES (@Ename,@CompId) ";
            // create connection and command
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // define parameters and their values
                cmd.Parameters.Add("@Ename", SqlDbType.NVarChar, 100).Value = employee.Ename;
                cmd.Parameters.Add("@CompId", SqlDbType.Int).Value = employee.CompId;
                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        public List<Employee> GetAllEmp()
        {
            string connectionString = @"server=(local)\SQLExpress;database=Registration;integrated Security=SSPI;";
            DataTable employeeTable;
            var employeeList = new List<Employee>();
            // create connection and command
            using (SqlConnection _con = new SqlConnection(connectionString))
            {
                string queryStatement = "SELECT * FROM dbo.Employee ORDER BY EmpId";
                              
                    using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                    {
                        employeeTable = new DataTable("Employee");

                        SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                        _con.Open();
                        _dap.Fill(employeeTable);
                        _con.Close();
                    }
                }
            foreach (DataRow row in employeeTable.Rows)
                {
                    var selectedEmployee = new Employee();
                    selectedEmployee.EmpId = Convert.ToInt32(row["EmpId"]);
                    selectedEmployee.Ename = row["Ename"].ToString();
                    selectedEmployee.CompId = Convert.ToInt32(row["CompanyId"]);
                 employeeList.Add(selectedEmployee);
                }
            
            return employeeList;
        }

}
}
