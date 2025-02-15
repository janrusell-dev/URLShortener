namespace URLShortener.Dto
{
    public class ShortenUrlsDto
    {
        public int Id { get; set; }
        public string url { get; set; }
        public string? shortenUrl{ get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
