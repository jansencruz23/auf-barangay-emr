﻿using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IVaccinationRecordRepository : IGenericRepository<VaccinationRecord>
    {
        Task<List<VaccinationRecord>> GetVaccinationRecordsWithDetails(int id);
        Task DeleteVaccinationRecord(int vaccinationAppointmendId, int vaccineId);
        Task<List<VaccinationAppointment>> GetVaccinationAppointmentsForm(int appointmentId);
        Task<List<Vaccine>> GetVaccinesForm(int appointmentId);
        Task<List<VaccinationRecord>> GetVaccineRecordsForm(int appointmentId);
    }
}
