using Microsoft.EntityFrameworkCore;
using RP_Server.Exceptions;
using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories.Implementation
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LocationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Location>> GetAll()
            => await _dbContext.Locations.ToListAsync();

        public Location GetById(int id)
        {
            var result = _dbContext.Locations.Include(l => l.Groups).Include(l => l.Activities).FirstOrDefault(l => l.Id == id);
            if (result == null) { throw new NotFoundException($"Cannot found {nameof(Location)} with Id: {id}"); }
            return result;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Locations.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public Location Create(Location location)
        {
            var result = _dbContext.Locations.Add(location).Entity;
            _dbContext.SaveChanges();
            return result;
        }
        public Location Update(Location location)
        {
            var toUpdate = _dbContext.Locations.FirstOrDefault(l => l.Id == location.Id);
            if (toUpdate == null)
            {
                throw new NotFoundException($"Cannot update customer with id: {location.Id}");
            }
            _dbContext.Locations.Update(toUpdate).CurrentValues.SetValues(location);
            _dbContext.SaveChanges();
            return toUpdate;
        }
    }
}
