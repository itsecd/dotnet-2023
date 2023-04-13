namespace PharmacyCityNetwork;

    /// <summary>
    /// Сlass describing an Sale
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Unique Id of Sale
        /// </summary>
        public int SaleId { get; set; } = 0;
        /// <summary>
        /// Payment Choice
        /// </summary>
        public string PaymentChoice { get; set; } = string.Empty;
        /// <summary>
        /// Payment Date
        /// </summary>
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Pharmacy
        /// </summary>
        //public Pharmacy Pharmacy { get; set; } = new ();
        /// <summary>
        /// Product
        /// </summary>
        public Product Product { get; set; } 
        public Sale() { }
        public Sale(string paymentChoice, DateTime paymentDate, Product product)
        {
            PaymentChoice = paymentChoice;
            PaymentDate = paymentDate;
            Product = product;
        }
    }
