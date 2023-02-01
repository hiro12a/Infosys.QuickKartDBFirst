using System;
using Infosys.DBFirstCore.DataAccessLayer;
using Infosys.DBFirstCore.DataAccessLayer.Models;

namespace Infosys.DBFirstCore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickKartRepository repository = new QuickKartRepository();
            var categories = repository.GetAllCategories();
            Console.WriteLine("------------------------------");
            Console.WriteLine("CategoryId\tCategoryName");
            Console.WriteLine("------------------------------");

            // Display all of the Category ID and Category name 
            foreach(var category in categories)
            {
                Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            }

            // Display product by category id
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Show Product by Category Id");
            Console.WriteLine("-----------------------------");
            byte categoryId = 1;
            List<Product> products = repository.GetProductsOnCategoryId(categoryId);

            if(products.Count == 0)
            {
                Console.WriteLine("No Products available under the category: " + categoryId);
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId","ProductName","CategoryId","Price","QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach(var product in products)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId,product.Price,product.QuantityAvailable);
                }
            }

            // Display product by category id
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Filter To The End of Product");
            Console.WriteLine("-----------------------------");
            Product prod = repository.FilterProducts(categoryId);

            if (products.Count == 0)
            {
                Console.WriteLine("No Products available under the category: " + categoryId);
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", prod.ProductId, prod.ProductName, prod.CategoryId, prod.Price, prod.QuantityAvailable);
            }

            // Display product by pattern
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Filter Product by Pattern");
            Console.WriteLine("-----------------------------");
            string pat = "BMW%";
            List<Product> lstProd = repository.FilterProductsUsingLikes(pat);
            if (lstProd.Count == 0)
            {
                Console.WriteLine("No Products available under the category: " + categoryId);
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (var product in lstProd)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
                }
            }

            /*// Add Products
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Product Details Added");
            Console.WriteLine("-----------------------------");
            Product productOne = new Product();
            productOne.ProductId = "P158";
            productOne.ProductName = "The Ship of Secrets - Geronimo Stilton";
            productOne.CategoryId = 8;
            productOne.Price = 450;
            productOne.QuantityAvailable = 10;

            Product productTwo = new Product();
            productTwo.ProductId = "P159";
            productTwo.ProductName = "101 Nursery Rhymes";
            productTwo.CategoryId = 8;
            productTwo.Price = 700;
            productTwo.QuantityAvailable = 10;
            bool prodResult = repository.AddProductUsingAddRange(productOne, productTwo);
            if (prodResult)
            {
                Console.WriteLine("Product Details added successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong. Try again");
            }*/

            // Update CategoryName by ID
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Update CategoryName by Id");
            Console.WriteLine("-----------------------------");
            bool updateResult = repository.UpdateCategory(8, "Sationary");
            if(updateResult == true)
            {
                Console.WriteLine("CategoryName has been updated");
            }
            else
            {
                Console.WriteLine("Something went wrong, CategoryName has not been updated");
            }

            /*// Update Product Price by Id
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Update Product Price by Id");
            Console.WriteLine("-----------------------------");
            int status = repository.UpdateProduct("P159", 666);
            if(status == 1)
            {
                Console.WriteLine("Product Price Updated Successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong, try again!");
            }*/

            // Update Multiple Product by Id
            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("Update Multiple Product Quantity with the same CategoryId");
            Console.WriteLine("----------------------------------------------------------");
            int prodStatus = repository.UpdateProductUsingUpdateRange(1, 15);
            if(prodStatus == 1)
            {
                Console.WriteLine("Products updated successfully");
            }
            else
            {
                Console.WriteLine("Something went wrong, try again");
            }

            /*// Delete Product
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("Delete Product");
            Console.WriteLine("-----------------------------");
            bool deleteProd = repository.DeleteProduct("P159");
            if(deleteProd == true)
            {
                Console.WriteLine("Product has been successfully deleted");
            }
            else
            {
                Console.WriteLine("Something went wrong, product has not been deleted");
            }*/

            // Delete Product using range
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Delete Product Using Range by ProductName");
            Console.WriteLine("-------------------------------------------");
            bool delteRange = repository.DeleteProductUsingRange("BMW"); // Delte any product that has BMW in it
            if (delteRange == true)
            {
                Console.WriteLine("Products has been successfully deleted");
            }
            else
            {
                Console.WriteLine("Something went wrong, product has not been deleted");
            }
        }
    }
}