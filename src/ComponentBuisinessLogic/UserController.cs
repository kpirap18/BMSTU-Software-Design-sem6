using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class UserController
    {
        protected IPlayerRepository playerRepository;
        protected ITeamRepository teamRepository;
        protected IDesiredPlayersRepository desiredPlayers;
        protected IStatisticsRepository statisticsRepository;
        protected IManagementRepository managementRepository;
        protected IFunctionsRepository functionsRepository;
        protected Userinfo _user;
        protected ILogger<UserController> _logger;
        public UserController(Userinfo user, ILogger<UserController> logger, IFunctionsRepository funcRep, IPlayerRepository playerRep, ITeamRepository teamRep, IManagementRepository managementRep, IDesiredPlayersRepository desiredPlayerRep, IStatisticsRepository statRep)
        {
            playerRepository = playerRep;
            teamRepository = teamRep;
            desiredPlayers = desiredPlayerRep;
            statisticsRepository = statRep;
            managementRepository = managementRep;
            functionsRepository = funcRep;
            _user = user;
            _logger = logger;
        }
        public List<Player> GetAllPlayers()
        {
            return playerRepository.GetAll();
        }
        public List<PlayersTeamStat> GetPlayerTeamStat()
        {
            return functionsRepository.GetPlayersTeamStat();
        }
        public List<Player> GetPlayersByTeam(int teamID)
        {
            Team team = teamRepository.FindTeamByID(teamID);
            return playerRepository.GetPlayersByTeam(team);
        }
        public Player FindPlayerByID(int id)
        {
            return playerRepository.FindPlayerByID(id);
        }
        public Player FindPlayerByName(string name)
        {
            return playerRepository.FindPlayerByName(name);
        }
        public List<Team> GetAllTeams()
        {
            return teamRepository.GetAll();
        }
        public Team FindTeamByID(int id)
        {
            return teamRepository.FindTeamByID(id);
        }
        public Team FindTeamByName(string name)
        {
            return teamRepository.FindTeamByName(name);
        }
        public Statistic GetPlayerStatistic(int id)
        {
            return statisticsRepository.GetStatisticByID(id);
        }
    }
}
