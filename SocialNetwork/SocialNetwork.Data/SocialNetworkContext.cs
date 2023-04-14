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
	public DbSet<GroupDBModel> Groups { get; set; }

	/// <summary>
	/// Список записей.
	/// </summary>
	public DbSet<NoteDBModel> Notes { get; set; }	

	/// <summary>
	/// Список ролей.
	/// </summary>
	public DbSet<RoleDBModel> Roles { get; set; }

	/// <summary>
	/// Список пользователей.
	/// </summary>
	public DbSet<UserDBModel> Users { get; set; }

	/// <summary>
	/// Список связей пользователей, групп и ролей.
	/// </summary>
	public DbSet<UserGroupRoleDBModel> UsersGroupsRoles { get; set; }

	public SocialNetworkContext(DbContextOptions options) 
		: base(options)
	{
		Database.EnsureCreated();
	}
}
