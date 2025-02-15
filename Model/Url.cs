namespace URLShortener.Model
{
    public class Url
    {
        public int Id { get; set; }
        public string url  { get; set; }

        public string? shortenUrl { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; } = DateTime.UtcNow;
    }
}
