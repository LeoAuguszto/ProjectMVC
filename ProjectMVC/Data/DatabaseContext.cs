using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;

namespace ProjectMVC.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) 
        { 

        }
        public DbSet<ContactModel> Contacts {  get; set; }
        public DbSet<UserModel> Users { get; set; }



    }
}
