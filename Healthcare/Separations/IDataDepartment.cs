using System.ComponentModel.DataAnnotations;
using Healthcare.Models;
using Healthcare.Separations.Models;

namespace Healthcare.Separations;

internal interface IDataDepartment
{
    [Key]
    Guid Id { get; set; }
    List<Cabinet> Cabinets { get; }
    public IEnumerable<Doctor> Doctors { get; set; }
    public IEnumerable<Patient> Patients { get; set; }
    string Name { get; set; }
    string Address { get; }
    int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; set; }
}