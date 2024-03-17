using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Common;
using AUF.EMR.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence
{
    public class EMRDbContext : IdentityDbContext<ApplicationUser>
    {
        public EMRDbContext(DbContextOptions<EMRDbContext> options)
            : base(options)
        {

        }

        public DbSet<Household> HouseHolds { get; set; }
        public DbSet<HouseholdMember> HouseHoldMembers { get; set; }
        public DbSet<WomanOfReproductiveAge> WomanOfReproductiveAges { get; set; }
        public DbSet<PregnancyTracking> PregnancyTrackings { get; set; }
        public DbSet<RecordLog> RecordLogs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added
                    || e.State == EntityState.Modified
                    || e.State == EntityState.Deleted)
                .ToList();
            
            foreach (var modifiedEntity in modifiedEntities)
            {
                var recordLog = new RecordLog
                {
                    EntityName = modifiedEntity.Entity.GetType().Name,
                    Action = modifiedEntity.State.ToString(),
                    Timestamp = DateTime.Now
                };

                RecordLogs.Add(recordLog);
            }

            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
