using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public interface IUserRepository
    {
        UserModel ListarId(int id);
        List<UserModel> BuscarTodos();
        UserModel Adicionar(UserModel usuario);
        UserModel AtualizarRegistro(UserModel usuario);
        bool RemoveRegistro(int id);


    }

}
