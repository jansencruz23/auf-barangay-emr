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
    public class PregnancyAppointmentRepository : GenericRepository<PregnancyAppointment>, IPregnancyAppointmentRepository
    {
        private readonly EMRDbContext _dbContext;

        public PregnancyAppointmentRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PregnancyAppointment>> GetPregnancyAppointmentsWithDetails(int recordId)
        {
            var appointments = await _dbContext.PregnancyAppointments
                .AsNoTracking()
                .Include(a => a.PregnancyRecord)
                    .ThenInclude(p => p.Patient)
                        .ThenInclude(p => p.Household)
                .Where(p => p.Status &&
                    p.PregnancyRecord.Status &&
                    p.PregnancyRecord.Id == recordId &&
                    p.PregnancyRecord.Patient.Household.Status)
                .ToListAsync();

            return appointments;
        }

        public async Task<PregnancyAppointment> GetPregnancyAppointmentWithDetails(int id)
        {
            var appointment = await _dbContext.PregnancyAppointments
                .AsNoTracking()
                .Include(a => a.PregnancyRecord)
                    .ThenInclude(p => p.Patient)
                        .ThenInclude(p => p.Household)
                .Where(p => p.Status &&
                    p.PregnancyRecord.Status &&
                    p.PregnancyRecord.Patient.Household.Status)
                .FirstOrDefaultAsync(p => p.Id == id);

            return appointment;
        }
    }
}
