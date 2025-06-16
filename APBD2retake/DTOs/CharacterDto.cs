namespace APBD2retake.DTOs;

public class CharacterDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public List<BackpackItemDto> BackpackItems { get; set; } = null!;
    public List<CharacterTitleDto> Titles { get; set; } = null!;
}

public class BackpackItemDto
{
    public string ItemName { get; set; } = null!;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class CharacterTitleDto
{
    public string Title { get; set; } = null!;
    public DateTime AcquiredAt { get; set; }
}