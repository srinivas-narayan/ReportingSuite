using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace SriReportSuite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Consultant",
                columns: table => new
                {
                    ConsultantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(nullable: true),
                    ForeName = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    SurName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.ConsultantID);
                });
            migrationBuilder.CreateTable(
                name: "Registrars",
                columns: table => new
                {
                    RegID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(nullable: true),
                    ForeName = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    SurName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrars", x => x.RegID);
                });
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleDesc = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
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
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    ClinicID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicPlace = table.Column<string>(nullable: false),
                    ClinicShortName = table.Column<string>(nullable: false),
                    ConsultantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.ClinicID);
                    table.ForeignKey(
                        name: "FK_Clinic_Consultant_ConsultantID",
                        column: x => x.ConsultantID,
                        principalTable: "Consultant",
                        principalColumn: "ConsultantID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ClinicClinicID = table.Column<int>(nullable: true),
                    ConsultantConsultantID = table.Column<int>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Dead = table.Column<bool>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    HospNum = table.Column<string>(nullable: true),
                    NHSNum = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Procedures = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Clinic_ClinicClinicID",
                        column: x => x.ClinicClinicID,
                        principalTable: "Clinic",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patient_Consultant_ConsultantConsultantID",
                        column: x => x.ConsultantConsultantID,
                        principalTable: "Consultant",
                        principalColumn: "ConsultantID",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Study",
                columns: table => new
                {
                    StudyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bronchosopy = table.Column<bool>(nullable: false),
                    CVP = table.Column<decimal>(nullable: false),
                    ConsultantID = table.Column<int>(nullable: false),
                    Contrast = table.Column<string>(nullable: true),
                    ContrastDose = table.Column<string>(nullable: true),
                    Echo = table.Column<string>(nullable: true),
                    Echocardiogram = table.Column<string>(nullable: true),
                    FiO2 = table.Column<decimal>(nullable: false),
                    Findings = table.Column<string>(nullable: true),
                    GA = table.Column<bool>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Indication = table.Column<string>(nullable: true),
                    LastUpdated = table.Column<byte[]>(nullable: true),
                    PatientID = table.Column<int>(nullable: false),
                    RegID = table.Column<int>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    Saturations = table.Column<int>(nullable: false),
                    ScanSummary = table.Column<string>(nullable: true),
                    StudyDate = table.Column<DateTime>(nullable: false),
                    StudyStatus = table.Column<string>(nullable: true),
                    StudyType = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Study", x => x.StudyID);
                    table.ForeignKey(
                        name: "FK_Study_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Study_Registrars_RegID",
                        column: x => x.RegID,
                        principalTable: "Registrars",
                        principalColumn: "RegID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Flow",
                columns: table => new
                {
                    FlowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ForwardFlow = table.Column<float>(nullable: false),
                    HeartRate = table.Column<int>(nullable: false),
                    ReverseFlow = table.Column<float>(nullable: false),
                    Structure = table.Column<string>(nullable: true),
                    StudyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flow", x => x.FlowID);
                    table.ForeignKey(
                        name: "FK_Flow_Study_StudyID",
                        column: x => x.StudyID,
                        principalTable: "Study",
                        principalColumn: "StudyID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Img = table.Column<byte[]>(nullable: true),
                    ImgDesc = table.Column<string>(nullable: true),
                    StudyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_Study_StudyID",
                        column: x => x.StudyID,
                        principalTable: "Study",
                        principalColumn: "StudyID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Measure = table.Column<string>(nullable: true),
                    MeasureSequence = table.Column<string>(nullable: true),
                    Strucuture = table.Column<string>(nullable: true),
                    StudyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementID);
                    table.ForeignKey(
                        name: "FK_Measurement_Study_StudyID",
                        column: x => x.StudyID,
                        principalTable: "Study",
                        principalColumn: "StudyID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Volume",
                columns: table => new
                {
                    VolumeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Chamber = table.Column<string>(nullable: true),
                    EDV = table.Column<float>(nullable: false),
                    ESV = table.Column<float>(nullable: false),
                    HeartRate = table.Column<int>(nullable: false),
                    StudyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volume", x => x.VolumeID);
                    table.ForeignKey(
                        name: "FK_Volume_Study_StudyID",
                        column: x => x.StudyID,
                        principalTable: "Study",
                        principalColumn: "StudyID",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("Flow");
            migrationBuilder.DropTable("Image");
            migrationBuilder.DropTable("Measurement");
            migrationBuilder.DropTable("Role");
            migrationBuilder.DropTable("Volume");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetUsers");
            migrationBuilder.DropTable("Study");
            migrationBuilder.DropTable("Patient");
            migrationBuilder.DropTable("Registrars");
            migrationBuilder.DropTable("Clinic");
            migrationBuilder.DropTable("Consultant");
        }
    }
}
