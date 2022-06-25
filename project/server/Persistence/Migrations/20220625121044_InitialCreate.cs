using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoggedMinutes = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLogs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1ae2"), "Porche" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("01e3903b-fabf-43bf-ad1f-550eee74f6bc"), "Tesco" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6dd0b608-04a8-42e1-bcaf-971367bd8302"), "ING" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("be8a467f-0f93-4993-b516-5ba58e88abf0"), "Nike" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c6aee1bb-a570-49f4-b3b8-6448e336c42b"), "BMW" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("daa4e8ca-929f-43f1-816d-c580f11ff905"), "Addidas" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1"), new Guid("daa4e8ca-929f-43f1-816d-c580f11ff905"), true, new DateTime(2022, 7, 14, 10, 0, 0, 898, DateTimeKind.Local), "Site update" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb"), new Guid("01e3903b-fabf-43bf-ad1f-550eee74f6bc"), false, new DateTime(2022, 7, 22, 9, 0, 0, 898, DateTimeKind.Local), "External portal" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("2593faee-7b0d-4a56-81d8-9466c82a2ac4"), new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1ae2"), false, new DateTime(2022, 7, 1, 16, 0, 0, 898, DateTimeKind.Local), "Car Preview" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b"), new Guid("c6aee1bb-a570-49f4-b3b8-6448e336c42b"), false, new DateTime(2022, 6, 28, 16, 0, 0, 898, DateTimeKind.Local), "SSO Auth" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775"), new Guid("6dd0b608-04a8-42e1-bcaf-971367bd8302"), false, new DateTime(2022, 8, 10, 12, 0, 0, 898, DateTimeKind.Local), "Proctocol Update" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("7f650e8b-f17c-48e5-a343-e7658d9feb39"), new Guid("be8a467f-0f93-4993-b516-5ba58e88abf0"), false, new DateTime(2022, 8, 1, 7, 0, 0, 898, DateTimeKind.Local), "Shoe Designer Tool" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("b23817f7-1eae-4de4-bd4a-a1d8544604ee"), new Guid("c6aee1bb-a570-49f4-b3b8-6448e336c42b"), false, new DateTime(2022, 7, 9, 11, 0, 0, 898, DateTimeKind.Local), "Admin Panel" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd"), new Guid("01e3903b-fabf-43bf-ad1f-550eee74f6bc"), false, new DateTime(2022, 7, 12, 15, 0, 0, 898, DateTimeKind.Local), "Main project" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompanyId", "Completed", "Deadline", "Name" },
                values: new object[] { new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6"), new Guid("c6aee1bb-a570-49f4-b3b8-6448e336c42b"), false, new DateTime(2022, 7, 5, 18, 0, 0, 898, DateTimeKind.Local), "Project Update" });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a00"), new DateTime(2022, 7, 14, 10, 0, 0, 898, DateTimeKind.Local), 30L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a01"), new DateTime(2022, 7, 15, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a02"), new DateTime(2022, 7, 16, 10, 0, 0, 898, DateTimeKind.Local), 90L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a03"), new DateTime(2022, 7, 17, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a04"), new DateTime(2022, 7, 18, 10, 0, 0, 898, DateTimeKind.Local), 100L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a05"), new DateTime(2022, 7, 19, 10, 0, 0, 898, DateTimeKind.Local), 20L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a06"), new DateTime(2022, 7, 20, 10, 0, 0, 898, DateTimeKind.Local), 50L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a07"), new DateTime(2022, 7, 22, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a08"), new DateTime(2022, 7, 23, 10, 0, 0, 898, DateTimeKind.Local), 40L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a10"), new DateTime(2022, 7, 14, 11, 0, 0, 898, DateTimeKind.Local), 120L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a11"), new DateTime(2022, 7, 15, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a12"), new DateTime(2022, 7, 16, 10, 0, 0, 898, DateTimeKind.Local), 90L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a13"), new DateTime(2022, 7, 17, 10, 0, 0, 898, DateTimeKind.Local), 120L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a14"), new DateTime(2022, 7, 18, 10, 0, 0, 898, DateTimeKind.Local), 130L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a15"), new DateTime(2022, 7, 19, 10, 0, 0, 898, DateTimeKind.Local), 200L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a16"), new DateTime(2022, 7, 20, 10, 0, 0, 898, DateTimeKind.Local), 160L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a17"), new DateTime(2022, 7, 22, 10, 0, 0, 898, DateTimeKind.Local), 210L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a18"), new DateTime(2022, 7, 23, 10, 0, 0, 898, DateTimeKind.Local), 240L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a19"), new DateTime(2022, 7, 24, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("c76cab95-4a52-4344-a803-ab78e06c59fd") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a20"), new DateTime(2022, 7, 14, 10, 0, 0, 898, DateTimeKind.Local), 120L, new Guid("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a21"), new DateTime(2022, 7, 15, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a22"), new DateTime(2022, 7, 16, 10, 0, 0, 898, DateTimeKind.Local), 90L, new Guid("5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a30"), new DateTime(2022, 7, 14, 10, 0, 0, 898, DateTimeKind.Local), 120L, new Guid("2593faee-7b0d-4a56-81d8-9466c82a2ac4") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a31"), new DateTime(2022, 7, 15, 10, 0, 0, 898, DateTimeKind.Local), 60L, new Guid("2593faee-7b0d-4a56-81d8-9466c82a2ac4") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a40"), new DateTime(2022, 7, 14, 10, 0, 0, 898, DateTimeKind.Local), 20L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a41"), new DateTime(2022, 7, 13, 10, 0, 0, 898, DateTimeKind.Local), 35L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a42"), new DateTime(2022, 7, 14, 10, 0, 0, 898, DateTimeKind.Local), 150L, new Guid("1c070edb-5e19-43f7-9727-cbc585524ebb") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a43"), new DateTime(2022, 7, 18, 10, 0, 0, 898, DateTimeKind.Local), 135L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a44"), new DateTime(2022, 7, 20, 10, 0, 0, 898, DateTimeKind.Local), 170L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a45"), new DateTime(2022, 7, 21, 10, 0, 0, 898, DateTimeKind.Local), 120L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a46"), new DateTime(2022, 7, 22, 10, 0, 0, 898, DateTimeKind.Local), 90L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a47"), new DateTime(2022, 7, 24, 10, 0, 0, 898, DateTimeKind.Local), 100L, new Guid("59dedd79-bce9-4c6e-8004-e91196dc7d3b") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a50"), new DateTime(2022, 7, 1, 10, 0, 0, 898, DateTimeKind.Local), 35L, new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a51"), new DateTime(2022, 7, 2, 10, 0, 0, 898, DateTimeKind.Local), 55L, new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a52"), new DateTime(2022, 7, 3, 10, 0, 0, 898, DateTimeKind.Local), 115L, new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a53"), new DateTime(2022, 7, 5, 10, 0, 0, 898, DateTimeKind.Local), 45L, new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a54"), new DateTime(2022, 7, 8, 10, 0, 0, 898, DateTimeKind.Local), 40L, new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a55"), new DateTime(2022, 7, 9, 10, 0, 0, 898, DateTimeKind.Local), 50L, new Guid("d8d28769-5d6b-4f36-b1e2-6df9f9fec2a6") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a60"), new DateTime(2022, 6, 1, 10, 0, 0, 898, DateTimeKind.Local), 480L, new Guid("b23817f7-1eae-4de4-bd4a-a1d8544604ee") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a61"), new DateTime(2022, 6, 8, 10, 0, 0, 898, DateTimeKind.Local), 300L, new Guid("b23817f7-1eae-4de4-bd4a-a1d8544604ee") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a62"), new DateTime(2022, 6, 13, 10, 0, 0, 898, DateTimeKind.Local), 360L, new Guid("b23817f7-1eae-4de4-bd4a-a1d8544604ee") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a63"), new DateTime(2022, 6, 15, 10, 0, 0, 898, DateTimeKind.Local), 300L, new Guid("b23817f7-1eae-4de4-bd4a-a1d8544604ee") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a70"), new DateTime(2022, 7, 1, 10, 0, 0, 898, DateTimeKind.Local), 120L, new Guid("7f650e8b-f17c-48e5-a343-e7658d9feb39") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a80"), new DateTime(2022, 7, 2, 15, 0, 0, 898, DateTimeKind.Local), 180L, new Guid("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a81"), new DateTime(2022, 7, 4, 15, 0, 0, 898, DateTimeKind.Local), 240L, new Guid("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1") });

            migrationBuilder.InsertData(
                table: "TimeLogs",
                columns: new[] { "Id", "CreatedAt", "LoggedMinutes", "ProjectId" },
                values: new object[] { new Guid("01cfd494-fca0-4a3f-9a2d-1763d62f1a82"), new DateTime(2022, 7, 5, 15, 0, 0, 898, DateTimeKind.Local), 210L, new Guid("0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1") });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CompanyId",
                table: "Projects",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_ProjectId",
                table: "TimeLogs",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeLogs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
