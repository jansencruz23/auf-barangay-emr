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

        public DbSet<HouseHold> HouseHolds { get; set; }
        public DbSet<HouseHoldMember> HouseHoldMembers { get; set; }
    }
}
