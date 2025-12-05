using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Unifrik.Common.Shared.Utils;
using Unifrik.Infrastructure.Shared.Storage;

namespace AuthService.API.Controllers
{
    [Route("api/v1/utility")]
    public class UtilityController : Controller
    {
        private IFileService _fileService;

        public UtilityController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var result = AllCountries.GetAllCountries;
            return Ok(result);
        }

        [Authorize]
        [HttpGet("download")]
        public async Task<IActionResult> Download([FromQuery] string key)
        {
            var file = await _fileService.DownloadAsync(key);
            var fileName = Path.GetFileName(key);

            return File(file, "application/octet-stream", fileName);
        }

        [HttpGet("regions")]
        public IActionResult GetRegions()
        {
            var result = AllCountries.GetAllRegions;
            return Ok(result);
        }

        [HttpGet("business-categories")]
        public IActionResult GetCategories()
        {
            var result = BusinessCategories.Get;
            return Ok(result);
        }

        [HttpGet("languages")]
        public IActionResult GetLanguages()
        {
            var result = Languages.Get;
            return Ok(result);
        }
    }
}
