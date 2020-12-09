using Idealista.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Idealista.Application.Advertisements
{
    public class AdvertisementCommandHandler : IRequestHandler<AdvertisementCommand, Unit>
    {
        private readonly IAdvertisementService advertisementService;

        public AdvertisementCommandHandler(IAdvertisementService advertisementService)
        {
            this.advertisementService = advertisementService;
        }

        public async Task<Unit> Handle(AdvertisementCommand advertisement, CancellationToken cancellationToken)
        {
            await advertisementService.CalculateScore(advertisement.Id);
            return Unit.Value;
        }
    }
}
