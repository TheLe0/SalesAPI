using API.Entities;
using API.Utils;

using Dapper;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace API.DAO
{
    public class ProductDAO
    {
        public static bool CreateRecord(Product product)
        {
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"INSERT INTO PRODUCT(SKU, NAME) VALUES(@Sku, @Name)";
                connection.Execute(sql, new { product.Sku, product.Name });
            }

            return true;
        }

        public static bool Delete(int sku)
        {
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"DELETE FROM PRODUCT WHERE SKU = @Sku";
                connection.Execute(sql, new {Sku = sku });
            }

            return true;
        }

        public static bool Exists(int sku)
        {
            var rows = 0;
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"SELECT COUNT(SKU) FROM PRODUCT WHERE SKU = @Sku";
                rows = connection.QuerySingle<int>(sql, new { Sku = sku });
            }

            return rows > 0;
        }
    }
}
