using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Model.DTOS
{
    public class BankPaymentResponseDTO
    {
        public string Status { get; set; }
        public Guid Identifier { get; set; }
    }
}
