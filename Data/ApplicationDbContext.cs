using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Parcial_2025_I.Models;

namespace Parcial_2025_I.Data;

public class ApplicationDbContext : IdentityDbContext
{

    public DbSet<Jugador> Jugadores { get; set; }
    public DbSet<Equipo> Equipos { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
