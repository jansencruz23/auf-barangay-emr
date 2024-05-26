using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.FamilyPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IFamilyPlanningService : IGenericService<FamilyPlanningRecord>
    {
        Task<FamilyPlanningRecord> GetFPRecordWithDetails(int id);
        Task<List<FamilyPlanningRecord>> GetFPRecordsWithDetails(string householdNo);
        Task<FamilyPlanningRecord> AddFamilyPlanning(FamilyPlanningRecord fpRecord);
        Task UpdateFamilyPlanning(FamilyPlanningRecord fpRecord);
        Task<List<FamilyPlanningRecord>> GetFamilyPlanningForm(int id);
        Task<List<ClientType>> GetClientTypeForm(int id);
        Task<List<MedicalHistory>> GetMedicalHistoryForm(int id);
        Task<List<ObstetricalHistory>> GetObstetricalHistoryForm(int id);
        Task<List<RisksForSTI>> GetRisksForSTIForm(int id);
        Task<List<RisksForVAW>> GetRisksForVAWForm(int id);
        Task<List<PhysicalExamination>> GetPhysicalExaminationForm(int id);
    }
}
