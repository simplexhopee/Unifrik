using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unifrik.Common.Shared.Utils;

namespace AuthService.API.Controllers
{
    [Route("api/v1/utility")]
    public class UtilityController : Controller
    {
       
        [HttpGet("countries")]
        public IActionResult GetCountries()
        {
            var result = AllCountries.GetAllCountries;
            return Ok(result);
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
