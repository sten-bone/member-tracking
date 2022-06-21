using MemberTracking.Data.DbContext.EntityTypeConfigurations;
using MemberTracking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MemberTracking.Data.DbContext;

public class MemberDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    internal DbSet<Member> Members { get; set; } = null!;

    public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MemberEntityTypeConfiguration());
    }
}