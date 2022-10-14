using System.ComponentModel.DataAnnotations;
using Healthcare.Models;
using Healthcare.Separations.Models;

namespace Healthcare.Separations;

public interface IDataDepartment
{
    [Key] Guid Id { get; set; }
    public IEnumerable<Cabinet> Cabinets { get; set; }
    public IEnumerable<Doctor> Doctors { get; set; }
    public IEnumerable<Patient> Patients { get; set; }
    string Name { get; set; }
    string Address { get; }
    int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; set; }
}