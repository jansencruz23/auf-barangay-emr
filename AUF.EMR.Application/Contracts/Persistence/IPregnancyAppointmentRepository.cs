using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IPregnancyAppointmentRepository : IGenericRepository<PregnancyAppointment>
    {
        Task<List<PregnancyAppointment>> GetPregnancyAppointmentsWithDetails(int patientId);
        Task<PregnancyAppointment> GetPregnancyAppointmentWithDetails(int id);
    }
}
