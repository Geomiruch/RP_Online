using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RP_Server.DTO;
using RP_Server.Requests.CreateRequsts;
using RP_Server.Services;

namespace RP_Server.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("all")]
        public ActionResult<ICollection<ActivityDto>> ActivitiesList()
            => Ok(_activityService.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<ActivityDto> GetActivity(int id)
            => Ok(_activityService.GetById(id));

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteActivity(int id)
            => Ok(_activityService.Delete(id));

        [HttpPost("create")]
        public ActionResult<ActivityDto> CreateActivity(ActivityCreateRequest request)
            => Ok(_activityService.Create(request));

        [HttpPut("update")]
        public ActionResult<ActivityDto> UpdateActivity(ActivityDto request)
            => Ok(_activityService.Update(request));
    }
}
