﻿using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IWRAService : IGenericService<WomanOfReproductiveAge>
    {
        Task<List<WomanOfReproductiveAge>> GetWRAListWithDetails(string householdNo);
        Task<WomanOfReproductiveAge> GetWRAWithDetails(int id);
    }
}
