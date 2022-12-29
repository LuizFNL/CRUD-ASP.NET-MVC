using FormMVC.Data;
using FormMVC.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UsuarioModel> Alterar(UsuarioModel usuarioModel)
        {
            _context.Usuarios.Update(usuarioModel);
            await _context.SaveChangesAsync();

            return usuarioModel;
        }

        public async Task<UsuarioModel> BuscarUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            return usuario;
        }

        public async Task<List<UsuarioModel>> ListarTodos()
        {
            var usuariosDB = await _context.Usuarios.ToListAsync();

            return usuariosDB;
        }
    }
}