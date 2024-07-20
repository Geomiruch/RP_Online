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

        public ICollection<Character> GetAll()
            => _dbContext.Characters.ToList();
        public Character GetById(int id)
        {
            var result = _dbContext.Characters.AsNoTracking().FirstOrDefault(c=>c.Id == id);
            if (result == null) { throw new NotFoundException($"Cannot found {nameof(Character)} with Id: {id}"); }
            return result;
        }
        public bool Delete(int id)
        {
            int rowAffected = 0;
            var characters = _dbContext.Characters.Where(c => c.Id == id);
            foreach (var character in characters)
            {
                character.Owner.Characters.Remove(character);
                if(_dbContext.Characters.Remove(character) != null) rowAffected++;
            }
            _dbContext.SaveChanges();
            return rowAffected > 0;
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
                throw new Exception("Cannot update customer with id: " + customer.Id);
            }
            _dbContext.Characters.Update(toUpdate).CurrentValues.SetValues(customer);
            _dbContext.SaveChanges();
            return toUpdate;
        }
    }
}
