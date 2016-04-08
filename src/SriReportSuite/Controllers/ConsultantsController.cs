using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using SriReportSuite.Models;

namespace SriReportSuite.Controllers
{
    [Produces("application/json")]
    [Route("api/Consultants")]
    public class ConsultantsController : Controller
    {
        private ApplicationDbContext _context;

        public ConsultantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Consultants
        [HttpGet]
        public IEnumerable<Consultant> GetConsultants()
        {
            return _context.Consultants;
        }

        // GET: api/Consultants/5
        [HttpGet("{id}", Name = "GetConsultant")]
        public async Task<IActionResult> GetConsultant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Consultant consultant = await _context.Consultants.SingleAsync(m => m.ConsultantID == id);

            if (consultant == null)
            {
                return HttpNotFound();
            }

            return Ok(consultant);
        }

        // PUT: api/Consultants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultant([FromRoute] int id, [FromBody] Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != consultant.ConsultantID)
            {
                return HttpBadRequest();
            }

            _context.Entry(consultant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultantExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Consultants
        [HttpPost]
        public async Task<IActionResult> PostConsultant([FromBody] Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.Consultants.Add(consultant);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConsultantExists(consultant.ConsultantID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetConsultant", new { id = consultant.ConsultantID }, consultant);
        }

        // DELETE: api/Consultants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Consultant consultant = await _context.Consultants.SingleAsync(m => m.ConsultantID == id);
            if (consultant == null)
            {
                return HttpNotFound();
            }

            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();

            return Ok(consultant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultants.Count(e => e.ConsultantID == id) > 0;
        }
    }
}