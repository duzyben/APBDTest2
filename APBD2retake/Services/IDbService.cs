using APBD2retake.DTOs;

namespace APBD2retake.Service;

public interface IDbService
{
    Task<CharacterDto> GetCharacterByIdAsync(int characterId);
    Task<bool> AddItemsToBackpackAsync(int characterId, List<int> itemIds);
}