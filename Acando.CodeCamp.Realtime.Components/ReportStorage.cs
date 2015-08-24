using System.Collections.Generic;
using System.Linq;
using XSockets.Plugin.Framework.Attributes;

namespace Acando.CodeCamp.Realtime
{
    [Export(typeof(ReportStorage))]
    public class ReportStorage
    {
        #region Dummy data
        private static readonly List<ReportModel> Reports = new List<ReportModel>
        {
            new ReportModel
            {
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
        #endregion

        public virtual ReportModel[] GetReports(string username)
        {
            return Reports.ToArray();
        }

        public virtual void Upsert(ReportModel report)
        {
            int index = Reports.FindIndex(r => r.Year == report.Year && r.Week == report.Week);
            if (index < 0)
            {
                Reports.Add(report);
            }
            else
            {
                Reports[index] = report;
            }
        }
    }
}