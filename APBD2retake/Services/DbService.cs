using APBD2retake.Context;
using APBD2retake.DTOs;
using APBD2retake.Model;
using Microsoft.EntityFrameworkCore;

namespace APBD2retake.Service;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CharacterDto> GetCharacterByIdAsync(int characterId)
    {
        var character = await _context.Characters
            .Include(c => c.BackpackItems)
                .ThenInclude(b => b.Item)
            .Include(c => c.CharacterTitles)
                .ThenInclude(ct => ct.Title)
            .FirstOrDefaultAsync(c => c.CharacterId == characterId);

        if (character == null)
        {
            return null;
        }

        return new CharacterDto
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.BackpackItems.Select(b => new BackpackItemDto
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = character.CharacterTitles.Select(ct => new CharacterTitleDto
            {
                Title = ct.Title.Name,
                AcquiredAt = ct.AcquiredAt
            }).ToList()
        };
    }

    public async Task<bool> AddItemsToBackpackAsync(int characterId, List<int> itemIds)
    {
        var character = await _context.Characters
            .Include(c => c.BackpackItems)
            .FirstOrDefaultAsync(c => c.CharacterId == characterId);

        if (character == null)
        {
            return false;
        }

        var items = await _context.Items
            .Where(i => itemIds.Contains(i.ItemId))
            .ToListAsync();

        if (items.Count != itemIds.Count)
        {
            return false;
        }

        var totalWeightToAdd = items.Sum(i => i.Weight);

        if (character.CurrentWeight + totalWeightToAdd > character.MaxWeight)
        {
            return false;
        }

        foreach (var item in items)
        {
            var existingItem = character.BackpackItems.FirstOrDefault(b => b.ItemId == item.ItemId);

            if (existingItem != null)
            {
                existingItem.Amount++;
            }
            else
            {
                character.BackpackItems.Add(new Backpack
                {
                    ItemId = item.ItemId,
                    Amount = 1
                });
            }
        }

        character.CurrentWeight += totalWeightToAdd;

        await _context.SaveChangesAsync();
        return true;
    }
}