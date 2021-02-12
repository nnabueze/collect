using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErcasCollect.Helpers
{
    public class TypeAndChannelHelper
    {
        public static string PaymentChannel(int paymentChannelId)
        {
            switch (paymentChannelId)
            {
                case 1:
                    return "Pos";
                case 2:
                    return "NIBSS";
                case 3:
                    return "Flex";
                default:

                    return null;
            }
        }

        public static string TransactionType(int typeId)
        {
            switch (typeId)
            {
                case 1:
                    return "Collection";
                case 3:
                    return "Remittance";
                case 4:
                    return "Tax";
                case 5:
                    return "Invoice";
                case 6:
                    return "NonTax";
                case 7:
                    return "Card";
                default:
                    return null;
            }
        }
    }
}
