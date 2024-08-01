using RP_Server.DTO;

namespace RP_Server.Services
{
    public interface IActivityService
    {
        public ICollection<ActivityDto> GetAll();
        public ActivityDto GetById(int id);
        public bool Delete(int id);
        public ActivityDto Create(ActivityDto request);
        public ActivityDto Update(ActivityDto request);
    }
}
