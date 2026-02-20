using ParcelManagement.Domain.Entities;

namespace ParcelManagement.Application.Interfaces
{
    public interface IParcelService
    {
        Task<IEnumerable<Parcel>> GetAllParcelsAsync();
        Task<Parcel?> GetParcelByIdAsync(Guid id);
        Task<Parcel> CreateParcelAsync(Parcel parcel);
    }
}
