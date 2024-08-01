using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RP_Server.DTO;
using RP_Server.Requests.CreateRequsts;
using RP_Server.Services;
using RP_Server.Services.Implementation;

namespace RP_Server.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("all")]
        public ActionResult<ICollection<GroupDto>> ListGroups()
            => Ok(_groupService.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<GroupDto> GetGroupById(int id)
            => Ok(_groupService.GetById(id));

        [HttpDelete("{id:int}")]
        public ActionResult<bool> DeleteGroup(int id)
            => Ok(_groupService.Delete(id));

        [HttpPost("create")]
        public ActionResult<GroupDto> Create(GroupCreateRequest request)
            => Ok(_groupService.Create(request));

        [HttpPut("update")]
        public ActionResult<GroupDto> Update(GroupDto request)
            => Ok(_groupService.Update(request));
    }
}
