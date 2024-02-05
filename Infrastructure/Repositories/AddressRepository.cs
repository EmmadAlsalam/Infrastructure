using ConsoleApp.Entities;
using Infrastructure.Context;



namespace ConsoleApp.Repositories
{
    public class AddressRepository(DataContext context) : Repo<AddresEntity>(context)
    {
    }
}
