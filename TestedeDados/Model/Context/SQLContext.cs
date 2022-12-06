using Microsoft.EntityFrameworkCore;

namespace TestedeDados.Model.Context
{
    // Cria a conexão com o banco de dados 
    public class SQLContext : DbContext 
    {
      
        public SQLContext() 
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonsxPets;Integrated Security=True;" +
                                   "Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
                                    "ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Pessoas> Pessoas { get; set;}
        public DbSet<Pets> Pets {get; set;}

    }
}
