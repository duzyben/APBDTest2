using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD2retake.Model;

[Table("Character_Title")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle
{
    [ForeignKey(nameof(Character))]
    public int CharacterId { get; set; }
    
    [ForeignKey(nameof(Model.Title))]
    public int TitleId { get; set; }
    public DateTime AcquiredAt { get; set; }
    
    public Title Title { get; set; } = null!;
    public Character Character { get; set; } = null!;
}