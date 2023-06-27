using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Models;
namespace TesisPadel.Data;
public class TesisPadelDbContext: DbContext{
    public TesisPadelDbContext(DbContextOptions<TesisPadelDbContext> options) : base(options)
    {
    }
    public DbSet <Usuario>? Usuarios {get; set;}
    // public DbSet <Jugador> Jugadores {get; set;}
    public DbSet <Club>? Club {get; set;}
    // public DbSet <Torneo> Torneos {get; set;}
    public DbSet<Localidad>? Localidad { get; set; }
    public DbSet<Provincia>? Provincia { get; set; }
    public DbSet<TesisPadel.Models.Ranking> Ranking { get; set; }
    public DbSet<TesisPadel.Models.Categoria> Categoria { get; set; }
}