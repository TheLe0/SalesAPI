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
        public static List<Product> ListAll()
        {
            List<Product> _list = new List<Product>();

            string query = @"
                SELECT 
                    P.SKU,
                    P.NAME,
                    W.LOCALITY,
	                W.QUANTITY,
	                W.TYPE
                FROM 
                    PRODUCT P
                LEFT OUTER JOIN
	                WAREHOUSE W
		                ON W.SKU = P.SKU;
            ";

            using (var connection = new SqlConnection(Configuration.GetInstance().GetConnectionString()))
            {
                var productList = connection.Query<Product>(query).ToList();
            }

            return _list;
        }
    }
}
