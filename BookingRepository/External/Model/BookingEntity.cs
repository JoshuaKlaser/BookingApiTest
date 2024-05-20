namespace BookingRepository.External.Model
{
    public class BookingEntity
    {
        public Guid Id { get; set; }
        public DateTime BookingTime { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
