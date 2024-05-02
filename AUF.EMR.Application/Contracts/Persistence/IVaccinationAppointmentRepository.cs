using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IVaccinationAppointmentRepository : IGenericRepository<VaccinationAppointment>
    {
        Task<List<VaccinationAppointment>> GetVaccinationAppointmentsWithDetails(int patientId);
        Task<VaccinationAppointment> GetVaccinationAppointmentWithDetails(int id);
    }
}
