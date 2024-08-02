using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories
{
    public interface ILocationRepository
    {
        public Task<ICollection<Location>> GetAll();
        public Location GetById(int id);
        public bool Delete(int id);
        public Location Create(Location location);
        public Location Update(Location location);
    }
}
