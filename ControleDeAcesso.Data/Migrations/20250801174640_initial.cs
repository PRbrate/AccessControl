using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    ClaimType = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    ClaimValue = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    ClaimType = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    ClaimValue = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    RoleId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    ContaId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Adress = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    UserType = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    SecurityStamp = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ContaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    LoginProvider = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    EventDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantParticipants = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", unicode: false, maxLength: 500, nullable: false),
                    Adress = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ContaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    PriceId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ContaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ContaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_UsersEvent_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ContaId",
                table: "Events",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ContaId",
                table: "Participants",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId",
                table: "Participants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContaId",
                table: "Users",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersEvent_ContaId",
                table: "UsersEvent",
                column: "ContaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "UsersEvent");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
