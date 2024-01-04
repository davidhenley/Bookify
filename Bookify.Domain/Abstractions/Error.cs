using System.Runtime.InteropServices.JavaScript;

namespace Bookify.Domain.Abstractions;

public record Error(string Code, string Name)
{
    public static Error None = new(string.Empty, String.Empty);
    public static Error NullValue = new("Error.NullValue", "Null value was provided");
}