using FormMVC.Models;

namespace FormMVC.Repositories
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuarioModel);
        Task<List<UsuarioModel>> ListarTodos();
        Task<UsuarioModel> Alterar(UsuarioModel usuarioModel);
        Task<UsuarioModel> BuscarUsuario(int id);
        void Deletar(UsuarioModel usuarioModel);
    }
}