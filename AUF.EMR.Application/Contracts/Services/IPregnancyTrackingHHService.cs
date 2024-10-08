﻿using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IPregnancyTrackingHHService : IGenericService<PregnancyTrackingHH>
    {
        public Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(int id);
        public Task<PregnancyTrackingHH> GetPregnancyTrackingHHWithDetails(string householdNo);
        public Task<List<PregnancyTrackingHH>> GetPregnancyTrackingsHHWithDetails(string householdNo);
    }
}
