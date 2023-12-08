using KutuphaneHi.Data;
using KutuphaneHi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneHi.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.ToList()); //_context.Authors.ToList<Authors>()
        }
        [HttpGet]
        public IActionResult Add()//getir,getirecek
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)//işlem yap
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //Author authorToBeDeleted= _context.Authors.Find(id);
            //_context.Authors.Remove(authorToBeDeleted);
            _context.Authors.Remove(_context.Authors.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            //Author author = _context.Authors.Find(id);
            return View(_context.Authors.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
