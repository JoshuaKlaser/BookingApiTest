using BookingBusinessLogic.Internal;
using BookingRepository.External;
using BookingRepository.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace BookingBusinessLogic.External
{
    public static class IServiceCollectionExtension
    {
        public static void BuildLogicDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(BookingLogic));

            serviceCollection.AddSingleton<IBookingRepo, BookingRepo>();
        }
    }
}
