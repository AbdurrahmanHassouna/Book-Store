using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprilBookStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookStar = table.Column<double>(type: "float", nullable: true),
                    PublicationYear = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8d932540-e249-4d88-9914-02046615c1d7", "test@test.com", true, false, null, "TEST@TEST.COM", "ABDO", "AQAAAAEAACcQAAAAEHmurmHHg2FZ9HyvbFvD0+gYgPVS5boHPPP7oQM8srfuMB5RSoYdFv5JZ0pwI8Ky4g==", null, false, "dcf5f771-76ca-46a2-aac4-12071f3976c6", false, "Abdo" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "IsVisible", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 54, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Adam Kay", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Daniel Kahneman", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Paul Kalanithi", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Russ Harris", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Viktor E. Frankl", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Oliver Sacks", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Michael Mosley", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Jordan B. Peterson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Atul Gawande", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Giulia Enders", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Norman Doidge", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Anthony William", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Keri Smith", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Natasha Campbell-McBride", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Austin Kleon", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Eline Snel", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Michael Greger", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Tina Payne Bryson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Juju Sundin", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "American Psychiatric Association", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Philippa Perry", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "American Psychological Association", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Eben Alexander", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Rebecca Skloot", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Stephen R. Covey", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "C. G. Jung", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "James Clear", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Sarah McKay", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Rhonda Patrick", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Peter Singer", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Helen Fisher", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Seuss", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Brene Brown", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Marie Kondō", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "James Kerr", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Yuval Noah Harari", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Mark Manson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Eckhart Tolle", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Suess", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Robert Greene", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "IsVisible", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 94, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Simon Sinek", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Adam Grant", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Carol S. Dweck", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Malcolm Gladwell", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Ryan Holiday", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Tony Robbins", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "J.K. Rowling", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Jordan B. Peterson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dale Carnegie", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Susan Cain", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Cal Newport", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Gary Chapman", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Mark Manson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Charles Duhigg", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Napoleon Hill", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Daniel H. Pink", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Tara Westover", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Angela Duckworth", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Yuval Noah Harari", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 113, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Ray Dalio", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Jordan B. Peterson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Stephen R. Covey", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Paul Kalanithi", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "J.D. Vance", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Atul Gawande", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Robert T. Kiyosaki", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Cheryl Strayed", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 121, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Tim Ferriss", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dale Carnegie", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Robin Sharma", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Brene Brown", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Timothy Ferriss", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Jocko Willink", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "David Goggins", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "David Allen", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Yuval Noah Harari", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Gary John Bishop", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "James Clear", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Nir Eyal", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Stephen R. Covey", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Charles Duhigg", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Daniel Kahneman", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "IsVisible", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 136, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "James Clear", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Brené Brown", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dale Carnegie", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Don Miguel Ruiz", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Mark Manson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Daniel H. Pink", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Gary Chapman", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Stephen R. Covey", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Brene Brown", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dr. Shefali Tsabary", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Michael A. Singer", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Dale Carnegie", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Gary Chapman", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Simon Sinek", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Mark Manson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 155, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Daniel J. Levitin", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Erik Larson", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "IsDeleted", "IsVisible", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Medical", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Science-Geography", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "Art-Photography", new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookStar", "CategoryId", "CreatedDate", "Description", "Format", "ISBN", "ImgPath", "IsDeleted", "IsVisible", "Name", "Price", "PublicationYear", "QuantityInStock", "UpdatedDate" },
                values: new object[,]
                {
                    { 314, 54, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9781509858637L, "/book-covers/Medical/0000001.jpg", false, true, "This is Going to Hurt", 7.60m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 315, 55, 1.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780141033570L, "~/book-covers/Medical/0000002.jpg", false, true, "Thinking, Fast and Slow", 11.50m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 316, 56, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9781784701994L, "~/book-covers/Medical/0000003.jpg", false, true, "When Breath Becomes Air", 9.05m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 317, 57, 3.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9781845298258L, "/book-covers/Medical/0000004.jpg", false, true, "The Happiness Trap", 8.34m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 318, 58, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9781846041242L, "~/book-covers/Medical/0000005.jpg", false, true, "Man's Search For Meaning", 9.66m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 319, 59, 5.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780330523622L, "~/book-covers/Medical/0000006.jpg", false, true, "The Man Who Mistook His Wife for a Hat", 5.92m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 320, 60, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9781780722405L, "~/book-covers/Medical/0000007.jpg", false, true, "The 8-week Blood Sugar Diet", 8.85m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 321, 61, 4.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780062457714L, "/book-covers/Medical/0000008.jpg", false, true, "The Subtle Art of Not Giving a F*ck", 8.06m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 322, 62, 3.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780099511021L, "~/book-covers/Medical/0000009.jpg", false, true, "Educated", 8.73m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 323, 63, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780141978611L, "~/book-covers/Medical/0000010.jpg", false, true, "The Body Keeps the Score", 10.27m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 324, 64, 3.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780141983769L, "/book-covers/Medical/0000011.jpg", false, true, "Why We Sleep", 9.20m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 325, 65, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780330533447L, "~/book-covers/Medical/0000012.jpg", false, true, "The Immortal Life of Henrietta Lacks", 6.82m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 326, 66, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780099590087L, "~/book-covers/Medical/0000013.jpg", false, true, "Sapiens: A Brief History of Humankind", 10.15m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 327, 67, 3.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780007498086L, "/book-covers/Medical/0000014.jpg", false, true, "Bad Pharma", 7.84m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 328, 68, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9781846683145L, "~/book-covers/Medical/0000015.jpg", false, true, "The Checklist Manifesto", 8.34m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 329, 69, 4.5, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780007250929L, "~/book-covers/Medical/0000016.jpg", false, true, "The Emperor of All Maladies", 8.49m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 330, 70, 2.1000000000000001, 1, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "No Description AVAILABLE", "Paperback", 9780099584574L, "/book-covers/Medical/0000017.jpg", false, true, "The Gene", 12.20m, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Name",
                table: "Books",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_BookId",
                table: "CartItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
