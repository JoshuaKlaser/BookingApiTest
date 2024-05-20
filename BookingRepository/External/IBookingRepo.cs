using BookingRepository.External.Model;

namespace BookingRepository.External
{
    public interface IBookingRepo
    {
        ICollection<BookingEntity> GetAll();
        void Save(BookingEntity booking);
    }
}
