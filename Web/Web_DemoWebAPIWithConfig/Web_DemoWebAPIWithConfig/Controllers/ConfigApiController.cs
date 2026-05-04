using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Web_DemoWebAPIWithConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigApiController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;

        public ConfigApiController(IOptions<AppSettings> appSettings, IConfiguration configuration)
        {
            _appSettings = appSettings.Value;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            return Ok(new 
            { 
                AppName = _appSettings.ApplicationName,
                FeatureEnabled = _appSettings.EnableNewFeature,
                ConnectionString = _configuration.GetConnectionString("Default")
            });
        }
    }
}
