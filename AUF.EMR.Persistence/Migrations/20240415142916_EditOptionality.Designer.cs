﻿// <auto-generated />
using System;
using AUF.EMR.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AUF.EMR.Persistence.Migrations
{
    [DbContext(typeof(EMRDbContext))]
    [Migration("20240415142916_EditOptionality")]
    partial class EditOptionality
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AUF.EMR.Domain.Models.Barangay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BarangayHealthStation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BarangayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNo")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("longblob");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RuralHealthUnit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Barangays");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.Household", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Barangay")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FirstQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FourthQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HouseNoAndStreet")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HouseholdNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsHeadPhilhealthMember")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsIP")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsNHTS")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<string>("MotherMaidenName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhilhealthNo")
                        .HasColumnType("longtext");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("SecondQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ThirdQtrVisit")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Households");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.HouseholdMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<string>("FourthQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<string>("HouseholdNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsInSchool")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsNhts")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<string>("MotherMaidenName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameOfFather")
                        .HasColumnType("longtext");

                    b.Property<string>("NameOfMother")
                        .HasColumnType("longtext");

                    b.Property<string>("OtherRelation")
                        .HasColumnType("longtext");

                    b.Property<int>("RelationshipToHouseholdHead")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<string>("SecondQtrClassification")
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ThirdQtrClassification")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdId");

                    b.ToTable("HouseholdMembers");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("longblob");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.PregnancyTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EarlyNewbornDeath")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpectedDateOfDelivery")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FirstAntenatalCheckUp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Gravidity")
                        .HasColumnType("int");

                    b.Property<int>("HouseholdMemberId")
                        .HasColumnType("int");

                    b.Property<string>("HouseholdNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LiveBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("MaternalDeath")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<int>("Parity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PostnatalCheckUp24hrs")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("PostnatalCheckUp7days")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PregnancyOutcome")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SecondAntenatalCheckUp")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("StillBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ThirdAntenatalCheckUp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdMemberId");

                    b.ToTable("PregnancyTrackings");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.RecordLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("RecordLogs");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.WomanOfReproductiveAge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AcceptModernFpMethod")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CivilStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FPAcceptedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HouseholdMemberId")
                        .HasColumnType("int");

                    b.Property<string>("HouseholdNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsFPMethod")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsFPModern")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsFecund")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMFPUnmet")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPlanChildrenLimiting")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPlanChildrenNow")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsPlanChildrenSpacing")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsPlanningChildren")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModernFPMethod")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("ShiftToModern")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("HouseholdMemberId");

                    b.ToTable("WomanOfReproductiveAges");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.HouseholdMember", b =>
                {
                    b.HasOne("AUF.EMR.Domain.Models.Household", "Household")
                        .WithMany("HouseholdMembers")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.PregnancyTracking", b =>
                {
                    b.HasOne("AUF.EMR.Domain.Models.HouseholdMember", "HouseholdMember")
                        .WithMany()
                        .HasForeignKey("HouseholdMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseholdMember");
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.WomanOfReproductiveAge", b =>
                {
                    b.HasOne("AUF.EMR.Domain.Models.HouseholdMember", "HouseholdMember")
                        .WithMany()
                        .HasForeignKey("HouseholdMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HouseholdMember");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AUF.EMR.Domain.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AUF.EMR.Domain.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AUF.EMR.Domain.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AUF.EMR.Domain.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AUF.EMR.Domain.Models.Household", b =>
                {
                    b.Navigation("HouseholdMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
