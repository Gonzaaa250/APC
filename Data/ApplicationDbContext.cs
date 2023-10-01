using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TesisPadel.Models;
namespace TesisPadel.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet <Usuario>? Usuario {get; set;}
    public DbSet <Club>? Club {get; set;}
    public DbSet<Ranking>? Ranking { get; set; }
    public DbSet<Categoria>? Categoria {get; set;}
}
