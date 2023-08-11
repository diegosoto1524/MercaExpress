using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IProductRepo
    {
        Product GetProductById(int id);
        List <Product> GetAllProducts();
        bool CreateProduct (Product product);
        bool UpdateProduct (int id,Product product);
        bool DeleteProduct (int id);
        bool CheckIfProductExists(int id);
        double GetProductPrice (int id);


    }
}
