using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
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

        public async Task DeleteUrlAsync(int id)
        {
            var url = await _context.Urls.FindAsync(id);

            if (url != null)
            {
                _context.Urls.Remove(url);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Url> GetShortenUrlAsnyc(string shortenUrl)
        {
            return await _context.Urls.FirstOrDefaultAsync(u => u.shortenUrl== shortenUrl);
        }

    

        public async Task UpdateUrlAsync(Url url)
        {
             _context.Urls.Update(url);
            await _context.SaveChangesAsync();
        }
    }
}
