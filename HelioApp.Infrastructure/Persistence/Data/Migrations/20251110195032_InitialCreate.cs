using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelioApp.Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    LastLoginAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityServices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    document_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    working_hours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    display_order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityServices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DiscussionCircles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cover_image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    posts_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    members_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionCircles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<byte>(type: "tinyint", nullable: false),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    secondary_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    display_order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Module = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublicContent",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    page_key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meta_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_published = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    last_updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicContent", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceGuides",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icon_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pdf_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    display_order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceGuides", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TransportRoutes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    route_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transport_type = table.Column<byte>(type: "tinyint", nullable: false),
                    start_point = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    end_point = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stops = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    route_map_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fare = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRoutes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    video_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placement = table.Column<byte>(type: "tinyint", nullable: false),
                    referral_type = table.Column<byte>(type: "tinyint", nullable: false),
                    referral_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    external_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    target_audience = table.Column<byte>(type: "tinyint", nullable: false),
                    impression_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    click_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    priority = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    budget = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ads_ApplicationUsers_created_by",
                        column: x => x.created_by,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlockedUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    blocker_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    blocked_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_ApplicationUsers_blocked_id",
                        column: x => x.blocked_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_ApplicationUsers_blocker_id",
                        column: x => x.blocker_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    conversation_type = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "direct"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_message_content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_message_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_message_by = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conversations_ApplicationUsers_last_message_by",
                        column: x => x.last_message_by,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    favoritable_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    favoritable_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.id);
                    table.ForeignKey(
                        name: "FK_Favorites_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favorites_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    poster_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    company_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    job_type = table.Column<byte>(type: "tinyint", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    salary_min = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    salary_max = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: true),
                    salary_currency = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "EGP"),
                    salary_period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    experience_required = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    applications_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Jobs_ApplicationUsers_poster_id",
                        column: x => x.poster_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    likeable_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    likeable_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Likes_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LostAndFoundItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    poster_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    item_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_lost_or_found = table.Column<DateOnly>(type: "date", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    expires_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    resolved_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostAndFoundItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_LostAndFoundItems_ApplicationUsers_poster_id",
                        column: x => x.poster_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceItems",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    seller_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "EGP"),
                    category = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    is_negotiable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_MarketplaceItems_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MarketplaceItems_ApplicationUsers_seller_id",
                        column: x => x.seller_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    author_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    featured_image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    external_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_featured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_published = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    published_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.id);
                    table.ForeignKey(
                        name: "FK_News_ApplicationUsers_author_id",
                        column: x => x.author_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notification_type = table.Column<byte>(type: "tinyint", nullable: false),
                    picture_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    action_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    target_audience = table.Column<byte>(type: "tinyint", nullable: false),
                    specific_user_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    priority = table.Column<byte>(type: "tinyint", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    sent_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    read_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notifications_ApplicationUsers_created_by",
                        column: x => x.created_by,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    owner_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    property_type = table.Column<byte>(type: "tinyint", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_Properties_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_ApplicationUsers_owner_id",
                        column: x => x.owner_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportedContent",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reporter_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    content_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    content_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValue: "pending"),
                    reviewed_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewed_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    action_taken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportedContent", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReportedContent_ApplicationUsers_reporter_id",
                        column: x => x.reporter_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    activity_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    related_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    related_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserActivities_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRelationships",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    related_user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    relationship_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelationships", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserRelationships_ApplicationUsers_related_user_id",
                        column: x => x.related_user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRelationships_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ViewCounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    viewable_type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    viewable_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ip_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    viewed_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_ViewCounts_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    author_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    circle_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post_type = table.Column<byte>(type: "tinyint", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_pinned = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    is_locked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    likes_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    comments_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    reports_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_ApplicationUsers_author_id",
                        column: x => x.author_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_DiscussionCircles_circle_id",
                        column: x => x.circle_id,
                        principalTable: "DiscussionCircles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_ApplicationRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportSchedules",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    route_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    departure_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    arrival_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    frequency_minutes = table.Column<int>(type: "int", nullable: true),
                    days_of_week = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportSchedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransportSchedules_TransportRoutes_route_id",
                        column: x => x.route_id,
                        principalTable: "TransportRoutes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationParticipants",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "member"),
                    unread_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    last_read_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_muted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    joined_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    left_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationParticipants", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConversationParticipants_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConversationParticipants_Conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "Conversations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    conversation_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sender_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message_type = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "text"),
                    media_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_size = table.Column<int>(type: "int", nullable: true),
                    is_edited = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    edited_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_ApplicationUsers_sender_id",
                        column: x => x.sender_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "Conversations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    job_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    applicant_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cover_letter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resume_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    applied_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.id);
                    table.ForeignKey(
                        name: "FK_JobApplications_ApplicationUsers_applicant_id",
                        column: x => x.applicant_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "Jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    notification_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    is_read = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    read_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserNotifications_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotifications_Notifications_notification_id",
                        column: x => x.notification_id,
                        principalTable: "Notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubcategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationLat = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LocationLng = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    TotalReviews = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_ApplicationUsers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    author_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    parent_comment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likes_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    replies_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    reports_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_ApplicationUsers_author_id",
                        column: x => x.author_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Comments_parent_comment_id",
                        column: x => x.parent_comment_id,
                        principalTable: "Comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polls",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    post_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    allows_multiple_choices = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    total_votes = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ends_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polls", x => x.id);
                    table.ForeignKey(
                        name: "FK_Polls_Posts_post_id",
                        column: x => x.post_id,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageReadReceipts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    message_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    read_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReadReceipts", x => x.id);
                    table.ForeignKey(
                        name: "FK_MessageReadReceipts_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MessageReadReceipts_Messages_message_id",
                        column: x => x.message_id,
                        principalTable: "Messages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    service_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_by_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terms_and_conditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer_type = table.Column<byte>(type: "tinyint", nullable: false),
                    discount_percentage = table.Column<int>(type: "int", nullable: true),
                    discount_amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    redemption_method = table.Column<byte>(type: "tinyint", nullable: false),
                    max_redemptions = table.Column<int>(type: "int", nullable: true),
                    current_redemptions = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    requires_code = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    status = table.Column<byte>(type: "tinyint", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    view_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    claim_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offers_ApplicationUsers_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Services_service_id",
                        column: x => x.service_id,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerifiedPurchase = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HelpfulCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_ApplicationUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_ApplicationUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollOptions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    poll_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    option_text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    display_order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    votes_count = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollOptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_PollOptions_Polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "Polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferClaims",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    offer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    claim_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_redeemed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    redeemed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    redemption_location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    claimed_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferClaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_OfferClaims_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferClaims_Offers_offer_id",
                        column: x => x.offer_id,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferCodes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    offer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_used = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    used_by = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    used_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    expires_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_OfferCodes_ApplicationUsers_used_by",
                        column: x => x.used_by,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OfferCodes_Offers_offer_id",
                        column: x => x.offer_id,
                        principalTable: "Offers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ReviewReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorType = table.Column<byte>(type: "tinyint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewReplies_ApplicationUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReviewReplies_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PollVotes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    poll_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    option_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    voted_at = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSUTCDATETIME()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollVotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_PollVotes_ApplicationUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollVotes_PollOptions_option_id",
                        column: x => x.option_id,
                        principalTable: "PollOptions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PollVotes_Polls_poll_id",
                        column: x => x.poll_id,
                        principalTable: "Polls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_created_by",
                table: "Ads",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_blocked_id",
                table: "BlockedUsers",
                column: "blocked_id");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_blocker_id",
                table: "BlockedUsers",
                column: "blocker_id");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_blocker_id_blocked_id",
                table: "BlockedUsers",
                columns: new[] { "blocker_id", "blocked_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_author_id",
                table: "Comments",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_parent_comment_id",
                table: "Comments",
                column: "parent_comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipants_conversation_id",
                table: "ConversationParticipants",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipants_conversation_id_user_id",
                table: "ConversationParticipants",
                columns: new[] { "conversation_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipants_unread_count",
                table: "ConversationParticipants",
                column: "unread_count");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipants_user_id",
                table: "ConversationParticipants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_conversation_type",
                table: "Conversations",
                column: "conversation_type");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_is_active",
                table: "Conversations",
                column: "is_active");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_last_message_at",
                table: "Conversations",
                column: "last_message_at");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_last_message_by",
                table: "Conversations",
                column: "last_message_by");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ApplicationUserId",
                table: "Favorites",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_favoritable_type_favoritable_id",
                table: "Favorites",
                columns: new[] { "favoritable_type", "favoritable_id" });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_user_id",
                table: "Favorites",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_user_id_favoritable_type_favoritable_id",
                table: "Favorites",
                columns: new[] { "user_id", "favoritable_type", "favoritable_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_applicant_id",
                table: "JobApplications",
                column: "applicant_id");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_job_id",
                table: "JobApplications",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_created_at",
                table: "Jobs",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_location",
                table: "Jobs",
                column: "location");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_poster_id",
                table: "Jobs",
                column: "poster_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_status",
                table: "Jobs",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ApplicationUserId",
                table: "Likes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_user_id",
                table: "Likes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_LostAndFoundItems_created_at",
                table: "LostAndFoundItems",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_LostAndFoundItems_item_type",
                table: "LostAndFoundItems",
                column: "item_type");

            migrationBuilder.CreateIndex(
                name: "IX_LostAndFoundItems_poster_id",
                table: "LostAndFoundItems",
                column: "poster_id");

            migrationBuilder.CreateIndex(
                name: "IX_LostAndFoundItems_status",
                table: "LostAndFoundItems",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_ApplicationUserId",
                table: "MarketplaceItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_category",
                table: "MarketplaceItems",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_created_at",
                table: "MarketplaceItems",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_seller_id",
                table: "MarketplaceItems",
                column: "seller_id");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceItems_status",
                table: "MarketplaceItems",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReadReceipts_message_id",
                table: "MessageReadReceipts",
                column: "message_id");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReadReceipts_message_id_user_id",
                table: "MessageReadReceipts",
                columns: new[] { "message_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageReadReceipts_user_id",
                table: "MessageReadReceipts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ApplicationUserId",
                table: "Messages",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_conversation_id",
                table: "Messages",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_created_at",
                table: "Messages",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_sender_id",
                table: "Messages",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_author_id",
                table: "News",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_created_by",
                table: "Notifications",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_OfferClaims_offer_id",
                table: "OfferClaims",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferClaims_user_id",
                table: "OfferClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCodes_offer_id",
                table: "OfferCodes",
                column: "offer_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCodes_used_by",
                table: "OfferCodes",
                column: "used_by");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_created_by_id",
                table: "Offers",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_service_id",
                table: "Offers",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_PollOptions_poll_id",
                table: "PollOptions",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "IX_Polls_post_id",
                table: "Polls",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_option_id",
                table: "PollVotes",
                column: "option_id");

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_poll_id",
                table: "PollVotes",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "IX_PollVotes_user_id",
                table: "PollVotes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_author_id",
                table: "Posts",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_circle_id",
                table: "Posts",
                column: "circle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ApplicationUserId",
                table: "Properties",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_owner_id",
                table: "Properties",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_PublicContent_is_published",
                table: "PublicContent",
                column: "is_published");

            migrationBuilder.CreateIndex(
                name: "IX_PublicContent_page_key",
                table: "PublicContent",
                column: "page_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportedContent_content_id",
                table: "ReportedContent",
                column: "content_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedContent_content_type",
                table: "ReportedContent",
                column: "content_type");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedContent_created_at",
                table: "ReportedContent",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedContent_reporter_id",
                table: "ReportedContent",
                column: "reporter_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportedContent_status",
                table: "ReportedContent",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReplies_AuthorId",
                table: "ReviewReplies",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewReplies_ReviewId",
                table: "ReviewReplies",
                column: "ReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApplicationUserId",
                table: "Services",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProviderId",
                table: "Services",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SubcategoryId",
                table: "Services",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportSchedules_route_id",
                table: "TransportSchedules",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_activity_type",
                table: "UserActivities",
                column: "activity_type");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_created_at",
                table: "UserActivities",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_user_id",
                table: "UserActivities",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_notification_id",
                table: "UserNotifications",
                column: "notification_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotifications_user_id",
                table: "UserNotifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationships_related_user_id",
                table: "UserRelationships",
                column: "related_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationships_relationship_type",
                table: "UserRelationships",
                column: "relationship_type");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationships_user_id",
                table: "UserRelationships",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationships_user_id_related_user_id_relationship_type",
                table: "UserRelationships",
                columns: new[] { "user_id", "related_user_id", "relationship_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_user_id",
                table: "ViewCounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_viewable_id",
                table: "ViewCounts",
                column: "viewable_id");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_viewable_type",
                table: "ViewCounts",
                column: "viewable_type");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_viewed_at",
                table: "ViewCounts",
                column: "viewed_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "BlockedUsers");

            migrationBuilder.DropTable(
                name: "CityServices");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ConversationParticipants");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "LostAndFoundItems");

            migrationBuilder.DropTable(
                name: "MarketplaceItems");

            migrationBuilder.DropTable(
                name: "MessageReadReceipts");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OfferClaims");

            migrationBuilder.DropTable(
                name: "OfferCodes");

            migrationBuilder.DropTable(
                name: "PollVotes");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PublicContent");

            migrationBuilder.DropTable(
                name: "ReportedContent");

            migrationBuilder.DropTable(
                name: "ReviewReplies");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "ServiceGuides");

            migrationBuilder.DropTable(
                name: "TransportSchedules");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserRelationships");

            migrationBuilder.DropTable(
                name: "ViewCounts");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "PollOptions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "TransportRoutes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Polls");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "DiscussionCircles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
