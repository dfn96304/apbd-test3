using System.ComponentModel.DataAnnotations;

namespace apbd_test3.Models;

public class Map
{
    [Key]
    public int MapId { get; set; }
    [Required] [MaxLength(100)]
    public string Name { get; set; }
    [Required] [MaxLength(100)]
    public string Type { get; set; }
}