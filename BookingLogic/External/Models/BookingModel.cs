namespace BookingBusinessLogic.External.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; }
        public DateTime BookingTime { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
