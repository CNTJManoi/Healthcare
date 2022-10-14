namespace Healthcare.Logic.Models;

internal interface IPeople
{
    Guid Id { get; set; }
    string Surname { get; set; }
    string Name { get; set; }
    string Society { get; set; }
    string FullName { get; }
    string Address { get; set; }
}