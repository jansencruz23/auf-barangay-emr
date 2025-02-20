﻿using AUF.EMR.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Domain.Models
{
    public class Household : BaseDomainEntity
    {
        public string HouseholdNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FirstQtrVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SecondQtrVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ThirdQtrVisit { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FourthQtrVisit { get; set; }

        [Required(ErrorMessage = "Last name field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum character for last name is 50.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum character for first name is 50.")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum character for mother's maiden name is 50.")]
        public string? MotherMaidenName { get; set; }

        [Required(ErrorMessage = "House No and street field is required.")]
        public string HouseNoAndStreet { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Contact number must start with '09' and be exactly 11 digits.")]
        public string ContactNo { get; set; }
        public bool IsNHTS { get; set; }
        public bool IsHeadPhilhealthMember { get; set; }
        public string? PhilhealthNo { get; set; }
        public string? Category { get; set; }
        public bool IsIP { get; set; }
        public List<HouseholdMember> HouseholdMembers { get; set; } = new();

        public string FullAddress { get => $"{HouseNoAndStreet} {Barangay}, {City}, {Province}"; }
        public string FullName { get => $"{FirstName} {GetMiddleInitial()} {LastName}"; }

        private string GetMiddleInitial()
        {
            if (string.IsNullOrEmpty(MotherMaidenName) || MotherMaidenName.Length < 2)
                return string.Empty;

            return MotherMaidenName.Split(' ').Last()[0].ToString() + ".";
        }
    }
}
