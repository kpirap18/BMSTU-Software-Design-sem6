
using System;
using System.Windows.Forms;

namespace DB_CP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.GetAllVisitors = new System.Windows.Forms.Button();
            this.UserBox = new System.Windows.Forms.GroupBox();
            this.StatisticsBox = new System.Windows.Forms.GroupBox();
            this.GetStatisticsByID = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.StatisticsID = new System.Windows.Forms.TextBox();
            this.Visitors = new System.Windows.Forms.GroupBox();
            this.GetVisitorHotelStat = new System.Windows.Forms.Button();
            this.GetVisitorsByName = new System.Windows.Forms.Button();
            this.VisitorName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GetVisitorByID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.VisitorIDBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.category = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.GetHotelByStars = new System.Windows.Forms.Button();
            this.GetHotelByName = new System.Windows.Forms.Button();
            this.GetHotelByID = new System.Windows.Forms.Button();
            this.GetAllHotels = new System.Windows.Forms.Button();
            this.HotelName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HotelID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HotelBoxForVisitors = new System.Windows.Forms.GroupBox();
            this.GetVisitorsByHotelID = new System.Windows.Forms.Button();
            this.HotelIDBoxForVisitor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AnalyticGroup = new System.Windows.Forms.GroupBox();
            this.DeleteInterestVisitor = new System.Windows.Forms.Button();
            this.InterestVisitorID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddInterestVisitor = new System.Windows.Forms.Button();
            this.GetAllInterestVisitors = new System.Windows.Forms.Button();
            this.VisitorIDForInterest = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ManagerGroup = new System.Windows.Forms.GroupBox();
            this.DeleteDesVisitorManager = new System.Windows.Forms.Button();
            this.InterestVisitorForManager = new System.Windows.Forms.TextBox();
            this.GetInterestVisitorsForManager = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.GetOutcoming = new System.Windows.Forms.Button();
            this.GetIncoming = new System.Windows.Forms.Button();
            this.RejectDeal = new System.Windows.Forms.Button();
            this.ConfirmDeal = new System.Windows.Forms.Button();
            this.DealID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RequestVisitor = new System.Windows.Forms.Button();
            this.CostForManager = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.VisitorIDForManager = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ModeratorGroup = new System.Windows.Forms.GroupBox();
            this.DeleteUser = new System.Windows.Forms.Button();
            this.UserID = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.AddNewUser = new System.Windows.Forms.Button();
            this.Perm = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.Hash = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.GetAllUsers = new System.Windows.Forms.Button();
            this.GetAllDeals = new System.Windows.Forms.Button();
            this.DeleteDeal = new System.Windows.Forms.Button();
            this.MakeDeal = new System.Windows.Forms.Button();
            this.DealIDForModer = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.UserLogin = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Permission = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.UserBox.SuspendLayout();
            this.StatisticsBox.SuspendLayout();
            this.Visitors.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.HotelBoxForVisitors.SuspendLayout();
            this.AnalyticGroup.SuspendLayout();
            this.ManagerGroup.SuspendLayout();
            this.ModeratorGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(227, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(802, 731);
            this.dataGridView1.TabIndex = 1;
            // 
            // GetAllVisitors
            // 
            this.GetAllVisitors.Location = new System.Drawing.Point(6, 22);
            this.GetAllVisitors.Name = "GetAllVisitors";
            this.GetAllVisitors.Size = new System.Drawing.Size(176, 24);
            this.GetAllVisitors.TabIndex = 2;
            this.GetAllVisitors.Text = "Просмотреть всех посетителей";
            this.GetAllVisitors.UseVisualStyleBackColor = true;
            this.GetAllVisitors.Click += new System.EventHandler(this.GetAllVisitors_Click);
            // 
            // UserBox
            // 
            this.UserBox.Controls.Add(this.StatisticsBox);
            this.UserBox.Controls.Add(this.Visitors);
            this.UserBox.Controls.Add(this.groupBox1);
            this.UserBox.Controls.Add(this.HotelBoxForVisitors);
            this.UserBox.Location = new System.Drawing.Point(12, 12);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(209, 731);
            this.UserBox.TabIndex = 3;
            this.UserBox.TabStop = false;
            this.UserBox.Text = "User";
            // 
            // StatisticsBox
            // 
            this.StatisticsBox.Controls.Add(this.GetStatisticsByID);
            this.StatisticsBox.Controls.Add(this.label6);
            this.StatisticsBox.Controls.Add(this.StatisticsID);
            this.StatisticsBox.Location = new System.Drawing.Point(6, 635);
            this.StatisticsBox.Name = "StatisticsBox";
            this.StatisticsBox.Size = new System.Drawing.Size(195, 89);
            this.StatisticsBox.TabIndex = 14;
            this.StatisticsBox.TabStop = false;
            this.StatisticsBox.Text = "Statistics";
            // 
            // GetStatisticsByID
            // 
            this.GetStatisticsByID.Location = new System.Drawing.Point(8, 51);
            this.GetStatisticsByID.Name = "GetStatisticsByID";
            this.GetStatisticsByID.Size = new System.Drawing.Size(175, 27);
            this.GetStatisticsByID.TabIndex = 11;
            this.GetStatisticsByID.Text = "Получить статистику ";
            this.GetStatisticsByID.UseVisualStyleBackColor = true;
            this.GetStatisticsByID.Click += new System.EventHandler(this.GetStatisticsByID_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Statistics ID";
            // 
            // StatisticsID
            // 
            this.StatisticsID.Location = new System.Drawing.Point(83, 22);
            this.StatisticsID.Name = "StatisticsID";
            this.StatisticsID.Size = new System.Drawing.Size(100, 23);
            this.StatisticsID.TabIndex = 11;
            // 
            // Visitors
            // 
            this.Visitors.Controls.Add(this.GetVisitorHotelStat);
            this.Visitors.Controls.Add(this.GetVisitorsByName);
            this.Visitors.Controls.Add(this.VisitorName);
            this.Visitors.Controls.Add(this.label2);
            this.Visitors.Controls.Add(this.GetVisitorByID);
            this.Visitors.Controls.Add(this.label3);
            this.Visitors.Controls.Add(this.VisitorIDBox);
            this.Visitors.Controls.Add(this.GetAllVisitors);
            this.Visitors.Location = new System.Drawing.Point(7, 22);
            this.Visitors.Name = "Visitors";
            this.Visitors.Size = new System.Drawing.Size(194, 241);
            this.Visitors.TabIndex = 13;
            this.Visitors.TabStop = false;
            this.Visitors.Text = "Visitor";
            // 
            // GetVisitorHotelStat
            // 
            this.GetVisitorHotelStat.Location = new System.Drawing.Point(6, 178);
            this.GetVisitorHotelStat.Name = "GetVisitorHotelStat";
            this.GetVisitorHotelStat.Size = new System.Drawing.Size(176, 47);
            this.GetVisitorHotelStat.TabIndex = 12;
            this.GetVisitorHotelStat.Text = "Получить посетителей, их отели и статистики";
            this.GetVisitorHotelStat.UseVisualStyleBackColor = true;
            this.GetVisitorHotelStat.Click += new System.EventHandler(this.GetVisitorHotelStat_Click);
            // 
            // GetVisitorsByName
            // 
            this.GetVisitorsByName.Location = new System.Drawing.Point(6, 146);
            this.GetVisitorsByName.Name = "GetVisitorsByName";
            this.GetVisitorsByName.Size = new System.Drawing.Size(176, 27);
            this.GetVisitorsByName.TabIndex = 10;
            this.GetVisitorsByName.Text = "Получить посетителей по Name";
            this.GetVisitorsByName.UseVisualStyleBackColor = true;
            this.GetVisitorsByName.Click += new System.EventHandler(this.GetVisitorsByName_Click);
            // 
            // VisitorName
            // 
            this.VisitorName.Location = new System.Drawing.Point(82, 117);
            this.VisitorName.Name = "VisitorName";
            this.VisitorName.Size = new System.Drawing.Size(100, 23);
            this.VisitorName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Visitor Name";
            // 
            // GetVisitorByID
            // 
            this.GetVisitorByID.Location = new System.Drawing.Point(6, 84);
            this.GetVisitorByID.Name = "GetVisitorByID";
            this.GetVisitorByID.Size = new System.Drawing.Size(176, 27);
            this.GetVisitorByID.TabIndex = 11;
            this.GetVisitorByID.Text = "Получить посетителя по ID";
            this.GetVisitorByID.UseVisualStyleBackColor = true;
            this.GetVisitorByID.Click += new System.EventHandler(this.GetVisitorByID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Visitor ID";
            // 
            // VisitorIDBox
            // 
            this.VisitorIDBox.Location = new System.Drawing.Point(82, 55);
            this.VisitorIDBox.Name = "VisitorIDBox";
            this.VisitorIDBox.Size = new System.Drawing.Size(100, 23);
            this.VisitorIDBox.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.category);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.GetHotelByStars);
            this.groupBox1.Controls.Add(this.GetHotelByName);
            this.groupBox1.Controls.Add(this.GetHotelByID);
            this.groupBox1.Controls.Add(this.GetAllHotels);
            this.groupBox1.Controls.Add(this.HotelName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.HotelID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(9, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 244);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotel";
            // 
            // category
            // 
            this.category.Location = new System.Drawing.Point(83, 179);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(100, 23);
            this.category.TabIndex = 15;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 176);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 15);
            this.label24.TabIndex = 14;
            this.label24.Text = "Category";
            // 
            // GetHotelByStars
            // 
            this.GetHotelByStars.Location = new System.Drawing.Point(8, 208);
            this.GetHotelByStars.Name = "GetHotelByStars";
            this.GetHotelByStars.Size = new System.Drawing.Size(176, 27);
            this.GetHotelByStars.TabIndex = 13;
            this.GetHotelByStars.Text = "Получить отель по Звезде";
            this.GetHotelByStars.UseVisualStyleBackColor = true;
            this.GetHotelByStars.Click += new System.EventHandler(this.GetHotelByStars_Click);
            // 
            // GetHotelByName
            // 
            this.GetHotelByName.Location = new System.Drawing.Point(6, 146);
            this.GetHotelByName.Name = "GetHotelByName";
            this.GetHotelByName.Size = new System.Drawing.Size(176, 27);
            this.GetHotelByName.TabIndex = 10;
            this.GetHotelByName.Text = "Получить отель по Name";
            this.GetHotelByName.UseVisualStyleBackColor = true;
            this.GetHotelByName.Click += new System.EventHandler(this.GetHotelByName_Click);
            // 
            // GetHotelByID
            // 
            this.GetHotelByID.Location = new System.Drawing.Point(6, 84);
            this.GetHotelByID.Name = "GetHotelByID";
            this.GetHotelByID.Size = new System.Drawing.Size(176, 27);
            this.GetHotelByID.TabIndex = 9;
            this.GetHotelByID.Text = "Получить отель по ID";
            this.GetHotelByID.UseVisualStyleBackColor = true;
            this.GetHotelByID.Click += new System.EventHandler(this.GetHotelByID_Click);
            // 
            // GetAllHotels
            // 
            this.GetAllHotels.Location = new System.Drawing.Point(7, 22);
            this.GetAllHotels.Name = "GetAllHotels";
            this.GetAllHotels.Size = new System.Drawing.Size(176, 24);
            this.GetAllHotels.TabIndex = 12;
            this.GetAllHotels.Text = "Просмотреть все отели";
            this.GetAllHotels.UseVisualStyleBackColor = true;
            this.GetAllHotels.Click += new System.EventHandler(this.GetAllHotels_Click);
            // 
            // HotelName
            // 
            this.HotelName.Location = new System.Drawing.Point(82, 117);
            this.HotelName.Name = "HotelName";
            this.HotelName.Size = new System.Drawing.Size(100, 23);
            this.HotelName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hotel Name";
            // 
            // HotelID
            // 
            this.HotelID.Location = new System.Drawing.Point(82, 55);
            this.HotelID.Name = "HotelID";
            this.HotelID.Size = new System.Drawing.Size(100, 23);
            this.HotelID.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hotel ID";
            // 
            // HotelBoxForVisitors
            // 
            this.HotelBoxForVisitors.Controls.Add(this.GetVisitorsByHotelID);
            this.HotelBoxForVisitors.Controls.Add(this.HotelIDBoxForVisitor);
            this.HotelBoxForVisitors.Controls.Add(this.label1);
            this.HotelBoxForVisitors.Location = new System.Drawing.Point(7, 269);
            this.HotelBoxForVisitors.Name = "HotelBoxForVisitors";
            this.HotelBoxForVisitors.Size = new System.Drawing.Size(194, 110);
            this.HotelBoxForVisitors.TabIndex = 5;
            this.HotelBoxForVisitors.TabStop = false;
            this.HotelBoxForVisitors.Text = "Find visitor by team";
            // 
            // GetVisitorsByHotelID
            // 
            this.GetVisitorsByHotelID.Location = new System.Drawing.Point(7, 49);
            this.GetVisitorsByHotelID.Name = "GetVisitorsByHotelID";
            this.GetVisitorsByHotelID.Size = new System.Drawing.Size(176, 55);
            this.GetVisitorsByHotelID.TabIndex = 9;
            this.GetVisitorsByHotelID.Text = "Получить посетитетелей по ID";
            this.GetVisitorsByHotelID.UseVisualStyleBackColor = true;
            this.GetVisitorsByHotelID.Click += new System.EventHandler(this.GetHotelByIDForVisitors_Click);
            // 
            // HotelIDBoxForVisitor
            // 
            this.HotelIDBoxForVisitor.Location = new System.Drawing.Point(83, 20);
            this.HotelIDBoxForVisitor.Name = "HotelIDBoxForVisitor";
            this.HotelIDBoxForVisitor.Size = new System.Drawing.Size(100, 23);
            this.HotelIDBoxForVisitor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel ID";
            // 
            // AnalyticGroup
            // 
            this.AnalyticGroup.Controls.Add(this.DeleteInterestVisitor);
            this.AnalyticGroup.Controls.Add(this.InterestVisitorID);
            this.AnalyticGroup.Controls.Add(this.label7);
            this.AnalyticGroup.Controls.Add(this.AddInterestVisitor);
            this.AnalyticGroup.Controls.Add(this.GetAllInterestVisitors);
            this.AnalyticGroup.Controls.Add(this.VisitorIDForInterest);
            this.AnalyticGroup.Controls.Add(this.label8);
            this.AnalyticGroup.Location = new System.Drawing.Point(1035, 12);
            this.AnalyticGroup.Name = "AnalyticGroup";
            this.AnalyticGroup.Size = new System.Drawing.Size(221, 179);
            this.AnalyticGroup.TabIndex = 13;
            this.AnalyticGroup.TabStop = false;
            this.AnalyticGroup.Text = "Analytic";
            // 
            // DeleteInterestVisitor
            // 
            this.DeleteInterestVisitor.Location = new System.Drawing.Point(7, 146);
            this.DeleteInterestVisitor.Name = "DeleteInterestVisitor";
            this.DeleteInterestVisitor.Size = new System.Drawing.Size(197, 27);
            this.DeleteInterestVisitor.TabIndex = 10;
            this.DeleteInterestVisitor.Text = "Удалить желаемого посетителя";
            this.DeleteInterestVisitor.UseVisualStyleBackColor = true;
            this.DeleteInterestVisitor.Click += new System.EventHandler(this.DeleteInterestVisitor_Click);
            // 
            // InterestVisitorID
            // 
            this.InterestVisitorID.Location = new System.Drawing.Point(104, 117);
            this.InterestVisitorID.Name = "InterestVisitorID";
            this.InterestVisitorID.Size = new System.Drawing.Size(100, 23);
            this.InterestVisitorID.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "InterestVisitorID";
            // 
            // AddInterestVisitor
            // 
            this.AddInterestVisitor.Location = new System.Drawing.Point(8, 84);
            this.AddInterestVisitor.Name = "AddInterestVisitor";
            this.AddInterestVisitor.Size = new System.Drawing.Size(196, 27);
            this.AddInterestVisitor.TabIndex = 9;
            this.AddInterestVisitor.Text = "Добавить желаемого посетителя";
            this.AddInterestVisitor.UseVisualStyleBackColor = true;
            this.AddInterestVisitor.Click += new System.EventHandler(this.AddInterestVisitor_Click);
            // 
            // GetAllInterestVisitors
            // 
            this.GetAllInterestVisitors.Location = new System.Drawing.Point(7, 22);
            this.GetAllInterestVisitors.Name = "GetAllInterestVisitors";
            this.GetAllInterestVisitors.Size = new System.Drawing.Size(197, 24);
            this.GetAllInterestVisitors.TabIndex = 12;
            this.GetAllInterestVisitors.Text = "Получить желаемых посетителей";
            this.GetAllInterestVisitors.UseVisualStyleBackColor = true;
            this.GetAllInterestVisitors.Click += new System.EventHandler(this.GetAllInterestVisitors_Click);
            // 
            // VisitorIDForInterest
            // 
            this.VisitorIDForInterest.Location = new System.Drawing.Point(104, 55);
            this.VisitorIDForInterest.Name = "VisitorIDForInterest";
            this.VisitorIDForInterest.Size = new System.Drawing.Size(100, 23);
            this.VisitorIDForInterest.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Visitor ID";
            // 
            // ManagerGroup
            // 
            this.ManagerGroup.Controls.Add(this.DeleteDesVisitorManager);
            this.ManagerGroup.Controls.Add(this.InterestVisitorForManager);
            this.ManagerGroup.Controls.Add(this.GetInterestVisitorsForManager);
            this.ManagerGroup.Controls.Add(this.label17);
            this.ManagerGroup.Controls.Add(this.GetOutcoming);
            this.ManagerGroup.Controls.Add(this.GetIncoming);
            this.ManagerGroup.Controls.Add(this.RejectDeal);
            this.ManagerGroup.Controls.Add(this.ConfirmDeal);
            this.ManagerGroup.Controls.Add(this.DealID);
            this.ManagerGroup.Controls.Add(this.label11);
            this.ManagerGroup.Controls.Add(this.RequestVisitor);
            this.ManagerGroup.Controls.Add(this.CostForManager);
            this.ManagerGroup.Controls.Add(this.label10);
            this.ManagerGroup.Controls.Add(this.VisitorIDForManager);
            this.ManagerGroup.Controls.Add(this.label9);
            this.ManagerGroup.Location = new System.Drawing.Point(1035, 191);
            this.ManagerGroup.Name = "ManagerGroup";
            this.ManagerGroup.Size = new System.Drawing.Size(220, 552);
            this.ManagerGroup.TabIndex = 15;
            this.ManagerGroup.TabStop = false;
            this.ManagerGroup.Text = "Manager";
            // 
            // DeleteDesVisitorManager
            // 
            this.DeleteDesVisitorManager.Location = new System.Drawing.Point(6, 381);
            this.DeleteDesVisitorManager.Name = "DeleteDesVisitorManager";
            this.DeleteDesVisitorManager.Size = new System.Drawing.Size(197, 27);
            this.DeleteDesVisitorManager.TabIndex = 15;
            this.DeleteDesVisitorManager.Text = "Удалить желаемого посетителя";
            this.DeleteDesVisitorManager.UseVisualStyleBackColor = true;
            this.DeleteDesVisitorManager.Click += new System.EventHandler(this.DeleteDesVisitorManager_Click);
            // 
            // InterestVisitorForManager
            // 
            this.InterestVisitorForManager.Location = new System.Drawing.Point(105, 345);
            this.InterestVisitorForManager.Name = "InterestVisitorForManager";
            this.InterestVisitorForManager.Size = new System.Drawing.Size(100, 23);
            this.InterestVisitorForManager.TabIndex = 17;
            // 
            // GetInterestVisitorsForManager
            // 
            this.GetInterestVisitorsForManager.Cursor = System.Windows.Forms.Cursors.Default;
            this.GetInterestVisitorsForManager.Location = new System.Drawing.Point(6, 19);
            this.GetInterestVisitorsForManager.Name = "GetInterestVisitorsForManager";
            this.GetInterestVisitorsForManager.Size = new System.Drawing.Size(197, 24);
            this.GetInterestVisitorsForManager.TabIndex = 15;
            this.GetInterestVisitorsForManager.Text = "Получить желаемых посетит.";
            this.GetInterestVisitorsForManager.UseVisualStyleBackColor = true;
            this.GetInterestVisitorsForManager.Click += new System.EventHandler(this.GetInterestVisitorsForManager_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 348);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 15);
            this.label17.TabIndex = 16;
            this.label17.Text = "InterestVisitorID";
            // 
            // GetOutcoming
            // 
            this.GetOutcoming.Location = new System.Drawing.Point(7, 292);
            this.GetOutcoming.Name = "GetOutcoming";
            this.GetOutcoming.Size = new System.Drawing.Size(197, 47);
            this.GetOutcoming.TabIndex = 24;
            this.GetOutcoming.Text = "Получить исходящие предложения";
            this.GetOutcoming.UseVisualStyleBackColor = true;
            this.GetOutcoming.Click += new System.EventHandler(this.GetOutcoming_Click);
            // 
            // GetIncoming
            // 
            this.GetIncoming.Location = new System.Drawing.Point(6, 235);
            this.GetIncoming.Name = "GetIncoming";
            this.GetIncoming.Size = new System.Drawing.Size(197, 51);
            this.GetIncoming.TabIndex = 23;
            this.GetIncoming.Text = "Получить входящие предложения";
            this.GetIncoming.UseVisualStyleBackColor = true;
            this.GetIncoming.Click += new System.EventHandler(this.GetIncoming_Click);
            // 
            // RejectDeal
            // 
            this.RejectDeal.Location = new System.Drawing.Point(6, 202);
            this.RejectDeal.Name = "RejectDeal";
            this.RejectDeal.Size = new System.Drawing.Size(197, 27);
            this.RejectDeal.TabIndex = 22;
            this.RejectDeal.Text = "Отклонить сделку";
            this.RejectDeal.UseVisualStyleBackColor = true;
            this.RejectDeal.Click += new System.EventHandler(this.RejectDeal_Click);
            // 
            // ConfirmDeal
            // 
            this.ConfirmDeal.Location = new System.Drawing.Point(6, 169);
            this.ConfirmDeal.Name = "ConfirmDeal";
            this.ConfirmDeal.Size = new System.Drawing.Size(197, 27);
            this.ConfirmDeal.TabIndex = 21;
            this.ConfirmDeal.Text = "Подтвердить сделку";
            this.ConfirmDeal.UseVisualStyleBackColor = true;
            this.ConfirmDeal.Click += new System.EventHandler(this.ConfirmDeal_Click);
            // 
            // DealID
            // 
            this.DealID.Location = new System.Drawing.Point(103, 140);
            this.DealID.Name = "DealID";
            this.DealID.Size = new System.Drawing.Size(100, 23);
            this.DealID.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 19;
            this.label11.Text = "Deal ID";
            // 
            // RequestVisitor
            // 
            this.RequestVisitor.Location = new System.Drawing.Point(6, 107);
            this.RequestVisitor.Name = "RequestVisitor";
            this.RequestVisitor.Size = new System.Drawing.Size(197, 27);
            this.RequestVisitor.TabIndex = 15;
            this.RequestVisitor.Text = "Запросить посетителя";
            this.RequestVisitor.UseVisualStyleBackColor = true;
            this.RequestVisitor.Click += new System.EventHandler(this.RequestVisitor_Click);
            // 
            // CostForManager
            // 
            this.CostForManager.Location = new System.Drawing.Point(103, 78);
            this.CostForManager.Name = "CostForManager";
            this.CostForManager.Size = new System.Drawing.Size(100, 23);
            this.CostForManager.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "Cost";
            // 
            // VisitorIDForManager
            // 
            this.VisitorIDForManager.Location = new System.Drawing.Point(103, 49);
            this.VisitorIDForManager.Name = "VisitorIDForManager";
            this.VisitorIDForManager.Size = new System.Drawing.Size(100, 23);
            this.VisitorIDForManager.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Visitor ID";
            // 
            // ModeratorGroup
            // 
            this.ModeratorGroup.Controls.Add(this.DeleteUser);
            this.ModeratorGroup.Controls.Add(this.UserID);
            this.ModeratorGroup.Controls.Add(this.label23);
            this.ModeratorGroup.Controls.Add(this.AddNewUser);
            this.ModeratorGroup.Controls.Add(this.Perm);
            this.ModeratorGroup.Controls.Add(this.label22);
            this.ModeratorGroup.Controls.Add(this.Hash);
            this.ModeratorGroup.Controls.Add(this.label21);
            this.ModeratorGroup.Controls.Add(this.Username);
            this.ModeratorGroup.Controls.Add(this.label20);
            this.ModeratorGroup.Controls.Add(this.GetAllUsers);
            this.ModeratorGroup.Controls.Add(this.GetAllDeals);
            this.ModeratorGroup.Controls.Add(this.DeleteDeal);
            this.ModeratorGroup.Controls.Add(this.MakeDeal);
            this.ModeratorGroup.Controls.Add(this.DealIDForModer);
            this.ModeratorGroup.Controls.Add(this.label14);
            this.ModeratorGroup.Location = new System.Drawing.Point(1262, 12);
            this.ModeratorGroup.Name = "ModeratorGroup";
            this.ModeratorGroup.Size = new System.Drawing.Size(221, 389);
            this.ModeratorGroup.TabIndex = 25;
            this.ModeratorGroup.TabStop = false;
            this.ModeratorGroup.Text = "Moderator";
            // 
            // DeleteUser
            // 
            this.DeleteUser.Location = new System.Drawing.Point(6, 348);
            this.DeleteUser.Name = "DeleteUser";
            this.DeleteUser.Size = new System.Drawing.Size(197, 27);
            this.DeleteUser.TabIndex = 32;
            this.DeleteUser.Text = "Удалить пользователя";
            this.DeleteUser.UseVisualStyleBackColor = true;
            this.DeleteUser.Click += new System.EventHandler(this.DeleteUser_Click);
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(103, 319);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(100, 23);
            this.UserID.TabIndex = 31;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(5, 322);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 15);
            this.label23.TabIndex = 30;
            this.label23.Text = "User ID";
            // 
            // AddNewUser
            // 
            this.AddNewUser.Location = new System.Drawing.Point(7, 289);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(196, 24);
            this.AddNewUser.TabIndex = 29;
            this.AddNewUser.Text = "Добавить нового пользователя";
            this.AddNewUser.UseVisualStyleBackColor = true;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // Perm
            // 
            this.Perm.Location = new System.Drawing.Point(103, 257);
            this.Perm.Name = "Perm";
            this.Perm.Size = new System.Drawing.Size(100, 23);
            this.Perm.TabIndex = 28;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 260);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 15);
            this.label22.TabIndex = 27;
            this.label22.Text = "Permission";
            // 
            // Hash
            // 
            this.Hash.Location = new System.Drawing.Point(103, 228);
            this.Hash.Name = "Hash";
            this.Hash.Size = new System.Drawing.Size(100, 23);
            this.Hash.TabIndex = 26;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(5, 231);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 15);
            this.label21.TabIndex = 25;
            this.label21.Text = "Password";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(103, 199);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(100, 23);
            this.Username.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 202);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 15);
            this.label20.TabIndex = 23;
            this.label20.Text = "Username";
            // 
            // GetAllUsers
            // 
            this.GetAllUsers.Location = new System.Drawing.Point(7, 149);
            this.GetAllUsers.Name = "GetAllUsers";
            this.GetAllUsers.Size = new System.Drawing.Size(196, 46);
            this.GetAllUsers.TabIndex = 13;
            this.GetAllUsers.Text = "Просмотреть всех пользователей";
            this.GetAllUsers.UseVisualStyleBackColor = true;
            this.GetAllUsers.Click += new System.EventHandler(this.GetAllUsers_Click);
            // 
            // GetAllDeals
            // 
            this.GetAllDeals.Location = new System.Drawing.Point(6, 116);
            this.GetAllDeals.Name = "GetAllDeals";
            this.GetAllDeals.Size = new System.Drawing.Size(197, 27);
            this.GetAllDeals.TabIndex = 22;
            this.GetAllDeals.Text = "Получить все сделки";
            this.GetAllDeals.UseVisualStyleBackColor = true;
            this.GetAllDeals.Click += new System.EventHandler(this.GetAllDeals_Click);
            // 
            // DeleteDeal
            // 
            this.DeleteDeal.Location = new System.Drawing.Point(6, 83);
            this.DeleteDeal.Name = "DeleteDeal";
            this.DeleteDeal.Size = new System.Drawing.Size(197, 27);
            this.DeleteDeal.TabIndex = 21;
            this.DeleteDeal.Text = "Удалить сделку";
            this.DeleteDeal.UseVisualStyleBackColor = true;
            this.DeleteDeal.Click += new System.EventHandler(this.DeleteDeal_Click);
            // 
            // MakeDeal
            // 
            this.MakeDeal.Location = new System.Drawing.Point(6, 50);
            this.MakeDeal.Name = "MakeDeal";
            this.MakeDeal.Size = new System.Drawing.Size(197, 27);
            this.MakeDeal.TabIndex = 15;
            this.MakeDeal.Text = "Провести сделку";
            this.MakeDeal.UseVisualStyleBackColor = true;
            this.MakeDeal.Click += new System.EventHandler(this.MakeDeal_Click);
            // 
            // DealIDForModer
            // 
            this.DealIDForModer.Location = new System.Drawing.Point(103, 21);
            this.DealIDForModer.Name = "DealIDForModer";
            this.DealIDForModer.Size = new System.Drawing.Size(100, 23);
            this.DealIDForModer.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 15);
            this.label14.TabIndex = 15;
            this.label14.Text = "DealID";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1262, 405);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(172, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Информация о пользователе:";
            // 
            // UserLogin
            // 
            this.UserLogin.AutoSize = true;
            this.UserLogin.Location = new System.Drawing.Point(1327, 426);
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.Size = new System.Drawing.Size(37, 15);
            this.UserLogin.TabIndex = 27;
            this.UserLogin.Text = "Login";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1262, 426);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 28;
            this.label13.Text = "Login:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1262, 449);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "Password:";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(1328, 449);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(39, 15);
            this.Password.TabIndex = 30;
            this.Password.Text = "Passw";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1263, 473);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 15);
            this.label16.TabIndex = 31;
            this.label16.Text = "Permission:";
            // 
            // Permission
            // 
            this.Permission.AutoSize = true;
            this.Permission.Location = new System.Drawing.Point(1328, 470);
            this.Permission.Name = "Permission";
            this.Permission.Size = new System.Drawing.Size(65, 15);
            this.Permission.TabIndex = 32;
            this.Permission.Text = "Permission";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1263, 494);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "ID";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.BackColor = System.Drawing.SystemColors.Control;
            this.Status.Location = new System.Drawing.Point(1328, 494);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 15);
            this.Status.TabIndex = 34;
            this.Status.Text = "Status";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1262, 470);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 15);
            this.label19.TabIndex = 31;
            this.label19.Text = "Permission:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1269, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 27);
            this.button1.TabIndex = 25;
            this.button1.Text = "ВЫХОД";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Close);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1488, 748);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Permission);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.UserLogin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ModeratorGroup);
            this.Controls.Add(this.AnalyticGroup);
            this.Controls.Add(this.ManagerGroup);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Основная страница";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseForm);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.UserBox.ResumeLayout(false);
            this.StatisticsBox.ResumeLayout(false);
            this.StatisticsBox.PerformLayout();
            this.Visitors.ResumeLayout(false);
            this.Visitors.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.HotelBoxForVisitors.ResumeLayout(false);
            this.HotelBoxForVisitors.PerformLayout();
            this.AnalyticGroup.ResumeLayout(false);
            this.AnalyticGroup.PerformLayout();
            this.ManagerGroup.ResumeLayout(false);
            this.ManagerGroup.PerformLayout();
            this.ModeratorGroup.ResumeLayout(false);
            this.ModeratorGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void CloseForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button GetAllVisitors;
        private System.Windows.Forms.GroupBox UserBox;
        private System.Windows.Forms.GroupBox StatisticsBox;
        private System.Windows.Forms.Button GetStatistic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox StatisticsID;
        private System.Windows.Forms.GroupBox Visitors;
        private System.Windows.Forms.Button GetVisitorByID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox VisitorIDBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GetHotelByName;
        private System.Windows.Forms.Button GetHotelByID;
        private System.Windows.Forms.Button GetAllHotels;
        private System.Windows.Forms.TextBox HotelName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox HotelID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox HotelBoxForVisitors;
        private System.Windows.Forms.Button GetVisitorsByName;
        private System.Windows.Forms.Button GetVisitorsByHotelID;
        private System.Windows.Forms.TextBox VisitorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HotelIDBoxForVisitor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox AnalyticGroup;
        private System.Windows.Forms.Button DeleteInterestVisitor;
        private System.Windows.Forms.Button AddInterestVisitor;
        private System.Windows.Forms.Button GetAllInterestVisitors;
        private System.Windows.Forms.Button GetStatisticsByID;
        private System.Windows.Forms.TextBox VisitorIDForInterest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox InterestVisitorID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox ManagerGroup;
        private System.Windows.Forms.TextBox VisitorIDForManager;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox DealID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button RequestVisitor;
        private System.Windows.Forms.TextBox CostForManager;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ConfirmDeal;
        private System.Windows.Forms.Button RejectDeal;
        private System.Windows.Forms.Button GetOutcoming;
        private System.Windows.Forms.Button GetIncoming;
        private System.Windows.Forms.GroupBox ModeratorGroup;
        private System.Windows.Forms.Button DeleteDeal;
        private System.Windows.Forms.Button MakeDeal;
        private System.Windows.Forms.TextBox DealIDForModer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button GetAllDeals;
        private Button GetVisitorHotelStat;
        private Button GetInterestVisitorsForManager;
        private Label label12;
        private Label UserLogin;
        private Label label13;
        private Label label15;
        private Label Password;
        private Label label16;
        private Label Permission;
        private Label label18;
        private Label Status;
        private Button DeleteDesVisitorManager;
        private TextBox InterestVisitorForManager;
        private Label label17;
        private Label label19;
        private Button DeleteUser;
        private TextBox UserID;
        private Label label23;
        private Button AddNewUser;
        private TextBox Perm;
        private Label label22;
        private TextBox Hash;
        private Label label21;
        private TextBox Username;
        private Label label20;
        private Button GetAllUsers;
        private Button GetHotelByStars;
        private Label label24;
        private TextBox category;
        private Button button1;
    }
}

