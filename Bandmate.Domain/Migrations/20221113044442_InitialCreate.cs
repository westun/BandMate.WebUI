using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bandmate.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    B2CObjectIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    BandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.BandID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "AccountCredential",
                columns: table => new
                {
                    AccountCredentialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCredential", x => x.AccountCredentialID);
                    table.ForeignKey(
                        name: "FK_AccountCredential_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetRequests",
                columns: table => new
                {
                    PasswordResetRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Revoked = table.Column<bool>(type: "bit", nullable: false),
                    Expires = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetRequests", x => x.PasswordResetRequestID);
                    table.ForeignKey(
                        name: "FK_PasswordResetRequests_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueID);
                    table.ForeignKey(
                        name: "FK_Venues_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandAccounts",
                columns: table => new
                {
                    BandID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandAccounts", x => new { x.BandID, x.AccountID });
                    table.ForeignKey(
                        name: "FK_BandAccounts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandAccounts_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BandNames",
                columns: table => new
                {
                    BandNameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandNames", x => x.BandNameID);
                    table.ForeignKey(
                        name: "FK_BandNames_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    ElectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.ElectionID);
                    table.ForeignKey(
                        name: "FK_Elections_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetLists",
                columns: table => new
                {
                    SetListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    BandID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetLists", x => x.SetListID);
                    table.ForeignKey(
                        name: "FK_SetLists_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetLists_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongListTypes",
                columns: table => new
                {
                    SongListTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongListTypes", x => x.SongListTypeID);
                    table.ForeignKey(
                        name: "FK_SongListTypes_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRole",
                columns: table => new
                {
                    AccountsAccountID = table.Column<int>(type: "int", nullable: false),
                    RolesRoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => new { x.AccountsAccountID, x.RolesRoleID });
                    table.ForeignKey(
                        name: "FK_AccountRole_Accounts_AccountsAccountID",
                        column: x => x.AccountsAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRole_Role_RolesRoleID",
                        column: x => x.RolesRoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gigs",
                columns: table => new
                {
                    GigID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueID = table.Column<int>(type: "int", nullable: false),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    SetListID = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gigs", x => x.GigID);
                    table.ForeignKey(
                        name: "FK_Gigs_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gigs_SetLists_SetListID",
                        column: x => x.SetListID,
                        principalTable: "SetLists",
                        principalColumn: "SetListID");
                    table.ForeignKey(
                        name: "FK_Gigs_Venues_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venues",
                        principalColumn: "VenueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandID = table.Column<int>(type: "int", nullable: false),
                    SongListTypeID = table.Column<int>(type: "int", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bpm = table.Column<int>(type: "int", nullable: true),
                    KeySignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mp3FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TabFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyricFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SheetMusicFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SheetMusicURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LyricURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Songs_Bands_BandID",
                        column: x => x.BandID,
                        principalTable: "Bands",
                        principalColumn: "BandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_SongListTypes_SongListTypeID",
                        column: x => x.SongListTypeID,
                        principalTable: "SongListTypes",
                        principalColumn: "SongListTypeID");
                });

            migrationBuilder.CreateTable(
                name: "ElectionSong",
                columns: table => new
                {
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionSong", x => new { x.ElectionID, x.SongID });
                    table.ForeignKey(
                        name: "FK_ElectionSong_Elections_ElectionID",
                        column: x => x.ElectionID,
                        principalTable: "Elections",
                        principalColumn: "ElectionID");
                    table.ForeignKey(
                        name: "FK_ElectionSong_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongID");
                });

            migrationBuilder.CreateTable(
                name: "ElectionVotes",
                columns: table => new
                {
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    SongID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Remove = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionVotes", x => new { x.ElectionID, x.SongID, x.AccountID });
                    table.ForeignKey(
                        name: "FK_ElectionVotes_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_ElectionVotes_Elections_ElectionID",
                        column: x => x.ElectionID,
                        principalTable: "Elections",
                        principalColumn: "ElectionID");
                    table.ForeignKey(
                        name: "FK_ElectionVotes_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongID");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Rated = table.Column<double>(type: "float", nullable: false),
                    Priority = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Ratings_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SetListItems",
                columns: table => new
                {
                    SetListItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongID = table.Column<int>(type: "int", nullable: false),
                    SetListID = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetListItems", x => x.SetListItemID);
                    table.ForeignKey(
                        name: "FK_SetListItems_SetLists_SetListID",
                        column: x => x.SetListID,
                        principalTable: "SetLists",
                        principalColumn: "SetListID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetListItems_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongID");
                });

            migrationBuilder.CreateTable(
                name: "SongAccounts",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongAccounts", x => new { x.SongID, x.AccountID });
                    table.ForeignKey(
                        name: "FK_SongAccounts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongAccounts_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCredential_AccountID",
                table: "AccountCredential",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_RolesRoleID",
                table: "AccountRole",
                column: "RolesRoleID");

            migrationBuilder.CreateIndex(
                name: "IX_BandAccounts_AccountID",
                table: "BandAccounts",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_BandNames_BandID",
                table: "BandNames",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_BandID",
                table: "Elections",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionSong_SongID",
                table: "ElectionSong",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionVotes_AccountID",
                table: "ElectionVotes",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionVotes_SongID",
                table: "ElectionVotes",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_BandID",
                table: "Gigs",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_SetListID",
                table: "Gigs",
                column: "SetListID");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_VenueID",
                table: "Gigs",
                column: "VenueID");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetRequests_AccountID",
                table: "PasswordResetRequests",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetRequests_Token",
                table: "PasswordResetRequests",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AccountID",
                table: "Ratings",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SongID",
                table: "Ratings",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_SetListItems_SetListID",
                table: "SetListItems",
                column: "SetListID");

            migrationBuilder.CreateIndex(
                name: "IX_SetListItems_SongID",
                table: "SetListItems",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_SetLists_AccountID",
                table: "SetLists",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_SetLists_BandID",
                table: "SetLists",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_SongAccounts_AccountID",
                table: "SongAccounts",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_SongListTypes_BandID",
                table: "SongListTypes",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_BandID",
                table: "Songs",
                column: "BandID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_SongListTypeID",
                table: "Songs",
                column: "SongListTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_AddressID",
                table: "Venues",
                column: "AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCredential");

            migrationBuilder.DropTable(
                name: "AccountRole");

            migrationBuilder.DropTable(
                name: "BandAccounts");

            migrationBuilder.DropTable(
                name: "BandNames");

            migrationBuilder.DropTable(
                name: "ElectionSong");

            migrationBuilder.DropTable(
                name: "ElectionVotes");

            migrationBuilder.DropTable(
                name: "Gigs");

            migrationBuilder.DropTable(
                name: "PasswordResetRequests");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "SetListItems");

            migrationBuilder.DropTable(
                name: "SongAccounts");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "SetLists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "SongListTypes");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
