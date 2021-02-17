using ErcasCollect.Domain.Models.SqlViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers
{
    public static class ViewReportLink
    {
        public static void LinkView(this ModelBuilder builder)
        {


            builder
                .Entity<BillerAgentCashAtHand>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerAgentCashAtHand");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerTopPerformingLevelOne>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerTopPerformingLevelOne");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerWeeklyTotalAmountProcessed>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerWeeklyTotalAmountProcessed");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerYesterdayTotalAmountProcessed>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerYesterdayTotalAmountProcessed");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerTodayTotalAmountProcessed>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerTodayTotalAmountProcessed");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerTotalCashAtHand>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerTotalCashAtHand");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerTotalUser>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerTotalUser");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<BillerMonthlyTotalTransactions>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("BillerMonthlyTotalTransactions");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });

            builder
                .Entity<HqAllBillersMonthlyCashAtHand>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqAllBillersMonthlyCashAtHand");
                        eb.Property(v => v.TotalAmount).HasColumnName("TotalAmount");
                    });


            builder
                .Entity<HqMonthlyTransactionTotal>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqMonthlyTransactionTotal");
                        eb.Property(v => v.TotalTransaction).HasColumnName("TotalTransaction");
                    });

            builder
                .Entity<HqAllBillersMonthlyTotalAmount>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqAllBillersMonthlyTotalAmount");
                        eb.Property(v => v.TotalAmountProcessed).HasColumnName("TotalAmountProcessed");
                    });

            builder
                .Entity<MonthlyTopPerformingBillers>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("MonthlyTopPerformingBillers");
                        eb.Property(v => v.BillerId).HasColumnName("BillerId");
                    });


            builder
                .Entity<HqAllBillersYearlyTotalAmount>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqAllBillersYearlyTotalAmount");
                        eb.Property(v => v.TotalAmountProcessed).HasColumnName("TotalAmountProcessed");
                    });

            builder
                .Entity<HqBillerTotal>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqBillerTotal");
                        eb.Property(v => v.TotalBiller).HasColumnName("TotalBiller");
                    });

            builder
                .Entity<HqTotalUser>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqTotalUser");
                        eb.Property(v => v.TotalUser).HasColumnName("TotalUser");
                    });


            builder
                .Entity<HqYearlyTransactionTotal>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqYearlyTransactionTotal");
                        eb.Property(v => v.TotalTransaction).HasColumnName("TotalTransaction");
                    });


            builder
                .Entity<HqTotalPos>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqTotalPos");
                        eb.Property(v => v.TotalPos).HasColumnName("TotalPos");
                    });


            builder
                .Entity<HqDaylyTotalAmount>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqDaylyTotalAmount");
                        eb.Property(v => v.TotalAmountProcessed).HasColumnName("TotalAmountProcessed");
                    });


            builder
                .Entity<HqYestardayTotalAmount>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqYestardayTotalAmount");
                        eb.Property(v => v.TotalAmountProcessed).HasColumnName("TotalAmountProcessed");
                    });


            builder
                .Entity<HqWeeklyTotalAmount>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("HqWeeklyTotalAmount");
                        eb.Property(v => v.TotalAmountProcessed).HasColumnName("TotalAmountProcessed");
                    });

        }
    }
}
