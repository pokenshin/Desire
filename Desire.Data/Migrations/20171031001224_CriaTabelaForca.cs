using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Desire.Data.Migrations
{
    public partial class CriaTabelaForca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaForca",
                columns: table => new
                {
                    Pontos = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Classe = table.Column<char>(type: "INTEGER", nullable: false),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    BonusAP_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    BonusAP_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    BonusAP_ValorReal = table.Column<string>(type: "TEXT", nullable: true),
                    Dureza_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Dureza_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Dureza_ValorReal = table.Column<string>(type: "TEXT", nullable: true),
                    Golpe_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Golpe_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Golpe_ValorReal = table.Column<string>(type: "TEXT", nullable: true),
                    Porcentagem_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Porcentagem_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Porcentagem_ValorReal = table.Column<string>(type: "TEXT", nullable: true),
                    Potencia_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Potencia_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Potencia_ValorReal = table.Column<string>(type: "TEXT", nullable: true),
                    Sustentacao_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Sustentacao_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Sustentacao_ValorReal = table.Column<string>(type: "TEXT", nullable: true),
                    Vigor_Magnitude = table.Column<int>(type: "INTEGER", nullable: false),
                    Vigor_Valor = table.Column<int>(type: "INTEGER", nullable: false),
                    Vigor_ValorReal = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaForca", x => x.Pontos);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaForca");
        }
    }
}
