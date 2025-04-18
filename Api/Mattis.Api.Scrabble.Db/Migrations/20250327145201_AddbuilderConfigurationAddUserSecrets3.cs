﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mattis.Api.Scrabble.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddbuilderConfigurationAddUserSecrets3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MultipleHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Multiple = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleHistory", x => x.Id);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultipleHistory");
        }
    }
}
