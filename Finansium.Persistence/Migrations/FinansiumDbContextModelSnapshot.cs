﻿// <auto-generated />
using System;
using Finansium.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Finansium.Persistence.Migrations
{
    [DbContext(typeof(FinansiumDbContext))]
    partial class FinansiumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("core")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Finansium.Domain.Accounts.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_accounts_user_id");

                    b.ToTable("accounts", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Accounts.AccountTransfer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<decimal>("CurrencyRate")
                        .HasColumnType("numeric")
                        .HasColumnName("currency_rate");

                    b.Property<string>("SourceAccountId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("source_account_id");

                    b.Property<string>("TargetAccountId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("target_account_id");

                    b.Property<DateTimeOffset>("TransferDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("transfer_date");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_account_transfers");

                    b.HasIndex("SourceAccountId")
                        .HasDatabaseName("ix_account_transfers_source_account_id");

                    b.HasIndex("TargetAccountId")
                        .HasDatabaseName("ix_account_transfers_target_account_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_account_transfers_user_id");

                    b.ToTable("account_transfers", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Categories.ExpenseCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<decimal?>("MonthlyLimit")
                        .HasColumnType("numeric")
                        .HasColumnName("monthly_limit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_expense_categories");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_expense_categories_user_id");

                    b.ToTable("expense_categories", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Categories.IncomeCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_income_categories");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_income_categories_user_id");

                    b.ToTable("income_categories", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Counties.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Alpha2Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alpha2code");

                    b.Property<string>("Alpha3Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("alpha3code");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<short>("NumericCode")
                        .HasColumnType("smallint")
                        .HasColumnName("numeric_code");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("short_name");

                    b.HasKey("Id")
                        .HasName("pk_countries");

                    b.ToTable("countries", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Expenses.AutomatedExpense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<string>("ExpenseCategoryId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("expense_category_id");

                    b.Property<DateTimeOffset?>("NextPaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("next_payment_date");

                    b.Property<TimeSpan?>("RecurrenceInterval")
                        .HasColumnType("interval")
                        .HasColumnName("recurrence_interval");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_automated_expenses");

                    b.HasIndex("ExpenseCategoryId")
                        .HasDatabaseName("ix_automated_expenses_expense_category_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_automated_expenses_user_id");

                    b.ToTable("automated_expenses", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Expenses.Expense", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Acount")
                        .HasColumnType("numeric")
                        .HasColumnName("acount");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ExpenseCategoryId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("expense_category_id");

                    b.HasKey("Id")
                        .HasName("pk_expenses");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_expenses_account_id");

                    b.HasIndex("ExpenseCategoryId")
                        .HasDatabaseName("ix_expenses_expense_category_id");

                    b.ToTable("expenses", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Incomes.AutomatedIncome", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTimeOffset?>("NextPaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("next_payment_date");

                    b.Property<TimeSpan?>("RecurrenceInterval")
                        .HasColumnType("interval")
                        .HasColumnName("recurrence_interval");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_automated_incomes");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_automated_incomes_user_id");

                    b.ToTable("automated_incomes", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Incomes.Income", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("AccountId")
                        .HasColumnType("text")
                        .HasColumnName("account_id");

                    b.Property<string>("AcoountId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("acoount_id");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<string>("IncomeCategoryId")
                        .HasColumnType("text")
                        .HasColumnName("income_category_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_incomes");

                    b.HasIndex("AccountId")
                        .HasDatabaseName("ix_incomes_account_id");

                    b.HasIndex("IncomeCategoryId")
                        .HasDatabaseName("ix_incomes_income_category_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_incomes_user_id");

                    b.ToTable("incomes", "core");
                });

            modelBuilder.Entity("Finansium.Domain.News.News", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsOutDated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_out_dated");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_news");

                    b.ToTable("news", "core");
                });

            modelBuilder.Entity("Finansium.Domain.OutboxMessages.OutboxMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<string>("Error")
                        .HasColumnType("text")
                        .HasColumnName("error");

                    b.Property<DateTimeOffset>("OccurredOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("occurred_on_utc");

                    b.Property<DateTimeOffset?>("ProcessedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("processed_on_utc");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_outbox_messages");

                    b.ToTable("outbox_messages", "core");
                });

            modelBuilder.Entity("Finansium.Domain.SavingsGoals.SavingsGoal", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTimeOffset?>("CompletedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("completed_date");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_completed");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_savings_goals");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_savings_goals_user_id");

                    b.ToTable("savings_goals", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Users.Permission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_permissions_role_id");

                    b.ToTable("permissions", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Users.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2024, 10, 21, 16, 46, 56, 739, DateTimeKind.Unspecified).AddTicks(1015), new TimeSpan(0, 0, 0, 0, 0)))
                        .HasColumnName("created_at");

                    b.Property<DateTimeOffset>("ExpiredAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expired_at");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(88)
                        .HasColumnType("character varying(88)")
                        .HasColumnName("token");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_refresh_token");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_refresh_token_user_id");

                    b.ToTable("refresh_token", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Users.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("surname");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("ix_users_country_id");

                    b.HasIndex("Username", "Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_username_email");

                    b.ToTable("users", "core");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("text")
                        .HasColumnName("roles_id");

                    b.Property<string>("UsersId")
                        .HasColumnType("text")
                        .HasColumnName("users_id");

                    b.HasKey("RolesId", "UsersId")
                        .HasName("pk_role_user");

                    b.HasIndex("UsersId")
                        .HasDatabaseName("ix_role_user_users_id");

                    b.ToTable("role_user", "core");
                });

            modelBuilder.Entity("Finansium.Domain.Accounts.Account", b =>
                {
                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_accounts_users_user_id");

                    b.OwnsOne("Finansium.Domain.Shared.Money", "Balance", b1 =>
                        {
                            b1.Property<string>("AccountId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("balance_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("balance_currency");

                            b1.HasKey("AccountId");

                            b1.ToTable("accounts", "core");

                            b1.WithOwner()
                                .HasForeignKey("AccountId")
                                .HasConstraintName("fk_accounts_accounts_id");
                        });

                    b.Navigation("Balance")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Accounts.AccountTransfer", b =>
                {
                    b.HasOne("Finansium.Domain.Accounts.Account", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_account_transfers_accounts_source_account_id");

                    b.HasOne("Finansium.Domain.Accounts.Account", "TargetAccount")
                        .WithMany()
                        .HasForeignKey("TargetAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_account_transfers_accounts_target_account_id");

                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_account_transfers_users_user_id");

                    b.OwnsOne("Finansium.Domain.Shared.Money", "Amount", b1 =>
                        {
                            b1.Property<string>("AccountTransferId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("amount_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("amount_currency");

                            b1.HasKey("AccountTransferId");

                            b1.ToTable("account_transfers", "core");

                            b1.WithOwner()
                                .HasForeignKey("AccountTransferId")
                                .HasConstraintName("fk_account_transfers_account_transfers_id");
                        });

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("SourceAccount");

                    b.Navigation("TargetAccount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Categories.ExpenseCategory", b =>
                {
                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_expense_categories_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Categories.IncomeCategory", b =>
                {
                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_income_categories_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Expenses.AutomatedExpense", b =>
                {
                    b.HasOne("Finansium.Domain.Categories.ExpenseCategory", "ExpenseCategory")
                        .WithMany()
                        .HasForeignKey("ExpenseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_automated_expenses_expense_categories_expense_category_id");

                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany("AutomatedExpenses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_automated_expenses_users_user_id");

                    b.Navigation("ExpenseCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Expenses.Expense", b =>
                {
                    b.HasOne("Finansium.Domain.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_expenses_accounts_account_id");

                    b.HasOne("Finansium.Domain.Categories.ExpenseCategory", "ExpenseCategory")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_expenses_expense_categories_expense_category_id");

                    b.Navigation("Account");

                    b.Navigation("ExpenseCategory");
                });

            modelBuilder.Entity("Finansium.Domain.Incomes.AutomatedIncome", b =>
                {
                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany("AutomatedIncomes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_automated_incomes_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Incomes.Income", b =>
                {
                    b.HasOne("Finansium.Domain.Accounts.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_incomes_accounts_account_id");

                    b.HasOne("Finansium.Domain.Categories.IncomeCategory", null)
                        .WithMany("Incomes")
                        .HasForeignKey("IncomeCategoryId")
                        .HasConstraintName("fk_incomes_income_categories_income_category_id");

                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_incomes_users_user_id");

                    b.OwnsOne("Finansium.Domain.Shared.Money", "Amount", b1 =>
                        {
                            b1.Property<string>("IncomeId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("amount_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("amount_currency");

                            b1.HasKey("IncomeId");

                            b1.ToTable("incomes", "core");

                            b1.WithOwner()
                                .HasForeignKey("IncomeId")
                                .HasConstraintName("fk_incomes_incomes_id");
                        });

                    b.Navigation("Account");

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.SavingsGoals.SavingsGoal", b =>
                {
                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany("SavingTrackers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_savings_goals_users_user_id");

                    b.OwnsOne("Finansium.Domain.Shared.Money", "Current", b1 =>
                        {
                            b1.Property<string>("SavingsGoalId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("current_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("current_currency");

                            b1.HasKey("SavingsGoalId");

                            b1.ToTable("savings_goals", "core");

                            b1.WithOwner()
                                .HasForeignKey("SavingsGoalId")
                                .HasConstraintName("fk_savings_goals_savings_goals_id");
                        });

                    b.OwnsOne("Finansium.Domain.Shared.Money", "Target", b1 =>
                        {
                            b1.Property<string>("SavingsGoalId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("target_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("target_currency");

                            b1.HasKey("SavingsGoalId");

                            b1.ToTable("savings_goals", "core");

                            b1.WithOwner()
                                .HasForeignKey("SavingsGoalId")
                                .HasConstraintName("fk_savings_goals_savings_goals_id");
                        });

                    b.Navigation("Current")
                        .IsRequired();

                    b.Navigation("Target")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Users.Permission", b =>
                {
                    b.HasOne("Finansium.Domain.Users.Role", null)
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_permissions_roles_role_id");
                });

            modelBuilder.Entity("Finansium.Domain.Users.RefreshToken", b =>
                {
                    b.HasOne("Finansium.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_refresh_token_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Finansium.Domain.Users.User", b =>
                {
                    b.HasOne("Finansium.Domain.Counties.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_countries_country_id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Finansium.Domain.Users.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_user_roles_roles_id");

                    b.HasOne("Finansium.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_user_users_users_id");
                });

            modelBuilder.Entity("Finansium.Domain.Categories.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Finansium.Domain.Categories.IncomeCategory", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("Finansium.Domain.Users.Role", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Finansium.Domain.Users.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("AutomatedExpenses");

                    b.Navigation("AutomatedIncomes");

                    b.Navigation("SavingTrackers");
                });
#pragma warning restore 612, 618
        }
    }
}
