using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public interface ISessions
    {
        void CreateSession(UserModel usuario);
        void RemoveSession();
        UserModel SearchSession();
    }
}
