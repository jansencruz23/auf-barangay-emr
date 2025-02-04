﻿using AUF.EMR.Domain.Models;
using AUF.EMR.MVC.Models.Common;

namespace AUF.EMR.MVC.Models.IndexVM
{
    public class DiabetesRiskVM : BaseVM
    {
        public List<DiabetesRisk> DiabetesRisks { get; set; } = new();
    }
}
