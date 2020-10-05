﻿// <auto-generated />
using System;
using ErcasCollect.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ErcasCollect.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200827000516_init8")]
    partial class init8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ErcasCollect.Domain.Models.Bank", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Biller", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerTypeId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BillerTypeId");

                    b.HasIndex("StateId");

                    b.HasIndex("StatusId");

                    b.ToTable("Billers");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.BillerBankDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BVN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("BillerId");

                    b.ToTable("BillerBankDetails");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.BillerTINDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("bit");

                    b.Property<string>("TIN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.ToTable("BillerTinDetails");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.BillerType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("BillerTypes");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Branch", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("FundsweepPercentage")
                        .HasColumnType("decimal(18,6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.HasIndex("StatusId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.CashCollection", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PosId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("SessionID")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("PosId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TransactionId");

                    b.HasIndex("UserId");

                    b.ToTable("CashCollections");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BranchId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("Departmant")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.HasIndex("BranchId");

                    b.HasIndex("StatusId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.OS", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Os");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.PaymentChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("PaymentChannels");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Pos", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BranchId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OSId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Version")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.HasIndex("BranchId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("OSId");

                    b.HasIndex("UserId");

                    b.ToTable("Poses");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Service", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BranchId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsAmountFixed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.HasIndex("BranchId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("State");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.TaxPayer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("StatustId")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.HasIndex("StatusId");

                    b.ToTable("TaxPayers");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaidBy")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("PayerPhone")
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("PaymentChannelId")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceID")
                        .HasColumnType("nvarchar(32)");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("PaymentChannelId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BillerId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("BranchId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<decimal>("CollectionLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Createdby")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("SsoId")
                        .HasColumnType("int");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("BillerId");

                    b.HasIndex("BranchId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Biller", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.BillerType", "BillerType")
                        .WithMany()
                        .HasForeignKey("BillerTypeId");

                    b.HasOne("ErcasCollect.Domain.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErcasCollect.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.BillerBankDetail", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.BillerTINDetail", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Branch", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");

                    b.HasOne("ErcasCollect.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.CashCollection", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Pos", "Pos")
                        .WithMany()
                        .HasForeignKey("PosId");

                    b.HasOne("ErcasCollect.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("ErcasCollect.Domain.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");

                    b.HasOne("ErcasCollect.Domain.Models.User", "Agent")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Department", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");

                    b.HasOne("ErcasCollect.Domain.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("ErcasCollect.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Pos", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");

                    b.HasOne("ErcasCollect.Domain.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("ErcasCollect.Domain.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("ErcasCollect.Domain.Models.OS", "OS")
                        .WithMany()
                        .HasForeignKey("OSId");

                    b.HasOne("ErcasCollect.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Service", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");

                    b.HasOne("ErcasCollect.Domain.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("ErcasCollect.Domain.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.TaxPayer", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");

                    b.HasOne("ErcasCollect.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.Transaction", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("ErcasCollect.Domain.Models.PaymentChannel", "PaymentChannel")
                        .WithMany()
                        .HasForeignKey("PaymentChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErcasCollect.Domain.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ErcasCollect.Domain.Models.User", b =>
                {
                    b.HasOne("ErcasCollect.Domain.Models.Biller", "Biller")
                        .WithMany()
                        .HasForeignKey("BillerId");

                    b.HasOne("ErcasCollect.Domain.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("ErcasCollect.Domain.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("ErcasCollect.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ErcasCollect.Domain.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
