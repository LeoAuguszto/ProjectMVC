using System.Runtime.InteropServices.ObjectiveC;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public ContactModel Adicionar(ContactModel contato)
        {
            _databaseContext.Contacts.Add(contato);
            _databaseContext.SaveChanges();
            return contato;
        }

        public ContactModel AtualizarRegistro(ContactModel contato)
        {
            ContactModel dbContact = ListarId(contato.id);
            if (dbContact == null) throw new Exception("Houve um erro ao atualizado o registro, {registro Nulo!}");

            dbContact.name = contato.name;
            dbContact.email = contato.email;
            dbContact.phone = contato.phone;
            dbContact.uf = contato.uf;
            dbContact.gender = contato.gender;
            dbContact.city = contato.city;

            _databaseContext.Update(dbContact);
            _databaseContext.SaveChanges();

            return dbContact;
        }

        public List<ContactModel> BuscarTodos()
        {
            return _databaseContext.Contacts.ToList();
        }

        public ContactModel ListarId(int id)
        {
            return _databaseContext.Contacts.FirstOrDefault(x => x.id == id) ?? new ContactModel();
        }

        public bool RemoveRegistro(int id)
        {
            ContactModel dbContact = ListarId(id);
            if (dbContact == null) throw new Exception("Houve um erro ao deletar o registro");

            _databaseContext.Contacts.Remove(dbContact);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
