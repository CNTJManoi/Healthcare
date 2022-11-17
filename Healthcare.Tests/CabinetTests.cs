using System;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Logic.Tests;

public class CabinetTests
{
    [Fact]
    public void TestCreatingAccountWithImpossibleNumber()
    {
        // Arrange + Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Cabinet(TypeDoctor.Surgeon, -1, null, null, Guid.NewGuid()));
    }

    [Fact]
    public void TestAlreadyDoctorInCabinet()
    {
        // Arrange
        // Guid cabinetId = new Guid(2, 5, 5);
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var doctorInCabinet = new Doctor("Владислава", "Елизавета", "Петровна", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, doctorInCabinet, null, Guid.NewGuid());

        // Act
        var result = sut.CabinetIsBusy(doctor);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TestNoDoctorInCabinet()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());

        // Act
        var result = sut.CabinetIsBusy(doctor);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void TestEnterDoctorCabinetTest()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());

        // Act
        sut.EnterCabient(doctor);

        // Assert
        Assert.False(sut.CabinetIsBusy(doctor));
    }

    [Fact]
    public void TestEnterPatientCabinetTest()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, doctor, null, Guid.NewGuid());

        // Act
        sut.EnterCabient(patient);

        // Assert
        Assert.False(sut.CabinetIsBusy(patient));
    }

    [Fact]
    public void TestEnteredTheSameDoctor()
    {
        // Arrange
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());
        sut.EnterCabient(doctor);

        // Act
        sut.EnterCabient(doctor);

        // Assert
        Assert.False(sut.CabinetIsBusy(doctor));
    }

    [Fact]
    public void TestEnterCabinetWithoutDoctor()
    {
        // Arrange
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, Guid.NewGuid());


        // Act+Assert
        Assert.Throws<ArgumentNullException>(
            () => sut.EnterCabient(patient)
        );
    }
}