using ChallengeFiap.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeFiap.Entity
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<ClienteModel> TBClientes { get; set; } 

    }
}
