namespace Acando.CodeCamp.Realtime
{
    public class ReportModel
    {
        public int Year { get; set; }

        public int Week { get; set; }

        public bool Approved { get; set; }

        public Project[] Projects { get; set; }

        public class Project
        {
            public string Name { get; set; }

            public int Monday { get; set; }

            public int Tuesday { get; set; }

            public int Wednesday { get; set; }

            public int Thursday { get; set; }

            public int Friday { get; set; }

            public int Saturday { get; set; }

            public int Sunday { get; set; }
        }
    }
}