using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class ModeratorController : UserController
    {
        IAvailableDealsRepository dealsRepository;
        IUserInfoRepository userInfoRepository;
        public ModeratorController(Userinfo user, ILogger<UserController> logger, IFunctionsRepository funcRep, IUserInfoRepository userRep, IAvailableDealsRepository dealsRep, IPlayerRepository playerRep, ITeamRepository teamRep, IManagementRepository managementRep, IDesiredPlayersRepository desiredPlayerRep, IStatisticsRepository statRep) :
            base(user, logger, funcRep, playerRep, teamRep, managementRep, desiredPlayerRep, statRep)
        {
            dealsRepository = dealsRep;
            userInfoRepository = userRep;
        }
        public bool MakeDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                _logger.LogError("Deal {Number} was not fount at {dateTime}", dealID, DateTime.UtcNow);
                return false;
            }
            Team newTeam = teamRepository.FindTeamByManagement((int)deal.Frommanagementid);
            if (newTeam == null)
            {
                _logger.LogError("New team was not fount by Tomanagementid {id} at {dateTime}", (int)deal.Tomanagementid, DateTime.UtcNow);
                return false;
            }
            Team lastTeam = teamRepository.FindTeamByManagement((int)deal.Tomanagementid);
            if (lastTeam == null)
            {
                _logger.LogError("Last team was not fount by Frommanagementid {id} at {dateTime}", (int)deal.Frommanagementid, DateTime.UtcNow);
                return false;
            }
            Player player = playerRepository.FindPlayerByID((int)deal.Playerid);
            if (player == null)
            {
                _logger.LogError("Player {Number} was not fount at {dateTime}", (int)deal.Playerid, DateTime.UtcNow);
                return false;
            }
            if (! CheckOportunityToBuy(deal.Cost, newTeam))
            {
                _logger.LogError("Deal cost {Number} is more than team balance at {dateTime}", deal.Cost, DateTime.UtcNow);
                return false;
            }
            UpdateTeamBalance(lastTeam, newTeam, deal.Cost);
            UpdatePlayerTeam(player, newTeam.Teamid);
            dealsRepository.Delete(deal);
            return true;
        }
        public bool DeleteDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                _logger.LogError("Deal {Number} was not fount at {dateTime}", dealID, DateTime.UtcNow);
                return false;
            }
            dealsRepository.Delete(deal);
            return true;
        }
        public void UpdatePlayerTeam(Player player, int team)
        {
            player.Teamid = team;
            playerRepository.Update(player);
        }
        private void UpdateTeamBalance(Team lastTeam, Team newTeam, int cost)
        {
            lastTeam.Balance += cost;
            newTeam.Balance -= cost;
            teamRepository.Update(lastTeam);
            teamRepository.Update(newTeam);
        }
        private bool CheckOportunityToBuy(int cost, Team team)
        {
            return cost < team.Balance;
        }
        public List<Availabledeal> GetAllDeals()
        {
            return dealsRepository.GetAll();
        }
        public bool AddNewUser(string login, string hash, int perms)
        {
            if (userInfoRepository.FindUserByLogin(login) != null)
            {
                return false;
            }
            Userinfo user = new Userinfo { Login = login, Hash = hash, Permission = perms };
            userInfoRepository.Add(user);
            return true;
        }
        public bool DeleteUser(int id)
        {
            Userinfo user = userInfoRepository.FindUserByID(id);
            if (user == null)
            {
                _logger.LogError("User {id} was not found at {dateTime}", id, DateTime.UtcNow);
                return false;
            }
            userInfoRepository.Delete(user);
            return true;
        }
        public List<Userinfo> GetAllUsers()
        {
            return userInfoRepository.GetAll();
        }
    }
}
