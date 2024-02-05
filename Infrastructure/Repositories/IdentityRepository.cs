using ConsoleApp.Entities;
using Infrastructure.Context;


namespace ConsoleApp.Repositories;

public class IdentityRepository : Repo<IdentityEntity>
{
    public IdentityRepository(DataContext context) : base(context)
    {
    }
}