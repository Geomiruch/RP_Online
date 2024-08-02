using RP_Server.DTO;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services
{
    public interface ILocationService
    {
        public ICollection<LocationDto> GetAll();
        public LocationDto GetById(int id);
        public bool Delete(int id);
        public LocationDto Create(LocationCreateRequest request);
        public LocationDto Update(LocationDto request);
    }
}
