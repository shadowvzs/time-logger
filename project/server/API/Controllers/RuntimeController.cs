using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RuntimeController : BaseController
    {

        private readonly IConfiguration _configuration;

        public RuntimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/runtime/
        [HttpGet]
        public string Version()
        {
            return _configuration["Version"];
        }
    }
}