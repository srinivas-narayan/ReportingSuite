using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SriReportSuite.Models;

namespace SriReportSuite.Controllers
{
    public class ConsultantsController : Controller
    {
        private ApplicationDbContext _context;

        public ConsultantsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Consultant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultant.ToListAsync());
        }

        // GET: Consultant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Consultant consultant = await _context.Consultant.SingleAsync(m => m.ConsultantID == id);
            if (consultant == null)
            {
                return HttpNotFound();
            }

            return View(consultant);
        }

        // GET: Consultant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                _context.Consultant.Add(consultant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        // GET: Consultant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Consultant consultant = await _context.Consultant.SingleAsync(m => m.ConsultantID == id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            return View(consultant);
        }

        // POST: Consultant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                _context.Update(consultant);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consultant);
        }

        // GET: Consultant/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Consultant consultant = await _context.Consultant.SingleAsync(m => m.ConsultantID == id);
            if (consultant == null)
            {
                return HttpNotFound();
            }

            return View(consultant);
        }

        // POST: Consultant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Consultant consultant = await _context.Consultant.SingleAsync(m => m.ConsultantID == id);
            _context.Consultant.Remove(consultant);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
