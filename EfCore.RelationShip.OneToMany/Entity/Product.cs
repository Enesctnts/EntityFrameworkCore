using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.RelationShip.OneToMany.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Stock { get; set; }
        public string Barcode { get; set; }
        public int Category_Id { get; set; } //CategoryId yapsaydık C# kendisi anlıyor ForeignKey olduğunu. İsim farklı olursa nasıl yapılır diye böyle yapıyoruz.
        //[ForeignKey("Category_Id")] şeklinde yaparsakta olur ama buraya dataannotations larla doldurmak yanlış
        public Category Category { get; set; }
    }
}
