using AUF.EMR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application.Contracts.Services
{
    public interface IDashboardService
    {
        Task<IReadOnlyList<RecordLog>> GetAllCheckedToday(Guid id);
        Task<int> GetCheckedNewbornToday(Guid id);
        Task<int> GetCheckedInfantToday(Guid id);
        Task<int> GetCheckedUnderFiveToday(Guid id);
        Task<int> GetCheckedSchoolAgedToday(Guid id);
        Task<int> GetCheckedAdolescentToday(Guid id);
        Task<int> GetCheckedAdultToday(Guid id);
        Task<int> GetCheckedSeniorToday(Guid id);
    }
}
