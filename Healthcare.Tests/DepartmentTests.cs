using System;
using System.Collections.Generic;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Base;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Tests;

public class DepartmentTests
{
    [Fact]
    public void DepartmentRegisterRecordWithFreeCabinet()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        List<Cabinet> cb1 = new() { new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid()) };
        IDepartment sut = new Department(cb1, new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        var result = sut.AddRecord(doctor, patient, new DateTime(2022, 10, 27, 10, 15, 0));

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void DepartmentRegisterRecordWithBusyCabinet()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var doctorInCabinet = new Doctor("Владислава", "Елизавета", "Петровна", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        List<Cabinet> cb1 = new() { new Cabinet(TypeDoctor.Surgeon, 101, doctorInCabinet, null, Guid.NewGuid()) };
        IDepartment sut = new Department(cb1, new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        var result = sut.AddRecord(doctor, patient, new DateTime(2022, 10, 27, 10, 15, 0));

        // Assert
        Assert.Null(result);
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
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        sut.AddDoctor(doctor);

        // Assert
        Assert.Contains(doctor, sut.Doctors);
    }

    [Fact]
    public void DepartmentAddPatient()
    {
        // Arrange
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        sut.AddPatient(patient);

        // Assert
        Assert.Contains(patient, sut.Patients);
    }

    [Fact]
    public void DepartmentDismissDoctor()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
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
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment sut = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
        sut.AddPatient(patient);

        // Act
        sut.DischargePatient(patient);

        // Assert
        Assert.DoesNotContain(patient, sut.Patients);
    }
}