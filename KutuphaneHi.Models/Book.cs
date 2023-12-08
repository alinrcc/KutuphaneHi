using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneHi.Models
{
    [Table("Books")]
    public class Book:BaseModel
    {
        public int PageCount { get; set; } =0;
        public string? ISBN { get; set; }
        public bool IsDigital { get; set; }= false;
        public int CategoryId { get; set; }


        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
        public virtual ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
        //senaryo gereği bir kitabın sadece 1 kategorisi olma durumu varsayılmıştır.
        public virtual Category Category { get; set; }
    }
}
