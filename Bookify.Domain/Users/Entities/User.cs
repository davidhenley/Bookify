using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.ValueObjects;

namespace Bookify.Domain.Users.Entities;

public sealed class User : Entity
{
    private User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }

    public static User Create(FirstName firstName, LastName lastName, Email email) =>
        new(Guid.NewGuid(), firstName, lastName, email);
}