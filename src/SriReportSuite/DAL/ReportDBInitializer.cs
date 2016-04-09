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
            if (!context.Consultants.Any())
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
                consultants.ForEach(c => context.Consultants.Add(c));
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
            if (!context.Registrars.Any())
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
                registrars.ForEach(r => context.Registrars.Add(r));
                context.SaveChanges();
            }
            if (!context.Clinics.Any())
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
                    new Clinic {ClinicPlace="ELCH", ClinicShortName="ELCH", ConsultantID=10 }
                };
                clinics.ForEach(c => context.Clinics.Add(c));
                context.SaveChanges();
            }
        }
    }
}
