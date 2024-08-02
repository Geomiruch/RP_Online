using RP_Server.DTO;
using RP_Server.Requests.CreateRequsts;

namespace RP_Server.Services
{
    public interface IActivityService
    {
        public ICollection<ActivityDto> GetAll();
        public ActivityDto GetById(int id);
        public bool Delete(int id);
        public ActivityDto Create(ActivityCreateRequest request);
        public ActivityDto Update(ActivityDto request);
    }
}
