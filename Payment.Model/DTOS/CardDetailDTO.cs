using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Model.DTOS
{
    public class CardDetailDTO
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public int Cvv { get; set; }
        public string Currency { get; set; }
        public string ExpiryDate { get; set; }
    }
}
