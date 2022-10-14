using Healthcare.Logic.Models;

namespace Healthcare.Logic.Separations.Models;

public class Cabinet
{
    public Cabinet(TypeDoctor td, int numberCabinet)
    {
        Id = new Guid();
        TypeDoctor = td;
        Number = numberCabinet;
    }

    /// <summary>
    ///     Конструктор для базы данных
    /// </summary>
    public Cabinet()
    {
    }
    /// <summary>
    /// Идентификационный номер кабинета
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Прикрепленный доктор к кабинету
    /// </summary>
    private Doctor AttachedDoctor { get; set; }
    /// <summary>
    /// Тип кабинета
    /// </summary>
    public TypeDoctor TypeDoctor { get; set; }
    /// <summary>
    /// Вошедший пациент в кабинет
    /// </summary>
    private Patient EnteringPatient { get; set; }
    /// <summary>
    /// Номер кабинета
    /// </summary>
    public int Number { get; set; }
    /// <summary>
    /// Прикрепить доктора к кабинету
    /// </summary>
    /// <param name="dt"></param>
    public void EnterCabient(Doctor dt)
    {
        AttachedDoctor = dt;
    }
    /// <summary>
    /// Занят ли кабинет
    /// </summary>
    /// <param name="dt">Экземпляр класса возможного доктора в кабинете</param>
    /// <returns>bool - true если занят иначе false</returns>
    public bool CabinetIsBusy(Doctor dt)
    {
        if (AttachedDoctor == dt || AttachedDoctor == null) return false;
        return true;
    }
}