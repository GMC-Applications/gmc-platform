using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gmc.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Allergies = table.Column<string>(type: "text", nullable: true),
                    MedicalNotes = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "church_events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    StartsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    RegistrationRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_church_events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ministries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Podcasts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AudioUrl = table.Column<string>(type: "text", nullable: false),
                    CoverImageUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podcasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sermons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Speaker = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    SermonDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    AudioUrl = table.Column<string>(type: "text", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sermons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    EmailVerifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildCheckIns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChildId = table.Column<long>(type: "bigint", nullable: false),
                    CheckedInBy = table.Column<long>(type: "bigint", nullable: false),
                    CheckedInAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckedOutBy = table.Column<long>(type: "bigint", nullable: true),
                    CheckedOutAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SecurityCode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCheckIns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCheckIns_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServingRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinistryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServingRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServingRoles_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    TargetRole = table.Column<string>(type: "text", nullable: true),
                    MinistryId = table.Column<long>(type: "bigint", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcements_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Action = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: true),
                    EntityId = table.Column<long>(type: "bigint", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    MetadataJson = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    MemberSince = table.Column<DateOnly>(type: "date", nullable: true),
                    MembershipStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProfileVisibility = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CommunicationConsent = table.Column<bool>(type: "boolean", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "text", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TokenHash = table.Column<string>(type: "text", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeviceName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
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
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServingSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServingRoleId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduledFor = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServingSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServingSchedules_ServingRoles_ServingRoleId",
                        column: x => x.ServingRoleId,
                        principalTable: "ServingRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildGuardians",
                columns: table => new
                {
                    ChildId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: true),
                    AuthorizedPickup = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildGuardians", x => new { x.ChildId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_ChildGuardians_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildGuardians_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionSubmissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Interest = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AssignedTo = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectionSubmissions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    DonorName = table.Column<string>(type: "text", nullable: true),
                    DonorEmail = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Category = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Provider = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ProviderReference = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    PaidAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MinistryMembers",
                columns: table => new
                {
                    MinistryId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    IsLeader = table.Column<bool>(type: "boolean", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryMembers", x => new { x.MinistryId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_MinistryMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MinistryMembers_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrayerRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Request = table.Column<string>(type: "text", nullable: false),
                    Anonymous = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ModeratedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModeratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrayerRequests_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SermonNotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SermonId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SermonNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SermonNotes_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SermonNotes_Sermons_SermonId",
                        column: x => x.SermonId,
                        principalTable: "Sermons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmallGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinistryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MeetingDay = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    MeetingTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LeaderMemberId = table.Column<long>(type: "bigint", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmallGroups_Members_LeaderMemberId",
                        column: x => x.LeaderMemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SmallGroups_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    LastName = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    VisitDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ConvertedMemberId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Members_ConvertedMemberId",
                        column: x => x.ConvertedMemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ServingRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    RespondedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SubstituteMemberId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServingRequests_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServingRequests_ServingSchedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "ServingSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmallGroupMembers",
                columns: table => new
                {
                    SmallGroupId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallGroupMembers", x => new { x.SmallGroupId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_SmallGroupMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmallGroupMembers_SmallGroups_SmallGroupId",
                        column: x => x.SmallGroupId,
                        principalTable: "SmallGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_registrations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    MemberId = table.Column<long>(type: "bigint", nullable: true),
                    VisitorId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_registrations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_event_registrations_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_event_registrations_church_events_EventId",
                        column: x => x.EventId,
                        principalTable: "church_events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CreatedBy",
                table: "Announcements",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_MinistryId",
                table: "Announcements",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UserId",
                table: "AuditLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildCheckIns_ChildId",
                table: "ChildCheckIns",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildGuardians_MemberId",
                table: "ChildGuardians",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionSubmissions_MemberId",
                table: "ConnectionSubmissions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_MemberId",
                table: "Donations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ProviderReference",
                table: "Donations",
                column: "ProviderReference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_EventId",
                table: "event_registrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_MemberId",
                table: "event_registrations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_event_registrations_VisitorId",
                table: "event_registrations",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MinistryMembers_MemberId",
                table: "MinistryMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Code",
                table: "Permissions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrayerRequests_MemberId",
                table: "PrayerRequests",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_TokenHash",
                table: "RefreshTokens",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SermonNotes_MemberId",
                table: "SermonNotes",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SermonNotes_SermonId",
                table: "SermonNotes",
                column: "SermonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServingRequests_MemberId",
                table: "ServingRequests",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ServingRequests_ScheduleId",
                table: "ServingRequests",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServingRoles_MinistryId",
                table: "ServingRoles",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServingSchedules_ServingRoleId",
                table: "ServingSchedules",
                column: "ServingRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallGroupMembers_MemberId",
                table: "SmallGroupMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallGroups_LeaderMemberId",
                table: "SmallGroups",
                column: "LeaderMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SmallGroups_MinistryId",
                table: "SmallGroups",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_ConvertedMemberId",
                table: "Visitors",
                column: "ConvertedMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ChildCheckIns");

            migrationBuilder.DropTable(
                name: "ChildGuardians");

            migrationBuilder.DropTable(
                name: "ConnectionSubmissions");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "event_registrations");

            migrationBuilder.DropTable(
                name: "MinistryMembers");

            migrationBuilder.DropTable(
                name: "Podcasts");

            migrationBuilder.DropTable(
                name: "PrayerRequests");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "SermonNotes");

            migrationBuilder.DropTable(
                name: "ServingRequests");

            migrationBuilder.DropTable(
                name: "SmallGroupMembers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "church_events");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Sermons");

            migrationBuilder.DropTable(
                name: "ServingSchedules");

            migrationBuilder.DropTable(
                name: "SmallGroups");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ServingRoles");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Ministries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
