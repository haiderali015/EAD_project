
using EAD_project.Models;
using Microsoft.EntityFrameworkCore;

namespace EAD_project.Model
{
    public class CDatumContext:DbContext
    {
        public DbSet<CDatum> customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=customerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        
    }
}
