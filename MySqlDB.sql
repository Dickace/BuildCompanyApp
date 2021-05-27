/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     13.05.2021 21:41:07                          */
/*==============================================================*/


drop procedure if exists Add_Orders;

drop procedure if exists Show_Orders;

alter table Employee 
   drop foreign key FK_EMPLOYEE_RELATIONS_EMP_FUNC;

alter table Employee 
   drop foreign key FK_EMPLOYEE_RELATIONS_EMPLOYEE;

alter table Employee 
   drop foreign key FK_EMPLOYEE_RELATIONS_TEAM;

alter table Employee 
   drop foreign key FK_EMPLOYEE_àåÖÖí_TEAM;

alter table Employee_payout 
   drop foreign key FK_EMPLOYEE_RELATIONS_EMPLOYEE;

alter table Material_List 
   drop foreign key FK_MATERIAL_REFERENCE_MATERIAL;

alter table Material_List 
   drop foreign key FK_MATERIAL_RELATIONS_ORDERS;

alter table Orders 
   drop foreign key FK_ORDERS_RELATIONS_ORDER_ST;

alter table Orders 
   drop foreign key FK_ORDERS_RELATIONS_CLIENT;

alter table Orders 
   drop foreign key FK_ORDERS_RELATIONS_TEAM;

alter table SickLeave_Data 
   drop foreign key FK_SICKLEAV_RELATIONS_EMPLOYEE;

alter table SickLeave_Data 
   drop foreign key FK_SICKLEAV_RELATIONS_SICKLEAV;

alter table Team 
   drop foreign key FK_TEAM_RELATIONS_TEAM_STA;

alter table Team 
   drop foreign key FK_TEAM_êìäéÇéÑàí_EMPLOYEE;

alter table Vacation_Data 
   drop foreign key FK_VACATION_RELATIONS_VACATION;

alter table Vacation_Data 
   drop foreign key FK_VACATION_RELATIONS_EMPLOYEE;

drop table if exists Client;

drop table if exists Emp_Function;


alter table Employee 
   drop foreign key FK_EMPLOYEE_àåÖÖí_TEAM;

alter table Employee 
   drop foreign key FK_EMPLOYEE_RELATIONS_EMP_FUNC;

alter table Employee 
   drop foreign key FK_EMPLOYEE_RELATIONS_EMPLOYEE;

alter table Employee 
   drop foreign key FK_EMPLOYEE_RELATIONS_TEAM;

drop table if exists Employee;

drop table if exists Employee_Status;


alter table Employee_payout 
   drop foreign key FK_EMPLOYEE_RELATIONS_EMPLOYEE;

drop table if exists Employee_payout;

drop table if exists Material;


alter table Material_List 
   drop foreign key FK_MATERIAL_RELATIONS_ORDERS;

alter table Material_List 
   drop foreign key FK_MATERIAL_REFERENCE_MATERIAL;

drop table if exists Material_List;

drop table if exists Order_Status;


alter table Orders 
   drop foreign key FK_ORDERS_RELATIONS_CLIENT;

alter table Orders 
   drop foreign key FK_ORDERS_RELATIONS_TEAM;

alter table Orders 
   drop foreign key FK_ORDERS_RELATIONS_ORDER_ST;

drop table if exists Orders;


alter table SickLeave_Data 
   drop foreign key FK_SICKLEAV_RELATIONS_EMPLOYEE;

alter table SickLeave_Data 
   drop foreign key FK_SICKLEAV_RELATIONS_SICKLEAV;

drop table if exists SickLeave_Data;

drop table if exists SickLeave_Status;


alter table Team 
   drop foreign key FK_TEAM_êìäéÇéÑàí_EMPLOYEE;

alter table Team 
   drop foreign key FK_TEAM_RELATIONS_TEAM_STA;

drop table if exists Team;

drop table if exists Team_Status;


alter table Vacation_Data 
   drop foreign key FK_VACATION_RELATIONS_EMPLOYEE;

alter table Vacation_Data 
   drop foreign key FK_VACATION_RELATIONS_VACATION;

drop table if exists Vacation_Data;

drop table if exists Vacation_Status;

/*==============================================================*/
/* Table: Client                                                */
/*==============================================================*/
create table Client
(
   ID_Client            int not null  comment '',
   Client_Last_Name     text  comment '',
   Client_First_Name    text  comment '',
   Client_Patronymic    text  comment '',
   Client_Adress        text  comment '',
   Client_Description   text  comment '',
   primary key (ID_Client)
);

/*==============================================================*/
/* Table: Emp_Function                                          */
/*==============================================================*/
create table Emp_Function
(
   ID_Employee_Function int not null  comment '',
   Employee_Function_Name text  comment '',
   primary key (ID_Employee_Function)
);

/*==============================================================*/
/* Table: Employee                                              */
/*==============================================================*/
create table Employee
(
   ID_Employee          int not null  comment '',
   ID_Team              int  comment '',
   ID_Employee_Status   int  comment '',
   ID_Employee_Function int  comment '',
   Employee_FirstName   text  comment '',
   Employee_LastName    text  comment '',
   Employee_Patronymic  text  comment '',
   Employee_Passport_Data text  comment '',
   Employee_Phone_Number text  comment '',
   Employee_Email       text  comment '',
   ID_Lead_Team         int  comment '',
   primary key (ID_Employee)
);

/*==============================================================*/
/* Table: Employee_Status                                       */
/*==============================================================*/
create table Employee_Status
(
   ID_Employee_Status   int not null  comment '',
   Employee_Status_Name text  comment '',
   primary key (ID_Employee_Status)
);

/*==============================================================*/
/* Table: Employee_payout                                       */
/*==============================================================*/
create table Employee_payout
(
   ID_Employee_Payout   int not null  comment '',
   ID_Employee          int  comment '',
   Payout_For_Orders    int  comment '',
   Employee_Card_Number text  comment '',
   Employee_Tax_Number  text  comment '',
   Bonuses_And_Fines    int  comment '',
   Total_Payout         int  comment '',
   primary key (ID_Employee_Payout)
);

/*==============================================================*/
/* Table: Material                                              */
/*==============================================================*/
create table Material
(
   ID_Material          int not null  comment '',
   Material_Name        text  comment '',
   primary key (ID_Material)
);

/*==============================================================*/
/* Table: Material_List                                         */
/*==============================================================*/
create table Material_List
(
   ID_Material_List     int not null  comment '',
   ID_Material          int  comment '',
   ID_Order             int  comment '',
   Material_Name        text  comment '',
   Material_counts      int  comment '',
   Material_end_date    Date  comment '',
   primary key (ID_Material_List)
);

/*==============================================================*/
/* Table: Order_Status                                          */
/*==============================================================*/
create table Order_Status
(
   ID_Order_Status      int not null  comment '',
   Order_Status_Name    text  comment '',
   primary key (ID_Order_Status)
);

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders
(
   ID_Order             int not null  comment '',
   ID_Client            int not null  comment '',
   ID_Order_Status      int  comment '',
   ID_Team              int  comment '',
   Order_Number         int  comment '',
   Order_Summary        int  comment '',
   Order_Ending_Date    date  comment '',
   primary key (ID_Order)
);

/*==============================================================*/
/* Table: SickLeave_Data                                        */
/*==============================================================*/
create table SickLeave_Data
(
   ID_SickLeave_Data    int not null  comment '',
   ID_SickLeave_Data_Status int  comment '',
   ID_Employee          int  comment '',
   SickLeave_Start_Date date  comment '',
   Paid_SickLeave       bool  comment '',
   SickLeave_Number     int  comment '',
   SickLeave_End_Date   date  comment '',
   primary key (ID_SickLeave_Data)
);

/*==============================================================*/
/* Table: SickLeave_Status                                      */
/*==============================================================*/
create table SickLeave_Status
(
   ID_SickLeave_Status  int not null  comment '',
   SickLeave_Status_Name text  comment '',
   primary key (ID_SickLeave_Status)
);

/*==============================================================*/
/* Table: Team                                                  */
/*==============================================================*/
create table Team
(
   ID_Team              int not null  comment '',
   ID_Employee          int  comment '',
   ID_Team_Status       int  comment '',
   Team_Number          int  comment '',
   primary key (ID_Team)
);

/*==============================================================*/
/* Table: Team_Status                                           */
/*==============================================================*/
create table Team_Status
(
   ID_Team_Status       int not null  comment '',
   Team_Status_Name     text  comment '',
   primary key (ID_Team_Status)
);

/*==============================================================*/
/* Table: Vacation_Data                                         */
/*==============================================================*/
create table Vacation_Data
(
   ID_Vacation_Data     int not null  comment '',
   ID_Vacation_Status   int  comment '',
   ID_Employee          int  comment '',
   Vacation_Start_Date  date  comment '',
   Paid_Vacation        bool  comment '',
   Vacation_End_Date    date  comment '',
   primary key (ID_Vacation_Data)
);

/*==============================================================*/
/* Table: Vacation_Status                                       */
/*==============================================================*/
create table Vacation_Status
(
   ID_Vacation_Status   int not null  comment '',
   Vacation_Status_Name text  comment '',
   primary key (ID_Vacation_Status)
);

alter table Employee add constraint FK_EMPLOYEE_RELATIONS_EMP_FUNC foreign key (ID_Employee_Function)
      references Emp_Function (ID_Employee_Function) on delete restrict on update restrict;

alter table Employee add constraint FK_EMPLOYEE_RELATIONS_EMPLOYEE foreign key (ID_Employee_Status)
      references Employee_Status (ID_Employee_Status) on delete restrict on update restrict;

alter table Employee add constraint FK_EMPLOYEE_RELATIONS_TEAM foreign key (ID_Team)
      references Team (ID_Team) on delete restrict on update restrict;

alter table Employee add constraint FK_EMPLOYEE_àåÖÖí_TEAM foreign key (ID_Lead_Team)
      references Team (ID_Team) on delete restrict on update restrict;

alter table Employee_payout add constraint FK_EMPLOYEE_RELATIONS_EMPLOYEE foreign key (ID_Employee)
      references Employee (ID_Employee) on delete restrict on update restrict;

alter table Material_List add constraint FK_MATERIAL_REFERENCE_MATERIAL foreign key (ID_Material)
      references Material (ID_Material) on delete restrict on update restrict;

alter table Material_List add constraint FK_MATERIAL_RELATIONS_ORDERS foreign key (ID_Order)
      references Orders (ID_Order) on delete restrict on update restrict;

alter table Orders add constraint FK_ORDERS_RELATIONS_ORDER_ST foreign key (ID_Order_Status)
      references Order_Status (ID_Order_Status) on delete restrict on update restrict;

alter table Orders add constraint FK_ORDERS_RELATIONS_CLIENT foreign key (ID_Client)
      references Client (ID_Client) on delete restrict on update restrict;

alter table Orders add constraint FK_ORDERS_RELATIONS_TEAM foreign key (ID_Team)
      references Team (ID_Team) on delete restrict on update restrict;

alter table SickLeave_Data add constraint FK_SICKLEAV_RELATIONS_EMPLOYEE foreign key (ID_Employee)
      references Employee (ID_Employee) on delete restrict on update restrict;

alter table SickLeave_Data add constraint FK_SICKLEAV_RELATIONS_SICKLEAV foreign key (ID_SickLeave_Data_Status)
      references SickLeave_Status (ID_SickLeave_Status) on delete restrict on update restrict;

alter table Team add constraint FK_TEAM_RELATIONS_TEAM_STA foreign key (ID_Team_Status)
      references Team_Status (ID_Team_Status) on delete restrict on update restrict;

alter table Team add constraint FK_TEAM_êìäéÇéÑàí_EMPLOYEE foreign key (ID_Employee)
      references Employee (ID_Employee) on delete restrict on update restrict;

alter table Vacation_Data add constraint FK_VACATION_RELATIONS_VACATION foreign key (ID_Vacation_Status)
      references Vacation_Status (ID_Vacation_Status) on delete restrict on update restrict;

alter table Vacation_Data add constraint FK_VACATION_RELATIONS_EMPLOYEE foreign key (ID_Employee)
      references Employee (ID_Employee) on delete restrict on update restrict;


CREATE PROCEDURE [dbo].[add_Orders]
    @ID_Client int,
    @ID_Order_Status int,
    @Order_Number int,
    @Order_Summary int,
    @Order_Ending_Date date,
    @Id int out
AS
    INSERT INTO Orders (ID_Client, ID_Order_Status, Order_Number, Order_Summary, Order_Ending_Date )
    VALUES (@ID_Client, @ID_Order_Status, @Order_Number, @Order_Summary, @Order_Ending_Date)
   
    SET @Id=SCOPE_IDENTITY()
GO;


create procedure [dbo].[show_Orders]
AS
    SELECT Orders.[ID_Order], Orders.[ID_Client], Orders.[ID_Order_Status], Orders.[ID_Team], Orders.[Order_Number], Orders.[Order_Summary], Orders.[Order_Ending_Date]
    FROM Orders;
GO;

