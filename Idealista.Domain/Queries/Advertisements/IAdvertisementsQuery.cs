using Idealista.Domain.Queries.Advertisements.Responses;
using System.Collections.Generic;

namespace Idealista.Domain.Queries.Advertisements
{
    public interface IAdvertisementsQuery
    {
        IEnumerable<AdvertisementResponse> GetAllRelevant();
        IEnumerable<QualityAdvertisementResponse> GetAllIrrelevant();
    }
}
