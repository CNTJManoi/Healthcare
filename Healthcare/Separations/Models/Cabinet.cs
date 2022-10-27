using Healthcare.Logic.Models;

namespace Healthcare.Logic.Separations.Models;

public class Cabinet
{
    private Cabinet(TypeDoctor typeDoctor, int number, Guid id)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
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

    private Doctor AttachedDoctor { get; set; }

    /// <summary>
    ///     Тип кабинета
    /// </summary>
    public TypeDoctor TypeDoctor { get; set; }

    /// <summary>
    ///     Вошедший пациент в кабинет
    /// </summary>
    private Patient EnteringPatient { get; set; }

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
        AttachedDoctor = dt ?? throw new ArgumentNullException(nameof(dt));
    }

    /// <summary>
    ///     Занять кабинет пациентом
    /// </summary>
    /// <param name="dt"></param>
    public void EnterCabient(Patient patient)
    {
        EnteringPatient = patient;
    }

    /// <summary>
    ///     Занят ли кабинет
    /// </summary>
    /// <param name="dt">Экземпляр класса возможного доктора в кабинете</param>
    /// <returns>bool - true если занят иначе false</returns>
    public bool CabinetIsBusy(Doctor dt)
    {
        if (dt == null) throw new ArgumentNullException(nameof(dt));
        if (AttachedDoctor == dt || AttachedDoctor == null) return false;
        return true;
    }

    /// <summary>
    ///     Занят ли кабинет
    /// </summary>
    /// <param name="dt">Экземпляр класса возможного пациента в кабинете</param>
    /// <returns>bool - true если занят иначе false</returns>
    public bool CabinetIsBusy(Patient patient)
    {
        if (patient == null) throw new ArgumentNullException(nameof(patient));
        if (EnteringPatient == patient || EnteringPatient == null) return false;
        return true;
    }
}