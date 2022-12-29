using Microsoft.EntityFrameworkCore;
using FormMVC.Models;

namespace FormMVC.Data
{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
