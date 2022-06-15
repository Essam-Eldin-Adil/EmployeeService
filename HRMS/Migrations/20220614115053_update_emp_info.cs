using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.API.Migrations
{
    public partial class update_emp_info : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "employees",
                newName: "PositionName");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "employees",
                newName: "DepartmentName");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "employees",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmpName",
                table: "employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "EmpName",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "PositionName",
                table: "employees",
                newName: "MyProperty");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "employees",
                newName: "FullName");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
