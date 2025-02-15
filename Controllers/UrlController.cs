using Microsoft.AspNetCore.Mvc;
using URLShortener.Dto;
using URLShortener.Interface;

namespace URLShortener.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _service;
        public UrlController(IUrlService service)   
        {
            _service = service;
        }

        [HttpPost]
        public async Task <IActionResult> AddUrlAsync([FromBody] CreateUrlDto urlDto)
        {
            string shortCode = Guid.NewGuid().ToString().Substring(0, 6);
            string shortenedUrl = $"{shortCode}";

            var result = await _service.AddUrlAsync(new CreateUrlDto
            {
                url = urlDto.url,
            });

            result.shortenUrl = shortenedUrl;

            var response = new ShortenUrlsDto
            {
                Id = result.Id,
                url = result.url,
                shortenUrl = result.shortenUrl,
                createdAt = result.createdAt,
                updatedAt = result.updatedAt
            };

            return Ok(response);
        }
        [HttpGet("{shortenUrl}")]
        public async Task<IActionResult> GetByIdAsync(string shortenUrl)
        {
           var shortenUrls = await _service.GetUrlByIdAsync(shortenUrl);
            
           if (shortenUrls == null) return NotFound();
   
           return Ok(shortenUrls);
        }
        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateUrlAsync(int id, [FromBody] CreateUrlDto urlDto)
        {
            await _service.UpdateUrlAsync(id, urlDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrlAsync(int id)
        {
            await _service.DeleteUrlAsync(id);
            return NoContent();
        }
    }
}
