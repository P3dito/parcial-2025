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

        public IActionResult Crear()
        {
            ViewBag.Equipos = _context.Equipos.ToList();
            return View();
        }

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

        [HttpGet]
        public IActionResult Index()
        {
            var jugadores = _context.Jugadores.Include(j => j.Equipo).ToList();
            return View(jugadores);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var jugador = _context.Jugadores.Find(id);
            if (jugador == null) return NotFound();

            ViewBag.Equipos = _context.Equipos.ToList();
            return View(jugador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Update(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Equipos = _context.Equipos.ToList();
            return View(jugador);
        }
    }
}
