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
            var advertisements = database.GetAllAdvertisements().Where(a => a.Score >= 40).OrderByDescending(a => a.Score);
            return mapper.Map<IEnumerable<AdvertisementResponse>>(advertisements);
        }

        public IEnumerable<QualityAdvertisementResponse> GetAllForQuality()
        {
            var advertisements = database.GetAllAdvertisements().Where(a => a.IrrelevantSince != null);
            return mapper.Map<IEnumerable<QualityAdvertisementResponse>>(advertisements);
        }
    }
}
