using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using SriReportSuite.Models;

namespace SriReportSuite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160419154722_secondary")]
    partial class secondary
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("SriReportSuite.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("SriReportSuite.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClinicPlace")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ClinicShortName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 5);

                    b.Property<int>("ConsultantID");

                    b.HasKey("ClinicID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Consultant", b =>
                {
                    b.Property<int>("ConsultantID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Designation")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ForeName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("RoleID");

                    b.Property<string>("SurName")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("ConsultantID");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Consultant");
                });

            modelBuilder.Entity("SriReportSuite.Models.Flow", b =>
                {
                    b.Property<int>("FlowID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("ForwardFlow");

                    b.Property<int>("HeartRate");

                    b.Property<float>("ReverseFlow");

                    b.Property<string>("Structure");

                    b.Property<int>("StudyID");

                    b.HasKey("FlowID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Image", b =>
                {
                    b.Property<int>("ImageID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Img");

                    b.Property<string>("ImgDesc");

                    b.Property<int>("StudyID");

                    b.HasKey("ImageID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Measurement", b =>
                {
                    b.Property<int>("MeasurementID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Measure");

                    b.Property<string>("MeasureSequence");

                    b.Property<string>("Strucuture");

                    b.Property<int>("StudyID");

                    b.HasKey("MeasurementID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("ClinicClinicID");

                    b.Property<int?>("ConsultantConsultantID");

                    b.Property<DateTime>("DOB");

                    b.Property<bool>("Dead");

                    b.Property<string>("Diagnosis")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("HospNum")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("NHSNum")
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 15);

                    b.Property<string>("Procedures")
                        .HasAnnotation("MaxLength", 2000);

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("PatientID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Registrar", b =>
                {
                    b.Property<int>("RegID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Designation");

                    b.Property<string>("ForeName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("RoleID");

                    b.Property<string>("SurName")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("RegID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleDesc")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("RoleID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Study", b =>
                {
                    b.Property<int>("StudyID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Bronchoscopy");

                    b.Property<decimal>("CVP");

                    b.Property<int>("ClinicID");

                    b.Property<int>("ConsultantID");

                    b.Property<string>("Contrast");

                    b.Property<string>("ContrastDose");

                    b.Property<string>("Echo");

                    b.Property<int>("Echocardiogram");

                    b.Property<decimal>("FiO2");

                    b.Property<string>("Findings");

                    b.Property<bool>("GA");

                    b.Property<decimal>("Height");

                    b.Property<string>("Indication");

                    b.Property<byte[]>("LastUpdated")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("MRIConsultantConsultantID");

                    b.Property<int>("PatientID");

                    b.Property<int>("RegID");

                    b.Property<DateTime>("ReportDate");

                    b.Property<int>("Saturations");

                    b.Property<string>("ScanSummary");

                    b.Property<string>("StudyComment");

                    b.Property<DateTime>("StudyDate");

                    b.Property<int>("StudyStatus");

                    b.Property<int>("StudyType");

                    b.Property<string>("Summary");

                    b.Property<decimal>("Weight");

                    b.HasKey("StudyID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Volume", b =>
                {
                    b.Property<int>("VolumeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Chamber");

                    b.Property<float>("EDV");

                    b.Property<float>("ESV");

                    b.Property<int>("HeartRate");

                    b.Property<int>("StudyID");

                    b.HasKey("VolumeID");
                });

            modelBuilder.Entity("SriReportSuite.Models.MRIConsultant", b =>
                {
                    b.HasBaseType("SriReportSuite.Models.Consultant");


                    b.HasAnnotation("Relational:DiscriminatorValue", "MRIConsultant");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SriReportSuite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SriReportSuite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("SriReportSuite.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SriReportSuite.Models.Clinic", b =>
                {
                    b.HasOne("SriReportSuite.Models.Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Flow", b =>
                {
                    b.HasOne("SriReportSuite.Models.Study")
                        .WithMany()
                        .HasForeignKey("StudyID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Image", b =>
                {
                    b.HasOne("SriReportSuite.Models.Study")
                        .WithMany()
                        .HasForeignKey("StudyID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Measurement", b =>
                {
                    b.HasOne("SriReportSuite.Models.Study")
                        .WithMany()
                        .HasForeignKey("StudyID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Patient", b =>
                {
                    b.HasOne("SriReportSuite.Models.Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicClinicID");

                    b.HasOne("SriReportSuite.Models.Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantConsultantID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Study", b =>
                {
                    b.HasOne("SriReportSuite.Models.MRIConsultant")
                        .WithMany()
                        .HasForeignKey("MRIConsultantConsultantID");

                    b.HasOne("SriReportSuite.Models.Patient")
                        .WithMany()
                        .HasForeignKey("PatientID");

                    b.HasOne("SriReportSuite.Models.Registrar")
                        .WithMany()
                        .HasForeignKey("RegID");
                });

            modelBuilder.Entity("SriReportSuite.Models.Volume", b =>
                {
                    b.HasOne("SriReportSuite.Models.Study")
                        .WithMany()
                        .HasForeignKey("StudyID");
                });
        }
    }
}
