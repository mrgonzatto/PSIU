using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class PacientController : Controller
    {
        private IPacientRepository pacientRepository;

        public PacientController(
            IPacientRepository _pacientRepo
        ) 
        {
            pacientRepository = _pacientRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View( 
                pacientRepository.GetPacients() 
            );
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Pacient? p = 
                pacientRepository.GetPacientById(id.Value);

            if (p == null)
                return NotFound();

            return View(p);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pacient pacient)
        {
            if ( ModelState.IsValid )
            {
                try
                {
                    pacientRepository.Update(pacient);
                    return View("Index", pacientRepository.GetPacients());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }                
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        { 
            if(id == null)
                return NotFound();

            Pacient? p = pacientRepository.GetPacientById(id.Value);
            
            if (p == null)
                return NotFound();

            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        { 
            if(id == null || id == 0)
                return NotFound();

            pacientRepository.Delete(id);

            return RedirectToAction( nameof(Index) );
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Pacient p)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pacientRepository.Create(p);
                    return View("Index", pacientRepository.GetPacients());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }
    
    }
}
