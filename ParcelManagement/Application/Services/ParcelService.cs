using ParcelManagement.Application.Interfaces;
using ParcelManagement.Domain.Entities;
using ParcelManagement.Infrastructure.Interfaces;


namespace ParcelManagement.Application.Services
{
    // This is where Constructor Injection happens for the repository
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;

        // Constructor Injection of dependency
        public ParcelService(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }
        public async Task<IEnumerable<Parcel>> GetAllParcelsAsync()
        {
            return await _parcelRepository.GetAllAsync();
        }
        public async Task<Parcel?> GetParcelByIdAsync(Guid id)
        {
            return await _parcelRepository.GetByIdAsync(id);
        }
        public Task<Parcel> CreateParcelAsync(Parcel parcel)
        {
            // Basic validation rule (example)
            if (parcel.WeightKg <= 0)
            {
                throw new ArgumentException("Weight must be greater than zero");
            }

            if (string.IsNullOrWhiteSpace(parcel.TrackingNumber))
            {
                throw new ArgumentException("Tracking number is required");
            }

            return _parcelRepository.AddAsync(parcel);
        }

    }
}
// The service depends on an abstraction (IParcelRepository). We inject that dependency via the constructor.