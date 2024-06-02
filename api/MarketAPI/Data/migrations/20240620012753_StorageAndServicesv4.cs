﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class StorageAndServicesv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_IdClient",
                table: "Services",
                column: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Client_IdClient",
                table: "Services",
                column: "IdClient",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Client_IdClient",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_IdClient",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Services");
        }
    }
}
