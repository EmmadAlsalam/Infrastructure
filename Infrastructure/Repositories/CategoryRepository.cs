using ConsoleApp.Entities;
using Infrastructure.Context;


namespace ConsoleApp.Repositories;

public class CategoryRepository(DataContext context) : Repo<CategoryEntity>(context)
{
}
