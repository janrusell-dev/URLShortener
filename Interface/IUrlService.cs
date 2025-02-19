using URLShortener.Dto;
using URLShortener.Model;

namespace URLShortener.Interface
{
    public interface IUrlService
    {
        Task<ShortenUrlsDto> GetUrlByShortenAsync(string shortenUrl);
        Task<Url> AddUrlAsync(CreateUrlDto url);
        Task<Url> UpdateUrlAsync(string shortenUrl, CreateUrlDto urls);
        Task<Url> DeleteUrlAsync(string shortenUrl);
        Task<GetStatsDto> GetStatsByUrlAsync(string shortenUrl);
    }

}
