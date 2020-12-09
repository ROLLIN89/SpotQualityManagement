using System.Threading.Tasks;

namespace Idealista.Domain.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        //private readonly InMemoryPersistence database;

        public AdvertisementService()//InMemoryPersistence database)
        {
            //this.database = database;
        }

        public async Task CalculateScore(int advertisementId)
        {
            //var advertisement = await database.GetAdversisementById(advertisementId);

        }
    }
}
