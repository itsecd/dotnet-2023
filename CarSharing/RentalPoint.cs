namespace CarSharing
{
    /// <summary>
    /// this class describes rental point where client can rent a car
    /// </summary>
    public class RentalPoint
    {
        /// <summary>
        /// name of the rental point
        /// </summary>
        public string PointName { get; set; } = string.Empty;

        /// <summary>
        /// address of the rental point
        /// </summary>

        public string PointAddress { get; set; } = string.Empty;

        /// <summary>
        /// id of the rental point
        /// </summary>

        public Guid PointId { get; set; } = Guid.Empty;
        public RentalPoint() { }

        public RentalPoint(Guid pointId, string pointName, string pointAddress)
        {
            PointId = pointId;
            PointName = pointName;
            PointAddress = pointAddress;

        }
    }
}
