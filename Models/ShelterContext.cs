using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace ShelterHelperAPI.Models
{
    public class ShelterContext : DbContext
    {
		public DbSet<Animal> AnimalsDb { get; set; }
		public DbSet<Species> Species { get; set; }
		public DbSet<Diet> Diet { get; set; }
		public DbSet<Bedding> Bedding { get; set; }
		public DbSet<Toy> Toy { get; set; }
		public DbSet<Accessory> Accessory { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
			
			optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies();
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{		
			//seed data if tables are empty

			modelBuilder.Entity<Diet>().HasData(new Diet
			{
				DietId = 1,
				DietName = "dog food",
				Quantity_kg = 157,						
				
			});		

			modelBuilder.Entity<Accessory>().HasData(new Accessory
			{
				AccessoryId = 1,
				AccessoryName = "collar",
				Quantity = 14,
			});

			modelBuilder.Entity<Bedding>().HasData(new Bedding
			{
				BeddingId = 1,
				BeddingName = "blanket",
				Quantity_kg = 9
			});

			modelBuilder.Entity<Toy>().HasData(new Toy
			{
				ToyId = 1,
				ToyName = "ball",
				Quantity = 20
			});
			modelBuilder.Entity<Species>().HasData(new Species
			{
				SpeciesId = 1,
				SpeciesName = "dog",
				AccessoryId = 1,
				BeddingId = 1,
				ToyId = 1,
				DietId = 1,
			});

		}
		public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) {
			
		}
	}
}
