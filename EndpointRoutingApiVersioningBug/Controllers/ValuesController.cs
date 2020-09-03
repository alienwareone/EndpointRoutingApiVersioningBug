using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EndpointRoutingApiVersioningBug.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1", Deprecated = true)]
    [ApiVersion("2.0")]
    [Route("api/values")]
    [Route("api/v{version:apiVersion}/values")]
    public class ValuesController : Controller
    {
        [HttpGet(nameof(GetValues))]
        public async Task<object> GetValues()
        {
            await Task.CompletedTask;
            return HttpContext.GetRequestedApiVersion();
        }

        [MapToApiVersion("1.1")]
        [HttpGet(nameof(GetValues))]
        public async Task<object> GetValues_V1_1()
        {
            await Task.CompletedTask;
            return HttpContext.GetRequestedApiVersion();
        }

        [MapToApiVersion("2.0")]
        [HttpGet(nameof(GetValues))]
        public async Task<object> GetValues_V2_0()
        {
            await Task.CompletedTask;
            return HttpContext.GetRequestedApiVersion();
        }
    }
}