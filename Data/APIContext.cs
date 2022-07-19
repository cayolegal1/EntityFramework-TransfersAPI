
using EntityFrame.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrame.Data
{
    public class APIContext:DbContext
    {   

        //El DbSet representa toda la data de una entidad
        public DbSet<Client> Clients { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transfer> Transfers { get; set; }  


        public APIContext(DbContextOptions<APIContext> options): base(options) { }
    }
}
