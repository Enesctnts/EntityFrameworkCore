using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.DatabaseFirst.DAL
{
    public class DbContexInitializer
    {
        //IConfigurationRoot appsetting okumamızı sağlar
        public static IConfigurationRoot Configurations;
        public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder;

        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configurations = builder.Build();
            OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            OptionsBuilder.UseSqlServer(Configurations.GetConnectionString("SqlCon"));

        }


    }
}
