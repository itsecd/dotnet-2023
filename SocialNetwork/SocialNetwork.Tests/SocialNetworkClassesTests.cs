using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using SocialNetwork.Domain;

namespace SocialNetwork.Tests;

/// <summary>
/// ������������ ���������� ������� ��������� ���������� ����.
/// </summary>
public class SocialNetworkClassesTests 
{
	#region ������.
	/// <summary>
	/// �������� ������ � ������������� ����������� � ������������.
	/// </summary>
	/// <param name="groupId">������������� ������.</param>
	/// <param name="name">�������� ������.</param>
	/// <param name="description">�������� ������.</param>
	/// <param name="userId">������������� ��������� ������.</param>
	/// <param name="isCorrectUser">���������� �� ������������ ����� ������ � ������������.</param>
	/// <param name="isCorrectNotesList">���������� �� ������ ������� ����� ������ � ������������.</param>
	/// <param name="exceptionType">��� ����������, ������� ������ ���� �������.</param>
	[Theory]
	[InlineData(-1, "������", "�������� ������", 1, true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, "�������� ������", 1, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "������", null, 1, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "������", "�������� ������", -1, true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, "������", "�������� ������", 1, false, true, typeof(ArgumentNullException))]
	[InlineData(1, "������", "�������� ������", 1, true, false, typeof(ArgumentNullException))]
	public void InitGroup_WithIncorrectValue_ShouldThrowException(int groupId, string name, string description, 
		int userId, bool isCorrectUser, bool isCorrectNotesList, Type exceptionType) 
	{
		try
		{
			new Domain.Group(groupId, name, description, DateTime.Now, userId,
				isCorrectUser ? new User() : null, isCorrectNotesList ? new List<Note>() : null);
			Assert.Fail(ConstValues.NotThrowsException);
		}
		catch (ArgumentOutOfRangeException ex) 
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}

	}

	/// <summary>
	/// �������� ������ � ������������� ����������� � ������������.
	/// </summary>
	/// <param name="id">������������� ������.</param>
	/// <param name="name">�������� ������.</param>
	/// <param name="description">�������� ������.</param>
	/// <param name="userId">������������� ��������� ������.</param>
	/// <param name="isCorrectUser">���������� �� ������������ ����� ������ � ������������.</param>
	/// <param name="groupId">������������� ������.</param>
	/// <param name="isCorrectGroup">���������� �� ������ ����� ������� � ������������.</param>
	/// <param name="exceptionType">��� ����������, ������� ������ ���� �������.</param>
	[Theory]
	[InlineData(-1, "�������� ������", "�������� ������", 1, true, 1, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, "�������� ������", 1, true, 1, true, typeof(ArgumentNullException))]
	[InlineData(1, "�������� ������", null, 1, true, 1, true, typeof(ArgumentNullException))]
	[InlineData(1, "�������� ������", "�������� ������", -1, true, 1, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, "�������� ������", "�������� ������", 1,false, 1, true, typeof(ArgumentNullException))]
	[InlineData(1, "�������� ������", "�������� ������", 1, true, -1, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, "�������� ������", "�������� ������", 1, true, 1, false, typeof(ArgumentNullException))]
	public void InitNote_WithIncorrectValue_ShouldThrowException(int id, string name, string description, int userId,
		bool isCorrectUser, int groupId, bool isCorrectGroup, Type exceptionType)
	{
		try
		{
			new Note(id, name, description, DateTime.Now, userId, isCorrectUser ?
				new User() : null, groupId, isCorrectGroup ? ConstValues.DefaultGroup : null);
			Assert.Fail(ConstValues.NotThrowsException);
		}
		catch (ArgumentOutOfRangeException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
	}

	/// <summary>
	/// �������� ���� � ������������� ����������� � ������������.
	/// </summary>
	/// <param name="roleId">������������� ����.</param>
	/// <param name="name">�������� ����.</param>
	/// <param name="isCorrectUsersList">���������� �� ������ ������������� ����� ������������ � �����������.</param>
	/// <param name="isCorrectGroupsList">���������� �� ������ ����� ����� ������������ � �����������.</param>
	/// <param name="exceptionType">��� ����������, ������� ������ ���� �������.</param>
	[Theory]
	[InlineData(-1, "�������� ����", true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "�������� ����", false, true, typeof(ArgumentNullException))]
	[InlineData(1, "�������� ����", true, false, typeof(ArgumentNullException))]
	public void InitRole_WithIncorrectValue_ShouldThrowException(int roleId, string name, 
		bool isCorrectUsersList, bool isCorrectGroupsList, Type exceptionType)
	{
		try
		{
			new Role(roleId, name, isCorrectUsersList ? ConstValues.DefaultUsersList : null, 
				isCorrectGroupsList ? ConstValues.DefaultGroupsList : null);
			Assert.Fail(ConstValues.NotThrowsException);
		}
		catch (ArgumentOutOfRangeException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
	}

	/// <summary>
	/// �������� ������������ � ������������� ����������� � ������������.
	/// </summary>
	/// <param name="userId">������������� ������������.</param>
	/// <param name="firstName">��� ������������.</param>
	/// <param name="lastName">������� ������������.</param>
	/// <param name="patronymic">�������� ������������.</param>
	/// <param name="gender">���.</param>
	/// <param name="isCorrectNotesList">���������� �� ������ ������� ����� ������������ � �����������.</param>
	/// <param name="isCorrectGroupsList">���������� �� ������ ����� ����� ������������ � �����������.</param>
	/// <param name="isCorrectRolesList">���������� �� ������ ����� ����� ������������ � �����������.</param>
	/// <param name="exceptionType">��� ����������, ������� ������ ���� �������.</param>
	[Theory]
	[InlineData(-1, "���", "�������", "��������", "���", true, true, true, typeof(ArgumentOutOfRangeException))]
	[InlineData(1, null, "�������", "��������", "���", true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "���", null, "��������", "���", true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "���", "�������", null, "���", true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "���", "�������", "��������", null, true, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "���", "�������", "��������", "���", false, true, true, typeof(ArgumentNullException))]
	[InlineData(1, "���", "�������", "��������", "���", true, false, true, typeof(ArgumentNullException))]
	[InlineData(1, "���", "�������", "��������", "���", true, true, false, typeof(ArgumentNullException))]
	public void InitUser_WithIncorrectValue_ShouldThrowException(int userId, string firstName, 
		string lastName, string patronymic, string gender, bool isCorrectNotesList, 
		bool isCorrectGroupsList, bool isCorrectRolesList, Type exceptionType)  
	{
		try
		{
			new User(userId, firstName, lastName, patronymic, gender, DateTime.Now, DateTime.Now, isCorrectNotesList
				? ConstValues.DefaultNotesList : null, isCorrectGroupsList ?
				ConstValues.DefaultGroupsList : null, isCorrectRolesList ?
				ConstValues.DefaultRolesList : null);
			Assert.Fail(ConstValues.NotThrowsException);
		}
		catch (ArgumentOutOfRangeException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
		catch (ArgumentNullException ex)
		{
			Assert.True(ex.GetType() == exceptionType);
		}
	}
	#endregion
}