using System;
using System.Collections.Generic;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Base;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Logic.Tests;

public class DepartmentTests
{
    [Fact]
    public void DepartmentRegisterRecordWithFreeCabinet()
    {
        // Arrange
        Guid idPatient = new Guid(6, 12, 22, new byte[] { 2,3,4,5,6,7,8,9});
        Guid idCabinet = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        Guid idSut = new Guid(9, 12, 15, new byte[] { 8,7,6,5,4,3,2,1 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", idPatient);
        List<Cabinet> cb1 = new() { new Cabinet(TypeDoctor.Surgeon, 101, null, null, idCabinet) };
        IDepartment sut = new Department(cb1, new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idSut);
        var dataRegister = new DateTime(2022, 10, 27, 10, 15, 0);

        // Act
        var result = sut.AddRecord(doctor, patient, dataRegister);

        // Assert
        Assert.Equal(doctor, result.ResponsibleDoctor);
        Assert.Equal(patient, result.RegisteredPatient);
        Assert.Equal(dataRegister, result.RecordingTime);
    }

    [Fact]
    public void DepartmentRegisterRecordWithBusyCabinet()
    {
        // Arrange
        Guid idPatient = new Guid(6, 12, 22, new byte[] { 2, 3, 4, 5, 6, 7, 8, 9 });
        Guid idCabinet = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        Guid idSut = new Guid(9, 12, 15, new byte[] { 8, 7, 6, 5, 4, 3, 2, 1 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var doctorInCabinet = new Doctor("Владислава", "Елизавета", "Петровна", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", idPatient);
        List<Cabinet> cb1 = new() { new Cabinet(TypeDoctor.Surgeon, 101, doctorInCabinet, null, idCabinet) };
        IDepartment sut = new Department(cb1, new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idSut);

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() =>
            sut.AddRecord(doctor, patient, new DateTime(2022, 10, 27, 10, 15, 0)));
    }

    [Fact]
    public void DepartmentAddCabinet()
    {
        // Arrange
        Guid idCabinet = new Guid(6, 12, 22, new byte[] { 2, 3, 4, 5, 6, 7, 8, 9 });
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idCabinet);

        // Act
        sut.AddCabinet(cb);

        // Assert
        Assert.Contains(cb, sut.Cabinets);
    }

    [Fact]
    public void DepartmentAddDoctor()
    {
        // Arrange
        Guid idDoctor = new Guid(6, 12, 22, new byte[] { 2, 3, 4, 5, 6, 7, 8, 9 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idDoctor);

        // Act
        sut.AddDoctor(doctor);

        // Assert
        Assert.Contains(doctor, sut.Doctors);
    }

    [Fact]
    public void DepartmentAddPatient()
    {
        // Arrange
        Guid idPatient = new Guid(6, 12, 22, new byte[] { 2, 3, 4, 5, 6, 7, 8, 9 });
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idPatient);

        // Act
        sut.AddPatient(patient);

        // Assert
        Assert.Contains(patient, sut.Patients);
    }
}