using EntityFrameworkCore.CodeFirst.Query.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore.CodeFirst.Query.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configurations.GetConnectionString("SqlCon"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Veritabanına yeni bir kayıt eklendiği zaman otomatik olarak IsDeleted metodu false değeri alsın
            modelBuilder.Entity<Product>().Property(x => x.IsDeleted).HasDefaultValue(true);

            ////Product tablosundan verileri çekerken sadece IsDeleted alanı false olanlar gelsin diyoruz.
            modelBuilder.Entity<Product>().HasQueryFilter(x => x.IsDeleted == false);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
