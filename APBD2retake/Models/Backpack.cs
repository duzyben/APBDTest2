using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD2retake.Model;
[Table("Backpack")]
[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class Backpack
{
    [ForeignKey(nameof(Model.Character))]
    public int CharacterId { get; set; }
    
    [ForeignKey(nameof(Model.Item))]
    public int ItemId { get; set; }
    
    public int Amount { get; set; }
    
    public Character Character { get; set; } = null!;
    public Item Item { get; set; } = null!;
}