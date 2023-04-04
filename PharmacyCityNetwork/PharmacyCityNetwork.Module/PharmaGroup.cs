using System.Collections.Generic;

namespace PharmacyCityNetwork
{
    /// <summary>
    /// Сlass describing an pharma group
    /// </summary>
    public class PharmaGroup
    {
        /// <summary>
        /// Unique Id of Pharma Group
        /// </summary>
        public int PharmaGroupId { get; set; } = 0;
        /// <summary>
        /// Pharma Group Name
        /// </summary>
        public string PharmaGroupName { get; set; } = string.Empty;
        /// <summary>
        /// List Products
        /// </summary>
        //public List<Product> Products = new();

        public PharmaGroup() { }
        public PharmaGroup(string PharmaGroupName)
        {
            this.PharmaGroupName = PharmaGroupName;
        }
    }
}
