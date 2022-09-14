using DataRegistration.Models;
using Microsoft.EntityFrameworkCore;

namespace DataRegistration.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<RegistrationModel> Contacts { get; set; }
    }
}
