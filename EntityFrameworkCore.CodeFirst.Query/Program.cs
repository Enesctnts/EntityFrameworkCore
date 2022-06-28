// See https://aka.ms/new-console-template for more information


using EntityFrameworkCore.CodeFirst.Query;
using EntityFrameworkCore.CodeFirst.Query.DAL;
using EntityFrameworkCore.CodeFirst.Query.Entity;
using Microsoft.EntityFrameworkCore;

Initializer.Build();


using (var _context = new AppDbContext())
{
    //procedure
    //procedure geriye tablo dönüyorsa ve bu bizim entity tablolarımızsa bu şekilde yapılır.

    var products =  _context.Products.FromSqlRaw("EXEC  sp_get_products").ToList();

    products.ForEach(x =>

    Console.WriteLine($"{x.Name} {x.Price}")

    );
    #region Insert Data
    //var category = new Category() { Name = "Defterler" };

    //category.Products.Add(new Product { Name = "Defter 1", Barcode = "1111", Price = 10, Stock = 100, ProductFeature = new ProductFeature { Color = "Red", Height = 10, Width = 1, } });
    //category.Products.Add(new Product { Name = "Defter 2", Barcode = "2222", Price = 15, Stock = 100, ProductFeature = new ProductFeature { Color = "Red", Height = 10, Width = 1, } });
    //category.Products.Add(new Product { Name = "Defter 3", Barcode = "3333", Price = 25, Stock = 100, ProductFeature = new ProductFeature { Color = "Red", Height = 10, Width = 1, } });
    //category.Products.Add(new Product { Name = "Defter 4", Barcode = "4444", Price = 35, Stock = 100 });

    //_context.Add(category);
    //_context.SaveChanges();
    //Console.WriteLine("İşlem Tamamlandı"); 
    #endregion

}