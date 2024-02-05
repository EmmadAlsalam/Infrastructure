using ConsoleApp.Entities;
using ConsoleApp.Repositories;


namespace ConsoleApp.Services
{
    public class IdentityService(IdentityRepository identityRepository)
    {
        private readonly IdentityRepository _identityRepository = identityRepository;

        public IdentityEntity CreateIdentity(string identityName)
        {
            var identityEntity = _identityRepository.Get(x => x.IdentityName == identityName);
            identityEntity ??= _identityRepository.Create(new IdentityEntity { IdentityName = identityName });

            return identityEntity;
        }

        public IdentityEntity GetIdentityByIdentityName(string identityName)
        {
            var identityEntity = _identityRepository.Get(x => x.IdentityName == identityName);
            return identityEntity;
        }

        public IdentityEntity GetIdentityById(int id)
        {
            var identityEntity = _identityRepository.Get(x => x.Id == id);
            return identityEntity;
        }

        public IEnumerable<IdentityEntity> GetIdentities()
        {
            var identities = _identityRepository.GetAll();
            return identities;
        }

        public IdentityEntity UpdateIdentity(IdentityEntity identityEntity)
        {
            var updatedIdentityEntity = _identityRepository.Update(x => x.Id == identityEntity.Id, identityEntity);
            return updatedIdentityEntity;
        }

        public void DeleteIdentity(int id)
        {
            _identityRepository.Delete(x => x.Id == id);
        }
    }
}
