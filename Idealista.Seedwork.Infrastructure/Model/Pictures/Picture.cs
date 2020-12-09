namespace Idealista.Seedwork.Infrastructure
{
    public class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Quality { get; set; }


        private Picture() { }

        public static Picture New(int id, string url, string quality)
        {
            var picture = new Picture
            {
                Id = id,
                Url = url,
                Quality = quality
            };

            return picture;
        }

        public void SetId(int id) { Id = id; }
        public void SetUrl(string url) { Url = url; }
        public void SetQuality(string quality) { Quality = quality; }
    }
}
