using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            AppDbContext ctxt = serviceProvider
                .GetRequiredService<AppDbContext>();
            ctxt.Database.EnsureCreated();

            if (!ctxt.Centers.Any())
            {
                ctxt.Centers.AddRange(Centers.Select(c => c.Value));
            }

            if(!ctxt.Requests.Any())
            {
                ctxt.AddRange
                    (
                    new DonationRequest
                    {
                        Description = "Micul Vasilica are nevoie urgent de sange"
                    ,
                        DateIssued = "10/07/2016",
                        Doctor = "Dr.Delia Theiss",
                        Pacient = "Vasilica Amaratu",
                        CenterName = "MedLife"
                    },

                    new DonationRequest
                    {
                        Description = "Micul Ionica are nevoie urgent de sange"
                    ,
                        DateIssued = "13/09/2016",
                        Doctor = "Dr.Delia Theiss",
                        Pacient = "Ionica Saracu",
                        CenterName = "MedLife"
                    },

                    new DonationRequest
                    {
                        Description = "Micul Gigel are nevoie urgent de sange"
                    ,
                        DateIssued = "20/11/2017",
                        Doctor = "Dr.Pioana",
                        Pacient = "Gigel Bolnavu",
                        CenterName = "Regina Maria"
                    },

                    new DonationRequest
                    {
                        Description = "Micutza Marianela are nevoie urgent de sange"
                    ,
                        DateIssued = "20/11/2017",
                        Doctor = "Dr.Pioana",
                        Pacient = "Marianela Prafu",
                        CenterName = "Regina Maria"
                    },

                    new DonationRequest
                    {
                        Description = "Micutza Evanghelina are nevoie urgent de sange"
                    ,
                        DateIssued = "20/11/2017",
                        Doctor = "Dr.Pioana",
                        Pacient = "Evanghelina Sulemenitu",
                        CenterName = "Regina Maria"
                    }
                    );
            }

            ctxt.SaveChanges();
        }   

        private static Dictionary<string, DonationCenter> centers;
        public static Dictionary<string, DonationCenter> Centers
        {
            get
            {
                if(centers == null)
                {
                    var centersList = new DonationCenter[]
                    {
                        new DonationCenter{Name="Regina Maria"},
                        new DonationCenter{Name="MedLife"}
                    };

                    centers = new Dictionary<string, DonationCenter>();

                    foreach(DonationCenter center in centersList)
                    {
                        centers.Add(center.Name, center);
                    }
                }

                return centers;
            }
        }
    }
}
