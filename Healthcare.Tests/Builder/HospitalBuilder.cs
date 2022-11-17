using System;
using System.Collections.Generic;
using Healthcare.Logic.Models;
using Healthcare.Logic.Separations;
using Healthcare.Logic.Separations.Base;
using Healthcare.Logic.Separations.Models;

namespace Healthcare.Logic.Tests.Builder;

internal class HospitalBuilder
{
    private Hospital Hospital { get; set; }

    private IDepartment BuildDepartmentPart()
    {
        IDepartment dp = new Department(BuildListCabinets(), BuildListDoctor(), BuildListPatients()
            , "Поликлиника <Мертвый анархист>", "Свердловская 10/1", 1,
            TypeDepartment.Therapeutic, Guid.NewGuid());
        return dp;
    }

    private List<Patient> BuildListPatients()
    {
        return new List<Patient>
        {
            new("Владислав", "Семен", "Александрович", "Дуси Ковальчук 101 кв 105", Guid.NewGuid()),
            new("Лебедев", "Артём", "Викторович", "Многоножная 12", Guid.NewGuid())
        };
    }

    private List<Doctor> BuildListDoctor()
    {
        return new List<Doctor>
        {
            new("Потапов", "Алексей", "Даниилович", "Светлая 12"
                , "654767", TypeDoctor.Paramedic, "09", "15"),
            new("Озеров", "Захар", "Максимович", "Светлая 13"
                , "998234", TypeDoctor.Paramedic, "10", "15")
        };
    }

    private List<Cabinet> BuildListCabinets()
    {
        return new List<Cabinet>
        {
            new(TypeDoctor.Paramedic, 101, null, null, Guid.NewGuid())
        };
    }

    public Hospital BuildHospital()
    {
        Hospital = new Hospital(Guid.NewGuid(), "Солнышко");
        Hospital.AddDepartment(BuildDepartmentPart());
        return Hospital;
    }
}