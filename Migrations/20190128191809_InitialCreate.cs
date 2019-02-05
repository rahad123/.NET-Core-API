using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FistName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    ContactPhone = table.Column<int>(nullable: false),
                    Password = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Body = table.Column<string>(maxLength: 2000, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactPhone", "Email", "FistName", "LastName", "Password" },
                values: new object[] { 1, 1799052270, "rahaddiu@gmail.com", "Rahad", "Saidul", "143" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactPhone", "Email", "FistName", "LastName", "Password" },
                values: new object[] { 2, 1726688748, "sohag@gmail.com", "Sohag", "Jaidul", "143-15" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[] { 1, "First Body", "First Tittle", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Title", "UserId" },
                values: new object[] { 2, "Second Body", "Second Tittle", 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "PostId" },
                values: new object[] { 1, "First Message", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "PostId" },
                values: new object[] { 2, "Second Message", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
