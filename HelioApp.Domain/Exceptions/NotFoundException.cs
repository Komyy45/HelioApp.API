namespace HelioApp.Domain.Exceptions;

public sealed class NotFoundException(string entityName) : Exception($"{entityName} Not Found.")
{ }