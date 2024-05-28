using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class VaccinationAppointmentRepository : GenericRepository<VaccinationAppointment>, IVaccinationAppointmentRepository
    {
        private readonly EMRDbContext _dbContext;

        public VaccinationAppointmentRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VaccinationAppointment>> GetVaccinationAppointmentsWithDetails(int patientId)
        {
            var appointments = await _dbContext.VaccinationAppointments
                .AsNoTracking()
                .Include(a => a.PatientRecord)
                .Where(a => a.Status &&
                    a.PatientRecord.Status &&
                    a.PatientRecordId == patientId)
                .ToListAsync();

            return appointments;
        }

        public async Task<VaccinationAppointment> GetVaccinationAppointmentWithDetails(int id)
        {
            var appointment = await _dbContext.VaccinationAppointments
                .AsNoTracking()
                .Include(a => a.PatientRecord)
                .Where(a => a.Status &&
                    a.PatientRecord.Status)
                .FirstOrDefaultAsync(a => a.Id == id);

            return appointment;
        }
    }
}
