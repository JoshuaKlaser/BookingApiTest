using BookingBusinessLogic.External.Exceptions;
using BookingBusinessLogic.Internal;
using BookingRepository.External;
using BookingRepository.External.Model;
using BusinessLogic.UnitTest.Mocks;
using Moq;

namespace BusinessLogic.UnitTest.Tests.Booking
{
    [TestFixture]
    public class Tests
    {
        private BookingLogic _bookingLogic;

        [SetUp]
        public void Setup()
        {
            var mockBookingRepository = new Mock<IBookingRepo>();

            mockBookingRepository.Setup(br => br.GetAll()).Returns(BookingRepositoryMockData.BOOKING_REPO_WITH_NINEAM_TO_TENAM_FULLY_BOOKED);
            mockBookingRepository.Setup(br => br.Save(It.IsAny<BookingEntity>()));

            _bookingLogic = new BookingLogic(mockBookingRepository.Object, null, null);
        }

        [Test]
        public void WhenNineAmToTenAmIsFullyBooked_BookingNine_ShouldThrowException()
        {
            var exception = Assert.Throws<BookingException>(() => _bookingLogic.CreateBooking(DateTime.Today.AddHours(9), "ShouldFail"));

            Assert.That(exception.Status, Is.EqualTo(BookingErrorStatus.ConflictingBookings));
        }

        [Test]
        public void WhenNineAmToTenAmIsFullyBooked_BookingNineThirty_ShouldThrowException()
        {
            var exception = Assert.Throws<BookingException>(() => _bookingLogic.CreateBooking(DateTime.Today.AddHours(9).AddMinutes(30), "ShouldFail"));

            Assert.That(exception.Status, Is.EqualTo(BookingErrorStatus.ConflictingBookings));
        }

        [Test]
        public void WhenNineAmToTenAmIsFullyBooked_BookingNineFiftyNine_ShouldThrowException()
        {
            var exception = Assert.Throws<BookingException>(() => _bookingLogic.CreateBooking(DateTime.Today.AddHours(9).AddMinutes(59), "ShouldFail"));

            Assert.That(exception.Status, Is.EqualTo(BookingErrorStatus.ConflictingBookings));
        }

        [Test]
        public void WhenNineAmToTenAmIsFullyBooked_BookingTen_ShouldSucceed()
        {
             var newBookingId = _bookingLogic.CreateBooking(DateTime.Today.AddHours(10), "ShouldFail");

            Assert.IsTrue(newBookingId != Guid.Empty);
        }
    }
}