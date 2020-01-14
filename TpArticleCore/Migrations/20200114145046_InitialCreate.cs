using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TpArticleCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PositionMagasin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdArticle = table.Column<int>(nullable: false),
                    IdEtagere = table.Column<int>(nullable: false),
                    Quantite = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionMagasin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secteur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secteur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etagere",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PoidsMaximum = table.Column<decimal>(nullable: false),
                    IdSecteur = table.Column<int>(nullable: false),
                    SecteurId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etagere", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etagere_Secteur_SecteurId",
                        column: x => x.SecteurId,
                        principalTable: "Secteur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    DateSortie = table.Column<DateTime>(nullable: false),
                    PrixInitial = table.Column<decimal>(nullable: false),
                    Poids = table.Column<decimal>(nullable: false),
                    EtagereId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_Etagere_EtagereId",
                        column: x => x.EtagereId,
                        principalTable: "Etagere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_EtagereId",
                table: "Article",
                column: "EtagereId");

            migrationBuilder.CreateIndex(
                name: "IX_Etagere_SecteurId",
                table: "Etagere",
                column: "SecteurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "PositionMagasin");

            migrationBuilder.DropTable(
                name: "Etagere");

            migrationBuilder.DropTable(
                name: "Secteur");
        }
    }
}
