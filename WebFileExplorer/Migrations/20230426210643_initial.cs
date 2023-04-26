using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebFileExplorer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootFolderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_RootFolderId",
                        column: x => x.RootFolderId,
                        principalTable: "Folders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "RootFolderId" },
                values: new object[,]
                {
                    { 1, "Creating Digital Images", null },
                    { 2, "Resources", 1 },
                    { 3, "Evidence", 1 },
                    { 4, "Graphic Products", 1 },
                    { 5, "Primary Sources", 2 },
                    { 6, "Process", 4 },
                    { 7, "Final Product", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_RootFolderId",
                table: "Folders",
                column: "RootFolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
