using AUF.EMR.Application.Constants;
using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Domain.Models;

namespace AUF.EMR.Application.Services
{
    public class OralHealthService : GenericService<HouseholdMember>, IOralHealthService
    {
        private readonly IOralHealthRepository _oralRepository;
        private readonly IPregnancyTrackingService _pregnancyService;

        public OralHealthService(IOralHealthRepository oralRepository,
            IPregnancyTrackingService pregnancyService)
            : base(oralRepository)
        {
            _oralRepository = oralRepository;
            _pregnancyService = pregnancyService;
        }

        public Task<List<HouseholdMember>> GetAllOralClients(string householdNo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HouseholdMember>> GetOralClientInfant(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.InfantStart).AddDays(1);
            return await _oralRepository.GetListQuery(householdNo, startDate);
        }

        public async Task<List<HouseholdMember>> GetOralClient1to4(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.OneToFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.OneToFiveEnd);

            return await _oralRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetOralClient5to9(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.FiveToNineStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.FiveToNineEnd);

            return await _oralRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetOralClient10to14(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.TenToFourteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.TenToFourteenEnd);

            return await _oralRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetOralClient15to19(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.FifteenToNineteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.FifteenToNineteenEnd);

            return await _oralRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetOralClient20to49(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.TwentyToFourtynineStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.TwentyToFourtynineEnd);

            return await _oralRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetOralClientPregnant15to19(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.FifteenToNineteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.FifteenToNineteenEnd);

            return await _pregnancyService.GetPregnantHouseholdMembers(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetOralClientPregnant20to49(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralClientAgeRange.TwentyToFourtynineStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralClientAgeRange.TwentyToFourtynineEnd);

            return await _pregnancyService.GetPregnantHouseholdMembers(householdNo, startDate, endDate);
        }
    }
}
