using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD2retake.Model;

[Table("Title")]
public class Title
{
    [Key]
    public int TitleId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = null!;
}