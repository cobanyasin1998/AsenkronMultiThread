using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("İstek Başladı");

                await Task.Delay(5000, token);

                var myTask = new HttpClient().GetStringAsync("https://www.google.com");
                var data = await myTask;

                _logger.LogInformation("İstek Bitti");
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("İstek İptal Edildi: " + ex.Message);
                return BadRequest();
            }


        }
    }
}
