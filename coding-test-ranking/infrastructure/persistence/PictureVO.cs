namespace coding_test_ranking.infrastructure.persistence
{
    public class PictureVO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Quality { get; set; }


        private PictureVO() { }

        public static PictureVO New(int id, string url, string quality)
        {
            var picture = new PictureVO
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
