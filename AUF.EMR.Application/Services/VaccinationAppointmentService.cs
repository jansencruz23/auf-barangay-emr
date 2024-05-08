using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Services
{
    public class VaccinationAppointmentService : GenericService<VaccinationAppointment>, IVaccinationAppointmentService
    {
        private readonly IVaccinationAppointmentRepository _repository;

        public VaccinationAppointmentService(IVaccinationAppointmentRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<VaccinationAppointment>> GetVaccinationAppointmentsWithDetails(int patientId)
        {
            return await _repository.GetVaccinationAppointmentsWithDetails(patientId);
        }

        public async Task<VaccinationAppointment> GetVaccinationAppointmentWithDetails(int id)
        {
            return await _repository.GetVaccinationAppointmentWithDetails(id);
        }
    }
}
