using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IVaccinationRecordService : IGenericService<VaccinationRecord>
    {
        Task<List<VaccinationRecord>> GetVaccinationRecordsWithDetails(int id);
        Task<List<VaccinationRecord>> AddVaccinationRecords(int vaccinationAppointmentId, List<Vaccine> vaccines);
        Task DeleteVaccinationRecords(int vaccinationAppointmentId, List<Vaccine> vaccines);
        Task<List<VaccinationAppointment>> GetVaccinationAppointmentsForm(int appointmentId);
        Task<List<Vaccine>> GetVaccinesForm(int appointmentId);
        Task<List<VaccinationRecord>> GetVaccineRecordsForm(int appointmentId);
    }
}
