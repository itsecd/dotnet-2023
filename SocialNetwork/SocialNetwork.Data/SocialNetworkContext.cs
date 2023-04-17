using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data.Models;

namespace SocialNetwork.Data;

/// <summary>
/// База данных для сущностей социальной сети.
/// </summary>
public class SocialNetworkContext : DbContext
{
	/// <summary>
	/// Список групп.
	/// </summary>
	public DbSet<GroupDbModel> Groups { get; set; }

	/// <summary>
	/// Список записей.
	/// </summary>
	public DbSet<NoteDbModel> Notes { get; set; }	

	/// <summary>
	/// Список ролей.
	/// </summary>
	public DbSet<RoleDbModel> Roles { get; set; }

	/// <summary>
	/// Список пользователей.
	/// </summary>
	public DbSet<UserDbModel> Users { get; set; }

	/// <summary>
	/// Список связей пользователей, групп и ролей.
	/// </summary>
	public DbSet<UserGroupRoleDbModel> UsersGroupsRoles { get; set; }

	public SocialNetworkContext(DbContextOptions options) 
		: base(options)
	{
		Database.EnsureCreated();
	}

	/// <summary>
	/// Заполняет таблицы данных.
	/// </summary>
	/// <param name="modelBuilder">Построитель моделей.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		for (var i = 1; i < 10; i++)
		{
			modelBuilder.Entity<UserDbModel>().HasData(new UserDbModel
			{
				Id = i,
				FirstName = $"FirstName {i}",
				LastName = $"LastName {i}",
				Patronymic = $"Patronymic {i}",
				Gender = "Мужской",
				BirthDate = DateTime.Now,
				RegistrationDate = DateTime.Now
			});
		}

		modelBuilder.Entity<RoleDbModel>().HasData(new RoleDbModel
		{
			Id = 1,
			Name = "Админ"
		});


		modelBuilder.Entity<GroupDbModel>().HasData(new GroupDbModel
		{
			Id = 1,
			Name = "Название1",
			Description = "Описание1",
			CreationDate = DateTime.Now,
			UserId = 1
		});

		modelBuilder.Entity<NoteDbModel>().HasData(new NoteDbModel
		{
			Id = 1,
			Name = "Название1",
			Description = "Описание1",
			CreationDate = DateTime.Now,
			UserId = 1,
			GroupId = 1
		});

		modelBuilder.Entity<UserGroupRoleDbModel>().HasData(new UserGroupRoleDbModel
		{
			Id = 1,
			UserId = 1,
			GroupId = 1,
			RoleId = 1,
		});
	}
}
