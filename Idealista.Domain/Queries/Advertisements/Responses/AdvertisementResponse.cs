using System.Collections.Generic;

namespace Idealista.Domain.Queries.Advertisements.Responses
{
    public class AdvertisementResponse
    {

        public int Id { get; set; }
        public string Typology { get; set; }
        public string Description { get; set; }
        public List<string> PictureUrls { get; set; }
        public int HouseSize { get; set; }
        public int GardenSize { get; set; }
    }
}
