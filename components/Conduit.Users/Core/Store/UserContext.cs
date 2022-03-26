using Microsoft.EntityFrameworkCore;

namespace Conduit.Users.Core.Store;

public class UserContext : DbContext
{
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbSession> Sessions { get; set; }

    public UserContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var user = modelBuilder.Entity<DbUser>();
        user.HasKey(u => u.Email);

        var session = modelBuilder.Entity<DbSession>();
        session.HasKey(s => s.Token);
    }
}