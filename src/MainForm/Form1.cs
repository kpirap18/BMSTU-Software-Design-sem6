using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DB;
using BL;
using Serilog;
using Microsoft.Extensions.Logging;

namespace DB_CP
{
    public partial class Form1 : Form
    {
        
        readonly ILogger<Form1> _logger;
        readonly AnalyticController _analytic;
        readonly ManagerController _manager;
        readonly ModeratorController _moderator;
        readonly UserController _userController;
        readonly BL.Userinfo _user;
        public Form1(ILogger<Form1> logger, BL.Userinfo currentUser, AnalyticController analytic, ManagerController manager, ModeratorController moderator, UserController userController)
        {
            _analytic = analytic;
            _manager = manager;
            _moderator = moderator;
            _userController = userController;
            _logger = logger;
            _user = currentUser;
            InitializeComponent();
            CheckPerms();
        }
        private void CheckPerms()
        {
            _logger.LogInformation("CheckPerms {String} at {dateTime}", this._user.Login, DateTime.UtcNow);
            UserLogin.Text = _user.Login;
            Password.Text = _user.Hash;
            Status.Text = _user.Id.ToString();
            if (_user.Permission == (int)Permissions.Analytic)
            {
                ManagerGroup.Enabled = false;
                ModeratorGroup.Enabled = false;
                Permission.Text = "Аналитик";
                _logger.LogInformation("CheckPerms {String} at {dateTime} Аналитик", this._user.Login, DateTime.UtcNow);
            }
            else if (_user.Permission == (int)Permissions.Manager)
            {
                AnalyticGroup.Enabled = false;
                ModeratorGroup.Enabled = false;
                Permission.Text = "Менеджер";
                _logger.LogInformation("CheckPerms {String} at {dateTime} Менеджер", this._user.Login, DateTime.UtcNow);
            }
            else
            {
                AnalyticGroup.Enabled = false;
                ManagerGroup.Enabled = false;
                Permission.Text = "Модератор";
                _logger.LogInformation("CheckPerms {String} at {dateTime} Модератор", this._user.Login, DateTime.UtcNow);
            }
        }
        private void AddColumnsHotel()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("HotelID", "ID команды");
            dataGridView1.Columns.Add("ManagamanetID", "ID менеджемнта");
            dataGridView1.Columns.Add("Name", "Имя отеля");;
            dataGridView1.Columns.Add("Country", "Страна");
            dataGridView1.Columns.Add("Cost", "Стоимость");
            dataGridView1.Columns.Add("Stars", "Категория");
        }
        private void AddColumnsStatistic()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("StatisticsId", "ID статистики");
            dataGridView1.Columns.Add("Numberoftrips", "Количество туров");
            dataGridView1.Columns.Add("Averagerating", "Средная оценка");
        }
        private void AddColumnsVisitor()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("VisitorId", "ID игрока");
            dataGridView1.Columns.Add("HotelId", "ID отеля");
            dataGridView1.Columns.Add("Statistics", "ID статистики");
            dataGridView1.Columns.Add("Name", "Имя посетителя");
            dataGridView1.Columns.Add("Age", "Возраст");
            dataGridView1.Columns.Add("Country", "Страна");
            dataGridView1.Columns.Add("Budget", "Бюджет");
        }
        private void AddColumnsInterestVisitor()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "ID интересующего посетителя");
            dataGridView1.Columns.Add("VisitorId", "ID посетителя");
            dataGridView1.Columns.Add("HotelId", "ID отеля");
            dataGridView1.Columns.Add("ManagementID", "ID менеджемнта");
        }
        private void AddColumnsAvailableDeal()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Id", "ID доступной сделки");
            dataGridView1.Columns.Add("VisitorID", "ID посетителя");
            dataGridView1.Columns.Add("ToManagementId", "Какому менеджменту");
            dataGridView1.Columns.Add("FromManagementId", "От какого менеджмента");
            dataGridView1.Columns.Add("Cost", "Цена");
            dataGridView1.Columns.Add("Status", "Статус");
        }
        private void AddColumnsVisitorHotelStat()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("visitorid", "ID посетителя");
            dataGridView1.Columns.Add("visitor", "Имя посетителя");
            dataGridView1.Columns.Add("Hotel", "Отель посетителя");
            dataGridView1.Columns.Add("starts", "Количество звезд");
        }
        private void AddColumnsUserInfo()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "ID Пользователя");
            dataGridView1.Columns.Add("login", "Логин пользователя");
            dataGridView1.Columns.Add("hash", "Пароль пользователя");
            dataGridView1.Columns.Add("permission", "Разрешение");
        }
        private void Close(object sender, EventArgs e)
        {
            Serilog.Log.CloseAndFlush();
            Application.Exit();
        }
        private void GetAllVisitors_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("GetAllVisitors_Click {String} at {dateTime}", this._user.Login, DateTime.UtcNow);
            Console.WriteLine("kkkkkkk");
            AddColumnsVisitor();
            List<BL.Visitor> visitors = _userController.GetAllVisitors();
            if (visitors != null)
            {
                foreach (BL.Visitor visitor in visitors)
                {
                    dataGridView1.Rows.Add(visitor.VisitorID, visitor.HotelID, visitor.Statistics, visitor.Name,
                         visitor.Age, visitor.Country, visitor.Budget);
                }
            }
            else
            {
                MessageBox.Show("Посетители не найдены");
                _logger.LogWarning("GetAllVisitors_Click {String} at {dateTime} Посетители не найдены ", this._user.Login, DateTime.UtcNow);
            }

            
        }
        private void GetVisitorByID_Click(object sender, EventArgs e)
        {
            if (VisitorIDBox.Text != "")
            {
                AddColumnsVisitor();
                BL.Visitor visitor = _userController.FindVisitorByID(Convert.ToInt32(VisitorIDBox.Text));
                if (visitor != null)
                {
                    dataGridView1.Rows.Add(visitor.VisitorID, visitor.HotelID, visitor.Statistics, visitor.Name,
                         visitor.Age, visitor.Country, visitor.Budget);
                }
                else
                {
                    MessageBox.Show("Посетитель не найден");
                    _logger.LogWarning("GetVisitorByID_Click {String} at {dateTime} Посетитель не найден", this._user.Login, DateTime.UtcNow);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели Id Посетителя");
                _logger.LogError("GetVisitorByID_Click {String} at {dateTime} Вы не ввели Id Посетителя", this._user.Login, DateTime.UtcNow);
            }
        }
        private void GetHotelByIDForVisitors_Click(object sender, EventArgs e)
        {
            if (HotelIDBoxForVisitor.Text != "")
            {
                AddColumnsVisitor();
                List<BL.Visitor> visitors = _userController.GetVisitorsByHotel(Convert.ToInt32(HotelIDBoxForVisitor.Text));
                if (visitors != null)
                {
                    foreach (BL.Visitor visitor in visitors)
                    {
                        dataGridView1.Rows.Add(visitor.VisitorID, visitor.HotelID, visitor.Statistics, visitor.Name,
                         visitor.Age, visitor.Country, visitor.Budget);
                    }
                }
                else
                {
                    MessageBox.Show("Посетители не найдены");
                    _logger.LogWarning("GetHotelByIDForVisitors_Click {String} at {dateTime} Посетитель не найден", this._user.Login, DateTime.UtcNow);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели Id отеля");
                _logger.LogError("GetHotelByIDForVisitors_Click {String} at {dateTime} Вы не ввели Id Посетителя", this._user.Login, DateTime.UtcNow);
            }
        }
        private void GetVisitorsByName_Click(object sender, EventArgs e)
        {
            if (VisitorName.Text != "")
            {
                AddColumnsVisitor();
                BL.Visitor visitor = _userController.FindVisitorByName(VisitorName.Text);
                if (visitor != null)
                {
                    dataGridView1.Rows.Add(visitor.VisitorID, visitor.HotelID, visitor.Statistics, visitor.Name,
                         visitor.Age, visitor.Country, visitor.Budget);
                }
                else
                {
                    MessageBox.Show("Посетители не найден");
                    _logger.LogWarning("GetVisitorsByName_Click {String} at {dateTime} Посетитель не найден", this._user.Login, DateTime.UtcNow);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели Name посетителя");
                _logger.LogError("GetVisitorsByName_Click {String} at {dateTime} Вы не ввели Id Посетителя", this._user.Login, DateTime.UtcNow);
            }
        }
        private void GetAllHotels_Click(object sender, EventArgs e)
        {
            AddColumnsHotel();
            List<BL.Hotel> hotels = _userController.GetAllHotels();
            if (hotels != null)
            {
                foreach (BL.Hotel hotel in hotels)
                {
                    dataGridView1.Rows.Add(hotel.HotelID, hotel.Managementid, hotel.Name, hotel.Country, hotel.Cost, hotel.Stars);
                }
            }
            else
            {
                MessageBox.Show("Отели не найдены");
                _logger.LogWarning("GetAllHotels_Click {String} at {dateTime} Отели не найдены", this._user.Login, DateTime.UtcNow);
            }
        }
        private void GetHotelByID_Click(object sender, EventArgs e)
        {
            if (HotelID.Text != "")
            {
                AddColumnsHotel();
                BL.Hotel hotel = _userController.FindHotelByID(Convert.ToInt32(HotelID.Text));
                if (hotel != null)
                {
                    dataGridView1.Rows.Add(hotel.HotelID, hotel.Managementid, hotel.Name, hotel.Country, hotel.Cost, hotel.Stars);
                }
                else
                {
                    MessageBox.Show("Отель не найден");
                    _logger.LogWarning("GetHotelByID_Click {String} at {dateTime} Отели не найдены", this._user.Login, DateTime.UtcNow);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели Id отеля");
                _logger.LogError("GetHotelByID_Click {String} at {dateTime} Вы не ввели Id отеля", this._user.Login, DateTime.UtcNow);
            }
        }
        private void GetHotelByName_Click(object sender, EventArgs e)
        {
            if (HotelName.Text != "")
            {
                AddColumnsHotel();
                BL.Hotel hotel = _userController.FindHotelByName(HotelName.Text);
                if (hotel != null)
                {
                    dataGridView1.Rows.Add(hotel.HotelID, hotel.Managementid, hotel.Name, hotel.Country, hotel.Cost, hotel.Stars);
                }
                else
                {
                    MessageBox.Show("Отель не найден");
                    _logger.LogWarning("GetHotelByName_Click {String} at {dateTime} Отель не найден", this._user.Login, DateTime.UtcNow);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели Name отеля");
                _logger.LogError("GetHotelByName_Click {String} at {dateTime} Вы не ввели Name отеля", this._user.Login, DateTime.UtcNow);
            }
        }
        private void GetStatisticsByID_Click(object sender, EventArgs e)
        {
            if (StatisticsID.Text != "")
            {
                AddColumnsStatistic();
                BL.Statistic stat = _userController.GetVisitorStatistic(Convert.ToInt32(StatisticsID.Text));
                if (stat != null)
                {
                    dataGridView1.Rows.Add(stat.Statisticsid, stat.NumberOfTrips, stat.AverageRating);
                }
                else
                {
                    MessageBox.Show("Статистика не найдена");
                    _logger.LogWarning("GetStatisticsByID_Click {String} at {dateTime} Статистика не найдена", this._user.Login, DateTime.UtcNow);

                }
            }
            else
            {
                MessageBox.Show("Вы не ввели Id статистики");
                _logger.LogError("GetStatisticsByID_Click {String} at {dateTime} Вы не ввели Id статистики", this._user.Login, DateTime.UtcNow);

            }
        }
        private void GetAllInterestVisitors_Click(object sender, EventArgs e)
        {
            AddColumnsInterestVisitor();
            List<BL.InterestVisitor> visitors = _analytic.GetAllInterstVisitors();
            if (visitors != null)
            {
                foreach (BL.InterestVisitor visitor in visitors)
                {
                    dataGridView1.Rows.Add(visitor.Id, visitor.VisitorID, visitor.HotelID, visitor.Managementid);
                }
            }
            else
            {
                MessageBox.Show("Посетители не найдены");
                _logger.LogWarning("GetAllInterestVisitors_Click {String} at {dateTime} Посетители не найдены", this._user.Login, DateTime.UtcNow);

            }
        }
        private void AddInterestVisitor_Click(object sender, EventArgs e)
        {
            if (VisitorIDForInterest.Text == "")
            {
                MessageBox.Show("Не указан ID");
                _logger.LogError("AddInterestVisitor_Click {String} at {dateTime} Не указан ID", this._user.Login, DateTime.UtcNow);
                return;
            }
            if (_analytic.AddInterestVisitor(Convert.ToInt32(VisitorIDForInterest.Text)) == false)
            {
                MessageBox.Show("Не удалось добавить посетителя");
                _logger.LogWarning("AddInterestVisitor_Click {String} at {dateTime} Не удалось добавить посетителя", this._user.Login, DateTime.UtcNow);
                return;
            }
            GetAllInterestVisitors_Click(sender, e);
        }
        private void DeleteInterestVisitor_Click(object sender, EventArgs e)
        {
            if (InterestVisitorID.Text == "")
            {
                MessageBox.Show("Не указан ID");
                _logger.LogError("DeleteInterestVisitor_Click {String} at {dateTime} Не указан ID", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (_analytic.DeleteInterestVisitor(Convert.ToInt32(InterestVisitorID.Text)) == false)
            {
                MessageBox.Show("Не удалось удалить посетителя");
                _logger.LogWarning("DeleteInterestVisitor_Click {String} at {dateTime} Не удалось удалить посетителя", this._user.Login, DateTime.UtcNow);

                return;
            }
            GetAllInterestVisitors_Click(sender, e);
        }
        private void RequestVisitor_Click(object sender, EventArgs e)
        {
            if (VisitorIDForManager.Text == "")
            {
                MessageBox.Show("Не указан ID");
                _logger.LogError("RequestVisitor_Click {String} at {dateTime} Не указан ID", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (CostForManager.Text == "")
            {
                MessageBox.Show("Не указана цена");
                _logger.LogWarning("RequestVisitor_Click {String} at {dateTime} Не указана цена", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (_manager.RequestVisitor(Convert.ToInt32(VisitorIDForManager.Text), Convert.ToInt32(CostForManager.Text)) == false) 
            {
                MessageBox.Show("Не удалось предложить посетителя");
                _logger.LogWarning("RequestVisitor_Click {String} at {dateTime} Не удалось предложить посетителя", this._user.Login, DateTime.UtcNow);

                return;
            }
        }
        private void ConfirmDeal_Click(object sender, EventArgs e)
        {
            if (DealID.Text == "")
            {
                MessageBox.Show("Не указан ID сделки");
                _logger.LogError("ConfirmDeal_Click {String} at {dateTime} Не указан ID сделки", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (_manager.ConfirmDeal(Convert.ToInt32(DealID.Text)) == false)
            {
                MessageBox.Show("Не удалось подтвердить сделку");
                _logger.LogWarning("ConfirmDeal_Click {String} at {dateTime} Не удалось подтвердить сделку", this._user.Login, DateTime.UtcNow);

                return;
            }
            else
            {
                MessageBox.Show("Сделка подтверждена");
                _logger.LogWarning("ConfirmDeal_Click {String} at {dateTime} Сделка подтверждена", this._user.Login, DateTime.UtcNow);

            }
        }
        private void RejectDeal_Click(object sender, EventArgs e)
        {
            if (DealID.Text == "")
            {
                MessageBox.Show("Не указан ID сделки");
                _logger.LogError("RejectDeal_Click {String} at {dateTime} Не указан ID сделки", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (_manager.RejectDeal(Convert.ToInt32(DealID.Text)) == false)
            {
                MessageBox.Show("Не удалось отклонить сделку");
                _logger.LogWarning("RejectDeal_Click {String} at {dateTime} Не удалось отклонить сделку", this._user.Login, DateTime.UtcNow);

                return;
            }
        }
        private void GetIncoming_Click(object sender, EventArgs e)
        {
            AddColumnsAvailableDeal();
            List<BL.Availabledeal> deals = _manager.GetIncomingDeals();
            if (deals != null)
            {
                foreach (BL.Availabledeal deal in deals)
                {
                    dataGridView1.Rows.Add(deal.Id, deal.VisitorID, deal.Tomanagementid, deal.Frommanagementid, deal.Cost, deal.Status);
                }
            }   
            else
            {
                MessageBox.Show("Сделки не найдены");
                _logger.LogWarning("GetIncoming_Click {String} at {dateTime} Сделки не найдены", this._user.Login, DateTime.UtcNow);

            }
        }
        private void GetOutcoming_Click(object sender, EventArgs e)
        {
            AddColumnsAvailableDeal();
            List<BL.Availabledeal> deals = _manager.GetOutgoaingDeals();
            if (deals != null)
            {
                foreach (BL.Availabledeal deal in deals)
                {
                    dataGridView1.Rows.Add(deal.Id, deal.VisitorID, deal.Tomanagementid, deal.Frommanagementid, deal.Cost, deal.Status);
                }
            }
            else
            {
                MessageBox.Show("Сделки не найдены");
                _logger.LogWarning("GetOutcoming_Click {String} at {dateTime} Сделки не найдены", this._user.Login, DateTime.UtcNow);

            }
        }
        private void MakeDeal_Click(object sender, EventArgs e)
        {
            if (DealIDForModer.Text == "")
            {
                MessageBox.Show("Не указан ID сделки");
                _logger.LogError("MakeDeal_Click {String} at {dateTime} Не указан ID сделки", this._user.Login, DateTime.UtcNow);

            }
            else
            {
                if (!_moderator.MakeDeal(Convert.ToInt32(DealIDForModer.Text)))
                {
                    MessageBox.Show("Не удалось провести сделку");
                    _logger.LogWarning("MakeDeal_Click {String} at {dateTime} Не удалось провести сделку", this._user.Login, DateTime.UtcNow);

                }
                else
                {
                    MessageBox.Show("Сделка проведена");

                    _moderator.DeleteDeal(Convert.ToInt32(DealIDForModer.Text));
                    _logger.LogInformation("MakeDeal_Click {String} at {dateTime} Сделка проведена", this._user.Login, DateTime.UtcNow);

                }
            }
        }
        private void DeleteDeal_Click(object sender, EventArgs e)
        {
            if (DealIDForModer.Text == "")
            {
                MessageBox.Show("Не указан ID сделки");
                _logger.LogError("DeleteDeal_Click {String} at {dateTime} Не указан ID сделки", this._user.Login, DateTime.UtcNow);

            }
            else
            {
                if (!_moderator.DeleteDeal(Convert.ToInt32(DealIDForModer.Text)))
                {
                    MessageBox.Show("Не удалось удалить сделку");
                    _logger.LogWarning("DeleteDeal_Click {String} at {dateTime} Не удалось провести сделку", this._user.Login, DateTime.UtcNow);

                }
                else
                {
                    MessageBox.Show("Сделка удалена");
                    _logger.LogInformation("DeleteDeal_Click {String} at {dateTime} Сделка удалена", this._user.Login, DateTime.UtcNow);

                }
            }
        }
        private void GetAllDeals_Click(object sender, EventArgs e)
        {
            AddColumnsAvailableDeal();
            List<BL.Availabledeal> deals = _moderator.GetAllDeals();
            if (deals != null)
            {
                foreach (BL.Availabledeal deal in deals)
                {
                    dataGridView1.Rows.Add(deal.Id, deal.VisitorID, deal.Tomanagementid, deal.Frommanagementid, deal.Cost, deal.Status);
                }
            }
            else
            {
                MessageBox.Show("Сделки не найдены");
                _logger.LogWarning("GetAllDeals_Click {String} at {dateTime} Сделки не найдены", this._user.Login, DateTime.UtcNow);

            }
        }

        private void GetVisitorHotelStat_Click(object sender, EventArgs e)
        {
            AddColumnsVisitorHotelStat();
            List<BL.VisitorHotelStat> visitors = _userController.GetVisitorHotelStat();
            if (visitors != null)
            {
                foreach (BL.VisitorHotelStat visitor in visitors)
                {
                    dataGridView1.Rows.Add(visitor.visitorid, visitor.visitor, visitor.hotel, visitor.stars);
                }
            }
            else
            {
                MessageBox.Show("Посетители не найдены");
                _logger.LogWarning("GetVisitorHotelStat_Click {String} at {dateTime} Посетители не найдены", this._user.Login, DateTime.UtcNow);

            }
        }

        private void GetInterestVisitorsForManager_Click(object sender, EventArgs e)
        {
            AddColumnsInterestVisitor();
            List<BL.InterestVisitor> visitors = _manager.GetAllInterestVisitors();
            if (visitors != null)
            {
                foreach (BL.InterestVisitor visitor in visitors)
                {
                    dataGridView1.Rows.Add(visitor.Id, visitor.VisitorID, visitor.HotelID, visitor.Managementid);
                }
            }
            else
            {
                MessageBox.Show("Посетители не найдены");
                _logger.LogWarning("GetInterestVisitorsForManager_Click {String} at {dateTime} Посетители не найдены", this._user.Login, DateTime.UtcNow);

            }
        }

        private void DeleteDesVisitorManager_Click(object sender, EventArgs e)
        {
            if (InterestVisitorForManager.Text == "")
            {
                MessageBox.Show("Не указан ID");
                _logger.LogError("DeleteDesVisitorManager_Click {String} at {dateTime} Не указан ID", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (_manager.DeleteInterestVisitor(Convert.ToInt32(InterestVisitorForManager.Text)) == false)
            {
                MessageBox.Show("Не удалось удалить посетителя");
                _logger.LogWarning("DeleteDesVisitorManager_Click {String} at {dateTime} Не удалось удалить посетителя", this._user.Login, DateTime.UtcNow);

                return;
            }
            GetInterestVisitorsForManager_Click(sender, e);
        }

        private void GetAllUsers_Click(object sender, EventArgs e)
        {
            AddColumnsUserInfo();
            List<BL.Userinfo> users = _moderator.GetAllUsers();
            if (users != null)
            {
                foreach (BL.Userinfo user in users)
                {
                    dataGridView1.Rows.Add(user.Id, user.Login, user.Hash, user.Permission);
                }
            }
            else
            {
                MessageBox.Show("Пользователи не найдены");
                _logger.LogWarning("GetAllUsers_Click {String} at {dateTime} Пользователи не найдены", this._user.Login, DateTime.UtcNow);

            }
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                MessageBox.Show("Вы не ввели логин");
                _logger.LogError("AddNewUser_Click {String} at {dateTime} Вы не ввели логин", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (Hash.Text == "")
            {
                MessageBox.Show("Вы не ввели пароль");
                _logger.LogError("AddNewUser_Click {String} at {dateTime} Вы не ввели пароль", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (Perm.Text == "")
            {
                MessageBox.Show("Вы не ввели permissions");
                _logger.LogError("AddNewUser_Click {String} at {dateTime} Вы не ввели permissions", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (! _moderator.AddNewUser(Username.Text, Hash.Text, Convert.ToInt32(Perm.Text)))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
                _logger.LogWarning("AddNewUser_Click {String} at {dateTime} Пользователь с таким логином уже существует", this._user.Login, DateTime.UtcNow);

                return;
            }
            else
            {
                MessageBox.Show("Пользователь добавлен");
                _logger.LogInformation("AddNewUser_Click {String} at {dateTime} Пользователь добавлен", this._user.Login, DateTime.UtcNow);

            }
            GetAllUsers_Click(sender, e);
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (UserID.Text == "")
            {
                MessageBox.Show("Вы не ввели ID");
                _logger.LogError("DeleteUser_Click {String} at {dateTime} Вы не ввели ID", this._user.Login, DateTime.UtcNow);

                return;
            }
            if (_moderator.DeleteUser(Convert.ToInt32(UserID.Text)))
            {
                MessageBox.Show("Пользователь удален");

                GetAllUsers_Click(sender, e);
                _logger.LogInformation("DeleteUser_Click {String} at {dateTime} Пользователь удален", this._user.Login, DateTime.UtcNow);

                return;
            }
            MessageBox.Show("Пользователь не найден");
            _logger.LogWarning("DeleteUser_Click {String} at {dateTime} Пользователь не найден", this._user.Login, DateTime.UtcNow);


        }

        private void GetHotelByStars_Click(object sender, EventArgs e)
        {
            if (category.Text != "")
            {
                AddColumnsHotel();
                List<BL.Hotel> hotels = _userController.GetHotelByStars(Convert.ToInt32(category.Text));
                if (hotels != null)
                {
                    foreach (BL.Hotel hotel in hotels)
                    {
                        dataGridView1.Rows.Add(hotel.HotelID, hotel.Managementid, hotel.Name, hotel.Country, hotel.Cost, hotel.Stars);
                    }
                }
                else
                {
                    MessageBox.Show("Отель не найден");
                    _logger.LogWarning("GetHotelByID_Click {String} at {dateTime} Отели не найдены", this._user.Login, DateTime.UtcNow);
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели категорию");
                _logger.LogError("GetHotelByID_Click {String} at {dateTime} Вы не ввели Id отеля", this._user.Login, DateTime.UtcNow);
            }
        }

    }
}
