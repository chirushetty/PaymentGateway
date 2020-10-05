using Payment.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.IBL
{
    public interface IBankRepository
    {
        BankPaymentResponseDTO MakePayment(CardDetailDTO cardDetail);
        BankPreviousPaymentDetailDTO RetrievePreviousPayment(Guid identifier);
    }
}
