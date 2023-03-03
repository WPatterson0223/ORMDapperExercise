using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORMDapper;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperProductRepository(conn);

var prodList = repo.GetAllProducts();

foreach (var prod in prodList)
{
    Console.WriteLine($"{prod.ProductID} - {prod.Name}");
}



Console.WriteLine("What is the name of your new product?");
var prodName = Console.ReadLine();
Console.WriteLine("What is the price?");
var prodPrice = double.Parse(Console.ReadLine());
Console.WriteLine("What is the categoty ID?");
var prodCategory = int.Parse(Console.ReadLine());

repo.CreateProduct(prodName, prodPrice, prodCategory);

prodList = repo.GetAllProducts();

foreach (var prod in prodList)
{
    Console.WriteLine($"{prod.ProductID} - {prod.Name}");
}



Console.WriteLine("What is the Product ID you want to update?");
var prodID = int.Parse(Console.ReadLine());
Console.WriteLine("What do you want to change the product name to?");
var prodNewName = Console.ReadLine();

repo.UpdateProduct(prodID,prodNewName);

prodList = repo.GetAllProducts();

foreach (var prod in prodList)
{
    Console.WriteLine($"{prod.ProductID} - {prod.Name}");
}



Console.WriteLine("What is the producd ID that you want to delete?");
prodID = int.Parse(Console.ReadLine());

repo.DeleteProduct(prodID);

prodList = repo.GetAllProducts();

foreach (var prod in prodList)
{
    Console.WriteLine($"{prod.ProductID} - {prod.Name}");
}

