﻿using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class DashboardVM : BaseVM
    {
        public int HouseholdCount { get; set; } 
        public int HouseholdMemberCount { get; set; } 
        public int NewbornCount { get; set; } 
        public int InfantCount { get; set; } 
        public int UnderFiveCount { get; set; } 
        public int SchoolAgedCount { get; set; } 
        public int AdolescentsCount { get; set; } 
        public int AdultCount { get; set; } 
        public int SeniorCount { get; set; }
    }
}