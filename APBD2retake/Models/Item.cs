using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD2retake.Model;

[Table("Item")]
public class Item
{
    [Key]
    public int ItemId { get; set; }

    [MaxLength(100)] 
    public string Name { get; set; } = null!;
    public int Weight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; } = null!;
}