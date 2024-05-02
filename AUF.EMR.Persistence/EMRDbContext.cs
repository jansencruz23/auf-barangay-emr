using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.FamilyPlanning;
using AUF.EMR.Domain.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence
{
    public class EMRDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EMRDbContext(DbContextOptions<EMRDbContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Household> Households { get; set; }
        public DbSet<HouseholdMember> HouseholdMembers { get; set; }
        public DbSet<WomanOfReproductiveAge> WomanOfReproductiveAges { get; set; }
        public DbSet<PregnancyTracking> PregnancyTrackings { get; set; }
        public DbSet<RecordLog> RecordLogs { get; set; }
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<PregnancyTrackingHH> PregnancyTrackingHHs { get; set; }
        public DbSet<FamilyPlanningRecord> FamilyPlanningRecords { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<ObstetricalHistory> ObstetricalHistories { get; set; }
        public DbSet<PhysicalExamination> PhysicalExaminations { get; set; }
        public DbSet<RisksForSTI> RisksForSTIs { get; set; }
        public DbSet<RisksForVAW> RisksForVAWs { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }
        public DbSet<VaccinationAppointment> VaccinationAppointments { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = GetModifiedEntities();
            HandleEntityDelete();
            LogEntityChanges(modifiedEntities);

            return base.SaveChangesAsync(cancellationToken);
        }

        private List<EntityEntry<BaseDomainEntity>> GetModifiedEntities()
        {
            return ChangeTracker.Entries<BaseDomainEntity>()
                .Where(e => e.State == EntityState.Added
                    || e.State == EntityState.Modified
                    || e.State == EntityState.Deleted)
                .ToList();
        }

        private void HandleEntityDelete()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted)
                .ToList();

            if (entities.Any())
            {
                foreach (var entity in entities)
                {
                    if (entity.Entity is BaseDomainEntity)
                    {
                        entity.State = EntityState.Modified;
                        var domainEntity = entity.Entity as BaseDomainEntity;
                        domainEntity.Status = false;
                    }
                }
            }
        }

        private void LogEntityChanges(List<EntityEntry<BaseDomainEntity>> modifiedEntities)
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (currentUserId != null)
            {
                foreach (var modifiedEntity in modifiedEntities)
                {
                    if (modifiedEntity.Entity is BaseDomainEntity entity)
                    {
                        var recordLog = new RecordLog
                        {
                            EntityName = modifiedEntity.Entity.GetType().Name,
                            Action = modifiedEntity.State.ToString(),
                            Timestamp = DateTime.Now,
                            ModifiedById = Guid.Parse(currentUserId)
                        };

                        if (!entity.Status)
                        {
                            recordLog.Action = "Deleted";
                        }

                        RecordLogs.Add(recordLog);
                    }
                }

                foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
                {
                    entry.Entity.LastModified = DateTime.Now;
                    entry.Entity.ModifiedById = Guid.Parse(currentUserId);

                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.DateCreated = DateTime.Now;
                    }
                }
            }
        }
    }
}
