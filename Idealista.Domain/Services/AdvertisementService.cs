using Idealista.Domain.Enums;
using Idealista.Seedwork.Infrastructure;
using Idealista.Seedwork.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Idealista.Domain.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly InMemoryPersistence database;

        public AdvertisementService(InMemoryPersistence database)
        {
            this.database = database;
        }

        public async Task CalculateScore(int advertisementId)
        {
            var advertisement = database.GetAdversisementById(advertisementId);
            var score = GetScore(advertisement);
            advertisement.SetScore(score);

            if (score < 40)
                advertisement.SetIrrelevantSince(DateTime.Now);
        }

        private int GetScore(Advertisement advertisement)
        {
            var totalScore = 0;

            totalScore += GetScoreByPictures(advertisement);
            totalScore += GetScoreByDescription(advertisement);
            totalScore += GetScoreByFullAdvertisement(advertisement);

            if (totalScore < 0)
                return 0;
            else if (totalScore > 100)
                return 100;
            else
                return totalScore;
        }

        private static int GetScoreByPictures(Advertisement advertisement)
        {
            var scoreByPictures = 0;

            if (advertisement.GetTotalPictures() == 0)
                scoreByPictures -= 10;
            else
            {
                var pictures = advertisement.GetPictures();
                pictures.ForEach(p =>
                {
                    if (p.Quality == QualityEnum.HD.Name)
                        scoreByPictures += 20;
                    else
                        scoreByPictures += 10;
                });
            }

            return scoreByPictures;
        }

        private static int GetScoreByDescription(Advertisement advertisement)
        {
            var scoreByDescription = 0;

            if (!string.IsNullOrEmpty(advertisement.Description))
                scoreByDescription += 5;

            var wordsNumber = advertisement.Description.Split(' ');

            if (advertisement.Typology == TypologyEnum.Flat.Name)
            {
                if (wordsNumber.Length >= 50)
                    scoreByDescription += 30;
                else if (wordsNumber.Length < 50 && wordsNumber.Length >= 20)
                    scoreByDescription += 10;
            }
            else if (advertisement.Typology == TypologyEnum.Chalet.Name && wordsNumber.Length > 50)
                scoreByDescription += 20;

            wordsNumber.ToList().ForEach(w =>
            {
                if (w.Equals("Luminoso") || w.Equals("Nuevo") || w.Equals("Céntrico") || w.Equals("Reformado") || w.Equals("Ático")) scoreByDescription += 5;
            });

            return scoreByDescription;
        }

        private static int GetScoreByFullAdvertisement(Advertisement advertisement)
        {
            if (advertisement.GetTotalPictures() > 0)
            {
                switch (advertisement.Typology)
                {
                    case var f when (f == TypologyEnum.Flat.Name):
                        if (!string.IsNullOrEmpty(advertisement.Description) && advertisement.HouseSize > 0) return 40;
                        break;
                    case var c when (c == TypologyEnum.Chalet.Name):
                        if (!string.IsNullOrEmpty(advertisement.Description) && advertisement.HouseSize > 0 && advertisement.GardenSize > 0) return 40;
                        break;
                    case var g when (g == TypologyEnum.Garage.Name):
                        return 40;
                    default:
                        break;
                }
            }

            return 0;
        }
    }
}
