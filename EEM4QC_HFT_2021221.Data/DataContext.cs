using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Microsoft.EntityFrameworkCore;
using EEM4QC_HFT_2021221.Models;

namespace EEM4QC_HFT_2021221.Data
{
    public class DataContext : DbContext
    {
        //Initial Catalog = DataContext;
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<HrEmployee> Hr_Employees { get; set; }

        public virtual DbSet<HrEmployeeCredentials> Hr_Employee_Credentials { get; set; }

        public virtual DbSet<HrEmployeeExitDetail> Hr_Employee_Exit_Detail { get; set; }

        public virtual DbSet<HrEmployeeSalaryRecord> Hr_Employee_Salary_Record { get; set; }

        public virtual DbSet<HrEmployeeStatus> Hr_Employee_Status { get; set; }

        public virtual DbSet<UnExitedEmployeeModel> UnExited_Employee_Model { get; set; }

        public virtual DbSet<ExitedEmployeeModel> Exited_Employee_Model { get; set; }

        public virtual DbSet<HrEmployeeWorkDetails> Hr_Employee_Work_Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Trusted_Connection = True;");
                
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrEmployee>().HasData(

                new HrEmployee
                {

                    Emp_Name = "Sevinj",
                    Emp_Id = 1, 
                    Emp_Surname = "Abdullayeva",
                    Emp_Is_Existed = true
                },
                new HrEmployee
                {

                    Emp_Name = "James",
                    Emp_Id = 2,
                    Emp_Surname = "Bond",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {
                    Emp_Name = "Ilkin",
                    Emp_Id = 3,
                    Emp_Surname = "Mammad",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Zeynab",
                    Emp_Id = 4,
                    Emp_Surname = "Rahim",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Oktay",
                    Emp_Id = 5,
                    Emp_Surname = "Mammadov",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Buse",
                    Emp_Id = 6,
                    Emp_Surname = "Su",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Altay",
                    Emp_Id = 7,
                    Emp_Surname = "Aliyev",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Olive",
                    Emp_Id = 8,
                    Emp_Surname = "Mah",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Tommy",
                    Emp_Id = 9,
                    Emp_Surname = "Tomson",
                    Emp_Is_Existed = true

                },
                new HrEmployee
                {

                    Emp_Name = "Saleh",
                    Emp_Id = 10,
                    Emp_Surname = "Terim",
                    Emp_Is_Existed = true

                }
                );
            modelBuilder.Entity<HrEmployeeWorkDetails>().HasData(
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 1,
                    Wd_Employee_Exit_Detail_Id = 1,
                    Wd_Employee_Id = 1,
                    Wd_Title = "Web designer",
                    Wd_Location = "Budapest",
                    Wd_Work_Mail = "sevinj160@yahoo.com",
                    Wd_Work_Phone = "36203106684",
                    Wd_Employee_Status_Id = 1,
                    Wd_Experience = 1,
                    Wd_About = "junior 1",
                    Wd_Join_Date = new DateTime(2021, 12, 10)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 2,
                    Wd_Employee_Exit_Detail_Id = 2,
                    Wd_Employee_Id = 2,
                    Wd_Title = "Database administrator",
                    Wd_Location = "Debrecen",
                    Wd_Work_Mail = "james@yahoo.com",
                    Wd_Work_Phone = "36207896656",
                    Wd_Employee_Status_Id = 2,
                    Wd_Experience = 2,
                    Wd_About = "junior 2",
                    Wd_Join_Date = new DateTime(2021, 12, 10)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 3,
                    Wd_Employee_Exit_Detail_Id = 3,
                    Wd_Employee_Id = 3,
                    Wd_Title = "Programmer",
                    Wd_Location = "Baku",
                    Wd_Work_Mail = "ilkin@yahoo.com",
                    Wd_Work_Phone = "99450896656",
                    Wd_Employee_Status_Id = 3,
                    Wd_Experience = 3,
                    Wd_About = "junior 3",
                    Wd_Join_Date = new DateTime(2021, 12, 10)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 4,
                    Wd_Employee_Exit_Detail_Id = 4,
                    Wd_Employee_Id = 4,
                    Wd_Title = "Manager",
                    Wd_Location = "Zagatala",
                    Wd_Work_Mail = "zeynab@yahoo.com",
                    Wd_Work_Phone = "99450797756",
                    Wd_Employee_Status_Id = 4,
                    Wd_Experience = 4,
                    Wd_About = "senior 4",
                    Wd_Is_Exited = true,
                    Wd_Join_Date = new DateTime(2021, 12, 10)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 5,
                    Wd_Employee_Exit_Detail_Id = 5,
                    Wd_Employee_Id = 5,
                    Wd_Title = "Developer",
                    Wd_Location = "Prague",
                    Wd_Work_Mail = "oktay@yahoo.com",
                    Wd_Work_Phone = "42045678756",
                    Wd_Employee_Status_Id = 5,
                    Wd_Experience = 5,
                    Wd_About = "senior 5",
                    Wd_Is_Exited = true,
                    Wd_Join_Date = new DateTime(2021, 12, 10)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 6,
                    Wd_Employee_Exit_Detail_Id = 6,
                    Wd_Employee_Id = 6,
                    Wd_Title = "Jr. developer",
                    Wd_Location = "Paris",
                    Wd_Work_Mail = "buse@yahoo.com",
                    Wd_Work_Phone = "1550797756",
                    Wd_Employee_Status_Id = 6,
                    Wd_Experience = 6,
                    Wd_About = "junior 3m",
                    Wd_Join_Date = new DateTime(2021, 12, 6)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 7,
                    Wd_Employee_Exit_Detail_Id = 7,
                    Wd_Employee_Id = 7,
                    Wd_Title = "Assistant",
                    Wd_Location = "Istanbul",
                    Wd_Work_Mail = "altay@yahoo.com",
                    Wd_Work_Phone = "44250797756",
                    Wd_Employee_Status_Id = 7,
                    Wd_Experience = 7,
                    Wd_About = "senior 7",
                    Wd_Join_Date = new DateTime(2021, 12, 7)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 8,
                    Wd_Employee_Exit_Detail_Id = 8,
                    Wd_Employee_Id = 8,
                    Wd_Title = "Director",
                    Wd_Location = "Dresden",
                    Wd_Work_Mail = "olive@yahoo.com",
                    Wd_Work_Phone = "9945457756",
                    Wd_Employee_Status_Id = 8,
                    Wd_Experience = 8,
                    Wd_About = "senior 8",
                    Wd_Join_Date = new DateTime(2021, 12, 8)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 9,
                    Wd_Employee_Exit_Detail_Id = 9,
                    Wd_Employee_Id = 9,
                    Wd_Title = "Teacher",
                    Wd_Location = "New York",
                    Wd_Work_Mail = "tommy@yahoo.com",
                    Wd_Work_Phone = "99450798760",
                    Wd_Employee_Status_Id = 9,
                    Wd_Experience = 9,
                    Wd_About = "senior 9",
                    Wd_Join_Date = new DateTime(2021, 12, 9)
                },
                new HrEmployeeWorkDetails
                {
                    Wd_Id = 10,
                    Wd_Employee_Exit_Detail_Id = 10,
                    Wd_Employee_Id = 10,
                    Wd_Title = "Driver",
                    Wd_Location = "Miskolc",
                    Wd_Work_Mail = "saleh@yahoo.com",
                    Wd_Work_Phone = "3620697756",
                    Wd_Employee_Status_Id = 10,
                    Wd_Experience = 10,
                    Wd_About = "senior 10",
                    Wd_Join_Date = new DateTime(2021, 12, 10)
                }
                );
            modelBuilder.Entity<HrEmployeeCredentials>().HasData(
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 1,
                    Empc_Id = 1,
                    Empc_Mail = "sevinj160@yahoo.com",
                    Empc_Password = "sevinj",
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 2,
                    Empc_Id = 2,
                    Empc_Mail = "james@yahoo.com",
                    Empc_Password = "oktay"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 3,
                    Empc_Id = 3,
                    Empc_Mail = "ilkin@yahoo.com",
                    Empc_Password = "ilkin123"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 4,
                    Empc_Id = 4,
                    Empc_Mail = "zeynab@yahoo.com",
                    Empc_Password = "zeynab1"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 5,
                    Empc_Id = 5,
                    Empc_Mail = "oktay@yahoo.com",
                    Empc_Password = "oktay27"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 6,
                    Empc_Id = 6,
                    Empc_Mail = "buse@yahoo.com",
                    Empc_Password = "buse1"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 7,
                    Empc_Id = 7,
                    Empc_Mail = "altay@yahoo.com",
                    Empc_Password = "altay1"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 8,
                    Empc_Id = 8,
                    Empc_Mail = "olive@yahoo.com",
                    Empc_Password = "olive1"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 9,
                    Empc_Id = 9,
                    Empc_Mail = "tommy@yahoo.com",
                    Empc_Password = "tommy1"
                },
                new HrEmployeeCredentials
                {
                    Empc_Employee_Id = 10,
                    Empc_Id = 10,
                    Empc_Mail = "saleh@yahoo.com",
                    Empc_Password = "saleh1"
                }

                );
            modelBuilder.Entity<HrEmployeeExitDetail>().HasData(
                new HrEmployeeExitDetail
                {
                    Eed_Employee_Work_Details_Id = 1,
                    Eed_Date = new DateTime(2022, 12, 1),
                    Eed_Details = "passport number C234567",
                    Eed_Id = 1,
                    Eed_Interviewer = 1,
                    Eed_Questions = "non"

                },
                new HrEmployeeExitDetail
                {
                    Eed_Employee_Work_Details_Id = 2,
                    Eed_Date = new DateTime(2022, 12, 2),
                    Eed_Details = "passport number C2345676",
                    Eed_Id = 2,
                    Eed_Interviewer = 2,
                    Eed_Questions = "non"

                },
                new HrEmployeeExitDetail
                {
                    Eed_Employee_Work_Details_Id = 3,
                    Eed_Date = new DateTime(2022, 12, 3),
                    Eed_Details = "passport number 546789",
                    Eed_Id = 3,
                    Eed_Interviewer = 3,
                    Eed_Questions = "non"

                },
                new HrEmployeeExitDetail
                {
                    Eed_Employee_Work_Details_Id = 4,
                    Eed_Date = new DateTime(2022, 12, 4),
                    Eed_Details = "passport number 2345678",
                    Eed_Id = 4,
                    Eed_Interviewer = 4,
                    Eed_Questions = "non"

                },
                new HrEmployeeExitDetail
                {
                    Eed_Employee_Work_Details_Id = 5,
                    Eed_Date = new DateTime(2022, 12, 5),
                    Eed_Details = "passport number C2345671",
                    Eed_Id = 5,
                    Eed_Interviewer = 5,
                    Eed_Questions = "non"

                },
                new HrEmployeeExitDetail
                {
                    Eed_Date = new DateTime(2022, 12, 6),
                    Eed_Employee_Work_Details_Id = 6,
                    Eed_Details = "passport number C2656341",
                    Eed_Interviewer = 6,
                    Eed_Questions = "non",
                    Eed_Id = 6
                },
                new HrEmployeeExitDetail
                {
                    Eed_Date = new DateTime(2022, 12, 7),
                    Eed_Employee_Work_Details_Id = 7,
                    Eed_Details = "passport number 34567876",
                    Eed_Interviewer = 7,
                    Eed_Questions = "non",
                    Eed_Id = 7
                },

                new HrEmployeeExitDetail
                {
                    Eed_Date = new DateTime(2022, 12, 8),
                    Eed_Employee_Work_Details_Id = 8,
                    Eed_Details = "passport number 98765431",
                    Eed_Interviewer = 8,
                    Eed_Questions = "non",
                    Eed_Id = 8
                },

                new HrEmployeeExitDetail
                {
                    Eed_Date = new DateTime(2022, 12, 9),
                    Eed_Employee_Work_Details_Id = 9,
                    Eed_Details = "passport number C2309871",
                    Eed_Interviewer = 9,
                    Eed_Questions = "non",
                    Eed_Id = 9
                },
                new HrEmployeeExitDetail
                {
                    Eed_Date = new DateTime(2022, 12, 10),
                    Eed_Employee_Work_Details_Id = 10,
                    Eed_Details = "passport number C2345991",
                    Eed_Interviewer = 10,
                    Eed_Questions = "non",
                    Eed_Id = 10
                }
                );

            modelBuilder.Entity<ExitedEmployeeModel>().HasData(
               new ExitedEmployeeModel
               {
                   Exit_Id = 4,
                   ExitDate = new DateTime(2022, 12, 10),
                   ExitDetail = "passport number 2345678",
                   Name = "Zeynab",
                   Surname = "Rahim"

               },
               new ExitedEmployeeModel
               {
                   Exit_Id = 5,
                   ExitDate = new DateTime(2022, 12, 10),
                   ExitDetail = "passport number C2345671",
                   Name = "Oktay",
                   Surname = "Mammadov"

               }
               );


            modelBuilder.Entity<UnExitedEmployeeModel>().HasData(
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 1,
                   Name = "Sevinj",
                   Surname = "Abdullayeva",
                   Mail = "sevinj@yahoo.com",
                   JoinedDate = new DateTime(2022, 12, 10),
                   Location = "Budapest",
                   Phone = "36203106684",
                   Salary = 2000,
                   Summary = "non",
                   Title = "Sev"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 2,
                   Name = "James",
                   Surname = "Bond",
                   Mail = "james@yahoo.com",
                   JoinedDate = new DateTime(2022, 12, 10),
                   Location = "Debrecen",
                   Phone = "36207896656",
                   Salary = 2500,
                   Summary = "non",
                   Title = "JamesB"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 3,
                   Name = "Ilkin",
                   Surname = "Mammad",
                   Mail = "ilkin@yahoo.com",
                   JoinedDate = new DateTime(2022, 12, 10),
                   Location = "Baku",
                   Phone = "99450896656",
                   Salary = 3000,
                   Summary = "non",
                   Title = "IlkinM"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 6,
                   Name = "Buse",
                   Surname = "Su",
                   Mail = "buse@yahoo.com",
                   JoinedDate = new DateTime(2022, 12, 10),
                   Location = "Paris",
                   Phone = "1550797756",
                   Salary = 300,
                   Summary = "non",
                   Title = "Buse"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 7,
                   Name = "Altay",
                   Surname = "Aliyev",
                   Mail = "altay@yahoo.com",
                   JoinedDate = new DateTime(2022, 12, 7),
                   Location = "Istanbul",
                   Phone = "44250797756",
                   Salary = 10000,
                   Summary = "non",
                   Title = "AltayA"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 8,
                   Name = "OLive",
                   Surname = "Mah",
                   Mail = "olive@yahoo.com",
                   JoinedDate = new DateTime(2022, 12, 8),
                   Location = "Dresden",
                   Phone = "9945457756",
                   Salary = 30000,
                   Summary = "non",
                   Title = "OliveM"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 9,
                   Name = "Tommy",
                   Surname = "Tomson",
                   Mail = "tommy@yahoo.com",
                   JoinedDate = new DateTime(2021, 12, 9),
                   Location = "New York",
                   Phone = "99450798760",
                   Salary = 9000,
                   Summary = "non",
                   Title = "TommyT"
               },
               new UnExitedEmployeeModel
               {
                   Unexit_Id = 10,
                   Name = "Saleh",
                   Surname = "Terim",
                   Mail = "saleh@yahoo.com",
                   JoinedDate = new DateTime(2021, 12, 10),
                   Location = "Miskolc",
                   Phone = "3620697756",
                   Salary = 11000,
                   Summary = "non",
                   Title = "SalehT"
               }
               );
            modelBuilder.Entity<HrEmployeeSalaryRecord>().HasData(
                new HrEmployeeSalaryRecord
                {

                    Esr_Id = 1,
                    Esr_Amount = 2000,
                    Esr_Date = new DateTime(2022, 12, 1),
                    Esr_Employee_Id = 1,
                    Esr_Hours = 1,
                    Esr_Over_Time = 1,
                    Esr_Type = 1

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 2,
                    Esr_Amount = 2500,
                    Esr_Date = new DateTime(2022, 12, 2),
                    Esr_Employee_Id = 2,
                    Esr_Hours = 2,
                    Esr_Over_Time = 2,
                    Esr_Type = 2

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 3,
                    Esr_Amount = 3000,
                    Esr_Date = new DateTime(2022, 12, 3),
                    Esr_Employee_Id = 3,
                    Esr_Hours = 3,
                    Esr_Over_Time = 3,
                    Esr_Type = 3

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 4,
                    Esr_Amount = 4000,
                    Esr_Date = new DateTime(2022, 12, 4),
                    Esr_Employee_Id = 4,
                    Esr_Hours = 4,
                    Esr_Over_Time = 4,
                    Esr_Type = 4

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 5,
                    Esr_Amount = 5000,
                    Esr_Date = new DateTime(2022, 12, 5),
                    Esr_Employee_Id = 5,
                    Esr_Hours = 5,
                    Esr_Over_Time = 5,
                    Esr_Type = 5

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 6,
                    Esr_Amount = 300,
                    Esr_Date = new DateTime(2022, 12, 6),
                    Esr_Employee_Id = 6,
                    Esr_Hours = 6,
                    Esr_Over_Time = 6,
                    Esr_Type = 6

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 7,
                    Esr_Amount = 10000,
                    Esr_Date = new DateTime(2022, 12, 7),
                    Esr_Employee_Id = 7,
                    Esr_Hours = 7,
                    Esr_Over_Time = 7,
                    Esr_Type = 7

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 8,
                    Esr_Amount = 30000,
                    Esr_Date = new DateTime(2022, 12, 8),
                    Esr_Employee_Id = 8,
                    Esr_Hours = 8,
                    Esr_Over_Time = 8,
                    Esr_Type = 8

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 9,
                    Esr_Amount = 9000,
                    Esr_Date = new DateTime(2022, 12, 9),
                    Esr_Employee_Id = 9,
                    Esr_Hours = 9,
                    Esr_Over_Time = 9,
                    Esr_Type = 9

                },
                new HrEmployeeSalaryRecord
                {
                    Esr_Id = 10,
                    Esr_Amount = 11000,
                    Esr_Date = new DateTime(2022, 12, 10),
                    Esr_Employee_Id = 10,
                    Esr_Hours = 10,
                    Esr_Over_Time = 10,
                    Esr_Type = 10

                }


                );
            modelBuilder.Entity<HrEmployeeStatus>().HasData(
                new HrEmployeeStatus
                {
                    Emps_Id = 1,
                    Emps_Description = "1 year experience",
                    Emps_Title = "Web designer"
                },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 2,
                     Emps_Description = "2 years experience",
                     Emps_Title = "Database administrator"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 3,
                     Emps_Description = "3 years experience",
                     Emps_Title = "Programmer"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 4,
                     Emps_Description = "4 years experience",
                     Emps_Title = "Manager"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 5,
                     Emps_Description = "5 years experience",
                     Emps_Title = "Developer"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 6,
                     Emps_Description = "3 months experience",
                     Emps_Title = "Jr. developer"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 7,
                     Emps_Description = "7 years experience",
                     Emps_Title = "Assistant"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 8,
                     Emps_Description = "8 years experience",
                     Emps_Title = "Director"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 9,
                     Emps_Description = "9 years experience",
                     Emps_Title = "Teacher"
                 },
                 new HrEmployeeStatus
                 {
                     Emps_Id = 10,
                     Emps_Description = "10 years experience",
                     Emps_Title = "Driver"
                 }
                );

        }

    }
}