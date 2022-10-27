using System;
using System.Collections.Generic;
using System.Linq;
using Healthcare.Logic;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Base;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Tests;

public class HospitalTests
{
    [Fact]
    public void HospitalAddDepartmentTest()
    {
        // Arrange
        Hospital sut = new(Guid.NewGuid(), "Солнышко");
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());

        // Act
        sut.AddDepartment(dp);

        // Assert
        Assert.Contains(dp, sut.Buildings);
    }

    [Fact]
    public void HospitalAddPatientTest()
    {
        // Arrange
        Hospital sut = new(Guid.NewGuid(), "Солнышко");
        Patient p = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
        sut.AddDepartment(dp);

        // Act
        sut.AddPatient(p, 1);

        // Assert
        Assert.Contains(p, sut.Buildings.ToList()[0].Patients);
    }

    [Fact]
    public void HospitalAddDoctorTest()
    {
        // Arrange
        Hospital sut = new(Guid.NewGuid(), "Солнышко");
        var df1 = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
        sut.AddDepartment(dp);

        // Act
        sut.AddDoctor(df1, 1);

        // Assert
        Assert.Contains(df1, sut.Buildings.ToList()[0].Doctors);
    }
}