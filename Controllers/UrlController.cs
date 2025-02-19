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
            var result = await _service.AddUrlAsync(new CreateUrlDto
            {
                url = urlDto.url,
            });

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
           var shortenUrls = await _service.GetUrlByShortenAsync(shortenUrl);
            
           if (shortenUrls == null) return NotFound();
   
           return Ok(shortenUrls);
        }
        [HttpPut("{shortenUrl}")]
        public async Task <IActionResult> UpdateUrlAsync([FromRoute]string shortenUrl, CreateUrlDto urlDto)
        {
            var updateUrl = await _service.UpdateUrlAsync(shortenUrl, urlDto);
            
            if (updateUrl == null) return NotFound();

            return Ok(updateUrl);
        }
        [HttpDelete("{shortenUrl}")]
        public async Task<IActionResult> DeleteUrlAsync(string shortenUrl)
        {
            await _service.DeleteUrlAsync(shortenUrl);
            return NoContent();
        }

        [HttpGet("{shortenUrl}/stats")]
        public async Task <IActionResult> GetStatusAsync(string shortenUrl)
        {
           var stats = await _service.GetStatsByUrlAsync(shortenUrl);
            
           if (stats == null) return NotFound();
   
           return Ok(stats);
        }
    }
}
