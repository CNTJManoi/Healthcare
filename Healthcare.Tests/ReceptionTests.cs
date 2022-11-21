using System;
using System.Linq;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Tests.Builder;
using Xunit;

namespace Healthcare.Logic.Tests;

public class ReceptionTests
{
    private readonly HospitalBuilder _builder = new();

    [Fact]
    public void ReceptionCheckTrueRegistrationRecord()
    {
        // Arrange
        var sut = _builder.BuildHospital();
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(sut.Buildings.ToList()[0].Doctors.ToList()[0],
            sut.Buildings.ToList()[0].Patients.ToList()[0], new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.Successfully, status);
    }

    [Fact]
        public void ReceptionCheckRegistrationRecordDuringNonWorkingTimeDoctor()
    {
        // Arrange
        var sut = _builder.BuildHospital();
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(sut.Buildings.ToList()[0].Doctors.ToList()[0],
            sut.Buildings.ToList()[0].Patients.ToList()[0], new DateTime(2022, 10, 27, 04, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.ErrorTime, status);
    }

    [Fact]
    public void ReceptionCheckRegistrationRecordWithBusyDoctor()
    {
        // Arrange
        var sut = _builder.BuildHospital();
        sut.ReceptionHospital.RegistrationRecord(sut.Buildings.ToList()[0].Doctors.ToList()[0],
            sut.Buildings.ToList()[0].Patients.ToList()[0], new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(sut.Buildings.ToList()[0].Doctors.ToList()[0],
            sut.Buildings.ToList()[0].Patients.ToList()[0], new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.DoctorBusy, status);
    }

    [Fact]
    public void ReceptionCheckRegistrationRecordWithOfficesBusy()
    {
        // Arrange
        var sut = _builder.BuildHospital();
        sut.ReceptionHospital.RegistrationRecord(sut.Buildings.ToList()[0].Doctors.ToList()[0],
            sut.Buildings.ToList()[0].Patients.ToList()[0], new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => sut.ReceptionHospital.RegistrationRecord(
            sut.Buildings.ToList()[0].Doctors.ToList()[1],
            sut.Buildings.ToList()[0].Patients.ToList()[1], new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]));
    }
}