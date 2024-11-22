using Microsoft.EntityFrameworkCore;


namespace ShelterHelperAPI.Models
{
    public class ShelterContext : DbContext
    {
        public DbSet<Accessory> Accessory { get; set; }
        public DbSet<Animal> AnimalsDb { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Bedding> Bedding { get; set; }
        public DbSet<Diet> Diet { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Toy> Toy { get; set; }
        
        public DbSet<EmployeesAssignments> EmployeesAssignments { get; set; }

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

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeName = "Steve Wazowski",
                    EmployeePersonalId = 840792,
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeName = "Lee Smith",
                    EmployeePersonalId = 625614,
                },
                new Employee
                {
                    EmployeeId = 3,
                    EmployeeName = "Jill Jackson",
                    EmployeePersonalId = 739618,
                },
                new Employee
                {
                    EmployeeId = 4,
                    EmployeeName = "Sophie Brown",
                    EmployeePersonalId = 857104,
                },
                new Employee
                {
                    EmployeeId = 5,
                    EmployeeName = "Arnold Mason",
                    EmployeePersonalId = 629513,
                });

            modelBuilder.Entity<Owner>().HasData(
                new Owner
                {
                    OwnerId = 1,
                    OwnerName = "Amanda Lawson",
                    Address = "Park Road 7, Sydney"
                },
                new Owner
                {
                    OwnerId = 2,
                    OwnerName = "Guy Brickman",
                    Address = "Sausage Plaza 17, Pinewood"
                });

            modelBuilder.Entity<Assignment>().HasData(
                new Assignment
                {
                    AssignmentId = 1,
                    Title = "Clean the floors",
                    Priority = 2,
                    CreatorId = 142095
                },
                new Assignment
                {
                    AssignmentId = 2,
                    Title = "Patch leaky roof",
                    Priority = 3,
                    CreatorId = 153094,
                    IsInProgress = true
                });
            
            modelBuilder.Entity<EmployeesAssignments>().HasData(
                new EmployeesAssignments
                {
                    Id = 1,
                    EmployeeId = 1,
                    AssignmentId = 1
                }
            );

        }

        public ShelterContext()
        {
        }

        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
        {
        }
    }
}