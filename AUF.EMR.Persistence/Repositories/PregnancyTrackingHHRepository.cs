using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Domain.Models;
using AUF.EMR.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence.Repositories
{
    public class PregnancyTrackingHHRepository : GenericRepository<PregnancyTrackingHH>, IPregnancyTrackingHHRepository
    {
        private readonly EMRDbContext _dbContext;

        public PregnancyTrackingHHRepository(EMRDbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
