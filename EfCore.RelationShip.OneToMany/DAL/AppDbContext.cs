using EfCore.RelationShip.OneToMany.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationShip.OneToMany.DAL
{
    public class AppDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//CategoryId yapsaydık C# kendisi anlıyor ForeignKey olduğunu. İsim farklı olursa nasıl yapılır diye böyle yapıyoruz.
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(x => x.Category).HasForeignKey(x => x.Category_Id);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
