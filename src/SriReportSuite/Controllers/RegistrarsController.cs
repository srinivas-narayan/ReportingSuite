using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SriReportSuite.Models;

namespace SriReportSuite.Controllers
{
    public class RegistrarsController : Controller
    {
        private ApplicationDbContext _context;

        public RegistrarsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Registrar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registrar.ToListAsync());
        }

        // GET: Registrar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Registrar registrar = await _context.Registrar.SingleAsync(m => m.RegID == id);
            if (registrar == null)
            {
                return HttpNotFound();
            }

            return View(registrar);
        }

        // GET: Registrar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                _context.Registrar.Add(registrar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registrar);
        }

        // GET: Registrar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Registrar registrar = await _context.Registrar.SingleAsync(m => m.RegID == id);
            if (registrar == null)
            {
                return HttpNotFound();
            }
            return View(registrar);
        }

        // POST: Registrar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Registrar registrar)
        {
            if (ModelState.IsValid)
            {
                _context.Update(registrar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registrar);
        }

        // GET: Registrar/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Registrar registrar = await _context.Registrar.SingleAsync(m => m.RegID == id);
            if (registrar == null)
            {
                return HttpNotFound();
            }

            return View(registrar);
        }

        // POST: Registrar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Registrar registrar = await _context.Registrar.SingleAsync(m => m.RegID == id);
            _context.Registrar.Remove(registrar);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
