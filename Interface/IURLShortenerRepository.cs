using URLShortener.Dto;
using URLShortener.Model;

namespace URLShortener.Interface
{
    public interface IURLShortenerRepository
    {
        Task<Url> AddUrlAsync(Url url);
        Task<Url> UpdateUrlAsync(string shortenUrl, CreateUrlDto url);
        Task<Url> DeleteUrlAsync(string shortenUrl);
        Task<Url> GetShortenUrlAsnyc(string url);
        Task<Url> GetUrlStatsAsync(string url);
    }
}
