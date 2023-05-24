using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Models;
namespace TesisPadel.Data;
public class TesisPadelDbContext: DbContext{
    public TesisPadelDbContext(DbContextOptions<TesisPadelDbContext> options) : base(options)
    {
    }
    public DbSet <Usuario> Usuarios {get; set;}
    public DbSet <Administrador> Administradores {get; set;}
    public DbSet <Torneo> Torneos {get; set;}
}