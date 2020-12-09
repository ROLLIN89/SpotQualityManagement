using System.Threading.Tasks;

namespace Idealista.Domain.Services
{
    public interface IAdvertisementService
    {
        Task CalculateScore(int advertisementId);
    }
}
