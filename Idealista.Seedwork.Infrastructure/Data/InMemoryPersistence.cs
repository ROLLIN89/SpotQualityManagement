using Idealista.Domain;
using System.Collections.Generic;

namespace Idealista.Seedwork.Infrastructure.Data
{
    public class InMemoryPersistence
    {
        private List<Advertisement> advertisements;
        private List<Picture> pictures;

        public InMemoryPersistence()
        {
            advertisements = new List<Advertisement>();
            advertisements.Add(Advertisement.New(1, "CHALET", "Este piso es una ganga, compra, compra, COMPRA!!!!!", houseSize: 300));
            advertisements.Add(Advertisement.New(2, "FLAT", "Nuevo ático céntrico recién reformado. No deje pasar la oportunidad y adquiera este ático de lujo", houseSize: 300, pictureIds: new List<int> { 4 }));
            advertisements.Add(Advertisement.New(3, "CHALET", string.Empty, houseSize: 300, pictureIds: new List<int> { 2 }));
            advertisements.Add(Advertisement.New(4, "FLAT", "Ático céntrico muy luminoso y recién reformado, parece nuevo", houseSize: 300, pictureIds: new List<int> { 5 }));
            advertisements.Add(Advertisement.New(5, "FLAT", "Pisazo,", houseSize: 300, pictureIds: new List<int> { 3, 8 }));
            advertisements.Add(Advertisement.New(6, "GARAGE", string.Empty, houseSize: 300, pictureIds: new List<int> { 6 }));
            advertisements.Add(Advertisement.New(7, "GARAGE", "Garaje en el centro de Albacete", houseSize: 300 ));
            advertisements.Add(Advertisement.New(8, "CHALET", "Maravilloso chalet situado en lAs afueras de un pequeño pueblo rural. El entorno es espectacular, las vistas magníficas. ¡Cómprelo ahora!", houseSize: 300, pictureIds: new List<int> { 1, 7 }));

            pictures = new List<Picture>();
            pictures.Add(Picture.New(1, "http://www.idealista.com/pictures/1", "SD"));
            pictures.Add(Picture.New(2, "http://www.idealista.com/pictures/2", "HD"));
            pictures.Add(Picture.New(3, "http://www.idealista.com/pictures/3", "SD"));
            pictures.Add(Picture.New(4, "http://www.idealista.com/pictures/4", "HD"));
            pictures.Add(Picture.New(5, "http://www.idealista.com/pictures/5", "SD"));
            pictures.Add(Picture.New(6, "http://www.idealista.com/pictures/6", "SD"));
            pictures.Add(Picture.New(7, "http://www.idealista.com/pictures/7", "SD"));
            pictures.Add(Picture.New(8, "http://www.idealista.com/pictures/8", "HD"));
        }

        public List<Picture> GetAllPictures()
        {
            return pictures;
        }

        public List<Advertisement> GetAllAdvertisements()
        {
            return advertisements;
        }
    }
}
