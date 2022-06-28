using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationShip.OneToMany.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Product> Products { get; set; }
    }
} 
