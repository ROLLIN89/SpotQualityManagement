using System;

namespace Idealista.Domain.Queries.Advertisements.Responses
{
    public class QualityAdvertisementResponse : AdvertisementResponse
    {
        public int Score { get; set; }
        public DateTime IrrelevantSince { get; set; }
    }
}
