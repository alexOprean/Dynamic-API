namespace Dynamic.Api.Controllers
{
    using Dynamic.Api.Attributes;
    using Dynamic.Core.Interfaces;
    using Dynamic.Core.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Performance()]
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicController : ControllerBase
    {
        private IDynamicService dynamicServices;

        public DynamicController(IDynamicService dynamicServices)
        {
            this.dynamicServices = dynamicServices;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateDocumentAsync([FromBody] DocumentViewModel documentViewModel)
        {
            DocumentResponseViewModel document = await dynamicServices.CreateDocumentAsync(documentViewModel);
            return Ok(document);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] string id, [FromQuery] string name)
        {
            DocumentViewModel document = !string.IsNullOrEmpty(id) ? await dynamicServices.GetByIdAsync(id): await dynamicServices.GetByNameAsync(name);

            return Ok(document);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteDocumentAsync([FromQuery] string id)
        {
            await dynamicServices.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Route("clean")]
        public async Task<IActionResult> CleanCollectionAsync()
        {
            await dynamicServices.DeleteAllDocuments();
            return Ok();
        }
    }
}
