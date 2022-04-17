using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ComponentBuisinessLogic;

#nullable disable

namespace ComponentAccessToDB
{
    public partial class transfersystemContext : DbContext
    {
        private string ConnectionString { get; set; }
        public transfersystemContext(string conn)
        {
            ConnectionString = conn;
        }

        public transfersystemContext(DbContextOptions<transfersystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailabledealDB> Availabledeals { get; set; }
        public virtual DbSet<InterestVisitorDB> InterestVisitors { get; set; }
        public virtual DbSet<ManagementDB> Managements { get; set; }
        public virtual DbSet<VisitorDB> Visitors { get; set; }
        public virtual DbSet<StatisticDB> Statistics { get; set; }
        public virtual DbSet<HotelDB> Hotels { get; set; }
        public virtual DbSet<UserinfoDB> Userinfos { get; set; }
        public IQueryable<VisitorHotelStatDB> getvisitors() => FromExpression(() => getvisitors());
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDbFunction(() => getvisitors());

            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<AvailabledealDB>(entity =>
            {
                entity.HasKey(e => e.Id)
                    //.ValueGeneratedNever()
                    .HasName("id");

                entity.ToTable("availabledeals");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Frommanagementid).HasColumnName("frommanagementid");

                entity.Property(e => e.VisitorID).HasColumnName("visitorid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tomanagementid).HasColumnName("tomanagementid");

                entity.HasOne(d => d.Frommanagement)
                    .WithMany(p => p.AvailabledealFrommanagements)
                    .HasForeignKey(d => d.Frommanagementid)
                    .HasConstraintName("availabledeals_frommanagementid_fkey");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Availabledeals)
                    .HasForeignKey(d => d.VisitorID)
                    .HasConstraintName("availabledeals_visitorid_fkey");

                entity.HasOne(d => d.Tomanagement)
                    .WithMany(p => p.AvailabledealTomanagements)
                    .HasForeignKey(d => d.Tomanagementid)
                    .HasConstraintName("availabledeals_tomanagementid_fkey");
            });

            modelBuilder.Entity<InterestVisitorDB>(entity =>
            {
                entity.HasKey(e => e.Id)
                    //.ValueGeneratedNever()
                    .HasName("id");

                entity.ToTable("interestvisitor");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Managementid).HasColumnName("managementid");

                entity.Property(e => e.VisitorID).HasColumnName("visitorid");

                entity.Property(e => e.HotelID).HasColumnName("hotelid");

                entity.HasOne(d => d.Management)
                    .WithMany(p => p.InterestVisitors)
                    .HasForeignKey(d => d.Managementid)
                    .HasConstraintName("interestvisitors_managementid_fkey");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.InterestVisitors)
                    .HasForeignKey(d => d.VisitorID)
                    .HasConstraintName("interestvisitors_visitorid_fkey");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.InterestVisitors)
                    .HasForeignKey(d => d.HotelID)
                    .HasConstraintName("interestvisitors_hotelid_fkey");
            });

            modelBuilder.Entity<ManagementDB>(entity =>
            {
                entity.HasKey(e => e.Managementid)
                    //.ValueGeneratedNever()
                    .HasName("managementid");

                entity.ToTable("management");

                entity.Property(e => e.Managementid)
                    .ValueGeneratedNever()
                    .HasColumnName("managementid");

                entity.Property(e => e.Analysistid).HasColumnName("analysistid");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.HasOne(d => d.Analysist)
                    .WithMany(p => p.ManagementAnalysists)
                    .HasForeignKey(d => d.Analysistid)
                    .HasConstraintName("management_analysistid_fkey");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.ManagementManagers)
                    .HasForeignKey(d => d.Managerid)
                    .HasConstraintName("management_managerid_fkey");
            });

            modelBuilder.Entity<VisitorDB>(entity =>
            {
                entity.HasKey(e => e.VisitorID)
                    .HasName("visitorid");

                entity.ToTable("visitor");

                entity.Property(e => e.VisitorID)
                    .ValueGeneratedNever()
                    .HasColumnName("visitorid");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Budget).HasColumnName("budget");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country");

                //entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

               // entity.Property(e => e.Number).HasColumnName("number");

               // entity.Property(e => e.Position)
               //     .IsRequired()
               //     .HasMaxLength(10)
               //     .HasColumnName("position");

                entity.Property(e => e.Statistics).HasColumnName("statistics");

                entity.Property(e => e.HotelID).HasColumnName("hotelid");

                //entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.StatisticsNavigation)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.Statistics)
                    .HasConstraintName("visitor_statistics_fkey");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.HotelID)
                    .HasConstraintName("visitor_hotelid_fkey");
            });

            modelBuilder.Entity<StatisticDB>(entity =>
            {
                entity.HasKey(e => e.Statisticsid)
                    .HasName("statistics_pkey");

                entity.ToTable("statistics");

                entity.Property(e => e.Statisticsid)
                    .ValueGeneratedNever()
                    .HasColumnName("statisticsid");

                entity.Property(e => e.AverageRating).HasColumnName("averagerating");

                entity.Property(e => e.NumberOfTrips).HasColumnName("numberoftrips");
            });

            modelBuilder.Entity<HotelDB>(entity =>
            {
                entity.HasKey(e => e.HotelID)
                    //.ValueGeneratedNever()
                    .HasName("hotelid");

                entity.ToTable("hotel");

                entity.Property(e => e.HotelID)
                    .ValueGeneratedNever()
                    .HasColumnName("hotelid");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("country");

                //entity.Property(e => e.Headcoach)
                //    .IsRequired()
                //    .HasMaxLength(30)
                //    .HasColumnName("headcoach");

                entity.Property(e => e.Managementid).HasColumnName("managementid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                //entity.Property(e => e.Stadium)
                //    .IsRequired()
                //    .HasMaxLength(60)
                //    .HasColumnName("stadium");

                entity.HasOne(d => d.Management)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.Managementid)
                    .HasConstraintName("hotel_managementid_fkey");
            });

            modelBuilder.Entity<UserinfoDB>(entity =>
            {
                entity.HasKey(e => e.Id)
                    //.ValueGeneratedNever()
                    .HasName("id");

                entity.ToTable("userinfo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("hash");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("login");

                entity.Property(e => e.Permission).HasColumnName("permission");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
