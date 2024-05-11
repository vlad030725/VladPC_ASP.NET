using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VladPC_ASP.NET.Migrations
{
    /// <inheritdoc />
    public partial class setnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "__MigrationHistory",
                schema: "dbo",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ContextKey = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Model = table.Column<byte[]>(type: "bytea", nullable: false),
                    ProductVersion = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.__MigrationHistory", x => new { x.MigrationId, x.ContextKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procurements",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Sum = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Procurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Discount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PromoCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Sockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMemories",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TypeMemories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProducts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TypeProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsSale = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: true),
                    IdCompany = table.Column<int>(type: "integer", nullable: true),
                    IdTypeProduct = table.Column<int>(type: "integer", nullable: true),
                    CountCores = table.Column<int>(type: "integer", nullable: true),
                    CountStreams = table.Column<int>(type: "integer", nullable: true),
                    Frequency = table.Column<int>(type: "integer", nullable: true),
                    IdSocket = table.Column<int>(type: "integer", nullable: true),
                    CountMemory = table.Column<int>(type: "integer", nullable: true),
                    IdTypeMemory = table.Column<int>(type: "integer", nullable: true),
                    IdFormFactor = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.FormFactors_IdFormFactor",
                        column: x => x.IdFormFactor,
                        principalSchema: "dbo",
                        principalTable: "FormFactors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.Sockets_IdSocket",
                        column: x => x.IdSocket,
                        principalSchema: "dbo",
                        principalTable: "Sockets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.TypeMemories_IdTypeMemory",
                        column: x => x.IdTypeMemory,
                        principalSchema: "dbo",
                        principalTable: "TypeMemories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Products_dbo.TypeProducts_IdTypeProduct",
                        column: x => x.IdTypeProduct,
                        principalSchema: "dbo",
                        principalTable: "TypeProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: true),
                    IdStatus = table.Column<int>(type: "integer", nullable: true),
                    IdPromoCode = table.Column<int>(type: "integer", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Sum = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Customs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Customs_dbo.PromoCodes_IdPromoCode",
                        column: x => x.IdPromoCode,
                        principalSchema: "dbo",
                        principalTable: "PromoCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customs_dbo.Status_IdStatus",
                        column: x => x.IdStatus,
                        principalSchema: "dbo",
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customs_dbo.Users_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcurementRows",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdProduct = table.Column<int>(type: "integer", nullable: true),
                    IdProcurement = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ProcurementRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ProcurementRows_dbo.Procurements_IdProcurement",
                        column: x => x.IdProcurement,
                        principalSchema: "dbo",
                        principalTable: "Procurements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProcurementRows_dbo.Products_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CustomRows",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCustom = table.Column<int>(type: "integer", nullable: true),
                    IdProduct = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: true),
                    Count = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CustomRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CustomRows_dbo.Customs_IdCustom",
                        column: x => x.IdCustom,
                        principalSchema: "dbo",
                        principalTable: "Customs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomRows_dbo.Products_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "CustomRows_IX_IdCustom",
                schema: "dbo",
                table: "CustomRows",
                column: "IdCustom");

            migrationBuilder.CreateIndex(
                name: "CustomRows_IX_IdProduct",
                schema: "dbo",
                table: "CustomRows",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "Customs_IX_IdPromoCode",
                schema: "dbo",
                table: "Customs",
                column: "IdPromoCode");

            migrationBuilder.CreateIndex(
                name: "Customs_IX_IdStatus",
                schema: "dbo",
                table: "Customs",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "Customs_IX_IdUser",
                schema: "dbo",
                table: "Customs",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "ProcurementRows_IX_IdProcurement",
                schema: "dbo",
                table: "ProcurementRows",
                column: "IdProcurement");

            migrationBuilder.CreateIndex(
                name: "ProcurementRows_IX_IdProduct",
                schema: "dbo",
                table: "ProcurementRows",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "Products_IX_IdCompany",
                schema: "dbo",
                table: "Products",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "Products_IX_IdFormFactor",
                schema: "dbo",
                table: "Products",
                column: "IdFormFactor");

            migrationBuilder.CreateIndex(
                name: "Products_IX_IdSocket",
                schema: "dbo",
                table: "Products",
                column: "IdSocket");

            migrationBuilder.CreateIndex(
                name: "Products_IX_IdTypeMemory",
                schema: "dbo",
                table: "Products",
                column: "IdTypeMemory");

            migrationBuilder.CreateIndex(
                name: "Products_IX_IdTypeProduct",
                schema: "dbo",
                table: "Products",
                column: "IdTypeProduct");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__MigrationHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomRows",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProcurementRows",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Procurements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PromoCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FormFactors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sockets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TypeMemories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TypeProducts",
                schema: "dbo");
        }
    }
}
