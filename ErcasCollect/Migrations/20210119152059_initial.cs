using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErcasCollect.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NumberSeries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFor = table.Column<string>(nullable: true),
                    Acronym = table.Column<string>(nullable: true),
                    LastIssued = table.Column<int>(nullable: false),
                    LastDateIssued = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Os",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Os", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentChannels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(64)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<string>(nullable: true),
                    BankId = table.Column<string>(nullable: true),
                    BankId1 = table.Column<int>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    BVN = table.Column<string>(nullable: true),
                    IsValidated = table.Column<bool>(nullable: false),
                    AccountName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_Banks_BankId1",
                        column: x => x.BankId1,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillerTypeId = table.Column<int>(nullable: false),
                    FieldOne = table.Column<string>(nullable: true),
                    FieldTwo = table.Column<string>(nullable: true),
                    FieldThree = table.Column<string>(nullable: true),
                    FieldFour = table.Column<string>(nullable: true),
                    FieldFive = table.Column<string>(nullable: true),
                    FieldSix = table.Column<string>(nullable: true),
                    FieldSeven = table.Column<string>(nullable: true),
                    FieldEight = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaData_BillerTypes_BillerTypeId",
                        column: x => x.BillerTypeId,
                        principalTable: "BillerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Billers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    BillerTypeId = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    StatusCode = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Commission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billers_BillerTypes_BillerTypeId",
                        column: x => x.BillerTypeId,
                        principalTable: "BillerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Billers_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillerTinDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillerId = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId1 = table.Column<int>(nullable: true),
                    TIN = table.Column<string>(nullable: true),
                    IsValidated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillerTinDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillerTinDetails_Billers_BillerId1",
                        column: x => x.BillerId1,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelOne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    FundsweepPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelOne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelOne_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    BankId = table.Column<int>(nullable: false),
                    BillerId = table.Column<int>(nullable: false),
                    PaymentChannelId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    PaidBy = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    PayerPhone = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    ReferenceID = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    TransactionNumber = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settlements_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settlements_PaymentChannels_PaymentChannelId",
                        column: x => x.PaymentChannelId,
                        principalTable: "PaymentChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settlements_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BillerId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false),
                    LastPaidDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPayers_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelTwo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BillerId = table.Column<int>(nullable: false),
                    LevelOneId = table.Column<int>(nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelTwo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelTwo_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelTwo_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundSweep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillerId = table.Column<int>(nullable: false),
                    LevelOneId = table.Column<int>(nullable: true),
                    LevelTwoId = table.Column<int>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    DateProcessed = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    isProcessed = table.Column<bool>(nullable: false),
                    isConfirmed = table.Column<bool>(nullable: false),
                    ConfirmedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundSweep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundSweep_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundSweep_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundSweep_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundSweep_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelThree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillerId = table.Column<int>(nullable: false),
                    LevelOneId = table.Column<int>(nullable: true),
                    LevelTwoId = table.Column<int>(nullable: true),
                    IsAmountFixed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelThree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelThree_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelThree_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LevelThree_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionSummaryViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillerId = table.Column<int>(nullable: false),
                    LevelOneId = table.Column<int>(nullable: true),
                    LevelTwoId = table.Column<int>(nullable: true),
                    AmountCollected = table.Column<decimal>(nullable: false),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    isClosed = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateClosed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSummaryViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionSummaryViews_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionSummaryViews_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionSummaryViews_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SsoId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    BillerId = table.Column<int>(nullable: false),
                    LevelTwoId = table.Column<int>(nullable: true),
                    LevelOneId = table.Column<int>(nullable: true),
                    StatusCode = table.Column<int>(nullable: false),
                    CollectionLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CashAtHand = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Batchs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCount = table.Column<int>(nullable: false),
                    OfflineId = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    BillerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batchs_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batchs_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OSId = table.Column<int>(nullable: false),
                    Version = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    BillerId = table.Column<int>(nullable: false),
                    LevelOneId = table.Column<int>(nullable: true),
                    Activationpin = table.Column<string>(nullable: true),
                    LevelTwoId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poses_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poses_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poses_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poses_Os_OSId",
                        column: x => x.OSId,
                        principalTable: "Os",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    Createdby = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemittanceNumber = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    PosId = table.Column<int>(nullable: false),
                    PayerName = table.Column<string>(nullable: true),
                    PayerPhone = table.Column<string>(nullable: true),
                    AgentId = table.Column<int>(nullable: false),
                    SessionId = table.Column<string>(nullable: true),
                    OfflineSessionId = table.Column<string>(nullable: true),
                    BillerId = table.Column<int>(nullable: true),
                    BatchId = table.Column<int>(nullable: false),
                    OfflineBatchId = table.Column<string>(nullable: true),
                    TransactionTypeId = table.Column<int>(nullable: false),
                    PaymentChannelId = table.Column<int>(nullable: false),
                    TransactionNumber = table.Column<string>(nullable: true),
                    LevelOneId = table.Column<int>(nullable: true),
                    LevelTwoId = table.Column<int>(nullable: true),
                    LevelThreeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Billers_BillerId",
                        column: x => x.BillerId,
                        principalTable: "Billers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_LevelOne_LevelOneId",
                        column: x => x.LevelOneId,
                        principalTable: "LevelOne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_LevelThree_LevelThreeId",
                        column: x => x.LevelThreeId,
                        principalTable: "LevelThree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_LevelTwo_LevelTwoId",
                        column: x => x.LevelTwoId,
                        principalTable: "LevelTwo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_PaymentChannels_PaymentChannelId",
                        column: x => x.PaymentChannelId,
                        principalTable: "PaymentChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Poses_PosId",
                        column: x => x.PosId,
                        principalTable: "Poses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_BankId1",
                table: "BankDetails",
                column: "BankId1");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_AgentId",
                table: "Batchs",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_BillerId",
                table: "Batchs",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Billers_BillerTypeId",
                table: "Billers",
                column: "BillerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Billers_StateId",
                table: "Billers",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_BillerTinDetails_BillerId1",
                table: "BillerTinDetails",
                column: "BillerId1");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_BankId",
                table: "FundSweep",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_BillerId",
                table: "FundSweep",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_LevelOneId",
                table: "FundSweep",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_FundSweep_LevelTwoId",
                table: "FundSweep",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOne_BillerId",
                table: "LevelOne",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_BillerId",
                table: "LevelThree",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_LevelOneId",
                table: "LevelThree",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelThree_LevelTwoId",
                table: "LevelThree",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_BillerId",
                table: "LevelTwo",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelTwo_LevelOneId",
                table: "LevelTwo",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_BillerTypeId",
                table: "MetaData",
                column: "BillerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_BillerId",
                table: "Poses",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_LevelOneId",
                table: "Poses",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_LevelTwoId",
                table: "Poses",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_OSId",
                table: "Poses",
                column: "OSId");

            migrationBuilder.CreateIndex(
                name: "IX_Poses_UserId",
                table: "Poses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BankId",
                table: "Settlements",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_BillerId",
                table: "Settlements",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_PaymentChannelId",
                table: "Settlements",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_TransactionTypeId",
                table: "Settlements",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayers_BillerId",
                table: "TaxPayers",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AgentId",
                table: "Transactions",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BillerId",
                table: "Transactions",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LevelOneId",
                table: "Transactions",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LevelThreeId",
                table: "Transactions",
                column: "LevelThreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LevelTwoId",
                table: "Transactions",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PaymentChannelId",
                table: "Transactions",
                column: "PaymentChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PosId",
                table: "Transactions",
                column: "PosId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_BillerId",
                table: "TransactionSummaryViews",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_LevelOneId",
                table: "TransactionSummaryViews",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSummaryViews_LevelTwoId",
                table: "TransactionSummaryViews",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BillerId",
                table: "Users",
                column: "BillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelOneId",
                table: "Users",
                column: "LevelOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LevelTwoId",
                table: "Users",
                column: "LevelTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Batchs");

            migrationBuilder.DropTable(
                name: "BillerTinDetails");

            migrationBuilder.DropTable(
                name: "FundSweep");

            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.DropTable(
                name: "NumberSeries");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "TaxPayers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionSummaryViews");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "LevelThree");

            migrationBuilder.DropTable(
                name: "PaymentChannels");

            migrationBuilder.DropTable(
                name: "Poses");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "Os");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LevelTwo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "LevelOne");

            migrationBuilder.DropTable(
                name: "Billers");

            migrationBuilder.DropTable(
                name: "BillerTypes");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
