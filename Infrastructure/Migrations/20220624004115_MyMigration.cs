using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 24, 0, 41, 15, 552, DateTimeKind.Utc).AddTicks(4435))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    ClassificacaoIndicativa = table.Column<int>(type: "int", nullable: false),
                    Lancamento = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Id_Filme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_idx",
                        column: x => x.Id_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filme_idx",
                        column: x => x.Id_Filme,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nome",
                table: "Cliente",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_ClassificacaoIndicativa",
                table: "Filme",
                column: "ClassificacaoIndicativa");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_Id_Cliente",
                table: "Locacao",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_Id_Filme",
                table: "Locacao",
                column: "Id_Filme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
