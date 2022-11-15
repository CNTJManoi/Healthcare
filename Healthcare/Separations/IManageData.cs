using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Separations;

public interface IManageData

{
    void AddCabinet(Cabinet cb);
    void AddDoctor(Doctor dt);
    void AddPatient(Patient pt);
    void DismissDoctor(Doctor dt);
    void DischargePatient(Patient pt);
    Record AddRecord(Doctor doctor, Patient pt, DateTime dt);
}