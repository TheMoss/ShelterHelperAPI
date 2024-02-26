﻿using Microsoft.EntityFrameworkCore;
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
				
			},
			new Diet
			{
				DietId = 2,
				DietName = "hay",
				Quantity_kg = 452,
			}
			);		

			modelBuilder.Entity<Accessory>().HasData(new Accessory
			{
				AccessoryId = 1,
				AccessoryName = "collar",
				Quantity = 14,
			},
			new Accessory
			{
				AccessoryId = 2,
				AccessoryName = "halter",
				Quantity = 7,
			},
			new Accessory
			{
				AccessoryId = 3,
				AccessoryName = "brush",
				Quantity = 15,
			});

			modelBuilder.Entity<Bedding>().HasData(new Bedding
			{
				BeddingId = 1,
				BeddingName = "blanket",
				Quantity_kg = 9
			},
			new Bedding
			{
				BeddingId = 2,
				BeddingName = "straw",
				Quantity_kg = 143,
			}
			);

			modelBuilder.Entity<Toy>().HasData(new Toy
			{
				ToyId = 1,
				ToyName = "ball",
				Quantity = 20
			},
			new Toy
			{
				ToyId = 2,
				ToyName = "salt block",
				Quantity = 5,
			},
			new Toy
			{
				ToyId = 3,
				ToyName = "big ball",
				Quantity = 3,
			});
			modelBuilder.Entity<Species>().HasData(new Species
			{
				SpeciesId = 1,
				SpeciesName = "dog",
				AccessoryId = 1,
				BeddingId = 1,
				ToyId = 1,
				DietId = 1,
			},
			new Species
			{
				SpeciesId = 2,
				SpeciesName = "cow",
				AccessoryId = 2,
				BeddingId = 2,
				ToyId = 2,
				DietId = 2,
			},
			new Species
			{
				SpeciesId = 3,
				SpeciesName = "horse",
				AccessoryId = 3,
				BeddingId = 2,
				ToyId = 3,
				DietId = 2,
			});

		}
		public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) {
			
		}
	}
}
