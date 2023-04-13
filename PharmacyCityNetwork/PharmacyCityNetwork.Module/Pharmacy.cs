using System.Collections.Generic;

namespace PharmacyCityNetwork;

    /// <summary>
    /// Сlass describing an Pharmancy
    /// </summary>
    public class Pharmacy
    {
        /// <summary>
        /// Unique Id of Pharmacy
        /// </summary>
        public int PharmacyId { get; set; } = 0;
        /// <summary>
        /// Pharmacy Name
        /// </summary>
        public string PharmacyName { get; set; } = string.Empty;
        /// <summary>
        /// Pharmacy Phone
        /// </summary>
        public string PharmacyPhone { get; set; } = string.Empty;
        /// <summary>
        /// Pharmacy Address
        /// </summary>
        public string PharmacyAddress { get; set; } = string.Empty;
        /// <summary>
        /// Pharmacy Director
        /// </summary>
        public string PharmacyDirector { get; set; } = string.Empty;
        //public ProductPharmacy ProductPharmacy { get; set; } = new();
        public List<ProductPharmacy> ProductPharmacy { get; set; } = new List<ProductPharmacy>();
        public Pharmacy() { }
        public Pharmacy(string pharmancyName, string pharmancyPhone, string pharmancyAddress, string pharmancyDirector)
        {
            PharmacyName = pharmancyName;
            PharmacyPhone = pharmancyPhone;
            PharmacyAddress = pharmancyAddress;
            PharmacyDirector = pharmancyName;
        }

    }
