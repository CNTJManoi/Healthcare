using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Separations;

public interface IDataDepartment
{
    Guid Id { get; }
    public IEnumerable<Cabinet> Cabinets { get; }
    public IEnumerable<Doctor> Doctors { get; }
    public IEnumerable<Patient> Patients { get; }
    string Name { get; set; }
    string Address { get; }
    int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; set; }
}