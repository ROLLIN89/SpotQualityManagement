using System;
using System.Collections.Generic;

namespace Idealista.Domain
{
    public class Advertisement
    {
        public int Id { get; private set; }
        public string Typology { get; private set; }
        public string Description { get; private set; }
        public int? HouseSize { get; private set; }
        public int? GardenSize { get; private set; }
        public int Score { get; private set; }
        public DateTime? IrrelevantSince { get; private set; }

        internal List<int> pictures = new List<int>();
        public IReadOnlyCollection<int> Pictures => pictures.AsReadOnly();


        private Advertisement() { }

        public static Advertisement New(int id, string typology, string description, int? houseSize = null, int? gardenSize = null, List<int> pictureIds = null)
        {
            var advertisement = new Advertisement
            {
                Id = id,
                Typology = typology,
                Description = description,
                HouseSize = houseSize,
                GardenSize = gardenSize,
                Score = 0,
                IrrelevantSince = null,
                pictures = pictureIds
            };

            return advertisement;
        }

        public void SetId(int id) { Id = id; }
        public void SetTypology(string typology) { Typology = typology; }
        public void SetDescription(string description) { Description = description; }
        public void SetHouseSize(int? houseSize) { HouseSize = houseSize; }
        public void SetGardenSize(int? gardenSize) { GardenSize = gardenSize; }
        public void SetScore(int score) { Score = score; }
        public void SetIrrelevantSince(DateTime? irrelevantSince) { IrrelevantSince = irrelevantSince; }
        
        public void ClearPictures()
        {
            pictures.Clear();
        }
        public void AddPictures(int pictureId)
        {
            pictures.Add(pictureId);
        }
    }
}
