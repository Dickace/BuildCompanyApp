using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BuildCompany
{
    public partial class buildcompanyContext : DbContext
    {
        public buildcompanyContext()
        {
        }

        public buildcompanyContext(DbContextOptions<buildcompanyContext> options)
            : base(options)
        {
        }

        internal void Load()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<EmpFunction> EmpFunctions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePayout> EmployeePayouts { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialList> MaterialLists { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<SickleaveDatum> SickleaveData { get; set; }
        public virtual DbSet<SickleaveStatus> SickleaveStatuses { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamStatus> TeamStatuses { get; set; }
        public virtual DbSet<VacationDatum> VacationData { get; set; }
        public virtual DbSet<VacationStatus> VacationStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            
            if (!optionsBuilder.IsConfigured)
            {
                var sett = Properties.Settings.Default;
                
                string connString = "server="+sett.IP + ";port=" + sett.host +";user=" +sett.login +";database="+sett.database+";password="+sett.password ;
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql(connString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.34-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("PRIMARY");

                entity.ToTable("client");

                entity.Property(e => e.IdClient)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Client");

                entity.Property(e => e.ClientAdress)
                    .HasColumnType("text")
                    .HasColumnName("Client_Adress");

                entity.Property(e => e.ClientDescription)
                    .HasColumnType("text")
                    .HasColumnName("Client_Description");

                entity.Property(e => e.ClientFirstName)
                    .HasColumnType("text")
                    .HasColumnName("Client_First_Name");

                entity.Property(e => e.ClientLastName)
                    .HasColumnType("text")
                    .HasColumnName("Client_Last_Name");

                entity.Property(e => e.ClientPatronymic)
                    .HasColumnType("text")
                    .HasColumnName("Client_Patronymic");
            });

            modelBuilder.Entity<EmpFunction>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeFunction)
                    .HasName("PRIMARY");

                entity.ToTable("emp_function");

                entity.Property(e => e.IdEmployeeFunction)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Employee_Function");

                entity.Property(e => e.EmployeeFunctionName)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Function_Name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.HasIndex(e => e.IdEmployeeStatus, "FK_EMPLOYEE_RELATIONS_EMPLOYEE");

                entity.HasIndex(e => e.IdEmployeeFunction, "FK_EMPLOYEE_RELATIONS_EMP_FUNC");

                entity.HasIndex(e => e.IdTeam, "FK_EMPLOYEE_RELATIONS_TEAM");

                entity.HasIndex(e => e.IdLeadTeam, "FK_EMPLOYEE_ИМЕЕТ_TEAM");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Employee");

                entity.Property(e => e.EmployeeEmail)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Email");

                entity.Property(e => e.EmployeeFirstName)
                    .HasColumnType("text")
                    .HasColumnName("Employee_FirstName");

                entity.Property(e => e.EmployeeLastName)
                    .HasColumnType("text")
                    .HasColumnName("Employee_LastName");

                entity.Property(e => e.EmployeePassportData)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Passport_Data");

                entity.Property(e => e.EmployeePatronymic)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Patronymic");

                entity.Property(e => e.EmployeePhoneNumber)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Phone_Number");

                entity.Property(e => e.IdEmployeeFunction)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Employee_Function");

                entity.Property(e => e.IdEmployeeStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Employee_Status");

                entity.Property(e => e.IdLeadTeam)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Lead_Team");

                entity.Property(e => e.IdTeam)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Team");

                entity.HasOne(d => d.IdEmployeeFunctionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdEmployeeFunction)
                    .HasConstraintName("FK_EMPLOYEE_RELATIONS_EMP_FUNC");

                entity.HasOne(d => d.IdEmployeeStatusNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdEmployeeStatus)
                    .HasConstraintName("FK_EMPLOYEE_RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdLeadTeamNavigation)
                    .WithMany(p => p.EmployeeIdLeadTeamNavigations)
                    .HasForeignKey(d => d.IdLeadTeam)
                    .HasConstraintName("FK_EMPLOYEE_ИМЕЕТ_TEAM");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.EmployeeIdTeamNavigations)
                    .HasForeignKey(d => d.IdTeam)
                    .HasConstraintName("FK_EMPLOYEE_RELATIONS_TEAM");
            });

            modelBuilder.Entity<EmployeePayout>(entity =>
            {
                entity.HasKey(e => e.IdEmployeePayout)
                    .HasName("PRIMARY");

                entity.ToTable("employee_payout");

                entity.Property(e => e.IdEmployeePayout)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Employee_Payout");

                entity.Property(e => e.BonusesAndFines)
                    .HasColumnType("int(11)")
                    .HasColumnName("Bonuses_And_Fines");

                entity.Property(e => e.EmployeeCardNumber)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Card_Number");

                entity.Property(e => e.EmployeeTaxNumber)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Tax_Number");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Employee");

                entity.Property(e => e.PayoutForOrders)
                    .HasColumnType("int(11)")
                    .HasColumnName("Payout_For_Orders");

                entity.Property(e => e.TotalPayout)
                    .HasColumnType("int(11)")
                    .HasColumnName("Total_Payout");
            });

            modelBuilder.Entity<EmployeeStatus>(entity =>
            {
                entity.HasKey(e => e.IdEmployeeStatus)
                    .HasName("PRIMARY");

                entity.ToTable("employee_status");

                entity.Property(e => e.IdEmployeeStatus)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Employee_Status");

                entity.Property(e => e.EmployeeStatusName)
                    .HasColumnType("text")
                    .HasColumnName("Employee_Status_Name");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("material");

                entity.Property(e => e.IdMaterial)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Material");

                entity.Property(e => e.MaterialName)
                    .HasColumnType("text")
                    .HasColumnName("Material_Name");
            });

            modelBuilder.Entity<MaterialList>(entity =>
            {
                entity.HasKey(e => e.IdMaterialList)
                    .HasName("PRIMARY");

                entity.ToTable("material_list");

                entity.HasIndex(e => e.IdMaterial, "FK_MATERIAL_REFERENCE_MATERIAL");

                entity.HasIndex(e => e.IdOrder, "FK_MATERIAL_RELATIONS_ORDERS");

                entity.Property(e => e.IdMaterialList)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Material_List");

                entity.Property(e => e.IdMaterial)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Material");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Order");

                entity.Property(e => e.MaterialCounts)
                    .HasColumnType("int(11)")
                    .HasColumnName("Material_counts");

                entity.Property(e => e.MaterialEndDate)
                    .HasColumnType("date")
                    .HasColumnName("Material_end_date");

               

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.MaterialLists)
                    .HasForeignKey(d => d.IdMaterial)
                    .HasConstraintName("FK_MATERIAL_REFERENCE_MATERIAL");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.MaterialLists)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_MATERIAL_RELATIONS_ORDERS");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasIndex(e => e.IdClient, "FK_ORDERS_RELATIONS_CLIENT");

                entity.HasIndex(e => e.IdOrderStatus, "FK_ORDERS_RELATIONS_ORDER_ST");

                entity.HasIndex(e => e.IdTeam, "FK_ORDERS_RELATIONS_TEAM");

                entity.Property(e => e.IdOrder)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Order");

                entity.Property(e => e.IdClient)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Client");

                entity.Property(e => e.IdOrderStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Order_Status");

                entity.Property(e => e.IdTeam)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Team");

                entity.Property(e => e.OrderEndingDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_Ending_Date");

                entity.Property(e => e.OrderNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("Order_Number");

                entity.Property(e => e.OrderSummary)
                    .HasColumnType("int(11)")
                    .HasColumnName("Order_Summary");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_RELATIONS_CLIENT");

                entity.HasOne(d => d.IdOrderStatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdOrderStatus)
                    .HasConstraintName("FK_ORDERS_RELATIONS_ORDER_ST");

                entity.HasOne(d => d.IdTeamNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdTeam)
                    .HasConstraintName("FK_ORDERS_RELATIONS_TEAM");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdOrderStatus)
                    .HasName("PRIMARY");

                entity.ToTable("order_status");

                entity.Property(e => e.IdOrderStatus)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Order_Status");

                entity.Property(e => e.OrderStatusName)
                    .HasColumnType("text")
                    .HasColumnName("Order_Status_Name");
            });

            modelBuilder.Entity<SickleaveDatum>(entity =>
            {
                entity.HasKey(e => e.IdSickLeaveData)
                    .HasName("PRIMARY");

                entity.ToTable("sickleave_data");

                entity.HasIndex(e => e.IdEmployee, "FK_SICKLEAV_RELATIONS_EMPLOYEE");

                entity.HasIndex(e => e.IdSickLeaveDataStatus, "FK_SICKLEAV_RELATIONS_SICKLEAV");

                entity.Property(e => e.IdSickLeaveData)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SickLeave_Data");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Employee");

                entity.Property(e => e.IdSickLeaveDataStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_SickLeave_Data_Status");

                entity.Property(e => e.PaidSickLeave).HasColumnName("Paid_SickLeave");

                entity.Property(e => e.SickLeaveEndDate)
                    .HasColumnType("date")
                    .HasColumnName("SickLeave_End_Date");

                entity.Property(e => e.SickLeaveNumber)
                    .HasColumnType("text")
                    .HasColumnName("SickLeave_Number");

                entity.Property(e => e.SickLeaveStartDate)
                    .HasColumnType("date")
                    .HasColumnName("SickLeave_Start_Date");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.SickleaveData)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_SICKLEAV_RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdSickLeaveDataStatusNavigation)
                    .WithMany(p => p.SickleaveData)
                    .HasForeignKey(d => d.IdSickLeaveDataStatus)
                    .HasConstraintName("FK_SICKLEAV_RELATIONS_SICKLEAV");
            });

            modelBuilder.Entity<SickleaveStatus>(entity =>
            {
                entity.HasKey(e => e.IdSickLeaveStatus)
                    .HasName("PRIMARY");

                entity.ToTable("sickleave_status");

                entity.Property(e => e.IdSickLeaveStatus)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_SickLeave_Status");

                entity.Property(e => e.SickLeaveStatusName)
                    .HasColumnType("text")
                    .HasColumnName("SickLeave_Status_Name");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.IdTeam)
                    .HasName("PRIMARY");

                entity.ToTable("team");

                entity.HasIndex(e => e.IdTeamStatus, "FK_TEAM_RELATIONS_TEAM_STA");

                entity.HasIndex(e => e.IdEmployee, "FK_TEAM_РУКОВОДИТ_EMPLOYEE");

                entity.Property(e => e.IdTeam)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Team");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Employee");

                entity.Property(e => e.IdTeamStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Team_Status");

                entity.Property(e => e.TeamNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("Team_Number");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_TEAM_РУКОВОДИТ_EMPLOYEE");

                entity.HasOne(d => d.IdTeamStatusNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.IdTeamStatus)
                    .HasConstraintName("FK_TEAM_RELATIONS_TEAM_STA");
            });

            modelBuilder.Entity<TeamStatus>(entity =>
            {
                entity.HasKey(e => e.IdTeamStatus)
                    .HasName("PRIMARY");

                entity.ToTable("team_status");

                entity.Property(e => e.IdTeamStatus)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Team_Status");

                entity.Property(e => e.TeamStatusName)
                    .HasColumnType("text")
                    .HasColumnName("Team_Status_Name");
            });

            modelBuilder.Entity<VacationDatum>(entity =>
            {
                entity.HasKey(e => e.IdVacationData)
                    .HasName("PRIMARY");

                entity.ToTable("vacation_data");

                entity.HasIndex(e => e.IdEmployee, "FK_VACATION_RELATIONS_EMPLOYEE");

                entity.HasIndex(e => e.IdVacationStatus, "FK_VACATION_RELATIONS_VACATION");

                entity.Property(e => e.IdVacationData)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Vacation_Data");

                entity.Property(e => e.IdEmployee)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Employee");

                entity.Property(e => e.IdVacationStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Vacation_Status");

                entity.Property(e => e.PaidVacation).HasColumnName("Paid_Vacation");

                entity.Property(e => e.VacationEndDate)
                    .HasColumnType("date")
                    .HasColumnName("Vacation_End_Date");

                entity.Property(e => e.VacationStartDate)
                    .HasColumnType("date")
                    .HasColumnName("Vacation_Start_Date");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.VacationData)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_VACATION_RELATIONS_EMPLOYEE");

                entity.HasOne(d => d.IdVacationStatusNavigation)
                    .WithMany(p => p.VacationData)
                    .HasForeignKey(d => d.IdVacationStatus)
                    .HasConstraintName("FK_VACATION_RELATIONS_VACATION");
            });

            modelBuilder.Entity<VacationStatus>(entity =>
            {
                entity.HasKey(e => e.IdVacationStatus)
                    .HasName("PRIMARY");

                entity.ToTable("vacation_status");

                entity.Property(e => e.IdVacationStatus)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Vacation_Status");

                entity.Property(e => e.VacationStatusName)
                    .HasColumnType("text")
                    .HasColumnName("Vacation_Status_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
