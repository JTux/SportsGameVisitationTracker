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

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Guid publicGuid = new Guid("00000000-0000-0000-0000-000000000000");

            context.Leagues.AddOrUpdate(leagues => leagues.LeagueID,
                new LeagueEntity { LeagueID = 1, LeagueName = "American", OwnerID = publicGuid },
                new LeagueEntity { LeagueID = 2, LeagueName = "National", OwnerID = publicGuid }
            );

            context.Teams.AddOrUpdate(teams => teams.TeamID,
                new TeamEntity { TeamID = 1, TeamName = "Baltimore Orioles", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 2, TeamName = "Boston Red Sox", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 3, TeamName = "Chicago White Sox", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 4, TeamName = "Cleveland Indians", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 5, TeamName = "Detroit Tigers", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 6, TeamName = "Houston Astros", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 7, TeamName = "Kansas City Royals", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 8, TeamName = "Los Angeles Angels", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 9, TeamName = "Minnesota Twins", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 10, TeamName = "New York Yankees", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 11, TeamName = "Oakland Athletics", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 12, TeamName = "Seattle Mariners", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 13, TeamName = "Tampa Bay Rays", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 14, TeamName = "Texas Rangers", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 15, TeamName = "Toronto Blue Jays", LeagueID = 1, OwnerID = publicGuid },
                new TeamEntity { TeamID = 16, TeamName = "Arizona Diamondbacks", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 17, TeamName = "Atlanta Braves", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 18, TeamName = "Chicago Cubs", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 19, TeamName = "Cincinnati Reds", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 20, TeamName = "Colorado Rockies", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 21, TeamName = "Los Angeles Dodgers", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 22, TeamName = "Miami Marlins", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 23, TeamName = "Milwaukee Brewers", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 24, TeamName = "New York Mets", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 25, TeamName = "Philadelphia Phillies", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 26, TeamName = "Pittsburgh Pirates", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 27, TeamName = "San Diego Padres", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 28, TeamName = "San Francisco Giants", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 29, TeamName = "St. Louis Cardinals", LeagueID = 2, OwnerID = publicGuid },
                new TeamEntity { TeamID = 30, TeamName = "Washington Nationals", LeagueID = 2, OwnerID = publicGuid }
            );

            context.Stadiums.AddOrUpdate(stadiums => stadiums.StadiumID,
                new StadiumEntity {StadiumID = 1, StadiumName = "Oriole Park at Camden Yards", CityName = "Baltimore", StateName = StateEnum.MARYLAND, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 2, StadiumName = "Fenway Park", CityName = "Boston", StateName = StateEnum.MASSACHUSETTS, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 3, StadiumName = "Guaranteed Rate Field", CityName = "Chicago", StateName = StateEnum.ILLINOIS, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 4, StadiumName = "Progressive Field", CityName = "Cleveland", StateName = StateEnum.OHIO, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 5, StadiumName = "Comerica Park", CityName = "Detroit", StateName = StateEnum.MICHIGAN, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 6, StadiumName = "Minute Maid Park", CityName = "Houston", StateName = StateEnum.TEXAS, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 7, StadiumName = "Kauffman Stadium", CityName = "Kansas City", StateName = StateEnum.MISSOURI, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 8, StadiumName = "Angel Stadium", CityName = "Anaheim", StateName = StateEnum.CALIFORNIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 9, StadiumName = "Target Field", CityName = "Minneapolis", StateName = StateEnum.MINNESOTA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 10, StadiumName = "Yankee Stadium", CityName = "Bronx", StateName = StateEnum.NEW_YORK, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 11, StadiumName = "Oakland Coliseum", CityName = "Oakland", StateName = StateEnum.CALIFORNIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 12, StadiumName = "T-Mobile Park", CityName = "Seattle", StateName = StateEnum.WASHINGTON, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 13, StadiumName = "Tropicana Field", CityName = "St. Petersburg", StateName = StateEnum.FLORIDA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 14, StadiumName = "Globe Life Park in Arlington", CityName = "Arlington", StateName = StateEnum.TEXAS, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 15, StadiumName = "Rogers Centre", CityName = "Toronto", StateName = StateEnum.ONTARIO, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 16, StadiumName = "Chase Field", CityName = "Phoenix", StateName = StateEnum.ARIZONA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 17, StadiumName = "SunTrust Park", CityName = "Atlanta", StateName = StateEnum.GEORGIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 18, StadiumName = "Wrigley Field", CityName = "Chicago", StateName = StateEnum.ILLINOIS, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 19, StadiumName = "Great American Ball Park", CityName = "Cincinnati", StateName = StateEnum.OHIO, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 20, StadiumName = "Coors Field", CityName = "Denver", StateName = StateEnum.COLORADO, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 21, StadiumName = "Dodger Stadium", CityName = "Los Angeles", StateName = StateEnum.CALIFORNIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 22, StadiumName = "Marlins Park", CityName = "Miami", StateName = StateEnum.FLORIDA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 23, StadiumName = "Miller Park", CityName = "Milwaukee", StateName = StateEnum.WISCONSIN, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 24, StadiumName = "Citi Field", CityName = "Flushing", StateName = StateEnum.NEW_YORK, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 25, StadiumName = "Citizens Bank Park", CityName = "Philadelphia", StateName = StateEnum.PENNSYLVANIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 26, StadiumName = "PNC Park", CityName = "Pittsburgh", StateName = StateEnum.PENNSYLVANIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 27, StadiumName = "Petco Park", CityName = "San Diego", StateName = StateEnum.CALIFORNIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 28, StadiumName = "Oracle Park", CityName = "San Francisco", StateName = StateEnum.CALIFORNIA, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 29, StadiumName = "Busch Stadium", CityName = "St. Louis", StateName = StateEnum.MISSOURI, OwnerID = publicGuid },
                new StadiumEntity {StadiumID = 30, StadiumName = "Nationals Park", CityName = "Washington", StateName = StateEnum.DC, OwnerID = publicGuid }
            );
        }
    }
}
