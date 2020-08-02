using API.Entities;
using API.Utils;

using Dapper;

using System.Data.SqlClient;

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

        public static bool Update(Product product)
        {
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"UPDATE PRODUCT SET NAME = @Name WHERE SKU = @Sku";
                connection.Execute(sql, new { product.Name, product.Sku });
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

        public static string Find(int sku)
        {
            string name;
            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var sql = @"SELECT NAME FROM PRODUCT WHERE SKU = @Sku";
                name = connection.QuerySingle<string>(sql, new { Sku = sku });
            }

            return name;
        }
    }
}
