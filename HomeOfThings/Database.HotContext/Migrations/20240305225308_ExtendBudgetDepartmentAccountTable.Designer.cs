﻿// <auto-generated />
using System;
using Database.HotContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.HotContext.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240305225308_ExtendBudgetDepartmentAccountTable")]
    partial class ExtendBudgetDepartmentAccountTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Date.Models.Entities.Finance.BudgetAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BudgetAccountTable");
                });

            modelBuilder.Entity("Date.Models.Entities.Finance.BudgetDepartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BudgetDepartmentTable");
                });

            modelBuilder.Entity("Date.Models.Entities.Finance.BudgetDepartmentAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPayment")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("DepartmentId")
                        .IsUnique();

                    b.ToTable("BudgetDepartmentAccountTable");
                });

            modelBuilder.Entity("Date.Models.Entities.Log.LogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("ExMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StackTrace")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Trigger")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LogTable");
                });

            modelBuilder.Entity("Date.Models.Entities.User.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("UserRolesJson")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1960),
                            CreatedBy = "System",
                            DateOfBirth = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "exampleuser@gmx.com",
                            EmailConfirmed = false,
                            FirstName = "",
                            IsActive = true,
                            LastName = "",
                            Password = "UEBzc3dvcmRiZmZjYjEzMy02ZTM0LTRmYzUtOGU5My1kNGM3OGE4YWE5NmE=",
                            Salt = "bffcb133-6e34-4fc5-8e93-d4c78a8aa96a",
                            UserRolesJson = "{\"Name\":\"System Admin\",\"Description\":\"System Admin User\",\"Id\":3,\"CreatedBy\":\"System\",\"CreatedAt\":\"2024-03-05T22:53:08.4321962Z\",\"UpdatedBy\":null,\"UpdatedAt\":null}"
                        });
                });

            modelBuilder.Entity("Date.Models.Entities.User.UserRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserRolesTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1560),
                            CreatedBy = "System",
                            Description = "Default User",
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1566),
                            CreatedBy = "System",
                            Description = "Admin User",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 3, 5, 22, 53, 8, 432, DateTimeKind.Utc).AddTicks(1567),
                            CreatedBy = "System",
                            Description = "System Admin User",
                            Name = "System Admin"
                        });
                });

            modelBuilder.Entity("Date.Models.Entities.Finance.BudgetDepartmentAccount", b =>
                {
                    b.HasOne("Date.Models.Entities.Finance.BudgetAccount", "Account")
                        .WithOne("FinanceAccountDepartment")
                        .HasForeignKey("Date.Models.Entities.Finance.BudgetDepartmentAccount", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Date.Models.Entities.Finance.BudgetDepartment", "Department")
                        .WithOne("FinanceAccountDepartment")
                        .HasForeignKey("Date.Models.Entities.Finance.BudgetDepartmentAccount", "DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Date.Models.Entities.Finance.BudgetAccount", b =>
                {
                    b.Navigation("FinanceAccountDepartment")
                        .IsRequired();
                });

            modelBuilder.Entity("Date.Models.Entities.Finance.BudgetDepartment", b =>
                {
                    b.Navigation("FinanceAccountDepartment")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}