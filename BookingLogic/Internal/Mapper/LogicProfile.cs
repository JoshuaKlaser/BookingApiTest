using AutoMapper;
using BookingBusinessLogic.External.Models;
using BookingRepository.External.Model;

namespace BookingBusinessLogic.Internal.Mapper
{
    public class LogicProfile : Profile
    {
        public LogicProfile()
        {
            CreateMap<BookingModel, BookingEntity>();
            CreateMap<BookingEntity, BookingModel>();
        }
    }
}
