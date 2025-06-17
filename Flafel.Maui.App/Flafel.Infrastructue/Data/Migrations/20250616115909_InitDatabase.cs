using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flafel.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SalaryType = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "DAILY"),
                    CrewTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUsers_Crews_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CrewTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrewTitles_SystemUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CrewTitles_SystemUsers_LastModifiedBy",
                        column: x => x.LastModifiedBy,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_SystemUsers_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolePermission = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "READ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolePermissions_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CreatedBy",
                table: "Crews",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewTitleId",
                table: "Crews",
                column: "CrewTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_LastModifiedBy",
                table: "Crews",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_Mobile",
                table: "Crews",
                column: "Mobile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crews_Name",
                table: "Crews",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrewTitles_CreatedBy",
                table: "CrewTitles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CrewTitles_LastModifiedBy",
                table: "CrewTitles",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CrewTitles_Name",
                table: "CrewTitles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUsers_CrewId",
                table: "SystemUsers",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUsers_UserName",
                table: "SystemUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRolePermissions_UserRoleId",
                table: "UserRolePermissions",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_SystemUserId",
                table: "UserRoles",
                column: "SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_CrewTitles_CrewTitleId",
                table: "Crews",
                column: "CrewTitleId",
                principalTable: "CrewTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_SystemUsers_CreatedBy",
                table: "Crews",
                column: "CreatedBy",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_SystemUsers_LastModifiedBy",
                table: "Crews",
                column: "LastModifiedBy",
                principalTable: "SystemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_CrewTitles_CrewTitleId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Crews_SystemUsers_CreatedBy",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Crews_SystemUsers_LastModifiedBy",
                table: "Crews");

            migrationBuilder.DropTable(
                name: "UserRolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CrewTitles");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropTable(
                name: "Crews");
        }
    }
}
