using MediatR;

namespace Idealista.Application.Advertisements
{
    public class AdvertisementCommand : IRequest
    {
        public int Id { get; set; }
    }
}
