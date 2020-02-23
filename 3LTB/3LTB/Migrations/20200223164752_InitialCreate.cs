using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _3LTB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    SeniorityNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    Base = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bases",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OpDates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpDates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sequences",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseID = table.Column<int>(nullable: false),
                    SeqNum = table.Column<int>(nullable: false),
                    TTL = table.Column<float>(nullable: false),
                    RIG = table.Column<float>(nullable: false),
                    GTTL = table.Column<float>(nullable: false),
                    DaysOp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sequences", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sequences_Bases_BaseID",
                        column: x => x.BaseID,
                        principalTable: "Bases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutyPeriods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequenceID = table.Column<int>(nullable: false),
                    DPnum = table.Column<int>(nullable: false),
                    RPTdayNum = table.Column<string>(nullable: true),
                    RPTdepLCL = table.Column<string>(nullable: true),
                    RPTdepHBT = table.Column<string>(nullable: true),
                    RLSarrLCL = table.Column<string>(nullable: true),
                    RLSarrHBT = table.Column<string>(nullable: true),
                    DPblock = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyPeriods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DutyPeriods_Sequences_SequenceID",
                        column: x => x.SequenceID,
                        principalTable: "Sequences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SequenceOpDate",
                columns: table => new
                {
                    SequenceSeqNum = table.Column<int>(nullable: false),
                    OpDateID = table.Column<int>(nullable: false),
                    SequenceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SequenceOpDate", x => new { x.SequenceSeqNum, x.OpDateID });
                    table.ForeignKey(
                        name: "FK_SequenceOpDate_OpDates_OpDateID",
                        column: x => x.OpDateID,
                        principalTable: "OpDates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SequenceOpDate_Sequences_SequenceID",
                        column: x => x.SequenceID,
                        principalTable: "Sequences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Legs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyPeriodID = table.Column<int>(nullable: false),
                    DPnum = table.Column<int>(nullable: false),
                    DayNumStart = table.Column<int>(nullable: false),
                    DayNumEnd = table.Column<int>(nullable: false),
                    EQP = table.Column<string>(nullable: true),
                    FLTnum = table.Column<int>(nullable: false),
                    DEPcity = table.Column<string>(nullable: true),
                    DEPlcl = table.Column<string>(nullable: true),
                    DEPhbt = table.Column<string>(nullable: true),
                    ARRcity = table.Column<string>(nullable: true),
                    ARRlcl = table.Column<string>(nullable: true),
                    ARRhbt = table.Column<string>(nullable: true),
                    LEGblock = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Legs_DutyPeriods_DutyPeriodID",
                        column: x => x.DutyPeriodID,
                        principalTable: "DutyPeriods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bases",
                columns: new[] { "ID", "BaseName" },
                values: new object[,]
                {
                    { 1, "BOS" },
                    { 13, "SLT" },
                    { 12, "SFO" },
                    { 11, "RDU" },
                    { 9, "PHL" },
                    { 8, "ORD" },
                    { 10, "PHX" },
                    { 6, "LGA" },
                    { 5, "LAX" },
                    { 4, "DFW" },
                    { 3, "DCA" },
                    { 2, "CLT" },
                    { 7, "MIA" }
                });

            migrationBuilder.InsertData(
                table: "OpDates",
                columns: new[] { "ID", "DateOp" },
                values: new object[,]
                {
                    { 23, 22 },
                    { 19, 18 },
                    { 20, 19 },
                    { 21, 20 },
                    { 22, 21 },
                    { 24, 23 },
                    { 31, 30 },
                    { 26, 25 },
                    { 27, 26 },
                    { 28, 29 },
                    { 29, 28 },
                    { 30, 29 },
                    { 18, 17 },
                    { 25, 24 },
                    { 17, 16 },
                    { 10, 9 },
                    { 15, 16 },
                    { 1, 31 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 16, 15 },
                    { 7, 6 },
                    { 9, 8 },
                    { 32, 31 },
                    { 11, 10 },
                    { 12, 11 },
                    { 13, 12 },
                    { 14, 13 },
                    { 8, 7 },
                    { 33, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DutyPeriods_SequenceID",
                table: "DutyPeriods",
                column: "SequenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Legs_DutyPeriodID",
                table: "Legs",
                column: "DutyPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_SequenceOpDate_OpDateID",
                table: "SequenceOpDate",
                column: "OpDateID");

            migrationBuilder.CreateIndex(
                name: "IX_SequenceOpDate_SequenceID",
                table: "SequenceOpDate",
                column: "SequenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Sequences_BaseID",
                table: "Sequences",
                column: "BaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Legs");

            migrationBuilder.DropTable(
                name: "SequenceOpDate");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DutyPeriods");

            migrationBuilder.DropTable(
                name: "OpDates");

            migrationBuilder.DropTable(
                name: "Sequences");

            migrationBuilder.DropTable(
                name: "Bases");
        }
    }
}
