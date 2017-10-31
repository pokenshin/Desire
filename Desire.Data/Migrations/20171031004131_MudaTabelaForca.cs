using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Desire.Data.Migrations
{
    public partial class MudaTabelaForca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusAP_ValorReal",
                table: "TabelaForca");

            migrationBuilder.DropColumn(
                name: "Dureza_ValorReal",
                table: "TabelaForca");

            migrationBuilder.DropColumn(
                name: "Golpe_ValorReal",
                table: "TabelaForca");

            migrationBuilder.DropColumn(
                name: "Porcentagem_ValorReal",
                table: "TabelaForca");

            migrationBuilder.DropColumn(
                name: "Potencia_ValorReal",
                table: "TabelaForca");

            migrationBuilder.DropColumn(
                name: "Sustentacao_ValorReal",
                table: "TabelaForca");

            migrationBuilder.DropColumn(
                name: "Vigor_ValorReal",
                table: "TabelaForca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BonusAP_ValorReal",
                table: "TabelaForca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dureza_ValorReal",
                table: "TabelaForca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Golpe_ValorReal",
                table: "TabelaForca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Porcentagem_ValorReal",
                table: "TabelaForca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Potencia_ValorReal",
                table: "TabelaForca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sustentacao_ValorReal",
                table: "TabelaForca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vigor_ValorReal",
                table: "TabelaForca",
                nullable: true);
        }
    }
}
