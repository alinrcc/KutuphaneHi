using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneHi.Models
{
    public class Publisher:BaseModel
    {
        public string? Address { get; set; }

        public virtual ICollection<Book> Books { get; set; }= new List<Book>();
        public virtual ICollection<Author> Authors { get; set; }= new List<Author>();
    }
}
