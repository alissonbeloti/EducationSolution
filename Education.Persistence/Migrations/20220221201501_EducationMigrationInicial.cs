using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "DataCriacao", "DataPublicacao", "Descricao", "Preco", "Titulo" },
                values: new object[] { new Guid("2a010d37-448d-4e5d-b5f3-46fd4920c6e8"), new DateTime(2022, 2, 21, 17, 15, 1, 218, DateTimeKind.Local).AddTicks(6797), new DateTime(2024, 2, 21, 17, 15, 1, 218, DateTimeKind.Local).AddTicks(6807), "Curso C# Basic", 56m, "C# do 0 ao avançado" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "DataCriacao", "DataPublicacao", "Descricao", "Preco", "Titulo" },
                values: new object[] { new Guid("3bfc679c-5345-41ff-91ba-5e4e8e8af286"), new DateTime(2022, 2, 21, 17, 15, 1, 218, DateTimeKind.Local).AddTicks(6839), new DateTime(2024, 2, 21, 17, 15, 1, 218, DateTimeKind.Local).AddTicks(6839), "Curso Java", 25m, "Master in Java Springs desde as raizes" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "DataCriacao", "DataPublicacao", "Descricao", "Preco", "Titulo" },
                values: new object[] { new Guid("4120f8c1-10e5-497e-8652-8e3ddac68ef4"), new DateTime(2022, 2, 21, 17, 15, 1, 218, DateTimeKind.Local).AddTicks(6843), new DateTime(2024, 2, 21, 17, 15, 1, 218, DateTimeKind.Local).AddTicks(6844), "Curso de Unit Test para Net Core", 1000m, "Master in Unit Test com CQRS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
