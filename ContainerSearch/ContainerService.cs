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
            List<ContainerModel> thePage = new List<ContainerModel>();
            var query = "SELECT C.ContainerCode Code,T.ContainerTypeCode Type,c.HireDate Hire FROM dbo.Container C INNER JOIN ContainerType T ON T.ContainerTypeId=C.ContainerTypeID";
            if (!string.IsNullOrEmpty(toSearch))
            {
                query = query + " WHERE ContainerCode LIKE @search";
            }
            query += $" ORDER BY ContainerCode OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                if (!string.IsNullOrEmpty(toSearch))
                {
                    cmd.Parameters.Add(new SqlParameter("search", "%" + toSearch + "%"));
                }
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = new ContainerModel()
                    {
                        Code = reader.GetString(reader.GetOrdinal("Code")),
                        HireDate = reader.GetDateTime(reader.GetOrdinal("Hire")),
                        Type = reader.GetString(reader.GetOrdinal("Type"))

                    };
                    thePage.Add(item);
                }

            }
            return thePage.ToArray();
        }

        public int GetCount(string toSearch)
        {
            var query = "SELECT COUNT(*) FROM dbo.Container";
            if (!string.IsNullOrEmpty(toSearch))
            {
                query = query + " WHERE ContainerCode LIKE @search";
            }
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                if (!string.IsNullOrEmpty(toSearch))
                {
                    cmd.Parameters.Add(new SqlParameter("search", "%" + toSearch + "%"));
                }
                return  Convert.ToInt32(cmd.ExecuteScalar());
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
