using ConfigureServices.Models.Fields;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConfigureServices.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "complexmodels",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_complexmodels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "simplemodel",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    field = table.Column<BaseField>(type: "jsonb", nullable: true),
                    attributeid = table.Column<long>(type: "bigint", nullable: false),
                    complexmodelid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_simplemodel", x => x.id);
                    table.ForeignKey(
                        name: "fk_simplemodel_complexmodels_complexmodelid",
                        column: x => x.complexmodelid,
                        principalTable: "complexmodels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_simplemodel_complexmodelid",
                table: "simplemodel",
                column: "complexmodelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "simplemodel");

            migrationBuilder.DropTable(
                name: "complexmodels");
        }
    }
}
