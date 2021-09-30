﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Models.SqlViewModels
{
    public class BillerTotalUser
    {
        public string BillerName { get; set; }

        public int BillerId { get; set; }

        public Biller Biller { get; set; }

        public int TotalUser { get; set; }
    }
}
