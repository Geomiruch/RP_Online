using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RP_Server.DTO;
using RP_Server.Services;

namespace RP_Server.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("all")]
        public ActionResult<ICollection<LocationDto>> ListActions() 
            => Ok(_locationService.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<LocationDto> GetLocation(int  id)
            => Ok(_locationService.GetById(id));

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteLocation(int id)
            => Ok(_locationService.Delete(id));

        [HttpPost("create")]
        public ActionResult<LocationDto> CreateLocation(LocationDto request)
            => Ok(_locationService.Create(request));

        [HttpPut("update")]
        public ActionResult<LocationDto> UpdadteLocation(LocationDto request)
            => Ok(_locationService.Update(request));
    }
}
