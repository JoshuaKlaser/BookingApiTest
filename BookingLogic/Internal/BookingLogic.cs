using AutoMapper;
using BookingBusinessLogic.External;
using BookingBusinessLogic.External.Exceptions;
using BookingBusinessLogic.External.Models;
using BookingRepository.External;
using BookingRepository.External.Model;
using Microsoft.Extensions.Logging;

namespace BookingBusinessLogic.Internal
{
    public class BookingLogic : IBookingLogic
    {
        private IBookingRepo _bookingRepo;
        private ILogger<BookingLogic> _logger;
        private IMapper _mapper;

        public BookingLogic(IBookingRepo bookingRepo, ILogger<BookingLogic> logger, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _logger = logger;
            _mapper = mapper;
        }

        public Guid CreateBooking(DateTime bookingTime, string bookingName)
        {
            var allBookings = _bookingRepo.GetAll();
            var conflictingBookings = GetConflictingBookings(bookingTime, allBookings);

            if (conflictingBookings.Count() >= 4)
                throw new BookingException(BookingErrorStatus.ConflictingBookings);

            var newBookingEntity = new BookingEntity
            {
                Id = Guid.NewGuid(),
                BookingTime = bookingTime,
                Name = bookingName
            };

            _bookingRepo.Save(newBookingEntity);

            return newBookingEntity.Id;
        }

        private IEnumerable<BookingEntity> GetConflictingBookings(DateTime bookingTime, IEnumerable<BookingEntity> bookingEntities)
        {
            var conflictingBookings = bookingEntities.Where(be => bookingTime >= be.BookingTime && bookingTime < be.BookingTime.AddHours(1));

            return conflictingBookings;
        }
    }
}
