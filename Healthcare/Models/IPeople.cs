using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models;

internal interface IPeople
{
    [Key]
    Guid Id { get; set; }
    string Surname { get; set; }
    string Name { get; set; }
    string Society { get; set; }
    string FullName { get; }
    string Address { get; set; }
}