using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class HouseholdMember : BaseDomainEntity
    {
        [StringLength(50)]
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string? MotherMaidenName { get; set; }

        [Required(ErrorMessage = "The Relationship to Household Head field is required.")]
        public int RelationshipToHouseholdHead { get; set; }
        public string? OtherRelation { get; set; }
        public char Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string? FirstQtrClassification { get; set; }
        public string? SecondQtrClassification { get; set; }
        public string? ThirdQtrClassification { get; set; }
        public string? FourthQtrClassification { get; set; }
        public string? Remarks { get; set; }
        public int HouseholdId { get; set; }
        public Household? Household { get; set; }
        public string? NameOfMother { get; set; }
        public string? NameOfFather { get; set; }

        [Required(ErrorMessage = "The NHTS field is required.")]
        public bool IsNhts { get; set; }
        public bool NotNhts { get => !IsNhts; }
        public bool? IsInSchool { get; set; }
        public bool? NotInSchool { get => !IsInSchool; }

        public string Age { get => GetAgeWithSuffix(Birthday, DateTime.Today); }
        public int AgeYears { get => DateTime.Today.Year - Birthday.Year; }
        public string? LastVisitedAge { get => GetAgeWithSuffix(Birthday, LastModified); } 

        public string FormattedFullName { get => $"{FirstName} {GetMiddleInitial()} {LastName}"; }
        public string FormattedFullName2 { get => $"{LastName}, {FirstName}, {GetMiddleInitial()}"; }
        public string FullName { get => $"{LastName}, {FirstName}{GetMotherMaidenName()}"; }
        public string MiddleInitial { get => $"{GetMiddleInitial()}"; }

        public bool TenToFourteen { get => int.Parse(Age.Split(" ")[0]) >= 10 && int.Parse(Age.Split(" ")[0]) <= 14; }
        public bool FifteenToNineteen { get => int.Parse(Age.Split(" ")[0]) >= 15 && int.Parse(Age.Split(" ")[0]) <= 19; }
        public bool TwentyToFourtyNine { get => int.Parse(Age.Split(" ")[0]) >= 20 && int.Parse(Age.Split(" ")[0]) <= 49; }

        private string GetMiddleInitial()
        {
            if (string.IsNullOrEmpty(MotherMaidenName) || MotherMaidenName.Length < 2)
                return string.Empty;

            return MotherMaidenName.Split(' ').Last()[0].ToString() + ".";
        }

        private string GetMotherMaidenName()
        {
            if (string.IsNullOrWhiteSpace(MotherMaidenName))
            {
                return "";
            }

            return $", {MotherMaidenName}";
        }

        public string GetRelationshipString
        {
            get
            {
                return RelationshipToHouseholdHead switch
                {
                    1 => "Head",
                    2 => "Spouse",
                    3 => "Son",
                    4 => "Daughter",
                    5 => "Other: " + OtherRelation,
                    _ => "Unknown"
                };
            }
        }

        private string GetAgeWithSuffix(DateTime birthDate, DateTime toDate)
        {
            int years = toDate.Year - birthDate.Year;
            int months = toDate.Month - birthDate.Month;
            int days = toDate.Day - birthDate.Day;

            if (toDate.Equals(DateTime.MinValue))
            {
                toDate = DateTime.Today;
            }

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(toDate.Year, toDate.Month - 1);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            if (years > 0)
            {
                return $"{years} yrs";
            }
            else if (months > 0)
            {
                return $"{months} mos";
            }
            else
            {
                return $"{days} days";
            }
        }
    }
}
