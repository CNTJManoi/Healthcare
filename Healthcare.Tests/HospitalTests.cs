using System;
using System.Collections.Generic;
using System.Linq;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Base;
using Healthcare.Logic.Separations.Models;
using Healthcare.Logic.Tests.Builder;
using Xunit;

namespace Healthcare.Logic.Tests;

public class HospitalTests
{
    private readonly HospitalBuilder _builder = new();

    [Fact]
    public void HospitalAddDepartmentTest()
    {
        // Arrange
        Guid idDp = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        var sut = _builder.BuildHospital();
        IDepartment dp = new Department(new List<Cabinet>(), new List<Doctor>(), new List<Patient>()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, idDp);

        // Act
        sut.AddDepartment(dp);

        // Assert
        Assert.Contains(dp, sut.Buildings);
    }

    [Fact]
    public void HospitalAddPatientTest()
    {
        // Arrange
        Guid idPatient = new Guid("B9213C5E-CEB2-4faa-A9T1-329CQ12FA1E4");
        var sut = _builder.BuildHospital();
        Patient p = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", idPatient);

        // Act
        sut.AddPatient(p, 1);

        // Assert
        Assert.Contains(p, sut.Buildings.ToList()[0].Patients);
    }

    [Fact]
    public void HospitalAddDoctorTest()
    {
        // Arrange
        var sut = _builder.BuildHospital();
        var df1 = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");

        // Act
        sut.AddDoctor(df1, 1);

        // Assert
        Assert.Contains(df1, sut.Buildings.ToList()[0].Doctors);
    }
}