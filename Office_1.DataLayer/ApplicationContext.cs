using Microsoft.EntityFrameworkCore;
using Office_1.DataLayer.Models;

namespace Office_1.DataLayer;

public sealed class ApplicationContext : DbContext
{

    public DbSet<Request> Requests { get; set; }
    public DbSet<Client> Clients { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("FileName=Application.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Request>()
            .HasOne(request => request.Client)
            .WithMany(client => client.Requests)
            .HasForeignKey(request => request.IdClient);*/
    }

}