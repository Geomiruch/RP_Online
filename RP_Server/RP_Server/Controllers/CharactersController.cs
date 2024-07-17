using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RP_Server.DTO;
using RP_Server.Models;

namespace RP_Server.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public CharactersController(ILogger<CharactersController> logger, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("new")]
        public async Task<ActionResult<Character>> CreateCharacter(CharacterDto characterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var character = new Character
            {
                Name = characterDto.Name,
                OwnerId = characterDto.OwnerId
            };

            _dbContext.Characters.Add(character);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            var character = await _dbContext.Characters.FindAsync(id);

            if (character is null)
            {
                return NotFound();
            }

            var characterDto = new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                OwnerId = character.OwnerId,
            };

            return characterDto;
        }


        [HttpGet]
        public async Task<CharactersDto> ListCharacters()
        {
            var charactersFromDb = await _dbContext.Characters.ToListAsync();

            var charactersDto = new CharactersDto();

            foreach (var character in charactersFromDb)
            {
                var characterDto = new CharacterDto
                {
                    Id = character.Id,
                    Name = character.Name,
                    OwnerId = character.OwnerId
                };

                charactersDto.Characters.Add(characterDto);
            }

            return charactersDto;
        }
    }
}
