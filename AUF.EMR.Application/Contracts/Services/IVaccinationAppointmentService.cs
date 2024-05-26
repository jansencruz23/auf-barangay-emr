using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IVaccinationAppointmentService : IGenericService<VaccinationAppointment>
    {
        Task<List<VaccinationAppointment>> GetVaccinationAppointmentsWithDetails(int patientId);
        Task<VaccinationAppointment> GetVaccinationAppointmentWithDetails(int id);
        Task<List<VaccinationRecord>> GetVaccinationRecordsForm(int id);
    }
}
