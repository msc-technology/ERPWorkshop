using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    public class SqlBulkPersister : IContainerPersisterService
    {
        DataTable table;
        Guid current;
        public void BeginPersistence()
        {
            table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("TransactionID", typeof(Guid));
            table.Columns.Add("ContainerCode", typeof(string));
            table.Columns.Add("ContainerType", typeof(string));
            table.Columns.Add("HireDate", typeof(string));
            current = Guid.NewGuid();
        }

        public void EndPersistence()
        {
            using (var conn = OpenConnection())
            using (var copybulk = new SqlBulkCopy(conn))
            {
                copybulk.DestinationTableName = "dbo.ContainerMart";
                copybulk.WriteToServer(table);
                var cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.InsertContainers";
                cmd.Parameters.AddWithValue("@TransacionId", current);
                cmd.ExecuteNonQuery();
            }
        }

        public void Persist(string containerCode, string containerType, DateTime hireDate)
        {
            table.Rows.Add(null,current,containerCode,containerType,hireDate);
        }
        SqlConnection OpenConnection()
        {
            var conn = new SqlConnection("data source=.;user=sa;password=wry6WeR56_P?;Initial Catalog=Container");
            conn.Open();
            return conn;
        }
    }
}
