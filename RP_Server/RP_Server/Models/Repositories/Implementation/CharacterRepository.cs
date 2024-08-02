using Microsoft.EntityFrameworkCore;
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

        public Character Create(Character character)
        {
            var result = _dbContext.Characters.Add(character).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public Character Update(Character character)
        {
            var toUpdate = _dbContext.Characters.FirstOrDefault(c => c.Id == character.Id);
            if (toUpdate == null)
            {
                throw new NotFoundException($"Cannot update customer with id: {character.Id}");
            }
            _dbContext.Characters.Update(toUpdate).CurrentValues.SetValues(character);
            _dbContext.SaveChanges();
            return toUpdate;
        }
    }
}
