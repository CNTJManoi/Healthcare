﻿namespace Healthcare.Logic.Models;

public class Doctor : IPeople
{
    public Doctor(string surname, string name, string society, string adr, string diplom,
        TypeDoctor specializationDoctor, string beginWorkTime,
        string endWorkTime)
    {
        Id = new Guid();
        Surname = surname;
        Name = name;
        Society = society;
        Address = adr;
        Diplom = diplom;
        SpecializationDoctor = specializationDoctor;
        BeginWorkTime = beginWorkTime;
        EndWorkTime = endWorkTime;
    }

    /// <summary>
    ///     Конструктор для базы данных
    /// </summary>
    public Doctor()
    {
    }
    /// <summary>
    /// Серия и номер документа об образовании
    /// </summary>
    public string Diplom { get; set; }
    /// <summary>
    /// Время начала рабочего дня
    /// </summary>
    public string BeginWorkTime { get; set; }
    /// <summary>
    /// Время окончания рабочего дня
    /// </summary>
    public string EndWorkTime { get; set; }
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public TypeDoctor SpecializationDoctor { get; set; }
    /// <summary>
    /// Идентификационный номер
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Фамилия доктора
    /// </summary>
    public string Surname { get; set; }
    /// <summary>
    /// Имя доктора
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Отчество доктора
    /// </summary>
    public string Society { get; set; }
    /// <summary>
    /// Фамилия, имя и отчество доктора
    /// </summary>
    public string FullName => Surname + " " + Name + " " + Society;
    /// <summary>
    /// Адрес постоянного места жительства
    /// </summary>
    public string Address { get; set; }
}