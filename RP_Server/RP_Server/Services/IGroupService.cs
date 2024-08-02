using RP_Server.DTO;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services
{
    public interface IGroupService
    {
        public ICollection<GroupDto> GetAll();
        public GroupDto GetById(int id);
        public bool Delete(int id);
        public GroupDto Create(GroupCreateRequest request);
        public GroupDto Update(GroupDto request);
    }
}
