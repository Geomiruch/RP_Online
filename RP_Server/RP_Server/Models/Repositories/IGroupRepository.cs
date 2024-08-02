using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories
{
    public interface IGroupRepository
    {
        public Task<ICollection<Group>> GetAll();
        public Group GetById(int id);
        public bool Delete(int id);
        public Group Create(Group group);
        public Group Update(Group group);
    }
}
