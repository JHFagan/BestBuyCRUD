using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Linq;

namespace BestBuyCRUD
{
    interface IProductRepository
    {
        
        public void GetAllProducts()
        {
        }

        public void CreateProduct(string name, int price, int categoryID)
        { 
        }

        public void UpdateProduct(int pID, int price, string name)
        { 
        }
    }
}
