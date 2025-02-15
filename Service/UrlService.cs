using URLShortener.Dto;
using URLShortener.Interface;
using URLShortener.Model;

namespace URLShortener.Service
{
    public class UrlService : IUrlService
    {
        private readonly IURLShortenerRepository _repository;

        public UrlService(IURLShortenerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Url> AddUrlAsync(CreateUrlDto url)
        {
            var urls = new Url
            {
                url = url.url
            };

           return await _repository.AddUrlAsync(urls);
        }

        public async Task DeleteUrlAsync(int id)
        {
            await _repository.DeleteUrlAsync(id);
        }

        public async Task<ShortenUrlsDto> GetUrlByIdAsync(string shortenUrl)
        {
            var urls = await _repository.GetShortenUrlAsnyc(shortenUrl);
            if (urls == null) return null;

            return new ShortenUrlsDto
            {
                url = urls.url
            };
        }

        public async Task UpdateUrlAsync(int id, CreateUrlDto url)
        {
            var urls = new Url
            {
                Id = id,
                url = url.url
            };

            await _repository.UpdateUrlAsync(urls);
        }
    }
}
