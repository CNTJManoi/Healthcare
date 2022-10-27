using System;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Tests;

public class CabinetTests
{
    [Fact]
    public void AlreadyDoctorInCabinetTest()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var doctorInCabinet = new Doctor("Владислава", "Елизавета", "Петровна", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, doctorInCabinet, null, Guid.NewGuid());

        // Act
        var result = cb.CabinetIsBusy(doctor);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void NoDoctorInCabinetTest()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());

        // Act
        var result = cb.CabinetIsBusy(doctor);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TestEnterDoctorCabinetTest()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());

        // Act
        cb.EnterCabient(doctor);

        // Assert
        Assert.False(cb.CabinetIsBusy(doctor));
    }

    [Fact]
    public void TestEnterPatientCabinetTest()
    {
        // Arrange
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        var cb = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());

        // Act
        cb.EnterCabient(patient);

        // Assert
        Assert.False(cb.CabinetIsBusy(patient));
    }
}