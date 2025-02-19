using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomeController : ControllerBase
    {
        private readonly ILogger<SomeController> _logger;
        private readonly ISomeService _someService;


        public SomeController(ILogger<SomeController> logger, ISomeService someService)
        {
            _someService = someService;
            _logger = logger;
        }

        [HttpGet("/test")]
        public string GetSomething()
        {
            _logger.LogInformation("ֲûחמג לועמהא GetTestLifeCycle");

            return _someService.GetTestLifeCycle();
        }
    }
}
