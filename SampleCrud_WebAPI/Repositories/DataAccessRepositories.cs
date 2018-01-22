using SampleCrud_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleCrud_WebAPI.Repositories
{
    public class DataAccess : IDataAccess<Product, int>
    {
        Models.AppContext context;
        public DataAccess(Models.AppContext appContext)
        {
            context = appContext;
        }
        public int AddProduct(Product product)
        {
            context.Add(product);
            return context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            int res = 0;
            var product = context.Products.FirstOrDefault(b => b.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                res = context.SaveChanges();
            }
            return res;
        }

        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public int UpdateProduct(int id, Product product)
        {
            int res = 0;
            var prod = context.Products.Find(id);
            if (prod != null)
            {
                prod.ProductName = product.ProductName;
                prod.Code = product.Code;
                prod.Price = product.Price;
                prod.ModifiedDate = product.ModifiedDate;

                res = context.SaveChanges();
            }
            return res;
        }
    }

    public interface IDataAccess<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetProducts();
        TEntity GetProduct(U id);
        int AddProduct(TEntity b);
        int UpdateProduct(U id, TEntity b);
        int DeleteProduct(U id);
    }
}
