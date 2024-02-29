using AUF.EMR.Domain.Models;

namespace AUF.EMR.MVC.Models
{
    public class MasterlistVM
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MotherMaidenName { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public DateTime Birthday { get; set; }
        public string HouseholdNo { get; set; }
        public int? HouseholdId { get; set; }
        public Household? Household { get; set; }
        public string? NameOfMother { get; set; }
        public string? NameOfFather { get; set; }
        public bool? IsNhts { get; set; }
        public bool? IsInSchool { get; set; }
    }
}
