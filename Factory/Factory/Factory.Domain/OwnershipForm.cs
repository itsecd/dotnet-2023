using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;
internal class OwnershipForm
{
    /// <summary>
    /// OwnershipForm's ID
    /// </summary>
    public int OwnershipFormID { get; set; } = 0;

    /// <summary>
    /// OwnershipForm name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public OwnershipForm() { }

    public OwnershipForm(int ownershipFormID, string name)
    {
        OwnershipFormID = ownershipFormID;
        Name = name;
    }
}
