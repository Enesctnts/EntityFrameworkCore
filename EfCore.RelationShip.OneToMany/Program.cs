// See https://aka.ms/new-console-template for more information
using EfCore.RelationShip.OneToMany.DAL;
using EfCore.RelationShip.OneToMany.Entity;

Console.WriteLine("Hello, World!");




//Sayfalama çağrılması
GetProducts(3, 3).ForEach(x =>
{
    Console.WriteLine($"{x.Id} {x.Name} {x.Price}");
});


//Numaralandırma işlemi
//Skip metodu içine yazdığımız sayı mesela 2 veri tabanı tablosundaki ilk 2 değeri atla demek.
//Take metodu içine mesele 3 yazdığımızda veri tabanı tablosundan ilk 3 değeri getirir.
static List<Product> GetProducts(int page, int pageSize)
{

    using (var _context = new AppDbContext())
    {
        return _context.Products.OrderByDescending(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
    }
}