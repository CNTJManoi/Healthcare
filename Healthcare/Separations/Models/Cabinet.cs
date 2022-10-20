using Healthcare.Logic.Models;

namespace Healthcare.Logic.Separations.Models;

public class Cabinet
{
    private Cabinet(TypeDoctor typeDoctor, int number, Guid id)
    {
        Id = id;
        TypeDoctor = typeDoctor;
        Number = number;
    }

    public Cabinet(TypeDoctor typeDoctor, int number, Doctor attachedDoctor, Patient enteringPatient, Guid id) : this(
        typeDoctor, number, id)
    {
        AttachedDoctor = attachedDoctor;
        EnteringPatient = enteringPatient;
    }

    /// <summary>
    ///     Идентификационный номер кабинета
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Прикрепленный доктор к кабинету
    /// </summary>

    public Doctor AttachedDoctor { get; private set; }

    /// <summary>
    ///     Тип кабинета
    /// </summary>
    public TypeDoctor TypeDoctor { get; set; }

    /// <summary>
    ///     Вошедший пациент в кабинет
    /// </summary>
    public Patient EnteringPatient { get; }

    /// <summary>
    ///     Номер кабинета
    /// </summary>
    public int Number { get; }

    /// <summary>
    ///     Прикрепить доктора к кабинету
    /// </summary>
    /// <param name="dt"></param>
    public void EnterCabient(Doctor dt)
    {
        AttachedDoctor = dt;
    }

    /// <summary>
    ///     Занят ли кабинет
    /// </summary>
    /// <param name="dt">Экземпляр класса возможного доктора в кабинете</param>
    /// <returns>bool - true если занят иначе false</returns>
    public bool CabinetIsBusy(Doctor dt)
    {
        if (AttachedDoctor == dt || AttachedDoctor == null) return false;
        return true;
    }
}