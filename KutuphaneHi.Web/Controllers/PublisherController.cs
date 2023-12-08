using KutuphaneHi.Data;
using KutuphaneHi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneHi.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PublisherController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Publishers.ToList<Publisher>());
            
        }

       
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Edit(int id)
        {
            return View(_context.Publishers.Find(id));

        }

        [HttpPost]
        public IActionResult Edit(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //_context.Publishers.Find(id);
            _context.Publishers.Remove(_context.Publishers.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
           

        }
    }
}
