using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LanchoneteApi.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "garcom",
                columns: table => new
                {
                    idgarcom = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nmgarcom = table.Column<string>(type: "text", nullable: false),
                    numeromesa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garcom", x => x.idgarcom);
                });

            migrationBuilder.CreateTable(
                name: "tipo",
                columns: table => new
                {
                    idtipo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nmtipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo", x => x.idtipo);
                });

            migrationBuilder.CreateTable(
                name: "comanda",
                columns: table => new
                {
                    idcomanda = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    statuscomanda = table.Column<bool>(type: "boolean", nullable: false),
                    garcom_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comanda", x => x.idcomanda);
                    table.ForeignKey(
                        name: "FK_comanda_garcom_garcom_id",
                        column: x => x.garcom_id,
                        principalTable: "garcom",
                        principalColumn: "idgarcom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    idproduto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nmproduto = table.Column<string>(type: "text", nullable: false),
                    descricaoproduto = table.Column<string>(type: "text", nullable: false),
                    vlproduto = table.Column<double>(type: "double precision", nullable: false),
                    tipo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.idproduto);
                    table.ForeignKey(
                        name: "FK_produto_tipo_tipo_id",
                        column: x => x.tipo_id,
                        principalTable: "tipo",
                        principalColumn: "idtipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemComanda",
                columns: table => new
                {
                    iditemcomanda = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vlvenda = table.Column<double>(type: "double precision", nullable: false),
                    comanda_id = table.Column<int>(type: "integer", nullable: false),
                    produto_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemComanda", x => x.iditemcomanda);
                    table.ForeignKey(
                        name: "FK_itemComanda_comanda_comanda_id",
                        column: x => x.comanda_id,
                        principalTable: "comanda",
                        principalColumn: "idcomanda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemComanda_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produto",
                        principalColumn: "idproduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comanda_garcom_id",
                table: "comanda",
                column: "garcom_id");

            migrationBuilder.CreateIndex(
                name: "IX_itemComanda_comanda_id",
                table: "itemComanda",
                column: "comanda_id");

            migrationBuilder.CreateIndex(
                name: "IX_itemComanda_produto_id",
                table: "itemComanda",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_produto_tipo_id",
                table: "produto",
                column: "tipo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemComanda");

            migrationBuilder.DropTable(
                name: "comanda");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "garcom");

            migrationBuilder.DropTable(
                name: "tipo");
        }
    }
}
