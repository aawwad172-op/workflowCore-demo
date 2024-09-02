using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure;

public class LeaveRequestDBContext : DbContext
{
    public LeaveRequestDBContext(DbContextOptions<LeaveRequestDBContext> options) : base(options) { }

    // Define a DbSet for each entity that you want to store in the database
    public DbSet<User> Users { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<Approval> Approvals { get; set; }

    // Override the OnModelCreating method to configure the model via the Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }



}
