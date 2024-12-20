using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;

namespace AUF.EMR.Application.Services;

public sealed class DiabetesRiskService : GenericService<DiabetesRisk>, IDiabetesRiskService
{
    public DiabetesRiskService(IGenericRepository<DiabetesRisk> repository) : base(repository)
    {
    }

    public Task<List<DiabetesRisk>> GetDiabetesRiskWithDetails(string householdNo)
    {
        throw new NotImplementedException();
    }

    public Task<DiabetesRisk> GetDiabetesRiskWithDetails(int id)
    {
        throw new NotImplementedException();
    }
}
