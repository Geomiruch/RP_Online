﻿using RP_Server.Models.Entities;

namespace RP_Server.Models.Repositories
{
    public interface ICharacterRepository
    {
        public Task<ICollection<Character>> GetAll();
        public Character GetById(int id);
        public bool Delete(int id);
        public Character Create(Character character);
        public Character Update(Character character);
    }
}
