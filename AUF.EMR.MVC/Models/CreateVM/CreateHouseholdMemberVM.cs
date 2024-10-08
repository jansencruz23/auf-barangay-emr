﻿using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.CreateVM
{
    public class CreateHouseholdMemberVM : BaseVM
    {
        public HouseholdMember HouseholdMember { get; set; }
        public int HouseholdId { get; set; }
        //public string AgeSuffix { get; set; }
        public List<Classification>? Classifications { get; set; }
        public List<Classification>? FirstQtrClassifications { get; set; }
        public List<Classification>? SecondQtrClassifications { get; set; }
        public List<Classification>? ThirdQtrClassifications { get; set; }
        public List<Classification>? FourthQtrClassifications { get; set; }

    }
}
