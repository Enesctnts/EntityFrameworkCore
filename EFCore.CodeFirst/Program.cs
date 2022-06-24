// See https://aka.ms/new-console-template for more information
using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

Initializer.Build();
using (var context = new AppDbContext())
{
    var products = await context.Products.ToListAsync();
    products.ForEach(p =>
    Console.WriteLine($"{p.Name} {p.Price}")
    );
}