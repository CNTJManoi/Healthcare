namespace Healthcare.Models.Separations;

internal class Cabinet
{
    public Cabinet(TypeDoctor td, int numberCabinet)
    {
        TypeDoctor = td;
        Number = numberCabinet;
    }

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
        if (AttachedDoctor == null) return false;
        if (AttachedDoctor == dt) return false;
        return true;
    }
}