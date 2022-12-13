using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Logic.Models;

namespace Healthcare.WPF.ParsersInformation
{
    public class HospitalStringCreator
    {
        public string GetDoctorSpecilialization(Doctor dt)
        {
            return dt.SpecializationDoctor switch
            {
                TypeDoctor.Therapist => "Терапевт",
                TypeDoctor.Paramedic => "Фельдшер",
                TypeDoctor.Gynecologist => "Гинеколог",
                TypeDoctor.Optometrist => "Окулист",
                TypeDoctor.Surgeon => "Хирург",
                TypeDoctor.Nurse => "Медсестра/Медбрат",
                _ => string.Empty
            };
        }
    }
}
