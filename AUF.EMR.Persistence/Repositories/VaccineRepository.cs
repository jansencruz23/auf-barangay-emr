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
    public class VaccineRepository : GenericRepository<Vaccine>, IVaccineRepository
    {
        private readonly EMRDbContext _dbContext;

        public VaccineRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HasData()
        {
            return await _dbContext.Vaccines.AnyAsync();
        }
    }
}
