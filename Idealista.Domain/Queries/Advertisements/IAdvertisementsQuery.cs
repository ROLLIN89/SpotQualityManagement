using Idealista.Domain.Queries.Advertisements.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Idealista.Domain.Queries.Advertisements
{
    public interface IAdvertisementsQuery
    {
        IEnumerable<AdvertisementResponse> GetAll();
        IEnumerable<QualityAdvertisementResponse> GetAllForQuality();
    }
}
