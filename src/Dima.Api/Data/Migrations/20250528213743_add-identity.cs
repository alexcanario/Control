using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dima.Api.Data.Migrations
{
	/// <inheritdoc />
	public partial class AddIdentity : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "RoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<long>(type: "bigint", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_RoleClaims", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
					Email = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Roles",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserAppId = table.Column<long>(type: "bigint", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Roles", x => x.Id);
					table.ForeignKey(
						name: "FK_Roles_Users_UserAppId",
						column: x => x.UserAppId,
						principalTable: "Users",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "UserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<long>(type: "bigint", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_UserClaims_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					UserId = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_UserLogins_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserRoles",
				columns: table => new
				{
					UserId = table.Column<long>(type: "bigint", nullable: false),
					RoleId = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
					table.ForeignKey(
						name: "FK_UserRoles_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserTokens",
				columns: table => new
				{
					UserId = table.Column<long>(type: "bigint", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
					Name = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_UserTokens_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Roles_NormalizedName",
				table: "Roles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_Roles_UserAppId",
				table: "Roles",
				column: "UserAppId");

			migrationBuilder.CreateIndex(
				name: "IX_UserClaims_UserId",
				table: "UserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserLogins_UserId",
				table: "UserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserRoles_UserId",
				table: "UserRoles",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_Users_NormalizedEmail",
				table: "Users",
				column: "NormalizedEmail",
				unique: true,
				filter: "[NormalizedEmail] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_Users_NormalizedUserName",
				table: "Users",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "RoleClaims");

			migrationBuilder.DropTable(
				name: "Roles");

			migrationBuilder.DropTable(
				name: "UserClaims");

			migrationBuilder.DropTable(
				name: "UserLogins");

			migrationBuilder.DropTable(
				name: "UserRoles");

			migrationBuilder.DropTable(
				name: "UserTokens");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
