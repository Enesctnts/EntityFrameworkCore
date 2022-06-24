// See https://aka.ms/new-console-template for more information
using EfCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContexInitializer.Build();
using (var context = new AppDbContext(DbContexInitializer.OptionsBuilder.Options))
{
    var products = await context.Products.ToListAsync();
    products.ForEach(p =>
    Console.WriteLine($"{p.Name} {p.Price}")
    );
}