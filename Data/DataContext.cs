using CURSO_ASP_.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace CURSO_ASP_.NET.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            this.Database.EnsureCreated(); // Vai criar o banco automaticamente quando iniciar a aplicação (Entity Framework)
        }

        public DbSet<Pessoa> pessoa { get; set; }
    }
}