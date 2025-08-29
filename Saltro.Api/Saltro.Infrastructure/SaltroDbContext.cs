using Microsoft.EntityFrameworkCore;
using Saltro.Domain.Entities;

namespace Saltro.Infrastructure;

public sealed class SaltroDbContext(DbContextOptions<SaltroDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserAssociate> UserAssociates => Set<UserAssociate>();
    public DbSet<UserGroup> UserGroups => Set<UserGroup>();
    public DbSet<UserGroupsMapping> UserGroupsMappings => Set<UserGroupsMapping>();
    public DbSet<UserSubscription> UserSubscriptions => Set<UserSubscription>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserAssociate>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.AssociateId });

            entity.HasOne(e => e.User)
                .WithMany(u => u.UserAssociates)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Associate)
                .WithMany(u => u.Associates)
                .HasForeignKey(e => e.AssociateId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.User_UserId);
            entity.Property(e => e.User_UserId1);
        });

        modelBuilder.Entity<UserGroupsMapping>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.UserGroupId });

            entity.HasOne(e => e.User)
                  .WithMany(u => u.UserGroupsMappings)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.UserGroup)
                  .WithMany(g => g.UserGroupsMappings)
                  .HasForeignKey(e => e.UserGroupId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
