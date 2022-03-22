using Conduit.Users.Interface;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Users.Core.Store;

public class UserContext : DbContext
{
    public DbSet<DbUser> Users { get; set; }

    public UserContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<DbUser>();
        user.HasKey(u => u.Email);
    }
}