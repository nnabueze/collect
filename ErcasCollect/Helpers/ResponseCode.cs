using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers
{
    public class ResponseCode
    {
        public int OK { get; set; }

        public int Created { get; set; }

        public int NoContent { get; set; }

        public int TransactionSuccessful { get; set; }

        public int AccountActivated { get; set; }

        public int RemmitanceGenerated { get; set; }

        public int POSActivated { get; set; }

        public int BadRequest { get; set; }

        public int Unauthorized { get; set; }

        public int NotFound { get; set; }

        public int TransactionFailed { get; set; }

        public int TransactionRejected { get; set; }

        public int InvalidPIN { get; set; }

        public int TransactionProcessing { get; set; }

        public int TransactionReversed { get; set; }

        public int AccountSuspended { get; set; }

        public int POSDeactivated { get; set; }

        public int PendingTaxes { get; set; }

        public int ClearedTaxes { get; set; }
    }
}
