using System.ComponentModel.DataAnnotations;
namespace ConsoleApp.Entities;

public class AddresEntity
{
    [Key]
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
