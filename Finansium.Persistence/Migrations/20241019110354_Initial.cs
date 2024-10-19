using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finansium.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "core");

            migrationBuilder.CreateTable(
                name: "countries",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    short_name = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    alpha2code = table.Column<string>(type: "text", nullable: false),
                    alpha3code = table.Column<string>(type: "text", nullable: false),
                    numeric_code = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_out_dated = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "core",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "core",
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    balance_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    balance_currency = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "automated_incomes",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    next_payment_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    recurrence_interval = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_automated_incomes", x => x.id);
                    table.ForeignKey(
                        name: "fk_automated_incomes_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expense_categories",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    monthly_limit = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_expense_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_expense_categories_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "income_categories",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_income_categories", x => x.id);
                    table.ForeignKey(
                        name: "fk_income_categories_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "character varying(88)", maxLength: 88, nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2024, 10, 19, 11, 3, 53, 426, DateTimeKind.Unspecified).AddTicks(6796), new TimeSpan(0, 0, 0, 0, 0))),
                    expired_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_token", x => x.id);
                    table.ForeignKey(
                        name: "fk_refresh_token_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_user",
                schema: "core",
                columns: table => new
                {
                    roles_id = table.Column<string>(type: "text", nullable: false),
                    users_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_user", x => new { x.roles_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_role_user_roles_roles_id",
                        column: x => x.roles_id,
                        principalSchema: "core",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_user_users_users_id",
                        column: x => x.users_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "savings_goals",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    current_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    current_currency = table.Column<string>(type: "text", nullable: false),
                    target_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    target_currency = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_savings_goals", x => x.id);
                    table.ForeignKey(
                        name: "fk_savings_goals_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "account_transfers",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    source_account_id = table.Column<string>(type: "text", nullable: false),
                    target_account_id = table.Column<string>(type: "text", nullable: false),
                    amount_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    amount_currency = table.Column<string>(type: "text", nullable: false),
                    conversion_rate = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_transfers", x => x.id);
                    table.ForeignKey(
                        name: "fk_account_transfers_accounts_source_account_id",
                        column: x => x.source_account_id,
                        principalSchema: "core",
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_transfers_accounts_target_account_id",
                        column: x => x.target_account_id,
                        principalSchema: "core",
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "automated_expenses",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    expense_category_id = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    next_payment_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    recurrence_interval = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_automated_expenses", x => x.id);
                    table.ForeignKey(
                        name: "fk_automated_expenses_expense_categories_expense_category_id",
                        column: x => x.expense_category_id,
                        principalSchema: "core",
                        principalTable: "expense_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_automated_expenses_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "expenses",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    account_id = table.Column<string>(type: "text", nullable: false),
                    expense_category_id = table.Column<string>(type: "text", nullable: false),
                    acount = table.Column<decimal>(type: "numeric", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_expenses", x => x.id);
                    table.ForeignKey(
                        name: "fk_expenses_accounts_account_id",
                        column: x => x.account_id,
                        principalSchema: "core",
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_expenses_expense_categories_expense_category_id",
                        column: x => x.expense_category_id,
                        principalSchema: "core",
                        principalTable: "expense_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incomes",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    acoount_id = table.Column<string>(type: "text", nullable: false),
                    account_id = table.Column<string>(type: "text", nullable: true),
                    amount_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    amount_currency = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    income_category_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_incomes", x => x.id);
                    table.ForeignKey(
                        name: "fk_incomes_accounts_account_id",
                        column: x => x.account_id,
                        principalSchema: "core",
                        principalTable: "accounts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_incomes_income_categories_income_category_id",
                        column: x => x.income_category_id,
                        principalSchema: "core",
                        principalTable: "income_categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_incomes_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "core",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_account_transfers_source_account_id",
                schema: "core",
                table: "account_transfers",
                column: "source_account_id");

            migrationBuilder.CreateIndex(
                name: "ix_account_transfers_target_account_id",
                schema: "core",
                table: "account_transfers",
                column: "target_account_id");

            migrationBuilder.CreateIndex(
                name: "ix_accounts_user_id",
                schema: "core",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_automated_expenses_expense_category_id",
                schema: "core",
                table: "automated_expenses",
                column: "expense_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_automated_expenses_user_id",
                schema: "core",
                table: "automated_expenses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_automated_incomes_user_id",
                schema: "core",
                table: "automated_incomes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_expense_categories_user_id",
                schema: "core",
                table: "expense_categories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_expenses_account_id",
                schema: "core",
                table: "expenses",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_expenses_expense_category_id",
                schema: "core",
                table: "expenses",
                column: "expense_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_income_categories_user_id",
                schema: "core",
                table: "income_categories",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_incomes_account_id",
                schema: "core",
                table: "incomes",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_incomes_income_category_id",
                schema: "core",
                table: "incomes",
                column: "income_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_incomes_user_id",
                schema: "core",
                table: "incomes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_role_id",
                schema: "core",
                table: "permissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_refresh_token_user_id",
                schema: "core",
                table: "refresh_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_user_users_id",
                schema: "core",
                table: "role_user",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_savings_goals_user_id",
                schema: "core",
                table: "savings_goals",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_country_id",
                schema: "core",
                table: "users",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_username_email",
                schema: "core",
                table: "users",
                columns: new[] { "username", "email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_transfers",
                schema: "core");

            migrationBuilder.DropTable(
                name: "automated_expenses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "automated_incomes",
                schema: "core");

            migrationBuilder.DropTable(
                name: "expenses",
                schema: "core");

            migrationBuilder.DropTable(
                name: "incomes",
                schema: "core");

            migrationBuilder.DropTable(
                name: "news",
                schema: "core");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "core");

            migrationBuilder.DropTable(
                name: "refresh_token",
                schema: "core");

            migrationBuilder.DropTable(
                name: "role_user",
                schema: "core");

            migrationBuilder.DropTable(
                name: "savings_goals",
                schema: "core");

            migrationBuilder.DropTable(
                name: "expense_categories",
                schema: "core");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "core");

            migrationBuilder.DropTable(
                name: "income_categories",
                schema: "core");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "core");

            migrationBuilder.DropTable(
                name: "users",
                schema: "core");

            migrationBuilder.DropTable(
                name: "countries",
                schema: "core");
        }
    }
}
