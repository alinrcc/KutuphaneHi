using KutuphaneHi.Data;
using KutuphaneHi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneHi.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Books.Include(b=>b.Authors).Include(b => b.Publishers).Include(b=>b.Category).ToList<Book>());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["categories"] = _context.Categories.ToList();
            ViewData["authors"] = _context.Authors.ToList();
            ViewData["publishers"] = _context.Publishers.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book, List<int>Publishers, List<int> Authors)
        {
            foreach(int id in Publishers)
                book.Publishers.Add(_context.Publishers.Find(id));
            

            foreach(int id in Authors)
                book.Authors.Add(_context.Authors.Find(id));

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var kategoriListesi = ViewData["categories"] as List<Category>;
            var yazarListesi = ViewData["authors"] as List<Author>;
            var yayinEviListesi = ViewData["publishers"] as List<Publisher>;
            Book book = _context.Books.Include(b=>b.Authors).Include(b=>b.Publishers).FirstOrDefault(b=>b.Id==id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
