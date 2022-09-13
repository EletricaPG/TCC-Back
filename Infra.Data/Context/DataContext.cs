using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}
        public DbSet<Adm> Adm {get; set;}
        public DbSet<Category> Category {get; set;}
        public DbSet<Client> Client {get; set;}
        public DbSet<Order> Order {get; set;}

          
        
    }
}