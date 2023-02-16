using Microsoft.EntityFrameworkCore.Migrations;

namespace Bcx.Platform.Migrations
{
    public partial class RelacionandoReceitasComIngredientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receita2ingredientes",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "integer", nullable: false),
                    ReceitaId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Unidade = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita2ingredientes", x => new { x.ReceitaId, x.IngredienteId });
                    table.ForeignKey(
                        name: "FK_receita2ingredientes_ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receita2ingredientes_receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_receita2ingredientes_IngredienteId",
                table: "receita2ingredientes",
                column: "IngredienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receita2ingredientes");
        }
    }
}
