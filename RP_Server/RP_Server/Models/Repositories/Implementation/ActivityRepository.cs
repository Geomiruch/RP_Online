using Microsoft.EntityFrameworkCore;
using RP_Server.Exceptions;
using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories.Implementation
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Activity>> GetAll()
            => await _dbContext.Activities.ToListAsync();
        public Activity GetById(int id)
        {
            var result = _dbContext.Activities.Include(a => a.Group).FirstOrDefault(a => a.Id == id);
            if (result == null) { throw new NotFoundException($"Cannot found {nameof(Activity)} with Id: {id}"); }
            return result;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return false;

            _dbContext.Activities.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public Activity Create(Activity activity)
        {
            var result = _dbContext.Activities.Add(activity).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public Activity Update(Activity activity)
        {
            var toUpdate = _dbContext.Activities.FirstOrDefault(a => a.Id == activity.Id);
            if (toUpdate == null)
            {
                throw new NotFoundException($"Cannot update customer with id: {activity.Id}");
            }
            _dbContext.Activities.Update(toUpdate).CurrentValues.SetValues(activity);
            _dbContext.SaveChanges();
            return toUpdate;
        }
    }
}
