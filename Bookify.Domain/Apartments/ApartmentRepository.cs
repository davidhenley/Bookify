using Bookify.Domain.Apartments.Entities;

namespace Bookify.Domain.Apartments;

public class ApartmentRepository : IApartmentRepository
{
    public Task<Apartment?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}