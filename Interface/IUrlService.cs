using URLShortener.Dto;
using URLShortener.Model;

namespace URLShortener.Interface
{
    public interface IUrlService
    {
        Task<ShortenUrlsDto> GetUrlByIdAsync(string shortenUrl);
        Task<Url> AddUrlAsync(CreateUrlDto url);
        Task UpdateUrlAsync(int id, CreateUrlDto url);
        Task DeleteUrlAsync(int id);


    }

}
