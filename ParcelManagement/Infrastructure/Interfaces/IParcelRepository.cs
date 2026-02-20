using ParcelManagement.Domain.Entities;

namespace ParcelManagement.Infrastructure.Interfaces
{
    public interface IParcelRepository
    {
        Task<IEnumerable<Parcel>> GetAllAsync();
        Task<Parcel?> GetByIdAsync(Guid id);
        Task<Parcel> AddAsync(Parcel parcel);
    }
}
