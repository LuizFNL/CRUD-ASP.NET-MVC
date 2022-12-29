using FormMVC.Models;

namespace FormMVC.Repositories
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuarioModel);
    }
}