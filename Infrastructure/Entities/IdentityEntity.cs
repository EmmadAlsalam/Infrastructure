
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities;

public class IdentityEntity
{
    [Key]
    public int Id { get; set; }
    public string IdentityName { get; set; } = null!;

}
