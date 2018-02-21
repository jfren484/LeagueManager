using System.Collections.Generic;
using System.IO;
using System.Linq;
using LeagueManager.Data;
using LeagueManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TourneySetup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = Configure();

            //CreateTeams(db);
            //CreateFall2017SoccerTourney(db);
            //Create2018BoysBasketballTourney(db);
        }

        public static ApplicationDbContext Configure()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            var configuration = builder.Build();

            var services = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            return services.GetService<ApplicationDbContext>();
        }

        public static void CreateTeams(ApplicationDbContext db)
        {
            db.Teams
              .AddRange(new Team
                        {
                            Id = TeamIds.Chisago,
                            Name = "Chisago",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.Foundation,
                            Name = "Foundation",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.Fourth,
                            Name = "Fourth",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.GraceMankato,
                            Name = "Grace-Mankato",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.Heritage,
                            Name = "Heritage",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.LakeRegion,
                            Name = "Lake Region",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.Owatonna,
                            Name = "Owatonna",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.PriorLake,
                            Name = "Prior Lake",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.Rosemount,
                            Name = "Rosemount",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.StFrancis,
                            Name = "St. Francis",
                            Level = TeamLevels.Varsity
                        },
                        new Team
                        {
                            Id = TeamIds.Woodcrest,
                            Name = "Woodcrest",
                            Level = TeamLevels.Varsity
                        });

            db.SaveChanges();
        }

        public static void CreateFall2017SoccerTourney(ApplicationDbContext db)
        {
            var tournamentTeams = new List<TournamentTeam>
                                  {
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Woodcrest,
                                          Seed = 1
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Rosemount,
                                          Seed = 2
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Fourth,
                                          Seed = 3
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Chisago,
                                          Seed = 4
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.StFrancis,
                                          Seed = 5
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Owatonna,
                                          Seed = 6,
                                          TeamNameOverride = "OCS/Oakland"
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.LakeRegion,
                                          Seed = 7
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.PriorLake,
                                          Seed = 8
                                      }
                                  };

            var qf1Vs8 = new TournamentGame
                         {
                             Description = "Thurs. 1:30PM<br/>35 min",
                             Tag = "QF.1",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 1),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 8)
                         };
            var qf4Vs5 = new TournamentGame
                         {
                             Description = "Thurs. 10:00AM<br/>35 min",
                             Tag = "QF.2",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 4),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 5)
                         };
            var qf2Vs7 = new TournamentGame
                         {
                             Description = "Thurs. 11:45AM<br/>35 min",
                             Tag = "QF.3",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 2),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 7)
                         };
            var qf3Vs6 = new TournamentGame
                         {
                             Description = "Thurs. 3:15PM<br/>35 min",
                             Tag = "QF.4",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 3),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 6)
                         };

            var sf1Vs4 = new TournamentGame
                         {
                             Description = "Friday 4:00PM<br/>40 min",
                             Tag = "SF.1",
                             ParticipantAGameIsWinner = true,
                             ParticipantBGameIsWinner = true,
                             ParticipantATournamentGame = qf1Vs8,
                             ParticipantBTournamentGame = qf4Vs5
                         };
            var sf2Vs3 = new TournamentGame
                         {
                             Description = "Friday 2:00PM<br/>40 min",
                             Tag = "SF.2",
                             ParticipantAGameIsWinner = true,
                             ParticipantBGameIsWinner = true,
                             ParticipantATournamentGame = qf2Vs7,
                             ParticipantBTournamentGame = qf3Vs6
                         };

            var csf5Vs8 = new TournamentGame
                          {
                              Description = "Friday 9:00AM<br/>35 min",
                              Tag = "CSF.1",
                              ParticipantAGameIsWinner = false,
                              ParticipantBGameIsWinner = false,
                              ParticipantATournamentGame = qf1Vs8,
                              ParticipantBTournamentGame = qf4Vs5
                          };
            var csf6Vs7 = new TournamentGame
                          {
                              Description = "Friday 10:30AM<br/>35 min",
                              Tag = "CSF.2",
                              ParticipantAGameIsWinner = false,
                              ParticipantBGameIsWinner = false,
                              ParticipantATournamentGame = qf2Vs7,
                              ParticipantBTournamentGame = qf3Vs6
                          };

            var cf5Vs6 = new TournamentGame
                         {
                             Description = "Consolation<br/>Saturday<br/>9:30AM<br/>35 min",
                             ResultLabel = "Consolation<br />Winner",
                             Tag = "CF.1",
                             ParticipantAGameIsWinner = true,
                             ParticipantBGameIsWinner = true,
                             ParticipantATournamentGame = csf5Vs8,
                             ParticipantBTournamentGame = csf6Vs7
                         };
            var f1Vs2 = new TournamentGame
                        {
                            Description = "Championship<br/>Saturday<br/>1:00PM<br/>40 min",
                            ResultLabel = "2017 MACS<br />Champions",
                            Tag = "F.1",
                            ParticipantAGameIsWinner = true,
                            ParticipantBGameIsWinner = true,
                            ParticipantATournamentGame = sf1Vs4,
                            ParticipantBTournamentGame = sf2Vs3
                        };
            var f3Vs4 = new TournamentGame
                        {
                            Description = "Saturday<br/>11:15AM<br/>35 min",
                            ResultLabel = "Third Place",
                            Tag = "F.2",
                            ParticipantAGameIsWinner = false,
                            ParticipantBGameIsWinner = false,
                            ParticipantATournamentGame = sf1Vs4,
                            ParticipantBTournamentGame = sf2Vs3
                        };

            db.Tournaments
              .AddRange(new Tournament
                        {
                            Name = "2017 MACS Soccer Tournament",
                            Dates = "October 26-28, 2017",
                            TournamentTeams = tournamentTeams,
                            TournamentGames = new List<TournamentGame>
                                              {
                                                  qf1Vs8,
                                                  qf4Vs5,
                                                  qf2Vs7,
                                                  qf3Vs6,
                                                  sf1Vs4,
                                                  sf2Vs3,
                                                  csf5Vs8,
                                                  csf6Vs7,
                                                  cf5Vs6,
                                                  f3Vs4,
                                                  f1Vs2
                                              }
                        });

            db.SaveChanges();
        }

        public static void Create2018BoysBasketballTourney(ApplicationDbContext db)
        {
            var tournamentTeams = new List<TournamentTeam>
                                  {
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.StFrancis,
                                          Seed = 1
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Fourth,
                                          Seed = 2
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.LakeRegion,
                                          Seed = 3
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Foundation,
                                          Seed = 4
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Rosemount,
                                          Seed = 5
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.PriorLake,
                                          Seed = 6
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Chisago,
                                          Seed = 7
                                      },
                                      new TournamentTeam
                                      {
                                          TeamId = TeamIds.Woodcrest,
                                          Seed = 8
                                      }
                                  };

            var qf1Vs8 = new TournamentGame
                         {
                             Description = "Thursday<br />8:00 PM",
                             Tag = "QF.1",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 1),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 8)
                         };
            var qf4Vs5 = new TournamentGame
                         {
                             Description = "Thursday<br />5:00 PM",
                             Tag = "QF.2",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 4),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 5)
                         };
            var qf2Vs7 = new TournamentGame
                         {
                             Description = "Thursday<br />11:00 AM",
                             Tag = "QF.3",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 2),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 7)
                         };
            var qf3Vs6 = new TournamentGame
                         {
                             Description = "Thursday<br />2:00 PM",
                             Tag = "QF.4",
                             ParticipantATournamentTeam = tournamentTeams.Single(tt => tt.Seed == 3),
                             ParticipantBTournamentTeam = tournamentTeams.Single(tt => tt.Seed == 6)
                         };

            var sf1Vs4 = new TournamentGame
                         {
                             Description = "Friday<br />7:30 PM",
                             Tag = "SF.1",
                             ParticipantAGameIsWinner = true,
                             ParticipantBGameIsWinner = true,
                             ParticipantATournamentGame = qf1Vs8,
                             ParticipantBTournamentGame = qf4Vs5
                         };
            var sf2Vs3 = new TournamentGame
                         {
                             Description = "Friday<br />4:30 PM",
                             Tag = "SF.2",
                             ParticipantAGameIsWinner = true,
                             ParticipantBGameIsWinner = true,
                             ParticipantATournamentGame = qf2Vs7,
                             ParticipantBTournamentGame = qf3Vs6
                         };

            var csf5Vs8 = new TournamentGame
                          {
                              Description = "Friday<br />9:00 AM<br />(at Woodcrest)",
                              Tag = "CSF.1",
                              ParticipantAGameIsWinner = false,
                              ParticipantBGameIsWinner = false,
                              ParticipantATournamentGame = qf1Vs8,
                              ParticipantBTournamentGame = qf4Vs5
                          };
            var csf6Vs7 = new TournamentGame
                          {
                              Description = "Friday<br />10:30 AM<br />(at Woodcrest)",
                              Tag = "CSF.2",
                              ParticipantAGameIsWinner = false,
                              ParticipantBGameIsWinner = false,
                              ParticipantATournamentGame = qf2Vs7,
                              ParticipantBTournamentGame = qf3Vs6
                          };

            var cf5Vs6 = new TournamentGame
                         {
                             Description = "Consolation<br/>Saturday<br />11:00 AM<br />(at Woodcrest)",
                             ResultLabel = "Consolation<br />Winner",
                             Tag = "CF.1",
                             ParticipantAGameIsWinner = true,
                             ParticipantBGameIsWinner = true,
                             ParticipantATournamentGame = csf5Vs8,
                             ParticipantBTournamentGame = csf6Vs7
                         };
            var f1Vs2 = new TournamentGame
                        {
                            Description = "Championship<br />Saturday<br />2:30 PM",
                            ResultLabel = "2018 MACS<br />Champions",
                            Tag = "F.1",
                            ParticipantAGameIsWinner = true,
                            ParticipantBGameIsWinner = true,
                            ParticipantATournamentGame = sf1Vs4,
                            ParticipantBTournamentGame = sf2Vs3
                        };
            var f3Vs4 = new TournamentGame
                        {
                            Description = "Third Place<br />Saturday<br />11:30 AM",
                            ResultLabel = "Third Place",
                            Tag = "F.2",
                            ParticipantAGameIsWinner = false,
                            ParticipantBGameIsWinner = false,
                            ParticipantATournamentGame = sf1Vs4,
                            ParticipantBTournamentGame = sf2Vs3
                        };

            db.Tournaments
              .AddRange(new Tournament
                        {
                            Name = "2018 MACS Boys Basketball Tournament",
                            Dates = "February 22-24, 2018",
                            TournamentTeams = tournamentTeams,
                            TournamentGames = new List<TournamentGame>
                                              {
                                                  qf1Vs8,
                                                  qf4Vs5,
                                                  qf2Vs7,
                                                  qf3Vs6,
                                                  sf1Vs4,
                                                  sf2Vs3,
                                                  csf5Vs8,
                                                  csf6Vs7,
                                                  cf5Vs6,
                                                  f3Vs4,
                                                  f1Vs2
                                              }
                        });

            db.SaveChanges();
        }
    }
}