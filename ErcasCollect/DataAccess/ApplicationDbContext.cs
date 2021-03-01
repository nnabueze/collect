using ErcasCollect.Domain.Models;
using ErcasCollect.Domain.Models.SqlViewModels;
using ErcasCollect.Helpers;
using ErcasCollect.Helpers.Seeder;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.DataAccess
{
    public class ApplicationDbContext : DbContext
    {

        //public DbSet<Status> Statuses{ get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Biller> Billers { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<BillerTINDetail> BillerTinDetails{ get; set; }
        public DbSet<BillerType> BillerTypes { get; set; }
        public DbSet<LevelOne> LevelOne{ get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<LevelTwo> LevelTwo{ get; set; }
        public DbSet<OS> Os{ get; set; }
        public DbSet<PaymentChannel> PaymentChannels { get; set; }
        public DbSet<Pos> Poses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Batch> Batchs { get; set; }
        public DbSet<MetaData> MetaData { get; set; }

        public DbSet<BillerNotification> BillerNotifications { get; set; }

        public DbSet<BillerEbillsProduct> BillerEbillsProducts { get; set; }

        public DbSet<BillerValidation> BillerValidations { get; set; }
        public DbSet<LevelDisplayName> LevelDisplayNames{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<PosLocation> PosLocation { get; set; }
        public DbSet<TaxPayer> TaxPayers { get; set; }
        public DbSet<NumberSeries> NumberSeries { get; set; }
        public DbSet<FundSweep> FundSweep{ get; set; }
        public DbSet<TransactionSummaryView> TransactionSummaryViews { get; set; }

        public DbSet<CategoryOneService> CategoryOneServices { get; set; }

        public DbSet<CategoryTwoService> CategoryTwoServices { get; set; }

        public DbSet<CloseBatchTransaction> CloseBatchTransactions { get; set; }

        public DbSet<EbillsProduct> EbillsProducts { get; set; }

        public DbSet<HqAllBillersYearlyTotalAmount> HqAllBillersYearlyTotalAmount { get; set; }

        public DbSet<HqBillerTotal> HqBillerTotal { get; set; }

        public DbSet<HqYearlyTransactionTotal> HqYearlyTransactionTotal { get; set; }

        public DbSet<HqTotalUser> HqTotalUser { get; set; }

        public DbSet<HqTotalPos> HqTotalPos { get; set; }

        public DbSet<HqDaylyTotalAmount> HqDaylyTotalAmount { get; set; }

        public DbSet<HqYestardayTotalAmount> HqYestardayTotalAmount { get; set; }

        public DbSet<HqWeeklyTotalAmount> HqWeeklyTotalAmount { get; set; }

        public DbSet<MonthlyTopPerformingBillers> MonthlyTopPerformingBillers { get; set; }

        public DbSet<HqAllBillersMonthlyTotalAmount> HqAllBillersMonthlyTotalAmount { get; set; }

        public DbSet<HqMonthlyTransactionTotal> HqMonthlyTransactionTotal { get; set; }

        public DbSet<HqAllBillersMonthlyCashAtHand> HqAllBillersMonthlyCashAtHand { get; set; }

        public DbSet<BillerMonthlyTotalTransactions> BillerMonthlyTotalTransactions { get; set; }

        public DbSet<BillerTotalUser> BillerTotalUser { get; set; }

        public DbSet<BillerTotalCashAtHand> BillerTotalCashAtHand { get; set; }

        public DbSet<BillerTodayTotalAmountProcessed> BillerTodayTotalAmountProcessed { get; set; }

        public DbSet<BillerYesterdayTotalAmountProcessed> BillerYesterdayTotalAmountProcessed { get; set; }

        public DbSet<BillerWeeklyTotalAmountProcessed> BillerWeeklyTotalAmountProcessed { get; set; }

        public DbSet<BillerTopPerformingLevelOne> BillerTopPerformingLevelOne { get; set; }

        public DbSet<BillerAgentCashAtHand> BillerAgentCashAtHand { get; set; }






        //public DbSet<typeof(BaseEntity<>)> Applicant { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();

            builder.RoleSeed();

            builder.BillerTypeSeed();

            builder.PaymentChannelSeed();

            builder.TransactionTypeSeed();

            builder.LinkView();

            builder.Entity<Biller>()
              .HasIndex(x => x.ReferenceKey)
                .IsUnique();

            builder.Entity<Biller>()
              .HasIndex(x => x.Abbreviation)
                .IsUnique();

            builder.Entity<CloseBatchTransaction>()
              .HasIndex(x => x.ReferenceKey)
                .IsUnique();

            builder.Entity<Pos>()
                .HasIndex(x => x.ActivationPin)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.Entity<Pos>()
                .HasIndex(x => x.PosImei)
                .IsUnique();

            builder.Entity<Batch>()
              .HasIndex(x => x.OfflineBatchId)
                .IsUnique();

            builder.Entity<Batch>()
              .HasIndex(x => x.ReferenceKey)
                .IsUnique();

            builder.Entity<Transaction>()
              .HasIndex(x => x.OfflineBatchId)
                .IsUnique();

            builder.Entity<Transaction>()
              .HasIndex(x => x.ReferenceKey)
                .IsUnique();

            builder.Entity<LevelOne>()
                .HasIndex(x => x.ReferenceKey)
                .IsUnique();

            builder.Entity<LevelTwo>()
                .HasIndex(x => x.ReferenceKey)
                .IsUnique();

            builder.Entity<LevelOne>()
                .HasMany(x => x.LevelTwo)
                .WithOne(x => x.LevelOne)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Biller>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Biller)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
