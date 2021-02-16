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
