using FormMVC.Data;
using FormMVC.Models;

namespace FormMVC.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AppDbContext _context;
        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}