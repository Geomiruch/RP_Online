using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories
{
    public interface ICharacterRepository
    {
        public ICollection<Character> GetAll();
        public Character GetById(int id);
        public bool Delete(int id);
        public Character Create(Character customer);
        public Character Update(Character customer);
    }
}
