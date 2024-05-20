using BookingRepository.External.Model;

namespace BusinessLogic.UnitTest.Mocks
{
    public static class BookingRepositoryMockData
    {
        public static List<BookingEntity>  BOOKING_REPO_WITH_NINEAM_TO_TENAM_FULLY_BOOKED = new List<BookingEntity> {
            new BookingEntity
            {
                Id = Guid.NewGuid(),
                BookingTime = DateTime.Today.AddHours(9),
                Name = "BookingOne"
            },
            new BookingEntity
            {
                Id = Guid.NewGuid(),
                BookingTime = DateTime.Today.AddHours(9),
                Name = "BookingTwo"
            },
            new BookingEntity
            {
                Id = Guid.NewGuid(),
                BookingTime = DateTime.Today.AddHours(9),
                Name = "BookingThree"
            },
            new BookingEntity
            {
                Id = Guid.NewGuid(),
                BookingTime = DateTime.Today.AddHours(9),
                Name = "BookingFour"
            }
        };  
    }
}
