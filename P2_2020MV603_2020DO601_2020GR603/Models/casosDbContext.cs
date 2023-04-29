using Microsoft.EntityFrameworkCore;
namespace P2_2020MV603_2020DO601_2020GR603.Models
{
    public class casosDbContext : DbContext
    {
        public casosDbContext(DbContextOptions options) : base(options)
        {
            
        }
            public DbSet<Casos_Reportados> Casos_Reportados { get; set; }
            public DbSet<Departamento> Departamento { get; set;}
            public DbSet<Genero> Genero { get; set;}   
    }
}
