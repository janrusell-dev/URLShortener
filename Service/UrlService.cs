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

            string shortCode = Guid.NewGuid().ToString().Substring(0, 6);
            string shortenedUrl = $"{shortCode}";

            var urls = new Url
            {
                url = url.url,
                shortenUrl = shortenedUrl    
            };

           return await _repository.AddUrlAsync(urls);
        }

        public async Task<Url> DeleteUrlAsync(string shortenUrl)
        {
           return await _repository.DeleteUrlAsync(shortenUrl);
        }

        public async Task<ShortenUrlsDto> GetUrlByShortenAsync(string shortenUrl)
        {
            var urls = await _repository.GetShortenUrlAsnyc(shortenUrl);
            if (urls == null) return null;

            return new ShortenUrlsDto
            {
                Id = urls.Id,
                url = urls.url,
                shortenUrl = urls.shortenUrl,
                createdAt = urls.createdAt,
                updatedAt = urls.updatedAt    
            };
        }

        public async Task <GetStatsDto> GetStatsByUrlAsync(string shortenUrl)
        {
            var urls =  await _repository.GetUrlStatsAsync(shortenUrl);
            if (urls == null) return null;

            return new GetStatsDto
            {
                Id = urls.Id,
                url = urls.url,
                shortenUrl = urls.shortenUrl,
                createdAt = urls.createdAt,
                updatedAt = urls.updatedAt,
                accessCount = urls.accessCount
            };
        }

        public async Task <Url> UpdateUrlAsync(string shortenUrl, CreateUrlDto url)
        {
            var urls = new Url
            {
                url = url.url
            };
            return await _repository.UpdateUrlAsync(shortenUrl, url);
        }
    }
}
