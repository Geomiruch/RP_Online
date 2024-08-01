using RP_Server.DTO;

namespace RP_Server.Services
{
    public interface IGroupService
    {
        public ICollection<GroupDto> GetAll();
        public GroupDto GetById(int id);
        public bool Delete(int id);
        public GroupDto Create(GroupDto request);
        public GroupDto Update(GroupDto request);
    }
}
