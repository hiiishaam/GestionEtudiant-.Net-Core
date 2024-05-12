using GestionEtudiant.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEtudiant.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { 
        }  
        public DbSet<Etudiant> etudiants { get; set; }  
    }
}
