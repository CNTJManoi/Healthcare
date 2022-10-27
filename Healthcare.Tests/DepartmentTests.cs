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
        IDepartment dp = new Department(cb1, new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        var result = dp.AddRecord(doctor, patient, new DateTime(2022, 10, 27, 10, 15, 0));

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
        IDepartment dp = new Department(cb1, new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        var result = dp.AddRecord(doctor, patient, new DateTime(2022, 10, 27, 10, 15, 0));

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void DepartmentAddCabinet()
    {
        // Arrange
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        dp.AddCabinet(cb);

        // Assert
        Assert.Contains(cb, dp.Cabinets);
    }

    [Fact]
    public void DepartmentAddDoctor()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        dp.AddDoctor(doctor);

        // Assert
        Assert.Contains(doctor, dp.Doctors);
    }

    [Fact]
    public void DepartmentAddPatient()
    {
        // Arrange
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        dp.AddPatient(patient);

        // Assert
        Assert.Contains(patient, dp.Patients);
    }

    [Fact]
    public void DepartmentDismissDoctor()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
        dp.AddDoctor(doctor);

        // Act
        dp.DismissDoctor(doctor);

        // Assert
        Assert.DoesNotContain(doctor, dp.Doctors);
    }

    [Fact]
    public void DepartmentDischargePatient()
    {
        // Arrange
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
        dp.AddPatient(patient);

        // Act
        dp.DischargePatient(patient);

        // Assert
        Assert.DoesNotContain(patient, dp.Patients);
    }
}