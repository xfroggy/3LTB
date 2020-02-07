﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3LTB.Data;

namespace _3LTB.Migrations
{
    [DbContext(typeof(_3LTBContext))]
    partial class _3LTBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("_3LTB.Helpers.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Base")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeniorityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("_3LTB.Models.Base", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseName")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Bases");
                });

            modelBuilder.Entity("_3LTB.Models.DutyPeriod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("DPblock")
                        .HasColumnType("real");

                    b.Property<int>("DPnum")
                        .HasColumnType("int");

                    b.Property<string>("RLSarrHBT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RLSarrLCL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RPTdayNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RPTdepHBT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RPTdepLCL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SequenceSeqNum")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SequenceSeqNum");

                    b.ToTable("DutyPeriods");
                });

            modelBuilder.Entity("_3LTB.Models.Leg", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ARRcity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ARRhbt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ARRlcl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DEPcity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DEPhbt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DEPlcl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DPnum")
                        .HasColumnType("int");

                    b.Property<int>("DayNumEnd")
                        .HasColumnType("int");

                    b.Property<int>("DayNumStart")
                        .HasColumnType("int");

                    b.Property<int>("DutyPeriodID")
                        .HasColumnType("int");

                    b.Property<string>("EQP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FLTnum")
                        .HasColumnType("int");

                    b.Property<float>("LEGblock")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("DutyPeriodID");

                    b.ToTable("Legs");
                });

            modelBuilder.Entity("_3LTB.Models.OpDate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DateOp")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("OpDate");
                });

            modelBuilder.Entity("_3LTB.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Flight")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Lang")
                        .HasColumnType("bit");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<bool>("RedFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Report")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("_3LTB.Models.Sequence", b =>
                {
                    b.Property<int>("SeqNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseID")
                        .HasColumnType("int");

                    b.Property<int>("DaysOp")
                        .HasColumnType("int");

                    b.Property<float>("GTTL")
                        .HasColumnType("real");

                    b.Property<float>("RIG")
                        .HasColumnType("real");

                    b.Property<float>("TTL")
                        .HasColumnType("real");

                    b.HasKey("SeqNum");

                    b.HasIndex("BaseID");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("_3LTB.Models.SequenceOpDate", b =>
                {
                    b.Property<int>("SequenceSeqNum")
                        .HasColumnType("int");

                    b.Property<int>("OpDateID")
                        .HasColumnType("int");

                    b.HasKey("SequenceSeqNum", "OpDateID");

                    b.HasIndex("OpDateID");

                    b.ToTable("SequenceOpDate");
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
                    b.HasOne("_3LTB.Helpers.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("_3LTB.Helpers.ApplicationUser", null)
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

                    b.HasOne("_3LTB.Helpers.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("_3LTB.Helpers.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3LTB.Models.DutyPeriod", b =>
                {
                    b.HasOne("_3LTB.Models.Sequence", "Sequence")
                        .WithMany("DutyPeriods")
                        .HasForeignKey("SequenceSeqNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3LTB.Models.Leg", b =>
                {
                    b.HasOne("_3LTB.Models.DutyPeriod", "DutyPeriod")
                        .WithMany("Legs")
                        .HasForeignKey("DutyPeriodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3LTB.Models.Sequence", b =>
                {
                    b.HasOne("_3LTB.Models.Base", "Base")
                        .WithMany("Sequences")
                        .HasForeignKey("BaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_3LTB.Models.SequenceOpDate", b =>
                {
                    b.HasOne("_3LTB.Models.OpDate", "OpDate")
                        .WithMany("SequenceOpDates")
                        .HasForeignKey("OpDateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_3LTB.Models.Sequence", "Sequence")
                        .WithMany("SequenceOpDates")
                        .HasForeignKey("SequenceSeqNum")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
