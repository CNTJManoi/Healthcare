using Healthcare.Models;
using Healthcare.Separations.Models;

namespace Healthcare.Separations;

internal interface IDataDepartment
{
    Guid Id { get; }
    List<Cabinet> Cabinets { get; }
    public IEnumerable<Doctor> Doctors { get; }
    public IEnumerable<Patient> Patients { get; }
    string Name { get; set; }
    string Address { get; }
    int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; }
}