namespace ParcelManagement.Domain.Entities
{
    public class Parcel
    {

        public Guid Id { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string DestinationAddress { get; set; } = string.Empty;
        public double WeightKg { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
