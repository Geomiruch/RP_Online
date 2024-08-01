using RP_Server.DTO;

namespace RP_Server.Services
{
    public interface ILocationService
    {
        public ICollection<LocationDto> GetAll();
        public LocationDto GetById(int id);
        public bool Delete(int id);
        public LocationDto Create(LocationDto request);
        public LocationDto Update(LocationDto request);
    }
}
