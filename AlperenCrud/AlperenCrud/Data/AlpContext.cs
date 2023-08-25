using AlperenCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AlperenCrud.Data
{
    public class AlpContext : DbContext
    {
        public AlpContext(DbContextOptions<AlpContext> options) : base(options)
        {
        }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AlpContext>
        {
            public AlpContext CreateDbContext(string[] args) // 
            {
                var builder = new DbContextOptionsBuilder<AlpContext>();
                var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=1AlperenCrud;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                builder.UseSqlServer(connectionString);
                return new AlpContext(builder.Options);
            }
        }
       
        public DbSet<Persons> Kisiler { get; set; }
    }
}
