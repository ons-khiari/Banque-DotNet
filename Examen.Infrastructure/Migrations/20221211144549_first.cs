using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banques",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banques", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DABs",
                columns: table => new
                {
                    DABId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agence = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DABs", x => x.DABId);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Proprietaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BanqueFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.NumeroCompte);
                    table.ForeignKey(
                        name: "FK_Comptes_Banques_BanqueFk",
                        column: x => x.BanqueFk,
                        principalTable: "Banques",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DabFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Prix = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => new { x.DabFK, x.NumeroCompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_Transactions_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_DABs_DabFK",
                        column: x => x.DabFK,
                        principalTable: "DABs",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRetrait",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DabFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutreAgence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRetrait", x => new { x.DabFK, x.NumeroCompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_DABs_DabFK",
                        column: x => x.DabFK,
                        principalTable: "DABs",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_Transactions_DabFK_NumeroCompteFk_Date",
                        columns: x => new { x.DabFK, x.NumeroCompteFk, x.Date },
                        principalTable: "Transactions",
                        principalColumns: new[] { "DabFK", "NumeroCompteFk", "Date" });
                });

            migrationBuilder.CreateTable(
                name: "TransactionTransfert",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DabFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTransfert", x => new { x.DabFK, x.NumeroCompteFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_DABs_DabFK",
                        column: x => x.DabFK,
                        principalTable: "DABs",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_Transactions_DabFK_NumeroCompteFk_Date",
                        columns: x => new { x.DabFK, x.NumeroCompteFk, x.Date },
                        principalTable: "Transactions",
                        principalColumns: new[] { "DabFK", "NumeroCompteFk", "Date" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_BanqueFk",
                table: "Comptes",
                column: "BanqueFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRetrait_NumeroCompteFk",
                table: "TransactionRetrait",
                column: "NumeroCompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_NumeroCompteFk",
                table: "Transactions",
                column: "NumeroCompteFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTransfert_NumeroCompteFk",
                table: "TransactionTransfert",
                column: "NumeroCompteFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionRetrait");

            migrationBuilder.DropTable(
                name: "TransactionTransfert");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "DABs");

            migrationBuilder.DropTable(
                name: "Banques");
        }
    }
}
