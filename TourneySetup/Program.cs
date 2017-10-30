using LeagueManager.Data;
using LeagueManager.Data.Entities;
using System;

namespace TourneySetup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void CreateTeams()
        {
            var db = new ApplicationDbContext();

            db.Teams
                .AddRange(
                    new Team
                    {
                        Id = 1,
                        Name = "Chisago",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 2,
                        Name = "Foundation",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 3,
                        Name = "Grace-Mankato",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 4,
                        Name = "Fourth",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 5,
                        Name = "Heritage",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 6,
                        Name = "Lake Region",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 7,
                        Name = "Owatonna",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 8,
                        Name = "Prior Lake",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 9,
                        Name = "Rosemount",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 10,
                        Name = "St. Francis",
                        Level = TeamLevels.Varsity
                    },
                    new Team
                    {
                        Id = 12,
                        Name = "Woodcrest",
                        Level = TeamLevels.Varsity
                    });

            db.SaveChanges();
        }
    }
}
