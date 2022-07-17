namespace MKCharacters.API.Models;

public class CharacterQueryParameters : QueryParameters
{
    public decimal? MinDamage { get; set; }
    public decimal? MaxDamage { get; set; }
    public string Variant { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public string SearchTerm { get; set; } = string.Empty;
}
