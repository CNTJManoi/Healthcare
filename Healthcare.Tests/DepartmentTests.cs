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
        Guid idPatient = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        Guid idCabinet = new Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8");
        Guid idSut = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
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
        Guid idPatient = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        Guid idCabinet = new Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8");
        Guid idSut = new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4");
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
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        sut.AddCabinet(cb);

        // Assert
        Assert.Contains(cb, sut.Cabinets);
    }

    [Fact]
    public void DepartmentAddDoctor()
    {
        // Arrange
        Guid idDoctor = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
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
        Guid idPatient = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idPatient);

        // Act
        sut.AddPatient(patient);

        // Assert
        Assert.Contains(patient, sut.Patients);
    }

    [Fact]
    public void DepartmentDismissDoctor()
    {
        // Arrange
        Guid idDoctor = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idDoctor);
        sut.AddDoctor(doctor);

        // Act
        sut.DismissDoctor(doctor);

        // Assert
        Assert.DoesNotContain(doctor, sut.Doctors);
    }

    [Fact]
    public void DepartmentDischargePatient()
    {
        // Arrange
        Guid idSut = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idSut);
        sut.AddPatient(patient);

        // Act
        sut.DischargePatient(patient);

        // Assert
        Assert.DoesNotContain(patient, sut.Patients);
    }
}