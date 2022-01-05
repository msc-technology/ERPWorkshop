using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateContainersBatch
{
    public class SqlNaivePersister : IContainerPersisterService
    {
        Dictionary<string, int> typeMap = new Dictionary<string, int>();
        public void BeginPersistence()
        {
            string query = "SELECT * FROM dbo.ContainerType";
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    typeMap[reader.GetString(reader.GetOrdinal("ContainerTypeCode"))] =
                        reader.GetInt32(reader.GetOrdinal("ContainerTypeId"));
                }
            }
        }

        public void EndPersistence()
        {
           
        }

        public void Persist(string containerCode, string containerType, DateTime hireDate)
        {
            var insert = "INSERT INTO Container(ContainerCode,ContainerTypeId,HireDate) VALUES (@code,@type,@hire)";
            if (!typeMap.ContainsKey(containerType))
            {
                throw new Exception("invalid type");
            }
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = insert;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("code",containerCode));
                cmd.Parameters.Add(new SqlParameter("type",typeMap[containerType]));
                cmd.Parameters.Add(new SqlParameter("hire", hireDate));
                var affected = cmd.ExecuteNonQuery();
                if (affected != 1)
                    throw new Exception("data insertion failed without database exception");
            }
        }

        SqlConnection OpenConnection()
        {
            var conn = new SqlConnection("data source=.;user=sa;password=wry6WeR56_P?;Initial Catalog=Container");
            conn.Open();
            return conn;
        }
    }
}
