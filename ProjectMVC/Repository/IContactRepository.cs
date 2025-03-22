using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public interface IContactRepository
    {
        ContactModel ListarId(int id);
        List<ContactModel> BuscarTodos();
        ContactModel Adicionar(ContactModel contato);
        ContactModel AtualizarRegistro(ContactModel contato);
        bool RemoveRegistro(int id);


    }

}
