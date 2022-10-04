using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer2._0.Repos
{
    internal class ItemCommand
    {
        private string _connection;
        public ItemCommand(string conn)
        {
            conn = _connection;
        }
        public IList<Models.ItemModel> GetList()
        {
            List<Models.ItemModel> items = new List<Models.ItemModel>();

            var sProc = "Item_GetList";

            using (SqlConnection sqlConn = new SqlConnection(_connection))
            {
                items = sqlConn.Query<Models.ItemModel>(sProc).ToList();
            }
            return items;
        }
    }
}
