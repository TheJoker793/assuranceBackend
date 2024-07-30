using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assurance_Backend.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTypeReglement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglements_Devises_DevisId",
                table: "Reglements");

            migrationBuilder.AlterColumn<int>(
                name: "DevisId",
                table: "Reglements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TypeReglementId",
                table: "Reglements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeReglements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeReglements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reglements_TypeReglementId",
                table: "Reglements",
                column: "TypeReglementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reglements_Devises_DevisId",
                table: "Reglements",
                column: "DevisId",
                principalTable: "Devises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reglements_TypeReglements_TypeReglementId",
                table: "Reglements",
                column: "TypeReglementId",
                principalTable: "TypeReglements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reglements_Devises_DevisId",
                table: "Reglements");

            migrationBuilder.DropForeignKey(
                name: "FK_Reglements_TypeReglements_TypeReglementId",
                table: "Reglements");

            migrationBuilder.DropTable(
                name: "TypeReglements");

            migrationBuilder.DropIndex(
                name: "IX_Reglements_TypeReglementId",
                table: "Reglements");

            migrationBuilder.DropColumn(
                name: "TypeReglementId",
                table: "Reglements");

            migrationBuilder.AlterColumn<int>(
                name: "DevisId",
                table: "Reglements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reglements_Devises_DevisId",
                table: "Reglements",
                column: "DevisId",
                principalTable: "Devises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
