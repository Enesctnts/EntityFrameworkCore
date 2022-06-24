// See https://aka.ms/new-console-template for more information
using EfCore.DatabaseFirstByScaffold.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new EfCoreDatabaseFirstContext())
{
    var products = await context.Products.ToListAsync();
    products.ForEach(p =>
    Console.WriteLine($"{p.Id} {p.Name} {p.Price}")
    );
}


//Bu yöntem Scaffold yöntemi deniyor. Veri tabanındaki tabloları otomatik olarak c# üzerinde kendisi oluşturuyor. 
//Scaffold-DbContext "Data Source=DESKTOP-B83TJ29;Initial Catalog=EfCoreDatabaseFirst;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models