using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TBCargo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBProjeto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeProjeto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProjeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBUsuario",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBUsuario_TBCargo_CargoId",
                        column: x => x.CargoId,
                        principalSchema: "dbo",
                        principalTable: "TBCargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBTarefa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConlusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    prioridade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTarefa_TBProjeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalSchema: "dbo",
                        principalTable: "TBProjeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBHistorico",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    descricaoAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAltracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBHistorico_TBTarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalSchema: "dbo",
                        principalTable: "TBTarefa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBHistorico_TBUsuario_usuarioId",
                        column: x => x.usuarioId,
                        principalSchema: "dbo",
                        principalTable: "TBUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBHistorico_TarefaId",
                schema: "dbo",
                table: "TBHistorico",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBHistorico_usuarioId",
                schema: "dbo",
                table: "TBHistorico",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTarefa_ProjetoId",
                schema: "dbo",
                table: "TBTarefa",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBUsuario_CargoId",
                schema: "dbo",
                table: "TBUsuario",
                column: "CargoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBHistorico",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBTarefa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBUsuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBProjeto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBCargo",
                schema: "dbo");
        }
    }
}
