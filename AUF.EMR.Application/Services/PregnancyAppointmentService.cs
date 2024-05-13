using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class PregnancyAppointmentService : GenericService<PregnancyAppointment>, IPregnancyAppointmentService
    {
        private readonly IPregnancyAppointmentRepository _repository;

        public PregnancyAppointmentService(IPregnancyAppointmentRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<PregnancyAppointment>> GetPregnancyAppointmentsWithDetails(int patientId)
        {
            return await _repository.GetPregnancyAppointmentsWithDetails(patientId);
        }

        public async Task<PregnancyAppointment> GetPregnancyAppointmentWithDetails(int id)
        {
            return await _repository.GetPregnancyAppointmentWithDetails(id);
        }
    }
}
