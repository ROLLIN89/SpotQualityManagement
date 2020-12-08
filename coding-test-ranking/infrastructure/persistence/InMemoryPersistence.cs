using System.Collections.Generic;

namespace coding_test_ranking.infrastructure.persistence
{
    public class InMemoryPersistence
    {
        private List<AdvertisementVO> advertisements;
        private List<PictureVO> pictures;

        public InMemoryPersistence()
        {
            advertisements = new List<AdvertisementVO>();
            advertisements.Add(AdvertisementVO.New(1, "CHALET", "Este piso es una ganga, compra, compra, COMPRA!!!!!", houseSize: 300));
            advertisements.Add(AdvertisementVO.New(2, "FLAT", "Nuevo ático céntrico recién reformado. No deje pasar la oportunidad y adquiera este ático de lujo", houseSize: 300, pictureIds: new List<int> { 4 }));
            advertisements.Add(AdvertisementVO.New(3, "CHALET", string.Empty, houseSize: 300, pictureIds: new List<int> { 2 }));
            advertisements.Add(AdvertisementVO.New(4, "FLAT", "Ático céntrico muy luminoso y recién reformado, parece nuevo", houseSize: 300, pictureIds: new List<int> { 5 }));
            advertisements.Add(AdvertisementVO.New(5, "FLAT", "Pisazo,", houseSize: 300, pictureIds: new List<int> { 3, 8 }));
            advertisements.Add(AdvertisementVO.New(6, "GARAGE", string.Empty, houseSize: 300, pictureIds: new List<int> { 6 }));
            advertisements.Add(AdvertisementVO.New(7, "GARAGE", "Garaje en el centro de Albacete", houseSize: 300 ));
            advertisements.Add(AdvertisementVO.New(8, "CHALET", "Maravilloso chalet situado en lAs afueras de un pequeño pueblo rural. El entorno es espectacular, las vistas magníficas. ¡Cómprelo ahora!", houseSize: 300, pictureIds: new List<int> { 1, 7 }));

            pictures = new List<PictureVO>();
            pictures.Add(PictureVO.New(1, "http://www.idealista.com/pictures/1", "SD"));
            pictures.Add(PictureVO.New(2, "http://www.idealista.com/pictures/2", "HD"));
            pictures.Add(PictureVO.New(3, "http://www.idealista.com/pictures/3", "SD"));
            pictures.Add(PictureVO.New(4, "http://www.idealista.com/pictures/4", "HD"));
            pictures.Add(PictureVO.New(5, "http://www.idealista.com/pictures/5", "SD"));
            pictures.Add(PictureVO.New(6, "http://www.idealista.com/pictures/6", "SD"));
            pictures.Add(PictureVO.New(7, "http://www.idealista.com/pictures/7", "SD"));
            pictures.Add(PictureVO.New(8, "http://www.idealista.com/pictures/8", "HD"));
        }

        public List<PictureVO> GetAllPictures()
        {
            return pictures;
        }

        public List<AdvertisementVO> GetAllAdvertisements()
        {
            return advertisements;
        }
    }
}
