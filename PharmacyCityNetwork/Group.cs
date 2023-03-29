namespace PharmacyCityNetwork
{
	/// <summary>
	/// Сlass describing an group
	/// </summary>
	public class Group
	{
		/// <summary>
		/// Unique Id of Group
		/// </summary>
		public int GroupId { get; set; } = 0;
		/// <summary>
		/// Group Name
		/// </summary>
		public string GroupName { get; set; } = string.Empty;
		public Group() { }
		public Group(string GroupName)
		{
			this.GroupName = GroupName;
		}
	}
}
