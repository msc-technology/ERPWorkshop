using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerSearch
{
    class ContainerService : IContainerService
    {
        public ContainerModel[] FetchPage(int offset, int pageSize, string toSearch)
        {
            throw new NotImplementedException();

        }
        

        public int GetCount(string toSearch)
        {
            throw new NotImplementedException();
        }
        SqlConnection OpenConnection()
        {
            var conn = new SqlConnection("data source=.;user=sa;password=wry6WeR56_P?;Initial Catalog=Container");
            conn.Open();
            return conn;
        }
    }
}
