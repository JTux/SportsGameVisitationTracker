namespace StadiumTracker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StadiumTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StadiumTracker.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            Guid publicGuid = new Guid("00000000-0000-0000-0000-000000000000");

            context.Leagues.AddOrUpdate(leagues => leagues.LeagueID,
                new LeagueEntity { LeagueID = 1, LeagueName = "American", OwnerID = publicGuid },
                new LeagueEntity { LeagueID = 2, LeagueName = "National", OwnerID = publicGuid }
            );

            context.Teams.AddOrUpdate(teams => teams.TeamID,
                new TeamEntity { TeamID = 1, TeamName = "Baltimore Orioles", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/52/thumbs/5258002019.gif" },
                new TeamEntity { TeamID = 2, TeamName = "Boston Red Sox", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/53/thumbs/c0whfsa9j0vbs079opk2s05lx.gif" },
                new TeamEntity { TeamID = 3, TeamName = "Chicago White Sox", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/55/thumbs/oxvkprv7v4inf5dgqdebp0yse.gif" },
                new TeamEntity { TeamID = 4, TeamName = "Cleveland Indians", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/57/thumbs/5753472014.gif" },
                new TeamEntity { TeamID = 5, TeamName = "Detroit Tigers", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/59/thumbs/5989642016.gif" },
                new TeamEntity { TeamID = 6, TeamName = "Houston Astros", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/4929/thumbs/492995032000.gif" },
                new TeamEntity { TeamID = 7, TeamName = "Kansas City Royals", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/62/thumbs/6283222019.gif" },
                new TeamEntity { TeamID = 8, TeamName = "Los Angeles Angels", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/6521/thumbs/652143892016.gif" },
                new TeamEntity { TeamID = 9, TeamName = "Minnesota Twins", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/65/thumbs/peii986yf4l42v3aa3hy0ovlf.gif" },
                new TeamEntity { TeamID = 10, TeamName = "New York Yankees", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/68/thumbs/1256.gif" },
                new TeamEntity { TeamID = 11, TeamName = "Oakland Athletics", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/69/thumbs/6xk2lpc36146pbg2kydf13e50.gif" },
                new TeamEntity { TeamID = 12, TeamName = "Seattle Mariners", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/75/thumbs/1305.gif" },
                new TeamEntity { TeamID = 13, TeamName = "Tampa Bay Rays", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/2535/thumbs/253594482019.gif" },
                new TeamEntity { TeamID = 14, TeamName = "Texas Rangers", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/77/thumbs/ajfeh4oqeealq37er15r3673h.gif" },
                new TeamEntity { TeamID = 15, TeamName = "Toronto Blue Jays", LeagueID = 1, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/53/78/thumbs/2559d7603ouedg7ldhw0br4fn.gif" },
                new TeamEntity { TeamID = 16, TeamName = "Arizona Diamondbacks", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/50/thumbs/gnnnrbxcmjhdgeu6mavqk3945.gif" },
                new TeamEntity { TeamID = 17, TeamName = "Atlanta Braves", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/51/thumbs/5171502018.gif" },
                new TeamEntity { TeamID = 18, TeamName = "Chicago Cubs", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/54/thumbs/q9gvs07u72gc9xr3395u6jh68.gif" },
                new TeamEntity { TeamID = 19, TeamName = "Cincinnati Reds", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/56/thumbs/z9e0rqit393ojiizsemd0t1hx.gif" },
                new TeamEntity { TeamID = 20, TeamName = "Colorado Rockies", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/58/thumbs/5868712017.gif" },
                new TeamEntity { TeamID = 21, TeamName = "Los Angeles Dodgers", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/63/thumbs/efvfv5b5g1zgpsf56gb04lthx.gif" },
                new TeamEntity { TeamID = 22, TeamName = "Miami Marlins", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/3637/thumbs/363775442019.gif" },
                new TeamEntity { TeamID = 23, TeamName = "Milwaukee Brewers", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/64/thumbs/6479972018.gif" },
                new TeamEntity { TeamID = 24, TeamName = "New York Mets", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/67/thumbs/m01gfgeorgvbfw15fy04alujm.gif" },
                new TeamEntity { TeamID = 25, TeamName = "Philadelphia Phillies", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/70/thumbs/7075792019.gif" },
                new TeamEntity { TeamID = 26, TeamName = "Pittsburgh Pirates", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/71/thumbs/7112502014.gif" },
                new TeamEntity { TeamID = 27, TeamName = "San Diego Padres", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/73/thumbs/7343442015.gif" },
                new TeamEntity { TeamID = 28, TeamName = "San Francisco Giants", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/74/thumbs/cpqj6up5bvgpoedg5fwsk20ve.gif" },
                new TeamEntity { TeamID = 29, TeamName = "St. Louis Cardinals", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/72/thumbs/3zhma0aeq17tktge1huh7yok5.gif" },
                new TeamEntity { TeamID = 30, TeamName = "Washington Nationals", LeagueID = 2, OwnerID = publicGuid, ImageData = "http://content.sportslogos.net/logos/54/578/thumbs/rcehah9k0kekjkgzm077fflws.gif" }
            );


            context.Stadiums.AddOrUpdate(stadiums => stadiums.StadiumID,
                new StadiumEntity { StadiumID = 1, StadiumName = "Oriole Park at Camden Yards", CityName = "Baltimore", StateName = "Maryland", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 2, StadiumName = "Fenway Park", CityName = "Boston", StateName = "Massachusetts", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 3, StadiumName = "Guaranteed Rate Field", CityName = "Chicago", StateName = "Illinois", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 4, StadiumName = "Progressive Field", CityName = "Cleveland", StateName = "Ohio", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 5, StadiumName = "Comerica Park", CityName = "Detroit", StateName = "Michigan", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 6, StadiumName = "Minute Maid Park", CityName = "Houston", StateName = "Texas", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 7, StadiumName = "Kauffman Stadium", CityName = "Kansas City", StateName = "Missouri", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 8, StadiumName = "Angel Stadium", CityName = "Anaheim", StateName = "California", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 9, StadiumName = "Target Field", CityName = "Minneapolis", StateName = "Minnesota", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 10, StadiumName = "Yankee Stadium", CityName = "Bronx", StateName = "New York", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 11, StadiumName = "Oakland Coliseum", CityName = "Oakland", StateName = "California", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 12, StadiumName = "T-Mobile Park", CityName = "Seattle", StateName = "Washington", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 13, StadiumName = "Tropicana Field", CityName = "St. Petersburg", StateName = "Florida", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 14, StadiumName = "Globe Life Park in Arlington", CityName = "Arlington", StateName = "Texas", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 15, StadiumName = "Rogers Centre", CityName = "Toronto", StateName = "Ontario", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 16, StadiumName = "Chase Field", CityName = "Phoenix", StateName = "Arizona", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 17, StadiumName = "SunTrust Park", CityName = "Atlanta", StateName = "Georgia", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 18, StadiumName = "Wrigley Field", CityName = "Chicago", StateName = "Illinois", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 19, StadiumName = "Great American Ball Park", CityName = "Cincinnati", StateName = "Ohio", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 20, StadiumName = "Coors Field", CityName = "Denver", StateName = "Colorado", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 21, StadiumName = "Dodger Stadium", CityName = "Los Angeles", StateName = "California", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 22, StadiumName = "Marlins Park", CityName = "Miami", StateName = "Florida", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 23, StadiumName = "Miller Park", CityName = "Milwaukee", StateName = "Wisconsin", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 24, StadiumName = "Citi Field", CityName = "Flushing", StateName = "New York", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 25, StadiumName = "Citizens Bank Park", CityName = "Philadelphia", StateName = "Pennsylvania", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 26, StadiumName = "PNC Park", CityName = "Pittsburgh", StateName = "Pennsylvania", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 27, StadiumName = "Petco Park", CityName = "San Diego", StateName = "California", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 28, StadiumName = "Oracle Park", CityName = "San Francisco", StateName = "California", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 29, StadiumName = "Busch Stadium", CityName = "St. Louis", StateName = "Missouri", OwnerID = publicGuid },
                new StadiumEntity { StadiumID = 30, StadiumName = "Nationals Park", CityName = "Washington", StateName = "DC", OwnerID = publicGuid }
            );
        }

    }
}
