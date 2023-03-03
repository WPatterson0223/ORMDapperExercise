using System;
using System.Data;
using Dapper;

namespace ORMDapper
{
	public class DapperProductRepository : IProductRepository
	{
        private readonly IDbConnection _connection;
		public DapperProductRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products(Name, Price, CategoryID) " +
                "VALUES(@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID});
        }

        public void UpdateProduct(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE productID = @productID;",
                new { productID = productID, newName = newName });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE productID = @productID;",
                new { productID = productID});
            _connection.Execute("DELETE FROM sales WHERE productID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM reviews WHERE productID = @productID;",
                new { productID = productID });
        }
    }
}

