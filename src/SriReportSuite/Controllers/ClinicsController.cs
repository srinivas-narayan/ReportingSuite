using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SriReportSuite.Models;

namespace SriReportSuite.Controllers
{
    public class ClinicsController : Controller
    {
        private ApplicationDbContext _context;

        public ClinicsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Clinic
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinic.ToListAsync());
        }

        // GET: Clinic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Clinic clinic = await _context.Clinic.SingleAsync(m => m.ClinicID == id);
            if (clinic == null)
            {
                return HttpNotFound();
            }

            return View(clinic);
        }

        // GET: Clinic/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Clinic.Add(clinic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Clinic clinic = await _context.Clinic.SingleAsync(m => m.ClinicID == id);
            if (clinic == null)
            {
                return HttpNotFound();
            }
            return View(clinic);
        }

        // POST: Clinic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                _context.Update(clinic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clinic);
        }

        // GET: Clinic/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Clinic clinic = await _context.Clinic.SingleAsync(m => m.ClinicID == id);
            if (clinic == null)
            {
                return HttpNotFound();
            }

            return View(clinic);
        }

        // POST: Clinic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Clinic clinic = await _context.Clinic.SingleAsync(m => m.ClinicID == id);
            _context.Clinic.Remove(clinic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
