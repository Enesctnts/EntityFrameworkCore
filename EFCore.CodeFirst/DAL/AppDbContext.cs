using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configurations.GetConnectionString("SqlCon"));
        }

        public override int SaveChanges()
        {
            //EntityFramework listeleme,ekleme,güncelleme,silme işlemlerini önce Tracker'a alır.Burda add,update,delete,list şeklinde işlemlerin durumu(State) ne ise o şekilde tutulur. SaveChanges yapıldıktan sonra veritabanına bildirilir.Bildirilmeden önce burda tutuğu için Ram'de yer kaplar ve sistemi yorar. Örnek verirsek 1000 tane ürün listelediğimiz zaman bu ürünlerin hepsini var products= dbcontext.product.tolist() yapıldında tracker'a alır. Burada ekleme silme veya güncelleme yapılmadıgı için trackerda yer kaplamasına yani ram' i yormasına gerek yok.
            //Bu durumlar için var products = Products.AsNoTracking().ToList(); yaparak Tracker'a alma deriz.Sistemi yormamış oluruz.

            //ChangeTracker propertysi sayesinde Tracker alınmış ürünleri görebiliyoruz.Ekleme,silme,güncelleme yapıldığı zaman Track edilmesini istiyoruz. Bu işlemler yapılacagı zaman track edilecek ürünler. Sonuçta ürün yeni eklendiği zaman track edilceği için track edilmiş mi yani soruyoruz edildiyse ürün yeni ekleniyor.
            
            //Burda Track edilen değerler yeni ürünler olduğu için CreatedDate ni merkezi yerden değerini vermiş oluyoruz. Otomatik olarak şuan ki tarihi atmış oluyoruz. Bu SAVECHANGES Metodunu ezmemizin sebebi SaveChanges yaptığımız zaman önce bu işlem yapılacak sonra veri tabanına kaydedicek.
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                //if'in içerisinde track edilmiş değerlerden entitysi Product'a dönüştürebiliyorsa dönüştürür ve p' ye at diyoruz. bu işlemi is keywordü sayesinde yapabiliyoruz. is keywordu dönüştürme işleminde true ya da false değeri döndürür true ise if'in içine girer.  
                if (e.Entity is Product p)
                {
                    //Track edilmiş ürünlerin o anki durumu ekleme ise if'e girer. Yeni oluşturulduğu için createdDate otomatik şu anki tarihi atar.
                    if (e.State == EntityState.Added)
                    {
                        p.CreatedDate = DateTime.Now;
                    }
                }
                
            });
                
            return base.SaveChanges();
        }

    }
}
