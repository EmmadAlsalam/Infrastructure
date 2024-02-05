using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities;

public class CategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

}
