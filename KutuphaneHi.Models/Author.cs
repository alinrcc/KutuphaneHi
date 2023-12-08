using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneHi.Models
{
    public class Author:BaseModel
    {
        public string? Biography { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
        public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
    }
}
