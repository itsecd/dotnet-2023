
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SocialNetwork.Client;
public class ApiWrapper
{
	private readonly ApiClient _client;

	public ApiWrapper()
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		_client = new ApiClient(configuration.GetSection("ServerUrl").Value, 
			new HttpClient());
	}

	public async Task<ICollection<GroupDtoGet>> GetAllGroups() => await _client.GetAllGroupsAsync();

	public async Task<int> CreateGroup(GroupDtoPostOrPut model) 
		=> await _client.CreateGroupAsync(model);
	

	public async Task UpdateGroup(int id, GroupDtoPostOrPut model)
	{
		await _client.UpdateGroupAsync(id, model);
	}

	public async Task DeleteGroup(int id)
	{
		await _client.DeleteGroupAsync(id);
	}

	public async Task<ICollection<NoteDtoGet>> GetAllNotes() => await _client.GetAllNotesAsync();

	public async Task<int> CreateNote(NoteDtoPostOrPut model) => 
		await _client.CreateNoteAsync(model);
	

	public async Task UpdateNote(int id, NoteDtoPostOrPut model)
	{
		await _client.UpdateNoteAsync(id, model);
	}

	public async Task DeleteNote(int id)
	{
		await _client.DeleteNoteAsync(id);
	}

	public async Task<ICollection<RoleDtoGet>> GetAllRoles() => await _client.GetAllRolesAsync();

	public async Task<int> CreateRole(RoleDtoPostOrPut model) => 
		await _client.CreateRoleAsync(model);
	

	public async Task UpdateRole(int id, RoleDtoPostOrPut model)
	{
		await _client.UpdateRoleAsync(id, model);
	}

	public async Task DeleteRole(int id)
	{
		await _client.DeleteRoleAsync(id);
	}

	public async Task<ICollection<UserDtoGet>> GetAllUsers() => await _client.GetAllUsersAsync();

	public async Task<int> CreateUser(UserDtoPostOrPut model) => 
		await _client.CreateUserAsync(model);
	

	public async Task UpdateUser(int id, UserDtoPostOrPut model)
	{
		await _client.UpdateUserAsync(id, model);
	}

	public async Task DeleteUser(int id)
	{
		await _client.DeleteUserAsync(id);
	}
}
