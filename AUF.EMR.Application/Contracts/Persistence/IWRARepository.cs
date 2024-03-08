using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Persistence
{
    public interface IWRARepository : IGenericRepository<WomanOfReproductiveAge>
    {
        Task<List<WomanOfReproductiveAge>> GetWRAWithDetails(string householdNo);
    }
}
