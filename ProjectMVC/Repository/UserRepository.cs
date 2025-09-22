using System.Runtime.InteropServices.ObjectiveC;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Data;
using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }
        public UserModel BuscarLogin(string login)
        {
           return _databaseContext.Users.FirstOrDefault(x => x.login.ToUpper() == login.ToUpper());
        }
        public UserModel Adicionar(UserModel usuario)
        {
            usuario.dataCadastro = DateTime.Now;
            _databaseContext. Users.Add(usuario);
            _databaseContext.SaveChanges();
            return usuario;
        }

        public UserModel AtualizarRegistro(UserModel usuario)
        {
            UserModel dbUser = ListarId(usuario.id);
            if (dbUser == null) throw new Exception("Houve um erro ao atualizado o registro, {registro Nulo!}");

            dbUser.name = usuario.name;
            dbUser.email = usuario.email;
            dbUser.login = usuario.login;
            dbUser.perfil = usuario.perfil;
            dbUser.dataAtualizacao = DateTime.Now;

            _databaseContext.Users.Update(dbUser);
            _databaseContext.SaveChanges();

            return dbUser;
        }

        public List<UserModel> BuscarTodos()
        {
            return _databaseContext.Users.ToList();
        }

        public UserModel ListarId(int id)
        {
            return _databaseContext.Users.FirstOrDefault(x => x.id == id);
      
        }

        public bool RemoveRegistro(int id)
        {
            UserModel dbContact = ListarId(id);
            if (dbContact == null) throw new Exception("Houve um erro ao deletar o registro");

            _databaseContext.Users.Remove(dbContact);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
