using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using StudocNetAPi_1.Models;
using StudocNetAPi_1.Models.RequestModels;
using StudocNetAPi_1.Repositories;

namespace StudocNetAPi_1.Services
{
    public interface IOwnerService
    {
        public Task<ICollection<Owner>> GetOwners();
        public Task<Owner> GetOwner(int ownerId);
        public void CreateOwner(OwnerRequest owner);
    }
    public class OwnerService : IOwnerService
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly CountryRepository _countryRepository;

        public OwnerService(OwnerRepository ownerRepository, IMapper mapper, CountryRepository countryRepository)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _countryRepository = countryRepository;
        }
        public async void CreateOwner(OwnerRequest owner)
        {
            var newOwner = _mapper.Map<Owner>(owner);
            if(newOwner == null)
            {
                throw new Exception();
            }
            _ownerRepository.Add(newOwner);
        }

        public async Task<Owner> GetOwner(int ownerId)
        {
            var owner = await _ownerRepository.GetAll()
                        .Include(o => o.Country)
                        .Where(o => o.Id == ownerId).FirstOrDefaultAsync();
            return owner;
        }

        public async Task<ICollection<Owner>> GetOwners()
        {
            var owners = await _ownerRepository.GetAll()
                .Include(o => o.Country).ToListAsync();
            return owners;
        }
    }
}
