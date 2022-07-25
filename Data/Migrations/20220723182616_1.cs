using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_Code = table.Column<int>(type: "int", nullable: false),
                    Price_Per_Sms = table.Column<decimal>(type: "decimal(6,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Smss",
                columns: table => new
                {
                    SmsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smss", x => x.SmsId);
                    table.ForeignKey(
                        name: "FK_Smss_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Country_Code", "Name", "Price_Per_Sms" },
                values: new object[] { 260, 48, "Poland", 0.032m });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Country_Code", "Name", "Price_Per_Sms" },
                values: new object[] { 232, 43, "Austria", 0.053m });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Country_Code", "Name", "Price_Per_Sms" },
                values: new object[] { 262, 49, "Germany", 0.055m });

            migrationBuilder.InsertData(
                table: "Smss",
                columns: new[] { "SmsId", "CountryId", "From", "SendTime", "Status", "Text", "To" },
                values: new object[] { 2, 232, "straja", new DateTime(2022, 7, 23, 20, 26, 15, 722, DateTimeKind.Local).AddTicks(1306), 0, "dahhahaha", "tea" });

            migrationBuilder.InsertData(
                table: "Smss",
                columns: new[] { "SmsId", "CountryId", "From", "SendTime", "Status", "Text", "To" },
                values: new object[] { 1, 262, "straja", new DateTime(2022, 7, 23, 20, 26, 15, 720, DateTimeKind.Local).AddTicks(3798), 1, "dsadsa", "tea" });

            migrationBuilder.CreateIndex(
                name: "IX_Smss_CountryId",
                table: "Smss",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smss");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
