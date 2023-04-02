using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SocialNetwork.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data;

/// <summary>
/// База данных для сущностей социальной сети.
/// </summary>
public class SocialNetworkContext : DbContext
{
	public DbSet<GroupDBModel> Groups { get; set; }

	public DbSet<NoteDBModel> Notes { get; set; }	

	public DbSet<RoleDBModel> Roles { get; set; }

	public DbSet<UserDBModel> Users { get; set; }
	
	public SocialNetworkContext(DbContextOptions options) 
		: base(options)
	{
	}

	//public class Factory : IDesignTimeDbContextFactory<SocialNetworkContext>
	//{
	//	public SocialNetworkContext CreateDbContext(string[] args)
	//	{
	//		var options = new DbContextOptionsBuilder();
	
	//		return new SocialNetworkContext(options);
	//	}
	//}
}
