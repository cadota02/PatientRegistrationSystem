using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRegistrationSystem.Data;
using PatientRegistrationSystem.Models;
using System.Linq;

namespace PatientRegistrationSystem.Controllers
{
    [Route("Patients")] // Define the base route for the controller
    public class PatientsController : Controller
    {
        private readonly AppDbContext _context;

        public PatientsController(AppDbContext context)
        {
            _context = context;
        }

   // ✅ Soft Delete Action
        [HttpPost("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.IsDeleted = true; // Mark as deleted
            _context.Update(patient);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Patient record deleted successfully!" });
        }
        // ✅ Define the index route explicitly
   [HttpGet("Index")]
public async Task<IActionResult> Index(string search, string gender)
{
    var patients = _context.Patients.Where(p => !p.IsDeleted);

    if (!string.IsNullOrEmpty(search))
    {
        search = search.ToLower();
        patients = patients.Where(p =>
            (p.Firstname + " " + p.Lastname + " " + p.MiddleName).ToLower().Contains(search));
    }

    if (!string.IsNullOrEmpty(gender) && gender != "All")
    {
        patients = patients.Where(p => p.Gender.ToLower() == gender.ToLower());
    }

    return View(await patients.ToListAsync());
}
     
    // ✅ Step 1: Add a GET method to show the create form
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // ✅ Step 2: Add a POST method to handle form submission
       [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Patient successfully created!";
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }
            // ✅ Step 1: GET - Show the edit form
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // ✅ Step 2: POST - Update the patient record
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                    {
                        _context.Update(patient);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Patient details successfully updated!";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!_context.Patients.Any(e => e.Id == patient.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
            {
                var patient = await _context.Patients
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (patient == null)
                {
                    return NotFound();
                }

                return View(patient);
            }
        // ✅ Define a proper error route
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}