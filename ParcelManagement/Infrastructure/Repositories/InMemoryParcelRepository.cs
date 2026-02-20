using ParcelManagement.Domain.Entities;
using ParcelManagement.Infrastructure.Interfaces;

namespace ParcelManagement.Infrastructure.Repositories
{
    public class InMemoryParcelRepository : IParcelRepository
    {
        //simulates a database
        private readonly List<Parcel> _parcels = new();

        public InMemoryParcelRepository()
        {
            // Seed with some initial data
            _parcels.Add(new Parcel
            {
                Id = Guid.NewGuid(),
                TrackingNumber = "DPD-123456",
                RecipientName = "John Doe",
                DestinationAddress = "Meadowdale Warehous",
                WeightKg = 2.5,
                CreatedAt = DateTime.UtcNow
            });
        }


        public Task<IEnumerable<Parcel>> GetAllAsync()
        {
            return Task.FromResult(_parcels.AsEnumerable());
        }


        public Task<Parcel?> GetByIdAsync(Guid id)
        {
            var parcel = _parcels.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(parcel);
        }


        public Task<Parcel> AddAsync(Parcel parcel)
        {
            parcel.Id = Guid.NewGuid();
            parcel.CreatedAt = DateTime.UtcNow;
            _parcels.Add(parcel);
            return Task.FromResult(parcel);
        }


    }
}
