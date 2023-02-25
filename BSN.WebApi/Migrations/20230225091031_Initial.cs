using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSN.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    PersonId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Persons_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Persons",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    TweetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AuthorPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuoteTweetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.TweetId);
                    table.ForeignKey(
                        name: "FK_Tweets_Persons_AuthorPersonId",
                        column: x => x.AuthorPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tweets_Tweets_QuoteTweetId",
                        column: x => x.QuoteTweetId,
                        principalTable: "Tweets",
                        principalColumn: "TweetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    AuthorPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    TwitTweetId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Persons_AuthorPersonId",
                        column: x => x.AuthorPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Tweets_TwitTweetId",
                        column: x => x.TwitTweetId,
                        principalTable: "Tweets",
                        principalColumn: "TweetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuthorPersonId",
                table: "Messages",
                column: "AuthorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_TwitTweetId",
                table: "Messages",
                column: "TwitTweetId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonId1",
                table: "Persons",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_AuthorPersonId",
                table: "Tweets",
                column: "AuthorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_QuoteTweetId",
                table: "Tweets",
                column: "QuoteTweetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
