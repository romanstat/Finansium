using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansium.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "conversion_rate",
                schema: "core",
                table: "account_transfers",
                newName: "currency_rate");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "completed_date",
                schema: "core",
                table: "savings_goals",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_completed",
                schema: "core",
                table: "savings_goals",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                schema: "core",
                table: "refresh_token",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 10, 21, 15, 16, 26, 44, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 10, 21, 12, 27, 2, 572, DateTimeKind.Unspecified).AddTicks(920), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "core",
                table: "accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "transfer_date",
                schema: "core",
                table: "account_transfers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                schema: "core",
                table: "account_transfers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "outbox_messages",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    occurred_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    processed_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_messages", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_transfers_user_id",
                schema: "core",
                table: "account_transfers",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_account_transfers_users_user_id",
                schema: "core",
                table: "account_transfers",
                column: "user_id",
                principalSchema: "core",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_account_transfers_users_user_id",
                schema: "core",
                table: "account_transfers");

            migrationBuilder.DropTable(
                name: "outbox_messages",
                schema: "core");

            migrationBuilder.DropIndex(
                name: "ix_account_transfers_user_id",
                schema: "core",
                table: "account_transfers");

            migrationBuilder.DropColumn(
                name: "completed_date",
                schema: "core",
                table: "savings_goals");

            migrationBuilder.DropColumn(
                name: "is_completed",
                schema: "core",
                table: "savings_goals");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "core",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "transfer_date",
                schema: "core",
                table: "account_transfers");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "core",
                table: "account_transfers");

            migrationBuilder.RenameColumn(
                name: "currency_rate",
                schema: "core",
                table: "account_transfers",
                newName: "conversion_rate");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_at",
                schema: "core",
                table: "refresh_token",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 10, 21, 12, 27, 2, 572, DateTimeKind.Unspecified).AddTicks(920), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 10, 21, 15, 16, 26, 44, DateTimeKind.Unspecified).AddTicks(1515), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
