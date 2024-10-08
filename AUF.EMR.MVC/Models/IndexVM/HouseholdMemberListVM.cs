﻿using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class HouseholdMemberListVM : BaseVM
    {
        public List<HouseholdMember> HouseholdMembers { get; set; }
        public Household Household { get; set; }
    }
}
