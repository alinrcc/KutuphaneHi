using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneHi.Models
{
    public class Category:BaseModel
    {
        public virtual ICollection<Book> Books { get; set; }=new List<Book>();
        //public Category Categories { get; set; }
        //public Category Category { get; set; }
    }
}
