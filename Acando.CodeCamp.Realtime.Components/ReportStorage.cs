using XSockets.Plugin.Framework.Attributes;

namespace Acando.CodeCamp.Realtime
{
    [Export(typeof(ReportStorage))]
    public class ReportStorage
    {
        public virtual ReportModel[] GetReports(string username)
        {
            return new[]
            {
                new ReportModel
                {
                    Year = 2015,
                    Week = 30,
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
}