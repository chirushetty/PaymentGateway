using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Model.DTOS
{
    public class BankPreviousPaymentDetailDTO
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int PaymentStatusCode { get; set; }
    }
}
