using System.Collections.Generic;

namespace Acando.CodeCamp.Realtime.Data
{
    internal class DummyData
    {
        public static readonly List<ReportModel> Reports = new List<ReportModel>
        {
            new ReportModel
            {
                Id = "201530",
                Year = 2015,
                Week = 30,
                Approved = true,
                Projects = new []
                {
                    new ReportModel.Project
                    {
                        Name= "H&M dev",
                        Monday = 8,
                        Tuesday = 8,
                        Wednesday = 8,
                        Thursday = 8,
                        Friday = 8,
                        Saturday = 0,
                        Sunday = 0
                    },
                    new ReportModel.Project
                    {
                        Name= "Internal",
                        Monday = 0,
                        Tuesday = 0,
                        Wednesday = 0,
                        Thursday = 2,
                        Friday = 0,
                        Saturday = 0,
                        Sunday = 0
                    },
                }
            },
            new ReportModel
            {
                Id = "201531",
                Year = 2015,
                Week = 31,
                Approved = true,
                Projects = new []
                {
                    new ReportModel.Project
                    {
                        Name= "H&M dev",
                        Monday = 8,
                        Tuesday = 8,
                        Wednesday = 8,
                        Thursday = 8,
                        Friday = 7,
                        Saturday = 0,
                        Sunday = 0
                    },
                    new ReportModel.Project
                    {
                        Name= "Internal",
                        Monday = 0,
                        Tuesday = 0,
                        Wednesday = 0,
                        Thursday = 0,
                        Friday = 0,
                        Saturday = 0,
                        Sunday = 0
                    },
                }
            },
            new ReportModel
            {
                Id = "201532",
                Year = 2015,
                Week = 32,
                Approved = true,
                Projects = new []
                {
                    new ReportModel.Project
                    {
                        Name= "H&M dev",
                        Monday = 8,
                        Tuesday = 9,
                        Wednesday = 8,
                        Thursday = 8,
                        Friday = 8,
                        Saturday = 0,
                        Sunday = 0
                    },
                    new ReportModel.Project
                    {
                        Name= "Internal",
                        Monday = 0,
                        Tuesday = 0,
                        Wednesday = 0,
                        Thursday = 0,
                        Friday = 0,
                        Saturday = 0,
                        Sunday = 0
                    }
                }
            }
        };
    }
}
