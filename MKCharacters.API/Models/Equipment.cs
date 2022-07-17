namespace MKCharacters.API.Models;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual List<Character> Characters { get; set; }

}
