using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int IdentityId { get; set; }
    public IdentityEntity Identitys { get; set; } = null!;


    public int AddressId { get; set; }
    public AddresEntity Address { get; set; } = null!;
}
