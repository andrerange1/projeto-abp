using Bcx.Platform.Receitas;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bcx.Platform.Migrations
{
    public partial class AdicionadaReceitaRanqueada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql(string.Format(@"
CREATE VIEW ""public"".""{0}""
as
   Select r.""Id""                      as ""Id"",
          a.""Id""                      as ""AutorId"",
          a.""Name""                    as ""AutorNome"",
          r.""Titulo""                  as ""Titulo"",
          r.""Descricao""               as ""Descricao"",
          f.""Uri""                     as ""Thumb"",
          AVG(COALESCE(h.""Score"", 0)) as ""Ranking""

     From ""public"".""receitas"" AS r

     Join ""identity"".""Users"" AS a 
       On r.""AutorId"" = a.""Id""

Left Join ""public"".""receita_foto"" as f
       On r.""Id"" = f.""ReceitaId"" And f.""Default"" = TRUE

Left Join ""public"".""rating"" as h
       On h.""ReceitaId"" = r.""Id""

 Group By r.""Id"",
          a.""Id"",
          a.""Name"",
          r.""Titulo"",
          r.""Descricao"",
          f.""Uri""

 Order by ""Ranking"" DESC;

", ReceitaRanqueadaEfMapping.ViewName));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql($"DROP MATERIALIZED VIEW IF EXISTS \"public\".\"{ReceitaRanqueadaEfMapping.ViewName}\";");
        }
    }
}
