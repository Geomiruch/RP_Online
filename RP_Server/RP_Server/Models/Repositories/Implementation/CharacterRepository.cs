using Microsoft.EntityFrameworkCore;
using RP_Server.Controllers;
using RP_Server.Exceptions;
using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories.Implementation
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CharacterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Character>> GetAll()
            => await _dbContext.Characters.ToListAsync();

        public Character GetById(int id)
        {
            var result = _dbContext.Characters.Include(c => c.Owner).FirstOrDefault(c => c.Id == id);
            if (result == null) { throw new NotFoundException($"Cannot found {nameof(Character)} with Id: {id}"); }
            return result;
        }
        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Characters.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public Character Create(Character customer)
        {
            var result = _dbContext.Characters.Add(customer).Entity;
            _dbContext.SaveChanges();
            return result;
        }
        public Character Update(Character customer)
        {
            var toUpdate = _dbContext.Characters.FirstOrDefault(c => c.Id == customer.Id);
            if (toUpdate == null)
            {
                throw new Exception($"Cannot update customer with id: {customer.Id}");
            }
            _dbContext.Characters.Update(toUpdate).CurrentValues.SetValues(customer);
            _dbContext.SaveChanges();
            return toUpdate;
        }
    }
}
