using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            //var repo = new DapperDepartmentRepo(conn);

            ///Console.WriteLine("Type a new Department name");

            //var newDepartment = Console.ReadLine();

            //repo.InsertDepartment(newDepartment);

            //var departments = repo.GetAllDepartments();

            //foreach (var dept in departments)
           // {
               //Console.WriteLine(dept.Name);
            //}


            var prodRepo = new ProductRepo(conn);

            //prodRepo.InsertProduct("Fallout: New Vegas", 15.00, 1);

            //prodRepo.UpdateProductName(943, "Banana");

            //prodRepo.DeleteProduct(943);

            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name} | Price: {product.Price} | Category: {product.CategoryID} | ID: {product.ProductID}");
            }
        }
    }
}
