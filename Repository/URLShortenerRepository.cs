using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Dto;
using URLShortener.Interface;
using URLShortener.Model;

namespace URLShortener.Repository
{
    public class URLShortenerRepository : IURLShortenerRepository
    {
        private readonly ApplicationDbContext _context;
        public URLShortenerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Url> AddUrlAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<Url> DeleteUrlAsync(string shortenUrl)
        {
            var url = _context.Urls.FirstOrDefault(i => i.shortenUrl == shortenUrl);

            if (url != null)
            {
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
            }
            return url;
        }

        public async Task<Url> GetShortenUrlAsnyc(string shortenUrl)
        {
           var url =  await _context.Urls.FirstOrDefaultAsync(u => u.shortenUrl== shortenUrl);
            
            url.accessCount++;
            _context.Urls.Update(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public async Task<Url> GetUrlStatsAsync(string shortenUrl)
        {
            return await _context.Urls.FirstOrDefaultAsync(i => i.shortenUrl == shortenUrl);
        }

        public async Task <Url> UpdateUrlAsync(string shortenUrl , CreateUrlDto urlDto)
        {
         var getUrl = await _context.Urls.FirstOrDefaultAsync(i => i.shortenUrl == shortenUrl);
        
         if (getUrl == null)
         {
             throw new KeyNotFoundException("URL not found.");
         }

        getUrl.url = urlDto.url;

        _context.Urls.Update(getUrl); 
        await _context.SaveChangesAsync(); 

        return getUrl;
        }

    }
}
