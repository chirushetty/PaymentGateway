using Payment.IBL;
using Payment.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BL
{
    public class MockBankRepository : IBankRepository
    {
        public BankPaymentResponseDTO MakePayment(CardDetailDTO cardDetail)
        {
            BankPaymentResponseDTO payment = new BankPaymentResponseDTO()
            {
                Identifier = new Guid(),
                Status = "Success"
            };
            return payment;
        }

        public BankPreviousPaymentDetailDTO RetrievePreviousPayment(Guid identifier)
        {
            BankPreviousPaymentDetailDTO paymentDetail = new BankPreviousPaymentDetailDTO()
            {
                Amount = 100,
                CardNumber = "1234567891234567",
                Currency = "Euro",
                PaymentStatusCode = 200
            };
            return paymentDetail;
        }
    }
}
