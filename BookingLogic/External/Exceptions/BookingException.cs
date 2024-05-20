namespace BookingBusinessLogic.External.Exceptions
{
    public enum BookingErrorStatus { ConflictingBookings }

    public class BookingException : Exception
    {
        public BookingErrorStatus Status { get; }

        public BookingException(BookingErrorStatus bookingErrorStatus)
        {
            Status = bookingErrorStatus;
        }
    }
}
