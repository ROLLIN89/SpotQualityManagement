using System;

namespace coding_test_ranking.infrastructure.api
{
    public class QualityAdvertisement : Advertisement
    {
        public int Score { get; set; }
        public DateTime IrrelevantSince { get; set; }
    }
}
