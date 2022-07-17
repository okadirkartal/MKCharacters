using Microsoft.EntityFrameworkCore;

namespace MKCharacters.API.Models;

public class MKContext : DbContext
{
    public MKContext(DbContextOptions<MKContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>()
        .HasMany(c => c.Characters)
        .WithOne(a => a.Equipment)
        .HasForeignKey(a => a.EquipmentId);

        modelBuilder.Seed();
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
}