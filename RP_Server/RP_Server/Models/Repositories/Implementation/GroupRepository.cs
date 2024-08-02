using Microsoft.EntityFrameworkCore;
using RP_Server.Controllers;
using RP_Server.Exceptions;
using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories.Implementation
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GroupRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Group>> GetAll()
            => await _dbContext.Groups.ToListAsync();

        public Group GetById(int id)
        {
            var result = _dbContext.Groups.Include(g => g.Location).Include(g => g.Characters).FirstOrDefault(g => g.Id == id);
            if (result == null) { throw new NotFoundException($"Cannot found {nameof(Group)} with Id: {id}"); }
            return result;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Groups.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public Group Create(Group group)
        {
            var result = _dbContext.Groups.Add(group).Entity;
            _dbContext.SaveChanges();
            return result;
        }
        public Group Update(Group group)
        {
            var toUpdate = _dbContext.Groups.FirstOrDefault(c => c.Id == group.Id);
            if (toUpdate == null)
            {
                throw new NotFoundException($"Cannot update customer with id: {group.Id}");
            }
            _dbContext.Groups.Update(toUpdate).CurrentValues.SetValues(group);
            _dbContext.SaveChanges();
            return toUpdate;
        }
    }
}
