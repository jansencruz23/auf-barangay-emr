using AUF.EMR.Domain.Models;
using AUF.EMR.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    }
}
