using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer2._0.Repos
{
    internal class CustomerCommand
    {
        private string _connection;
        public CustomerCommand(string conn)
        {
            conn = _connection;
        }
        public IList<Models.CustomerModel> GetList()
        {
            List<Models.CustomerModel> customers = new List<Models.CustomerModel>();

            var sProc = "Customer_GetList";

            using (SqlConnection sqlConn = new SqlConnection(_connection))
            {
                customers = sqlConn.Query<Models.CustomerModel>(sProc).ToList();
            }
            return customers;
        }
    }
}
