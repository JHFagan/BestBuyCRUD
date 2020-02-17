using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;


namespace BestBuyCRUD
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<Product> GetAllProducts(IDbConnection conn)
        {
            return _connection.Query<Product>("SELECT * FROM Products;").ToList();
        }
        public void CreateProduct(string name, int price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES (@prodName, @prodPrice, @prodID);",
                new { prodName = name  , prodPrice = price , prodID = categoryID });
        }

        public void UpdateProduct(int pID , int price, string name)
        {
            _connection.Execute("UPDATE Products SET Name = @prodName, Price = @prodPrice "
                + "WHERE ProductID = @prodID;",
                new { prodID = pID, prodPrice = price, prodName = name });
        }

        public void DeleteProduct (int prodID)
        {
            _connection.Execute("DELETE FROM Products WHERE ProductID = @pID;",
                new { pID = prodID });
        }
    }
}
