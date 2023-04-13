namespace PharmacyCityNetwork;

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
    public List<Product> Product{ get; set; } = new List<Product>();
    public Group() { }

		public Group(string groupName, int groupId)
		{
			GroupName = groupName;
			GroupId = groupId;
		}
	}
