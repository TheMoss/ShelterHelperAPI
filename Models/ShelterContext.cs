using Microsoft.EntityFrameworkCore;


namespace ShelterHelperAPI.Models
{
    public class ShelterContext : DbContext
    {
		public DbSet<Animal> AnimalsDb { get; set; }		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

			
			optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
		public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) {
			
		}
	}
}
