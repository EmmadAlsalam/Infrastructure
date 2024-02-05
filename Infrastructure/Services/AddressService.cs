using ConsoleApp.Entities;
using ConsoleApp.Repositories;


namespace ConsoleApp.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;

    public AddresEntity CreateAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        addressEntity ??= _addressRepository.Create(new AddresEntity { StreetName = streetName, PostalCode = postalCode, City = city });

        return addressEntity;
    }

    public AddresEntity GetAddress(string streetName, string postalCode, string city)
    {
        var addressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntity;
    }

    public AddresEntity GetAddressById(int id)
    {
        var addressEntity = _addressRepository.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddresEntity> GetAddresses()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }

    public AddresEntity UpdateAddress(AddresEntity addressEntity)
    {
        var updatedAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updatedAddressEntity;
    }


    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }
}
