using System;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Logic.Tests;

public class CabinetTests
{
    [Fact]
    public void TestCreatingCabinetWithNumberLessThanZero()
    {
        // Arrange
        Guid id = new Guid(3,10,20, new byte[]{1,2,3,4,5,6,7,8});
        // Arrange + Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Cabinet(TypeDoctor.Surgeon, -1, null, null, id));
    }

    [Fact]
    public void TestAlreadyDoctorInCabinet()
    {
        // Arrange
        Guid id = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var doctorInCabinet = new Doctor("Владислава", "Елизавета", "Петровна", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, doctorInCabinet, null, id);

        // Act
        var result = sut.CabinetIsBusy(doctor);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void TestNoDoctorInCabinet()
    {
        // Arrange
        Guid id = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, id);

        // Act
        var result = sut.CabinetIsBusy(doctor);

        // Assert   
        Assert.False(result);
    }

    [Fact]
    public void TestEnterDoctorCabinetTest()
    {
        // Arrange
        Guid id = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, id);

        // Act
        sut.EnterCabinet(doctor);

        // Assert
        Assert.False(sut.CabinetIsBusy(doctor));
    }

    [Fact]
    public void TestEnterPatientCabinetTest()
    {
        // Arrange
        Guid id = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, doctor, null, id);

        // Act
        sut.EnterCabinet(patient);

        // Assert
        Assert.False(sut.CabinetIsBusy(patient));
    }

    [Fact]
    public void TestEnteredTheSameDoctor()
    {
        // Arrange
        Guid id = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        var doctor = new Doctor("Жуков", "Артем", "Алексеевич", "Светлая 15"
            , "999875", TypeDoctor.Surgeon, "08", "15");
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, id);
        sut.EnterCabinet(doctor);

        // Act
        sut.EnterCabinet(doctor);

        // Assert
        Assert.False(sut.CabinetIsBusy(doctor));
    }

    [Fact]
    public void TestEnterCabinetWithoutDoctor()
    {
        // Arrange
        Guid id = new Guid(3, 10, 20, new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        Patient patient = new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid());
        var sut = new Cabinet(TypeDoctor.Surgeon, 101, null, null, id);


        // Act+Assert
        Assert.Throws<ArgumentNullException>(
            () => sut.EnterCabinet(patient)
        );
    }
}