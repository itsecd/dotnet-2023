using Microsoft.EntityFrameworkCore;
using RentalService.Domain;

public class RentalServiceDbContext : DbContext
{
    public RentalServiceDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Client>? Clients { get; set; }

    public DbSet<IssuedCar>? IssuedCars { get; set; }

    public DbSet<RefundInformation>? RefundInformations { get; set; }
    public DbSet<RentalInformation>? RentalInformations { get; set; }

    public DbSet<RentalPoint>? RentalPoints { get; set; }

    public DbSet<Vehicle>? Vehicles { get; set; }
    public DbSet<VehicleModel>? VehicleModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>().HasData(new List<Client>
        {
            new()
            {
                Id = 1,
                LastName = "Яруллин",
                FirstName = "Лаврентий",
                Patronymic = "Никитьевич",
                BirthDate = new DateTime(1967, 11, 17, 11, 34, 1),
                Passport = "4939 153040"
            },
            new()
            {
                Id = 2,
                LastName = "Аникин",
                FirstName = "Степан",
                Patronymic = "Валерьевич",
                BirthDate = new DateTime(1971, 12, 16, 13, 09, 1),
                Passport = "4599 723567"
            },
            new()
            {
                Id = 3,
                LastName = "Щербинина",
                FirstName = "Таисия",
                Patronymic = "Фадеевна",
                BirthDate = new DateTime(1993, 09, 24, 16, 12, 1),
                Passport = "4796 806443"
            },
            new()
            {
                Id = 4,
                LastName = "Горева",
                FirstName = "Алиса",
                Patronymic = "Федоровна",
                BirthDate = new DateTime(1966, 09, 27, 12, 12, 1),
                Passport = "4439 510590"
            },
            new()
            {
                Id = 5,
                LastName = "Лапидус",
                FirstName = "Григорий",
                Patronymic = "Федорович",
                BirthDate = new DateTime(1983, 08, 21, 16, 02, 1),
                Passport = "4896 462655"
            }
        });

        modelBuilder.Entity<RentalPoint>().HasData(new List<RentalPoint>
        {
            new()
            {
                Id = 1,
                Title = "Бумеранг-Авто",
                Address = "г.Самара, Московское ш., 163Б"
            },
            new()
            {
                Id = 2,
                Title = "Конкур-Аренда-авто",
                Address = "г.Самара, Олимпийская ул., 68"
            },
            new()
            {
                Id = 3,
                Title = "Wrc Motors",
                Address = "г.Самара, 6-я просека, 149"
            },
            new()
            {
                Id = 4,
                Title = "Luxury Time",
                Address = "г.Самара, Ново-Садовая ул., 162Д"
            },
            new()
            {
                Id = 5,
                Title = "Соло",
                Address = "г.Самара, ул. 22 Партсъезда, 207"
            }
        });

        modelBuilder.Entity<VehicleModel>().HasData(new List<VehicleModel>
        {
            new()
            {
                Id = 1,
                Model = "X3 M",
                Brand = "Honda"
            },
            new()
            {
                Id = 2,
                Model = "A2",
                Brand = "Infiniti"
            },
            new()
            {
                Id = 3,
                Model = "ix35",
                Brand = "Geely"
            },
            new()
            {
                Id = 4,
                Model = "X6",
                Brand = "BMW"
            },
            new()
            {
                Id = 5,
                Model = "Emgrand",
                Brand = "Geely"
            }
        });

        modelBuilder.Entity<Vehicle>().HasData(new List<Vehicle>
        {
            new()
            {
                Id = 1,
                Number = "К622КА39",
                VehicleModelId = 1,
                Colour = "Тёмно-синий"
            },
            new()
            {
                Id = 2,
                Number = "Х547ХМ18",
                VehicleModelId = 3,
                Colour = "Серо-зелёный"
            },
            new()
            {
                Id = 3,
                Number = "М018ЕС73",
                VehicleModelId = 3,
                Colour = "Серебристо-серо-зеленоватый"
            },
            new()
            {
                Id = 4,
                Number = "Н728МН81",
                VehicleModelId = 2,
                Colour = "Цвет морской волны"
            },
            new()
            {
                Id = 5,
                Number = "Н818ОО35",
                VehicleModelId = 5,
                Colour = "Зелёный"
            }
        });

        modelBuilder.Entity<RentalInformation>().HasData(new List<RentalInformation>
        {
            new()
            {
                Id = 1,
                RentalPointId = 1,
                RentalDate = new DateTime(2019, 05, 15, 11, 11, 11),
                RentalPeriod = 5,
                IssuedCarId = 1
            },
            new()
            {
                Id = 2,
                RentalPointId = 2,
                RentalDate = new DateTime(2019, 03, 04, 14, 14, 14),
                RentalPeriod = 10,
                IssuedCarId = 2
            },
            new()
            {
                Id = 3,
                RentalPointId = 3,
                RentalDate = new DateTime(2022, 07, 01, 09, 15, 12),
                RentalPeriod = 15,
                IssuedCarId = 3
            },
            new()
            {
                Id = 4,
                RentalPointId = 4,
                RentalDate = new DateTime(2022, 02, 02, 07, 09, 12),
                RentalPeriod = 2,
                IssuedCarId = 4
            },
            new()
            {
                Id = 5,
                RentalPointId = 1,
                RentalDate = new DateTime(2013, 04, 19, 12, 12, 12),
                RentalPeriod = 5,
                IssuedCarId = 5
            }
        });

        modelBuilder.Entity<RefundInformation>().HasData(new List<RefundInformation>
        {
            new()
            {
                Id = 1,
                RentalPointId = 1,
                RefundDate = new DateTime(2019, 05, 20, 11, 11, 11),
                IssuedCarId = 1
            },
            new()
            {
                Id = 2,
                RentalPointId = 2,
                RefundDate = new DateTime(2019, 03, 14, 14, 14, 14),
                IssuedCarId = 2
            },
            new()
            {
                Id = 3,
                RentalPointId = 3,
                RefundDate = new DateTime(2022, 07, 16, 09, 15, 12),
                IssuedCarId = 3
            },
            new()
            {
                Id = 4,
                RentalPointId = 4,
                RefundDate = new DateTime(2022, 02, 04, 07, 09, 12),
                IssuedCarId = 4
            },
            new()
            {
                Id = 5,
                RentalPointId = 5,
                RefundDate = new DateTime(2013, 04, 24, 12, 12, 12),
                IssuedCarId = null
            }
        });

        modelBuilder.Entity<IssuedCar>().HasData(new List<IssuedCar>
        {
            new()
            {
                Id = 1,
                ClientId = 1,
                VehicleId = 1,
                RefundInformationId = 1,
                RentalInformationId = 1
            },
            new()
            {
                Id = 2,
                ClientId = 2,
                VehicleId = 2,
                RefundInformationId = 2,
                RentalInformationId = 2
            },
            new()
            {
                Id = 3,
                ClientId = 3,
                VehicleId = 3,
                RefundInformationId = 3,
                RentalInformationId = 3
            },
            new()
            {
                Id = 4,
                ClientId = 4,
                VehicleId = 4,
                RefundInformationId = 4,
                RentalInformationId = 4
            },
            new()
            {
                Id = 5,
                ClientId = 5,
                VehicleId = 5,
                RefundInformationId = null,
                RentalInformationId = 5
            },
            new()
            {
                Id = 6,
                ClientId = 5,
                VehicleId = 5,
                RefundInformationId = null,
                RentalInformationId = 5
            }
        });
    }
}