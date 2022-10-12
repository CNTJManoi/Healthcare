using Healthcare.Models;

namespace Healthcare.Separations.Models;

internal class Cabinet
{
    public Cabinet(TypeDoctor td, int numberCabinet)
    {
        Id = new Guid();
        TypeDoctor = td;
        Number = numberCabinet;
    }
    /// <summary>
    /// Конструктор для базы данных
    /// </summary>
    public Cabinet()
    {

    }
    public Guid Id { get; set; }
    private Doctor AttachedDoctor { get; set; }
    public TypeDoctor TypeDoctor { get; set; }
    private Patient EnteringPatient { get; set; }
    public int Number { get; set; }

    public void EnterCabient(Doctor dt)
    {
        AttachedDoctor = dt;
    }

    public bool CabinetIsBusy(Doctor dt)
    {
        if (AttachedDoctor == dt || AttachedDoctor == null) return false;
        return true;
    }
}