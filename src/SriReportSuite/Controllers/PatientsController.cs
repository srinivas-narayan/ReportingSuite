using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SriReportSuite.Models;
using System.Collections.Generic;

namespace SriReportSuite.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Patients
        public IActionResult Index(string city, string searchString)
        {
            var cityQuery = from p in _context.Patient
                            orderby p.City
                            select p.City;
            var cityList = new List<string>();
            cityList.AddRange(cityQuery.Distinct());
            ViewData["city"] = new SelectList(cityList);


            var patients = from p in _context.Patient
                           select p; //LINQ: selects all Patients to a list called patients

            if (!string.IsNullOrEmpty(city))
            {
                patients = patients.Where(x => x.City == city);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.SurName.Contains(searchString));
                //select the patient with the surname if available
            }

            return View(patients);
        }

        // GET: Patients/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Patient patient = _context.Patient.Single(m => m.PatientID == id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PatientID, FirstName, SurName, DOB, HospNum, NHSNum, Address, City, PostCode, ClinicID,  ConsultantID, Diagnosis, Procedures, Dead")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patient.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Patient patient = _context.Patient.Single(m => m.PatientID == id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("PatientID, FirstName, SurName, DOB, HospNum, NHSNum, Address, City, PostCode, ClinicID,  ConsultantID, Diagnosis, Procedures, Dead")] Patient patient)
        {   //the Bind is to prevent over-posting security vulnerability - data only goes to designated fields and none else, for eg = cannot send PatientID through this post...
            if (ModelState.IsValid)
            {
                _context.Update(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Patient patient = _context.Patient.Single(m => m.PatientID == id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Patient patient = _context.Patient.Single(m => m.PatientID == id);
            _context.Patient.Remove(patient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
