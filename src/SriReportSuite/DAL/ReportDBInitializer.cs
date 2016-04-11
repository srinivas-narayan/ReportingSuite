using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SriReportSuite.Models;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;


namespace SriReportSuite.DAL
{
    public static class ReportDBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Role.Any())
            {
                var roles = new List<Role>
                {
                    new Role { RoleDesc="ACHD Specialist"},
                    new Role { RoleDesc="Electrophysiologist"},
                    new Role { RoleDesc="Fetal Cardiologist"},
                    new Role { RoleDesc="Imaging Specialist - Echo"},
                    new Role { RoleDesc="Imaging Specialist - Echo and MRI"},
                    new Role { RoleDesc="Imaging Specialist - MRI"},
                    new Role { RoleDesc="Cardiac Interventionalist "},
                    new Role { RoleDesc="Peadiatrician with Expertise in Cardiology"},
                    new Role { RoleDesc="Paediatrician"},
                    new Role { RoleDesc="Other"}
                };
                roles.ForEach(r => context.Role.Add(r));
                context.SaveChanges();
            }
            if (!context.Consultant.Any())
            {
                var consultants = new List<Consultant>
                {
                    new Consultant {ForeName="Owen", SurName="Miller",Designation="Consultant Paediatric Cardiologist", RoleID=6 },
                    new Consultant {ForeName="John", SurName="Simpson",Designation="Consultant Paediatric Cardiologist", RoleID=4 },
                    new Consultant {ForeName="Marietta", SurName="Charakida",Designation="Consultant Paediatric Cardiologist", RoleID=4 },
                    new Consultant {ForeName="Jelena", SurName="Saundankar",Designation="Locum Consultant Paediatric Cardiologist", RoleID=4 },
                    new Consultant {ForeName="Shakeel", SurName="Qureshi",Designation="Consultant Paediatric Cardiologist", RoleID=4 },
                    new Consultant {ForeName="Gareth", SurName="Morgan",Designation="Consultant Paediatric Cardiologist", RoleID=4 },
                    new Consultant {ForeName="Thomas", SurName="Krasemann",Designation="Consultant Paediatric Cardiologist", RoleID=4 },
                    new Consultant {ForeName="Eric", SurName="Rosenthal",Designation="Consultant Paediatric Cardiologist", RoleID=2 },
                    new Consultant {ForeName="Vita", SurName="Zidere", Designation="Consultant Paediatric Cardiologist", RoleID=3 },
                    new Consultant {ForeName="Gurleen", SurName="Sharland",Designation="Consultant Paediatric Cardiologist", RoleID=3 }
                };
                consultants.ForEach(c => context.Consultant.Add(c));
                context.SaveChanges();
                var mriconsultants = new List<MRIConsultant>
                {
                    new MRIConsultant {ForeName="Aaron", SurName="Bell",Designation="Consultant Paediatric Cardiologist", RoleID=6 },
                    new MRIConsultant {ForeName="Isra", SurName="Valverde",Designation="Locum Consultant Paediatric Cardiologist", RoleID=6 },
                    new MRIConsultant {ForeName="Sujeev", SurName="Mathur",Designation="Consultant Paediatric Cardiologist", RoleID=5 },
                    new MRIConsultant {ForeName="Kuberan", SurName="Pushparajah",Designation="Consultant Paediatric Cardiologist", RoleID=5 },
                    new MRIConsultant {ForeName="Yaso", SurName="Emmanuel",Designation="ACHD Consultant", RoleID=6 },
                    new MRIConsultant {ForeName="Christopher", SurName="Kiesewetter",Designation="ACHD Consultant", RoleID=6 },
                    new MRIConsultant {ForeName="Alessandra", SurName="Frigiola",Designation="ACHD Consultant", RoleID=6 },
                };
                mriconsultants.ForEach(mc => context.MRIConsultant.Add(mc));
            }
            if (!context.Registrar.Any())
            {
                var registrars = new List<Registrar>
                {
                    new Registrar {ForeName="Srinivas", SurName="Ananth Narayan",Designation="Registrar Paediatric Cardiologist", RoleID=6 },
                    new Registrar {ForeName="Henry", SurName="Chubb",Designation="Registrar Paediatric Cardiologist", RoleID=4 },
                    new Registrar {ForeName="Hannah", SurName="Bellsham-Revell",Designation="Registrar Paediatric Cardiologist", RoleID=4 },
                    new Registrar {ForeName="David", SurName="Lloyd",Designation="Registrar Paediatric Cardiologist", RoleID=4 },
                    new Registrar {ForeName="Michael", SurName="Harris",Designation="Registrar Paediatric Cardiologist", RoleID=4 },
                    new Registrar {ForeName="Laura", SurName="Konta",Designation="Registrar Paediatric Cardiologist", RoleID=4 },
                    new Registrar {ForeName="Mari Nieves", SurName="Velasco",Designation="Registrar Paediatric Cardiologist", RoleID=4 },
                    new Registrar {ForeName="Jacobus", SurName="Brum",Designation="Registrar Paediatric Cardiologist", RoleID=2 },
                    new Registrar {ForeName="Silvia", SurName="Italiana", Designation="Registrar Paediatric Cardiologist", RoleID=3 },
                    new Registrar {ForeName="Valentina", SurName="Italiana",Designation="Registrar Paediatric Cardiologist", RoleID=3 }
                };
                registrars.ForEach(r => context.Registrar.Add(r));
                context.SaveChanges();
            }
            if (!context.Clinic.Any())
            {
                var clinics = new List<Clinic>
                {
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=1 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=2 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=3 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=4 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=5 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=6 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=7 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=8 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=9 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=10 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=11 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=12 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=13 },
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=14 },
                    new Clinic {ClinicPlace="STH", ClinicShortName="STH", ConsultantID=15 },
                    new Clinic {ClinicPlace="STH", ClinicShortName="STH", ConsultantID=16 },
                    new Clinic {ClinicPlace="STH", ClinicShortName="STH", ConsultantID=17 }
                };
                clinics.ForEach(c => context.Clinic.Add(c));
                context.SaveChanges();
            }
            if (!context.Patient.Any())
            {
                var patients = new List<Patient>
                {
                    new Patient {FirstName="Mossack", SurName="Fonseca", ConsultantID=1 , DOB=new DateTime(1999,01,01), Address="1 Sampige Road", City="London", PostCode="E14 5UJ", ClinicID=1, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020030Y", NHSNum="123 456 7890", Dead=false},
                    new Patient {FirstName="David", SurName="Cameron", ConsultantID=2, DOB=new DateTime(2000,01,01), Address="2 Sampige Road", City="London", PostCode="E14 6UJ", ClinicID=2, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020031Y", NHSNum="123 456 7891", Dead=false },
                    new Patient {FirstName="George", SurName="Fernandes", ConsultantID=3, DOB=new DateTime(2001,01,01), Address="3 Sampige Road", City="London", PostCode="E14 7UJ", ClinicID=3, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020032Y", NHSNum="123 456 7892", Dead=false},
                    new Patient {FirstName="Narendra", SurName="Modi", ConsultantID=4, DOB=new DateTime(2002,01,01), Address="4 Sampige Road", City="London", PostCode="D14 5UJ", ClinicID=4, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020033Y", NHSNum="123 456 7893",Dead=false },
                    new Patient {FirstName="Amitabh", SurName="Bachchan", ConsultantID=5 , DOB=new DateTime(2003,01,01), Address="5 Sampige Road", City="London", PostCode="F14 5UJ", ClinicID=5, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020034Y", NHSNum="123 456 7894",Dead=false},
                    new Patient {FirstName="Saurav", SurName="Ganguly", ConsultantID=6, DOB=new DateTime(2004,01,01), Address="6 Sampige Road", City="London", PostCode="G14 5UJ", ClinicID=6, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020035Y", NHSNum="123 456 7895", Dead=false},
                    new Patient {FirstName="Mahatma", SurName="Gandhi", ConsultantID=7 , DOB=new DateTime(2005,01,01), Address="7 Sampige Road", City="London", PostCode="H14 5UJ", ClinicID=7, Diagnosis="<p>VSD<p>", Procedures="<p>VSD Closure</p>", HospNum="10020036Y", NHSNum="123 456 7896",Dead=true}
                };
                patients.ForEach(p => context.Patient.Add(p));
                context.SaveChanges();
            }
            if (!context.Study.Any())
            {
                var studies = new List<Study>
                {
                    new Study   {   PatientID= 1,
                                    StudyDate= new DateTime(2007, 01,01),
                                    ReportDate= new DateTime(2007, 01,01),
                                    StudyStatus= 0,
                                    StudyType= 0,
                                    GA= true,
                                    Echo= "0",
                                    Bronchoscopy= false,
                                    Weight= 23.35M,
                                    Height= 165,
                                    CVP= 0,
                                    Saturations= 98,
                                    FiO2= 21,
                                    Indication= "Testing1",
                                    Contrast= "Dotarem",
                                    ContrastDose = "4.7",
                                    ScanSummary= "<p>This is a summary1<p>1",
                                    Findings= "<p>This is the findings</p>1",
                                    Summary= "<p>This is a summary<p>1",
                                    RegID= 1,
                                    ConsultantID= 4,
                                    MRIConsultantConsultantID= 15
                                 },
                    new Study {     PatientID= 2,
                                    StudyDate= new DateTime(2008, 3,23),
                                    ReportDate= new DateTime(2007, 3,31),
                                    StudyStatus= 0,
                                    StudyType= 0,
                                    GA= true,
                                    Echo= "1",
                                    Bronchoscopy= true,
                                    Weight= 34.56M,
                                    Height= 145,
                                    CVP= 0,
                                    Saturations= 98,
                                    FiO2= 21,
                                    Indication= "Testing1",
                                    Contrast= "Dotarem",
                                    ContrastDose = "3.8ml",
                                    ScanSummary= "<p>This is a summary1<p>1",
                                    Findings= "<p>This is the findings</p>1",
                                    Summary= "<p>This is a summary<p>1",
                                    RegID= 1,
                                    ConsultantID= 4,
                                    MRIConsultantConsultantID= 16
                    }
                };
                studies.ForEach(s => context.Study.Add(s));
                context.SaveChanges();
            }
            if (!context.Flow.Any())
            {
                var flows = new List<Flow>
                {
                    new Flow { StudyID=1, Structure="Aorta", ForwardFlow=45, ReverseFlow=0, HeartRate=65  },
                    new Flow { StudyID=1, Structure="PA", ForwardFlow=48, ReverseFlow=2, HeartRate=65  },
                    new Flow { StudyID=2, Structure="Aorta", ForwardFlow=65, ReverseFlow=10, HeartRate=70  },
                    new Flow { StudyID=2, Structure="Aorta", ForwardFlow=130, ReverseFlow=65, HeartRate=70 },
                };
                flows.ForEach(f => context.Flow.Add(f));
                context.SaveChanges();
            }
            if (!context.Measurement.Any())
            {
                var measurements = new List<Measurement>
                {
                    new Measurement { StudyID=1, Strucuture="Aortic Root", MeasureSequence="3D SSFP Dia", Measure="22 x 24" },
                    new Measurement { StudyID=1, Strucuture="Pulmonary artery", MeasureSequence="3D SSFP Dia", Measure="22 x 24"  },
                    new Measurement { StudyID=2, Strucuture="Aortic Root", MeasureSequence="3D SSFP Dia", Measure="26 x 27 x 2" },
                    new Measurement { StudyID=2, Strucuture="Pulmonary Artery", MeasureSequence="3D SSFP Dia", Measure="22 x 24" },
                };
                measurements.ForEach(m => context.Measurement.Add(m));
                context.SaveChanges();
            }
            if (!context.Volume.Any())
            {
                var volumes = new List<Volume>
                {
                    new Volume { StudyID=1,  Chamber="LV", EDV=105, ESV=60, HeartRate=65},
                    new Volume { StudyID=1, Chamber="RV", EDV=105, ESV=60, HeartRate=65  },
                    new Volume { StudyID=2, Chamber="LV", EDV=105, ESV=60, HeartRate=70 },
                    new Volume { StudyID=2, Chamber="RV", EDV=105, ESV=60, HeartRate=70 },
                };
                volumes.ForEach(v => context.Volume.Add(v));
                context.SaveChanges();
            }
        }
    }
}
