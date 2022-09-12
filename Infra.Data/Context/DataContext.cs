using Domain.Entiy;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Adm> Adm {get; set;}
        
    }
}