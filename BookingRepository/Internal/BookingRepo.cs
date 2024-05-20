using BookingRepository.External;
using BookingRepository.External.Model;

namespace BookingRepository.Internal
{
    public class BookingRepo : IBookingRepo
    {
        private List<BookingEntity> _bookings;

        public BookingRepo()
        {
            _bookings = new List<BookingEntity>();
        }

        public ICollection<BookingEntity> GetAll()
        {
            return _bookings;
        }

        public void Save(BookingEntity booking)
        {
            _bookings.Add(booking);
        }
    }
}
