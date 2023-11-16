using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data.EF;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class MidiaController : Controller
    {
        private IMidiaRepository midiaRepository;

        public MidiaController(IMidiaRepository repo)
        { 
            midiaRepository = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(midiaRepository.GetMidias());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Midia? m =
                midiaRepository.GetMidiaById(id.Value);

            if (m == null)
                return NotFound();

            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Midia midia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    midiaRepository.Update(midia);
                    return View("Index", midiaRepository.GetMidias());
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
            if (id == null)
                return NotFound();

            Midia? m = midiaRepository.GetMidiaById(id.Value);

            if (m == null)
                return NotFound();

            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            midiaRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Midia m)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    midiaRepository.Create(m);
                    return View("Index", midiaRepository.GetMidias());
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
