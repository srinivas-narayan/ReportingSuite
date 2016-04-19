using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SriReportSuite.Models;

namespace SriReportSuite.Controllers
{
    public class StudiesController : Controller
    {
        private ApplicationDbContext _context;

        public StudiesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Study
        public async Task<IActionResult> Index()
        {
            return View(await _context.Study.ToListAsync());
        }

        // GET: Study/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Study study = await _context.Study.SingleAsync(m => m.StudyID == id);
            if (study == null)
            {
                return HttpNotFound();
            }

            return View(study);
        }

        // GET: Study/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Study/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Study study)
        {
            if (ModelState.IsValid)
            {
                _context.Study.Add(study);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(study);
        }

        // GET: Study/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Study study = await _context.Study.SingleAsync(m => m.StudyID == id);
            if (study == null)
            {
                return HttpNotFound();
            }
            return View(study);
        }

        // POST: Study/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Study study)
        {
            if (ModelState.IsValid)
            {
                _context.Update(study);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(study);
        }

        // GET: Study/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Study study = await _context.Study.SingleAsync(m => m.StudyID == id);
            if (study == null)
            {
                return HttpNotFound();
            }

            return View(study);
        }

        // POST: Study/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Study study = await _context.Study.SingleAsync(m => m.StudyID == id);
            _context.Study.Remove(study);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
