using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace MKCharacters.API.Models;

public class Character
{
    public int Id { get; set; }
    [Required]
    public string Variant { get; set; } = string.Empty;
    [Required]
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public bool IsAvailable { get; set; }

    [Required]
    public int EquipmentId { get; set; }
    [JsonIgnore]
    public virtual Equipment Equipment { get; set; }
}
