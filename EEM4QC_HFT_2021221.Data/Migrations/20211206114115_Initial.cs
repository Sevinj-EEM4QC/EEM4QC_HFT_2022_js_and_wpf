using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EEM4QC_HFT_2021221.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exited_Employee_Model",
                columns: table => new
                {
                    Exit_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exited_Employee_Model", x => x.Exit_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employee_Exit_Detail",
                columns: table => new
                {
                    Eed_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eed_Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eed_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eed_Questions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eed_Interviewer = table.Column<int>(type: "int", nullable: false),
                    Eed_Employee_Work_Details_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Employee_Exit_Detail", x => x.Eed_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employee_Salary_Record",
                columns: table => new
                {
                    Esr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Esr_Currency = table.Column<double>(type: "float", nullable: false),
                    Esr_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Esr_Hours = table.Column<byte>(type: "tinyint", nullable: false),
                    Esr_Over_Time = table.Column<int>(type: "int", nullable: false),
                    Esr_Amount = table.Column<double>(type: "float", nullable: false),
                    Esr_Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Esr_Frequency = table.Column<byte>(type: "tinyint", nullable: false),
                    Esr_Employee_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Employee_Salary_Record", x => x.Esr_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employee_Status",
                columns: table => new
                {
                    Emps_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emps_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emps_Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Employee_Status", x => x.Emps_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employee_Work_Details",
                columns: table => new
                {
                    Wd_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wd_Manager = table.Column<int>(type: "int", nullable: false),
                    Wd_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wd_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wd_Join_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wd_Experience = table.Column<int>(type: "int", nullable: false),
                    Wd_Work_Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wd_Work_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wd_Summary_Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wd_About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wd_Employee_Status_Id = table.Column<int>(type: "int", nullable: false),
                    Wd_Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Wd_Is_Exited = table.Column<bool>(type: "bit", nullable: false),
                    Wd_Employee_Exit_Detail_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Employee_Work_Details", x => x.Wd_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employees",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emp_Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emp_Is_Existed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Employees", x => x.Emp_Id);
                });

            migrationBuilder.CreateTable(
                name: "UnExited_Employee_Model",
                columns: table => new
                {
                    Unexit_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnExited_Employee_Model", x => x.Unexit_Id);
                });

            migrationBuilder.CreateTable(
                name: "Hr_Employee_Credentials",
                columns: table => new
                {
                    Empc_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empc_Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empc_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Empc_Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Empc_EmployeeEmp_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hr_Employee_Credentials", x => x.Empc_Id);
                    table.ForeignKey(
                        name: "FK_Hr_Employee_Credentials_Hr_Employees_Empc_EmployeeEmp_Id",
                        column: x => x.Empc_EmployeeEmp_Id,
                        principalTable: "Hr_Employees",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Exited_Employee_Model",
                columns: new[] { "Exit_Id", "ExitDate", "ExitDetail", "Name", "Surname" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number 2345678", "Zeynab", "Rahim" },
                    { 5, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C2345671", "Oktay", "Mammadov" }
                });

            migrationBuilder.InsertData(
                table: "Hr_Employee_Credentials",
                columns: new[] { "Empc_Id", "Empc_EmployeeEmp_Id", "Empc_Employee_Id", "Empc_Mail", "Empc_Password" },
                values: new object[,]
                {
                    { 10, null, 10, "saleh@yahoo.com", "saleh1" },
                    { 9, null, 9, "tommy@yahoo.com", "tommy1" },
                    { 8, null, 8, "olive@yahoo.com", "olive1" },
                    { 7, null, 7, "altay@yahoo.com", "altay1" },
                    { 6, null, 6, "buse@yahoo.com", "buse1" },
                    { 5, null, 5, "oktay@yahoo.com", "oktay27" },
                    { 3, null, 3, "ilkin@yahoo.com", "ilkin123" },
                    { 2, null, 2, "james@yahoo.com", "oktay" },
                    { 1, null, 1, "sevinj160@yahoo.com", "sevinj" },
                    { 4, null, 4, "zeynab@yahoo.com", "zeynab1" }
                });

            migrationBuilder.InsertData(
                table: "Hr_Employee_Exit_Detail",
                columns: new[] { "Eed_Id", "Eed_Date", "Eed_Details", "Eed_Employee_Work_Details_Id", "Eed_Interviewer", "Eed_Questions" },
                values: new object[,]
                {
                    { 9, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C2309871", 9, 9, "non" },
                    { 7, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number 34567876", 7, 7, "non" },
                    { 6, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C2656341", 6, 6, "non" },
                    { 8, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number 98765431", 8, 8, "non" },
                    { 5, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C2345671", 5, 5, "non" },
                    { 4, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number 2345678", 4, 4, "non" },
                    { 3, new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number 546789", 3, 3, "non" },
                    { 2, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C2345676", 2, 2, "non" },
                    { 1, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C234567", 1, 1, "non" },
                    { 10, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "passport number C2345991", 10, 10, "non" }
                });

            migrationBuilder.InsertData(
                table: "Hr_Employee_Salary_Record",
                columns: new[] { "Esr_Id", "Esr_Amount", "Esr_Currency", "Esr_Date", "Esr_Employee_Id", "Esr_Frequency", "Esr_Hours", "Esr_Over_Time", "Esr_Type" },
                values: new object[,]
                {
                    { 10, 11000.0, 0.0, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, (byte)0, (byte)10, 10, (byte)10 },
                    { 8, 30000.0, 0.0, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, (byte)0, (byte)8, 8, (byte)8 },
                    { 7, 10000.0, 0.0, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, (byte)0, (byte)7, 7, (byte)7 },
                    { 6, 300.0, 0.0, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, (byte)0, (byte)6, 6, (byte)6 },
                    { 5, 5000.0, 0.0, new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, (byte)0, (byte)5, 5, (byte)5 },
                    { 4, 4000.0, 0.0, new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, (byte)0, (byte)4, 4, (byte)4 },
                    { 2, 2500.0, 0.0, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, (byte)0, (byte)2, 2, (byte)2 },
                    { 9, 9000.0, 0.0, new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, (byte)0, (byte)9, 9, (byte)9 },
                    { 1, 2000.0, 0.0, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, (byte)0, (byte)1, 1, (byte)1 },
                    { 3, 3000.0, 0.0, new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, (byte)0, (byte)3, 3, (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "Hr_Employee_Status",
                columns: new[] { "Emps_Id", "Emps_Description", "Emps_Title" },
                values: new object[,]
                {
                    { 9, "9 years experience", "Teacher" },
                    { 8, "8 years experience", "Director" },
                    { 7, "7 years experience", "Assistant" },
                    { 6, "3 months experience", "Jr. developer" },
                    { 5, "5 years experience", "Developer" },
                    { 4, "4 years experience", "Manager" },
                    { 3, "3 years experience", "Programmer" },
                    { 2, "2 years experience", "Database administrator" },
                    { 1, "1 year experience", "Web designer" },
                    { 10, "10 years experience", "Driver" }
                });

            migrationBuilder.InsertData(
                table: "Hr_Employee_Work_Details",
                columns: new[] { "Wd_Id", "Wd_About", "Wd_Employee_Exit_Detail_Id", "Wd_Employee_Id", "Wd_Employee_Status_Id", "Wd_Experience", "Wd_Is_Exited", "Wd_Join_Date", "Wd_Location", "Wd_Manager", "Wd_Summary_Job", "Wd_Title", "Wd_Work_Mail", "Wd_Work_Phone" },
                values: new object[,]
                {
                    { 3, "junior 3", 3, 3, 3, 3, false, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baku", 0, null, "Programmer", "ilkin@yahoo.com", "99450896656" },
                    { 4, "senior 4", 4, 4, 4, 4, true, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagatala", 0, null, "Manager", "zeynab@yahoo.com", "99450797756" },
                    { 5, "senior 5", 5, 5, 5, 5, true, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prague", 0, null, "Developer", "oktay@yahoo.com", "42045678756" },
                    { 6, "junior 3m", 6, 6, 6, 6, false, new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paris", 0, null, "Jr. developer", "buse@yahoo.com", "1550797756" },
                    { 7, "senior 7", 7, 7, 7, 7, false, new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", 0, null, "Assistant", "altay@yahoo.com", "44250797756" },
                    { 8, "senior 8", 8, 8, 8, 8, false, new DateTime(2021, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dresden", 0, null, "Director", "olive@yahoo.com", "9945457756" },
                    { 9, "senior 9", 9, 9, 9, 9, false, new DateTime(2021, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", 0, null, "Teacher", "tommy@yahoo.com", "99450798760" },
                    { 10, "senior 10", 10, 10, 10, 10, false, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miskolc", 0, null, "Driver", "saleh@yahoo.com", "3620697756" },
                    { 1, "junior 1", 1, 1, 1, 1, false, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Budapest", 0, null, "Web designer", "sevinj160@yahoo.com", "36203106684" },
                    { 2, "junior 2", 2, 2, 2, 2, false, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debrecen", 0, null, "Database administrator", "james@yahoo.com", "36207896656" }
                });

            migrationBuilder.InsertData(
                table: "Hr_Employees",
                columns: new[] { "Emp_Id", "Emp_Is_Existed", "Emp_Name", "Emp_Surname" },
                values: new object[,]
                {
                    { 9, true, "Tommy", "Tomson" },
                    { 1, true, "Sevinj", "Abdullayeva" },
                    { 10, true, "Saleh", "Terim" },
                    { 7, true, "Altay", "Aliyev" },
                    { 6, true, "Buse", "Su" },
                    { 8, true, "Olive", "Mah" },
                    { 4, true, "Zeynab", "Rahim" },
                    { 3, true, "Ilkin", "Mammad" },
                    { 2, true, "James", "Bond" },
                    { 5, true, "Oktay", "Mammadov" }
                });

            migrationBuilder.InsertData(
                table: "UnExited_Employee_Model",
                columns: new[] { "Unexit_Id", "JoinedDate", "Location", "Mail", "Name", "Phone", "Salary", "Summary", "Surname", "Title" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "New York", "tommy@yahoo.com", "Tommy", "99450798760", 9000.0, "non", "Tomson", "TommyT" },
                    { 1, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Budapest", "sevinj@yahoo.com", "Sevinj", "36203106684", 2000.0, "non", "Abdullayeva", "Sev" },
                    { 2, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debrecen", "james@yahoo.com", "James", "36207896656", 2500.0, "non", "Bond", "JamesB" },
                    { 3, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baku", "ilkin@yahoo.com", "Ilkin", "99450896656", 3000.0, "non", "Mammad", "IlkinM" },
                    { 6, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paris", "buse@yahoo.com", "Buse", "1550797756", 300.0, "non", "Su", "Buse" },
                    { 7, new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istanbul", "altay@yahoo.com", "Altay", "44250797756", 10000.0, "non", "Aliyev", "AltayA" },
                    { 8, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dresden", "olive@yahoo.com", "OLive", "9945457756", 30000.0, "non", "Mah", "OliveM" },
                    { 10, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miskolc", "saleh@yahoo.com", "Saleh", "3620697756", 11000.0, "non", "Terim", "SalehT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hr_Employee_Credentials_Empc_EmployeeEmp_Id",
                table: "Hr_Employee_Credentials",
                column: "Empc_EmployeeEmp_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exited_Employee_Model");

            migrationBuilder.DropTable(
                name: "Hr_Employee_Credentials");

            migrationBuilder.DropTable(
                name: "Hr_Employee_Exit_Detail");

            migrationBuilder.DropTable(
                name: "Hr_Employee_Salary_Record");

            migrationBuilder.DropTable(
                name: "Hr_Employee_Status");

            migrationBuilder.DropTable(
                name: "Hr_Employee_Work_Details");

            migrationBuilder.DropTable(
                name: "UnExited_Employee_Model");

            migrationBuilder.DropTable(
                name: "Hr_Employees");
        }
    }
}
