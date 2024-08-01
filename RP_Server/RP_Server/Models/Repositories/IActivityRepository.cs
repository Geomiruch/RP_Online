using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories
{
    public interface IActivityRepository
    {
        public Task<ICollection<Activity>> GetAll();
        public Activity GetById(int id);
        public bool Delete(int id);
        public Activity Create(Activity activity);
        public Activity Update(Activity activity);
    }
}
