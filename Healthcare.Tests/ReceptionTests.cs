using System;
using System.Collections.Generic;
using System.Linq;
using Healthcare.Logic.Models;
using Healthcare.Logic.Reception.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Models;
using Xunit;

namespace Healthcare.Logic.Tests;

public class ReceptionTests
{
    [Fact]
    public void ReceptionCheckTrueRegistrationRecord()
    {
        // Arrange
        var sut = new Hospital(Guid.NewGuid(), "Яркое солнышко");
        var cb1 = new List<Cabinet>();
        cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101, null, null, Guid.NewGuid()));
        var d1 = new List<Doctor>();
        var dd1 = new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
            , "654767", TypeDoctor.Paramedic, "09", "15");
        d1.Add(dd1);


        sut.AddDepartment(new Department(cb1, d1, new List<Patient>
            {
                new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid())
            }, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid()));
        var patient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12", Guid.NewGuid());
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(dd1, patient, new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.Successfully, status);
    }

    [Fact]
    public void ReceptionCheckRegistrationRecordWithErrorTime()
    {
        // Arrange
        var sut = new Hospital(Guid.NewGuid(), "Яркое солнышко");
        var cb1 = new List<Cabinet>();
        cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101, null, null, Guid.NewGuid()));
        var d1 = new List<Doctor>();
        var dd1 = new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
            , "654767", TypeDoctor.Paramedic, "09", "15");
        d1.Add(dd1);


        sut.AddDepartment(new Department(cb1, d1, new List<Patient>
            {
                new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid())
            }, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid()));
        var patient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12", Guid.NewGuid());
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(dd1, patient, new DateTime(2022, 10, 27, 04, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.ErrorTime, status);
    }

    [Fact]
    public void ReceptionCheckRegistrationRecordWithBusyDoctor()
    {
        // Arrange
        var sut = new Hospital(Guid.NewGuid(), "Яркое солнышко");
        var cb1 = new List<Cabinet>();
        cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101, null, null, Guid.NewGuid()));
        var d1 = new List<Doctor>();
        var dd1 = new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
            , "654767", TypeDoctor.Paramedic, "09", "15");
        d1.Add(dd1);


        sut.AddDepartment(new Department(cb1, d1, new List<Patient>
            {
                new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid())
            }, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid()));
        var patient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12", Guid.NewGuid());
        sut.ReceptionHospital.RegistrationRecord(dd1, patient, new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(dd1, patient, new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.DoctorBusy, status);
    }

    [Fact]
    public void ReceptionCheckRegistrationRecordWithOfficesBusy()
    {
        // Arrange
        var sut = new Hospital(Guid.NewGuid(), "Яркое солнышко");
        var cb1 = new List<Cabinet>();
        cb1.Add(new Cabinet(TypeDoctor.Paramedic, 101, null, null, Guid.NewGuid()));
        var d1 = new List<Doctor>();
        var dd1 = new Doctor("Потапов", "Алексей", "Даниилович", "Светлая 12"
            , "654767", TypeDoctor.Paramedic, "09", "15");
        var dd2 = new Doctor("Озеров", "Захар", "Максимович", "Светлая 13"
            , "998234", TypeDoctor.Paramedic, "10", "15");
        d1.Add(dd1);
        d1.Add(dd2);

        sut.AddDepartment(new Department(cb1, d1, new List<Patient>
            {
                new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid())
            }, "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid()));
        var patient = new Patient("Лебедев", "Артём", "Викторович", "Многоножная 12", Guid.NewGuid());
        sut.ReceptionHospital.RegistrationRecord(dd1, patient, new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);
        // Act
        var status = sut.ReceptionHospital.RegistrationRecord(dd2, patient, new DateTime(2022, 10, 27, 10, 15, 0),
            sut.Buildings.ToList()[0]);

        // Assert
        Assert.Equal(TypeStatus.OfficesBusy, status);
    }
}