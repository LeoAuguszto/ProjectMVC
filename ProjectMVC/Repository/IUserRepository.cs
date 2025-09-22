    using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public interface IUserRepository
    {
        UserModel BuscarLogin(string login);
        UserModel ListarId(int id);
        List<UserModel> BuscarTodos();
        UserModel Adicionar(UserModel usuario);
        UserModel AtualizarRegistro(UserModel usuario);
        bool RemoveRegistro(int id);


    }

}
