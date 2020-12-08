using AutoMapper;
using Idealista.Domain.Queries.Advertisements;
using Idealista.Domain.Queries.Advertisements.Responses;
using Idealista.Seedwork.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;

namespace Idealista.Infrastructure.Queries.Advertisements
{
    public class AdvertisementsQuery : IAdvertisementsQuery
    {
        private readonly IMapper mapper;
        private readonly InMemoryPersistence database;

        public AdvertisementsQuery(InMemoryPersistence database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public IEnumerable<AdvertisementResponse> GetAll()
        {
            var advertisements = database.GetAllAdvertisements();
            return mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements.OrderByDescending(a => a.Score));
        }

        public IEnumerable<QualityAdvertisementResponse> GetAllForQuality()
        {
            return null;
        }
    }
}
