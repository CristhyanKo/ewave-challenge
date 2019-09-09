using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bibliotech.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Biografia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: false),
                    DataPublicacao = table.Column<DateTime>(nullable: false),
                    Paginas = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Sinopse = table.Column<string>(nullable: false),
                    Capa = table.Column<string>(nullable: false),
                    AutorId = table.Column<int>(nullable: false),
                    EditoraId = table.Column<int>(nullable: false),
                    GeneroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Editora_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LivroId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroLinks_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "Id", "Biografia", "DataNascimento", "Nome" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1839, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Machado de Assis" },
                    { 2, null, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Drummond de Andrade" },
                    { 3, null, new DateTime(1937, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clarice Lispector" },
                    { 4, null, new DateTime(1985, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "João Guimarães Rosa" }
                });

            migrationBuilder.InsertData(
                table: "Editora",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 6, "Imago" },
                    { 5, "Fonte Editorial" },
                    { 4, "Ecclesiae Editora" },
                    { 7, "Jurua" },
                    { 2, "Arte Editorial" },
                    { 1, "Global" },
                    { 3, "Europa" }
                });

            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 9, "Aventura" },
                    { 1, "Autobiografia" },
                    { 2, "Horror" },
                    { 3, "Biografia" },
                    { 4, "Apocalipse Zumbi;" },
                    { 5, "Romance" },
                    { 6, "Fábula" },
                    { 7, "Conto" },
                    { 8, "Crônica" },
                    { 10, "Guerra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorId",
                table: "Livro",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_EditoraId",
                table: "Livro",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_GeneroId",
                table: "Livro",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroLinks_LivroId",
                table: "LivroLinks",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroLinks");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Editora");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
