using APBD2retake.DTOs;
using APBD2retake.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD2retake.Controller;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<ActionResult<CharacterDto>> GetCharacter(int characterId)
    {
        var character = await _dbService.GetCharacterByIdAsync(characterId);

        if (character == null)
        {
            return NotFound();
        }

        return Ok(character);
    }

    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, [FromBody] List<int> itemIds)
    {
        if (itemIds == null || itemIds.Count == 0)
        {
            return BadRequest("No items provided");
        }

        var result = await _dbService.AddItemsToBackpackAsync(characterId, itemIds);

        if (!result)
        {
            return BadRequest("Could not add items to backpack. Check if items exist or if character has enough capacity.");
        }

        return NoContent();
    }
}