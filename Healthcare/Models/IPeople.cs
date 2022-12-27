namespace Healthcare.Logic.Models;

internal interface IPeople
{
    Guid Id { get; }
    string Surname { get; }
    string Name { get; }
    string Patronymic { get; }
    string FullName { get; }
    string Address { get; }
}