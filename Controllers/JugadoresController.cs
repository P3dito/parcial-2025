using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial_2025_I.Data;
using Parcial_2025_I.Models;

namespace Parcial_2025_I.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Jugadores/Crear
        public IActionResult Crear()
        {
            ViewBag.Equipos = _context.Equipos.ToList();
            return View();
        }

        // POST: /Jugadores/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Jugadores.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Crear"); // o a una vista de confirmación
            }

            ViewBag.Equipos = _context.Equipos.ToList();
            return View(jugador);
        }
    }
}
