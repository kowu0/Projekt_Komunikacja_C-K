using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_KCK.Migrations
{
    /// <inheritdoc />
    public partial class finalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Konfigurator");

            migrationBuilder.CreateTable(
                name: "Cases",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FormFactor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaxGPULength = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxCPUCoolerHeight = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurator",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CpuId = table.Column<int>(type: "INTEGER", nullable: false),
                    MotherboardId = table.Column<int>(type: "INTEGER", nullable: false),
                    RamId = table.Column<int>(type: "INTEGER", nullable: false),
                    GpuId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoolerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    DiskId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coolers",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FanSize = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxRPM = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cpus",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cores = table.Column<int>(type: "INTEGER", nullable: false),
                    ClockSpeed = table.Column<float>(type: "REAL", nullable: false),
                    Socket = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disk",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ReadSpeed = table.Column<float>(type: "REAL", nullable: false),
                    WriteSpeed = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MemorySize = table.Column<int>(type: "INTEGER", nullable: false),
                    MemoryType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CoreClock = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FormFactor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Socket = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RAMSlots = table.Column<int>(type: "INTEGER", nullable: false),
                    Chipset = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    EfficiencyRating = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FormFactor = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamMemories",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamMemories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredUser",
                schema: "Konfigurator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredUser", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "Configurator",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "Coolers",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "Cpus",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "Disk",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "Gpus",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "Motherboards",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "PowerSupplies",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "RamMemories",
                schema: "Konfigurator");

            migrationBuilder.DropTable(
                name: "RegisteredUser",
                schema: "Konfigurator");
        }
    }
}
