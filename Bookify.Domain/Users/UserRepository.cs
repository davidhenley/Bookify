using Bookify.Domain.Users.Entities;

namespace Bookify.Domain.Users;

public class UserRepository : IUserRepository
{
    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }
}