using Microsoft.EntityFrameworkCore;
using PermissionRequestApp.Entities.Models;

namespace PermissionRequestApp.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }
    }
}