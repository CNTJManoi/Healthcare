using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Separations;

public interface IDataDepartment
{
    Guid Id { get; set; }
    public IEnumerable<Cabinet> Cabinets { get; set; }
    public IEnumerable<Doctor> Doctors { get; set; }
    public IEnumerable<Patient> Patients { get; set; }
    string Name { get; set; }
    string Address { get; }
    int NumberOfFloors { get; set; }
    public TypeDepartment TypeDepartment { get; set; }
}