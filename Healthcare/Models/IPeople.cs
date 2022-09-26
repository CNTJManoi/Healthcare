namespace Healthcare.Models;

internal interface IPeople
{
    Guid Id { get; }
    string Surname { get; }
    string Name { get; }
    string Society { get; }
    string FullName { get; }
    string Address { get; }
}