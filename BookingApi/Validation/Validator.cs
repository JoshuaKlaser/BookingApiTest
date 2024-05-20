using BookingApi.Models;

namespace BookingApi.Validation
{
    public static class Validator
    {
        private static readonly DateTime DATE_RANGE_START = DateTime.Today.AddHours(9);
        private static readonly DateTime DATE_RANGE_END = DateTime.Today.AddHours(17);

        public static bool ValidateBookingRequestModel(BookingRequestModel requestModel)
        {
            if (requestModel == null)
                return false;

            if (string.IsNullOrWhiteSpace(requestModel.Name))
                return false;

            if (requestModel.BookingTime < DATE_RANGE_START || requestModel.BookingTime >= DATE_RANGE_END)
                return false;

            return true;
        }
    }
}
