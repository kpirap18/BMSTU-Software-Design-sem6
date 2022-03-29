using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class AnalyticController : UserController
    {
        public AnalyticController(Userinfo user, ILogger<UserController> logger, IFunctionsRepository funcRep, IPlayerRepository playerRep, ITeamRepository teamRep, IManagementRepository managementRep, IDesiredPlayersRepository desiredPlayerRep, IStatisticsRepository statRep) : 
            base(user, logger, funcRep, playerRep, teamRep, managementRep, desiredPlayerRep, statRep)
        {
        }
        public List<Desiredplayer> GetAllDesiredPlayers()
        {
            Management management = managementRepository.FindByAnalytic(_user.Id);
            return desiredPlayers.GetPlayersByManagement(management);
        }
        public bool AddDesiredPlayer(int playerID)
        {
            Player player = playerRepository.FindPlayerByID(playerID);
            if (player == null)
            {
                return false;
            }
            Management management = managementRepository.FindByAnalytic(_user.Id);
            if (management == null)
            {
                return false;
            }
            Desiredplayer newDesirePlayer = new Desiredplayer { Managementid = management.Managementid, Playerid = player.Playerid, Teamid = player.Teamid };
            desiredPlayers.Add(newDesirePlayer);
            return true;
        }
        public bool DeleteDesiredPlayer(int id)
        {
            Desiredplayer player = desiredPlayers.GetPlayerByID(id);
            if (player == null)
            {
                return false;
            }
            desiredPlayers.Delete(player);
            return true;
        }
    }
}
