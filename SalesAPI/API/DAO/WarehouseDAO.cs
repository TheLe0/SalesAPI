using API.Utils;
using API.Entities;

using Dapper;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace API.DAO
{
    public class WarehouseDAO
    {
        public static bool CreateRecord(Warehouse w, int sku)
        {
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"INSERT INTO WAREHOUSE(SKU, LOCALITY, QUANTITY, TYPE) VALUES(@Sku, @Locality, @Quantity, @Type)";
                connection.Execute(sql, new { Sku = sku, w.Locality, w.Quantity, w.Type });
            }

            return true;
        }

        public static bool Delete(int sku)
        {
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"DELETE FROM WAREHOUSE WHERE SKU = @Sku";
                connection.Execute(sql, new { Sku = sku });
            }

            return true;
        }

        public static List<Warehouse> Find(int sku)
        {
            List<Warehouse> list = new List<Warehouse>();

            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"SELECT LOCALITY, QUANTITY, TYPE FROM WAREHOUSE WHERE SKU = @Sku";

                list = connection.Query<Warehouse>(sql, new { Sku = sku }).ToList();
            }

            return list;
        }
    }
}
