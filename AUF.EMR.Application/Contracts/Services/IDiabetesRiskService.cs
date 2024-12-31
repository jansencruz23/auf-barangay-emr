using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;

namespace AUF.EMR.Application.Contracts.Services;

public interface IDiabetesRiskService : IGenericService<DiabetesRisk>
{
    Task<List<DiabetesRisk>> GetDiabetesRiskWithDetails(string householdNo);
    Task<DiabetesRisk> GetDiabetesRiskWithDetails(int id);
    Task<List<DiabetesRisk>> GetDiabetesRiskForm(int id);
}