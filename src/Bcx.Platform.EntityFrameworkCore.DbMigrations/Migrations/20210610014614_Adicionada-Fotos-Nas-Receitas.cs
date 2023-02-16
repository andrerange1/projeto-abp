using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bcx.Platform.Migrations
{
    public partial class AdicionadaFotosNasReceitas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receita_foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceitaId = table.Column<int>(type: "integer", nullable: false),
                    Default = table.Column<bool>(type: "boolean", nullable: false),
                    Uri = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receita_foto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receita_foto_receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_receita_somente_uma_foto_default",
                table: "receita_foto",
                columns: new[] { "ReceitaId", "Default" },
                unique: true,
                filter: "\"Default\" = (TRUE)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receita_foto");
        }
    }
}
