﻿using Healthcare.Models.Separations.Models;

namespace Healthcare.Models.Separations;

internal interface IManageData

{
    void AddCabinet(Cabinet cb);
    void AddDoctor(Doctor dt);
    void AddPatient(Patient pt);
    void DismissDoctor(Doctor dt);
    void DischargePatient(Patient pt);
    Record AddRecord(Doctor doctor, Patient pt, DateTime dt);
}