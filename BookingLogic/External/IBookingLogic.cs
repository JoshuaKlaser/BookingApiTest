using BookingBusinessLogic.External.Models;

namespace BookingBusinessLogic.External
{
    public interface IBookingLogic
    {
        public Guid CreateBooking(DateTime bookingTime, string bookingName);
    }
}
