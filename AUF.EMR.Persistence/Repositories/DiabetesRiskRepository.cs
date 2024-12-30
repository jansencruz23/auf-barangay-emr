using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR.Persistence.Repositories;

public sealed class DiabetesRiskRepository : GenericRepository<DiabetesRisk>, IDiabetesRiskRepository
{
    private readonly EMRDbContext _dbContext;

    public DiabetesRiskRepository(EMRDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DiabetesRisk>> GetDiabetesRiskWithDetails(string householdNo)
    {
        var query = await _dbContext.DiabetesRisks
            .AsNoTracking()
            .Include(x => x.HouseholdMember)
                .ThenInclude(x => x.Household)
            .Where(x => x.HouseholdMember.Household!.HouseholdNo.Equals(householdNo) 
                && x.Status 
                && x.HouseholdMember.Status)
            .ToListAsync();

        return query;
    }

    public async Task<DiabetesRisk> GetDiabetesRiskWithDetails(int id)
    {
        var query = await _dbContext.DiabetesRisks
            .AsNoTracking()
            .Include(x => x.HouseholdMember)
            .Where(x => x.Status && x.HouseholdMember.Status)
            .FirstOrDefaultAsync(x => x.Id == id);

        return query;
    }
}
