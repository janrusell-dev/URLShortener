using URLShortener.Model;

namespace URLShortener.Interface
{
    public interface IURLShortenerRepository
    {
        Task<Url> AddUrlAsync(Url url);
        Task UpdateUrlAsync(Url url);
        Task DeleteUrlAsync(int id);
        Task<Url> GetShortenUrlAsnyc(string url);

    }
}
