using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class ManagerController : UserController
    {
        IAvailableDealsRepository dealsRepository;
        public ManagerController(Userinfo user, ILogger<UserController> logger, IFunctionsRepository funcRep, IAvailableDealsRepository dealsRep, IPlayerRepository playerRep, ITeamRepository teamRep, IManagementRepository managementRep, IDesiredPlayersRepository desiredPlayerRep, IStatisticsRepository statRep) :
            base(user, logger, funcRep, playerRep, teamRep, managementRep, desiredPlayerRep, statRep)
        {
            dealsRepository = dealsRep;
        }
        public List<Desiredplayer> GetAllDesiredPlayers()
        {
            Management management = managementRepository.FindByManager(_user.Id);
            if (management != null)
            {
                return desiredPlayers.GetPlayersByManagement(management);
            }
            return null;
        }
        public bool RequestPlayer(int playerID, int cost)
        {
            Player player = playerRepository.FindPlayerByID(playerID);
            if (player == null)
            {
                return false;
            }
            Team team = teamRepository.FindTeamByPlayer(player);
            if (team == null)
            {
                return false;
            }
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null)
            {
                return false;
            }
            Availabledeal deal = new Availabledeal { Playerid = playerID, Tomanagementid = team.Managementid, Frommanagementid = management.Managementid, Cost = cost, Status = (int)Status.NotSeen };
            dealsRepository.Add(deal);
            return true;
        }
        public bool ConfirmDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                return false;
            }
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null || deal.Tomanagementid != management.Managementid)
            {
                return false;
            }
            Team team = teamRepository.FindTeamByManagement((int)management.Managementid);
            if (team == null)
            {
                return false;
            }
            if (deal.Cost > team.Balance)
            {
                return false;
            }
            dealsRepository.ConfirmDeal(deal);
            return true;
        }
        public bool RejectDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                return false;
            }
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null || deal.Tomanagementid != management.Managementid)
            {
                return false;
            }
            dealsRepository.RejectDeal(deal);
            return true;
        }
        public List<Availabledeal> GetIncomingDeals()
        {
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null)
            {
                return null;
            }
            return dealsRepository.GetIncomingDeals(management);
        }
        public List<Availabledeal> GetOutgoaingDeals()
        {
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null)
            {
                return null;
            }
            return dealsRepository.GetOutgoaingDeals(management);
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
