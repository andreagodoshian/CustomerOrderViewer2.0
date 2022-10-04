using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer2._0.Repos
{
    internal class CustomerOrderCmd
    {
        private string _connection;
        public CustomerOrderCmd(string conn)
        {
            conn = _connection;
        }

        public void Upsert(int customerOrderId, int customerId, int itemId, string userId)
        {
            var sprocUpsert = "CustomerOrderDetail_Upsert";

            var dataTable = new DataTable();
            dataTable.Columns.Add("CustomerOrderId", typeof(int));
            dataTable.Columns.Add("CustomerId", typeof(int));
            dataTable.Columns.Add("ItemId", typeof (int));
            dataTable.Rows.Add(customerOrderId, customerId, itemId);

            using (SqlConnection sqlConn = new SqlConnection(_connection))
            {
                sqlConn.Execute(sprocUpsert, new { @customerOrderType = dataTable.AsTableValuedParameter("CustomerOrderType"), @UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public void Delete(int customerOrderId, string userId)
        {
            var sprocDelete = "CustomerOrderDetail_Delete";

            using (SqlConnection sqlConn = new SqlConnection(_connection))
            {
                sqlConn.Execute(sprocDelete, new { @CustomerOrderId = customerOrderId, @UserId = userId }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public IList<Models.CustomerOrderDetailModel> GetList()
        {
            List<Models.CustomerOrderDetailModel> customerOrderDetails = new List<Models.CustomerOrderDetailModel>();

            var sProc = "CustomerOrderDetail_GetList";

            using (SqlConnection sqlConn = new SqlConnection(_connection))
            {
                customerOrderDetails = sqlConn.Query<Models.CustomerOrderDetailModel>(sProc).ToList();
            }
            return customerOrderDetails;
        }
    }
}
