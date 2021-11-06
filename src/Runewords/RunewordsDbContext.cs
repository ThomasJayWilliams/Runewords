using Microsoft.EntityFrameworkCore;
using Runewords.Models;

namespace Runewords
{
	public sealed class RunewordsDbContext : DbContext
	{
		public DbSet<Rune> Runes { get; set; } = null!;
		public DbSet<Runeword> Runewords { get; set; } = null!;
		public DbSet<Item> Items { get; set; } = null!;
		public DbSet<Class> Classes { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(Constants.SQLiteConnectionString);

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Rune>(e =>
			{
				e.HasKey(k => k.Id);
				e.Property(k => k.Id)
					.ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Item>(e =>
			{
				e.HasKey(p => p.Id);
				e.Property(p => p.Id)
					.ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Class>(e =>
			{
				e.HasKey(k => k.Id);
				e.Property(p => p.Id)
					.ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Runeword>(e =>
			{
				e.HasKey(k => k.Id);
				e.Property(p => p.Id)
					.ValueGeneratedOnAdd();
				e.HasOne(k => k.Class)
					.WithMany(k => k.Runewords)
					.OnDelete(DeleteBehavior.Restrict)
					.HasForeignKey(k => k.ClassId);
			});
			modelBuilder.Entity<RunewordItem>(e =>
			{
				e.HasKey(k => new { k.ItemId, k.RunewordId });
				e.HasOne(k => k.Runeword)
					.WithMany(k => k.RunewordItems)
					.OnDelete(DeleteBehavior.Restrict)
					.HasForeignKey(k => k.RunewordId);
				e.HasOne(k => k.Item)
					.WithMany(k => k.RunewordItems)
					.OnDelete(DeleteBehavior.Restrict)
					.HasForeignKey(k => k.ItemId);
			});
			modelBuilder.Entity<RunewordRune>(e =>
			{
				e.HasKey(k => k.Id);
				e.HasOne(k => k.Runeword)
					.WithMany(k => k.RunewordRunes)
					.OnDelete(DeleteBehavior.Restrict)
					.HasForeignKey(k => k.RunewordId);
				e.HasOne(k => k.Rune)
					.WithMany(k => k.RunewordRunes)
					.OnDelete(DeleteBehavior.Restrict)
					.HasForeignKey(k => k.RuneId);
				e.Property(k => k.Id)
					.ValueGeneratedOnAdd();
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
