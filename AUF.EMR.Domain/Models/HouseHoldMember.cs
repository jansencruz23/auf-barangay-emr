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
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MotherMaidenName { get; set; }
        public int RelationshipToHouseholdHead { get; set; }
        public string? OtherRelation { get; set; }
        public char Sex { get; set; }
        public string Age { get; set; }

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
        public bool? IsNhts { get; set; }
        public bool? IsInSchool { get; set; }

        public string FormattedFullName { get => $"{FirstName} {GetMiddleInitial()}. {LastName}"; }
        public string FullName { get => $"{LastName}, {FirstName}, {MotherMaidenName}"; }

        private string GetMiddleInitial()
        {
            if (string.IsNullOrEmpty(MotherMaidenName) || MotherMaidenName.Length < 2)
                return string.Empty;

            return MotherMaidenName.Split(' ').Last()[0].ToString();
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
    }
}
