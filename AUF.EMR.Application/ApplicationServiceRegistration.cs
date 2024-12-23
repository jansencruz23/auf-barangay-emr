﻿using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Application.Contracts.Services.Data;
using AUF.EMR.Application.Services;
using AUF.EMR.Application.Services.Common;
using AUF.EMR.Application.Services.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IHouseholdService, HouseholdService>();
            services.AddScoped<IHouseholdMemberService, HouseholdMemberService>();
            services.AddScoped<IMasterlistService, MasterlistService>();
            services.AddScoped<IOralHealthService, OralHealthService>();
            services.AddScoped<IWRAService, WRAService>();
            services.AddScoped<IPregnancyTrackingService, PregnancyTrackingService>();
            services.AddScoped<IBarangayService, BarangayService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IPregnancyTrackingHHService, PregnancyTrackingHHService>();
            services.AddScoped<IFamilyPlanningService, FamilyPlanningService>();
            services.AddScoped<IPatientRecordService, PatientRecordService>();
            services.AddScoped<IVaccinationAppointmentService, VaccinationAppointmentService>();
            services.AddScoped<IVaccineService, VaccineService>();
            services.AddScoped<IVaccinationRecordService, VaccinationRecordService>();
            services.AddScoped<IPregnancyRecordService, PregnancyRecordService>();
            services.AddScoped<IPregnancyAppointmentService, PregnancyAppointmentService>();
            services.AddScoped<ISummaryService, SummaryService>();
            services.AddScoped<IDiabetesRiskService, DiabetesRiskService>();

            services.AddTransient<IDatabaseExportService, DatabaseExportService>();

            return services;
        }
    }
}
