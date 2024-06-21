using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketAPI.Data.migrations
{
    /// <inheritdoc />
    public partial class StorageAndServicesv73 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    IdStorage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.IdStorage);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    NameUser = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordSalt = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NameFantasy = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    CNPJ = table.Column<int>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordSalt = table.Column<string>(type: "TEXT", nullable: true),
                    IdStorage = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_Storage_IdStorage",
                        column: x => x.IdStorage,
                        principalTable: "Storage",
                        principalColumn: "IdStorage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameProduto = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Qnt = table.Column<int>(type: "INTEGER", nullable: false),
                    IdStorage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Storage_IdStorage",
                        column: x => x.IdStorage,
                        principalTable: "Storage",
                        principalColumn: "IdStorage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdServices = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientIdClient = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdServices);
                    table.ForeignKey(
                        name: "FK_Services_Client_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdStorage",
                table: "Client",
                column: "IdStorage",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdStorage",
                table: "Produto",
                column: "IdStorage");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ClientIdClient",
                table: "Services",
                column: "ClientIdClient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
