using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class SummaryVM
    {
        public int NewbornCount { get; set; }
        public int InfantCount { get; set; }
        public int UnderFiveCount { get; set; }
        public int SchoolAgedCount { get; set; }
        public int AdolescentCount { get; set; }
        public int AdultCount { get; set; }
        public int SeniorCount { get; set; }
        public IReadOnlyList<RecordLog>? TotalRecords { get; set; }
    }
}
