using System.Collections.Generic;
using System.Linq;
using Infosys.DBFirstCore.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Infosys.DBFirstCore.DataAccessLayer
{
    public class QuickKartRepository
    {
        QuickKartDbContext context;
        public QuickKartRepository()
        {
            context = new QuickKartDbContext();
        }

        public List<Category> GetAllCategories()
        {
            // LINQ query
            var categoriesList = (from category in context.Categories
                                  orderby category.CategoryId
                                  select category).ToList(); 
            return categoriesList;
        }

        // Filer product by Id
        public List<Product> GetProductsOnCategoryId(byte categoryId)
        {
            List<Product> products = null;

            try
            {
                products = context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
            catch(Exception ex)
            {
                products = null;
            }

            return products;
        }

        // Filter product by category
        public Product FilterProducts(byte categoryId)
        {
            Product prod = null;
            try
            {
                prod = context.Products.Where(p => p.CategoryId == categoryId).OrderByDescending(p => p.Price).LastOrDefault();
            }
            catch (Exception ex)
            {
                prod = null;
            }
            return prod;
        }

        // Filter product by pattern
        public List<Product> FilterProductsUsingLikes(string pattern)
        {
            List<Product> lstproduct = null;
            try
            {
                lstproduct = context.Products.Where(p => EF.Functions.Like(p.ProductName, pattern)).ToList();
            }
            catch (Exception ex)
            {
                lstproduct = null;
            }
            return lstproduct;
        }

        // Add Product using AddRange()
        public bool AddProductUsingAddRange(params Product[] products)
        {
            bool stats = false;
            try
            {
                context.AddRange(products);
                context.SaveChanges();
                stats = true;
            }
            catch (Exception)
            {
                stats = false;
            }
            return stats;
        }

        // Update Category
        public bool UpdateCategory(byte categoryId, string newCategoryName)
        {
            bool status = false;
            Category category = context.Categories.Find(categoryId);

            try
            {
                if (category != null)
                {
                    category.CategoryName = newCategoryName;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch(Exception)
            {
                status = false;
            }

            return status;
        }

        // Update Product
        public int UpdateProduct(string productId, decimal price)
        {
            int status = -1;
            try
            {
                Product prod = context.Products.Find(productId);
                prod.Price = price;
                using (var newContext = new QuickKartDbContext())
                {
                    newContext.Products.Update(prod);
                    newContext.SaveChanges();
                    status = 1;
                }
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }

        // Update Multiple Product by Range
        public int UpdateProductUsingUpdateRange(byte categoryId, int quantityProcured)
        {
            int status = -1;
            try
            {
                List<Product> productList = context.Products.Where(p => p.CategoryId == categoryId).ToList();
                foreach(var product in productList)
                {
                    product.QuantityAvailable = quantityProcured;
                }
                using(var newContext = new QuickKartDbContext())
                {
                    newContext.UpdateRange(productList);
                    newContext.SaveChanges();
                    status = 1;
                }
            }
            catch (Exception)
            {
                status = -99;
            }
            return status;
        }

        // Delete Product
        public bool DeleteProduct(string productId)
        {
            bool status = false;
            try
            {
                Product product = context.Products.Find(productId);
                if(product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {
                status = false;
            }          
            return status;
        }

        // Delete Product using range
        public bool DeleteProductUsingRange(string subString)
        {
            bool status = false;
            try
            {
                var delteProduct = context.Products.Where(p => p.ProductName.Contains(subString)); 
                context.Products.RemoveRange(delteProduct);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
