using System.ComponentModel.DataAnnotations;

namespace BookingApi.Models
{
    public class BookingRequestModel
    {
        public DateTime BookingTime { get; set; }

        public string Name { get; set; }
    }
}