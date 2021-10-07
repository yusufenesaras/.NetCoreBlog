using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_newletter_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Blogs",
                newName: "WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterID",
                table: "Blogs",
                newName: "IX_Blogs_WriterId");

            migrationBuilder.CreateTable(
                name: "NewsLetters",
                columns: table => new
                {
                    mailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mailStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetters", x => x.mailId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "NewsLetters");

            migrationBuilder.RenameColumn(
                name: "WriterId",
                table: "Blogs",
                newName: "WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterId",
                table: "Blogs",
                newName: "IX_Blogs_WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
