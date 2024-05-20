using AutoMapper;
using BookingApi.Models;
using BookingApi.Validation;
using BookingBusinessLogic.External;
using BookingBusinessLogic.External.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private IBookingLogic _bookingLogic;
        private readonly ILogger<BookingController> _logger;
        private IMapper _mapper;

        public BookingController(IBookingLogic bookingLogic, ILogger<BookingController> logger, IMapper mapper)
        {
            _bookingLogic = bookingLogic;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Test hello!");
        }

        [HttpPost]
        public IActionResult PostBooking(BookingRequestModel requestModel)
        {
            var isBookingValid = Validator.ValidateBookingRequestModel(requestModel);

            if (!isBookingValid)
                return BadRequest();

            try
            {
                var bookingId = _bookingLogic.CreateBooking(requestModel.BookingTime, requestModel.Name);
                var responseModel = new BookingResponseModel
                {
                    BookingId = bookingId
                };

                return Ok(responseModel);
            }
            catch (BookingException ex)
            {
                if (ex.Status == BookingErrorStatus.ConflictingBookings)
                    return Conflict();

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred in {nameof(PostBooking)}", ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}