using APBD2retake.Model;
using Microsoft.EntityFrameworkCore;

namespace APBD2retake.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Backpack>()
            .HasKey(b => new { b.CharacterId, b.ItemId });

        modelBuilder.Entity<CharacterTitle>()
            .HasKey(ct => new { ct.CharacterId, ct.TitleId });
        
        modelBuilder.Entity<Item>().HasData(
            new Item { ItemId = 1, Name = "Item1", Weight = 10 },
            new Item { ItemId = 2, Name = "Item2", Weight = 11 },
            new Item { ItemId = 3, Name = "Item3", Weight = 12 }
        );

        modelBuilder.Entity<Title>().HasData(
            new Title { TitleId = 1, Name = "Title1" },
            new Title { TitleId = 2, Name = "Title2" },
            new Title { TitleId = 3, Name = "Title3" }
        );

        modelBuilder.Entity<Character>().HasData(
            new Character
            {
                CharacterId = 1,
                FirstName = "John",
                LastName = "Yakuza",
                CurrentWeight = 43,
                MaxWeight = 200
            }
        );

        modelBuilder.Entity<Backpack>().HasData(
            new Backpack { CharacterId = 1, ItemId = 1, Amount = 2 },
            new Backpack { CharacterId = 1, ItemId = 2, Amount = 1 },
            new Backpack { CharacterId = 1, ItemId = 3, Amount = 1 }
        );

        modelBuilder.Entity<CharacterTitle>().HasData(
            new CharacterTitle { CharacterId = 1, TitleId = 1, AcquiredAt = DateTime.Parse("2024-06-10") },
            new CharacterTitle { CharacterId = 1, TitleId = 2, AcquiredAt = DateTime.Parse("2024-06-09") },
            new CharacterTitle { CharacterId = 1, TitleId = 3, AcquiredAt = DateTime.Parse("2024-06-08") }
        );
    }
}