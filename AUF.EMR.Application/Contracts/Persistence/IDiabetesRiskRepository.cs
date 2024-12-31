using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;

namespace AUF.EMR.Application.Contracts.Persistence;

public interface IDiabetesRiskRepository : IGenericRepository<DiabetesRisk>
{
    Task<List<DiabetesRisk>> GetDiabetesRiskWithDetails(string householdNo);
    Task<DiabetesRisk> GetDiabetesRiskWithDetails(int id);
    Task<List<DiabetesRisk>> GetDiabetesRiskForm(int id);
}
