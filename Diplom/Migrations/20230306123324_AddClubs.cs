using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Migrations
{
    /// <inheritdoc />
    public partial class AddClubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "News",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "News",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "News",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Рисование помогает ребенку познать окружающий мир, приучает внимательно наблюдать и анализировать форму предметов, развивает зрительную память, пространственное мышление и способность к образному мышлению. Оно учит точности расчета, учит познавать красоту природы, мыслить и чувствовать, воспитывает чувство доброты, сопереживания и сочувствия окружающим.", "Рисунок и живопись" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 6, 15, 33, 24, 367, DateTimeKind.Local).AddTicks(5531));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "News",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "News",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "News",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 26, 19, 30, 13, 242, DateTimeKind.Local).AddTicks(1169));
        }
    }
}
