using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAspireApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationship_UserTodos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TodoItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTodos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTodos_TodoItems_TodoItemId",
                        column: x => x.TodoItemId,
                        principalTable: "TodoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTodos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTodos_TodoItemId",
                table: "UserTodos",
                column: "TodoItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTodos_UserId",
                table: "UserTodos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTodos");
        }
    }
}
