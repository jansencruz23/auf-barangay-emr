using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;

namespace AUF.EMR.Application.Services;

public sealed class DiabetesRiskService : GenericService<DiabetesRisk>, IDiabetesRiskService
{
    private readonly IDiabetesRiskRepository _diabetesRepository;

    public DiabetesRiskService(IDiabetesRiskRepository diabetesRepository) : base(diabetesRepository)
    {
        _diabetesRepository = diabetesRepository;
    }

    public async Task<List<DiabetesRisk>> GetDiabetesRiskWithDetails(string householdNo)
    {
        return await _diabetesRepository.GetDiabetesRiskWithDetails(householdNo);
    }

    public async Task<DiabetesRisk> GetDiabetesRiskWithDetails(int id)
    {
        return await _diabetesRepository.GetDiabetesRiskWithDetails(id);
    }
}
