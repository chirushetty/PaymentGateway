using Payment.BL.HelperClass;
using Payment.IBL;
using Payment.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BL
{
    public class PaymentGateway : IPaymentGateway
    {
        public IBankRepository IBankRepo { get; set; }
        public JsonResultDTO jsonResult { get; set; }

        public PaymentGateway(IBankRepository iBankRepo)
        {
            IBankRepo = iBankRepo;
            jsonResult = new JsonResultDTO();
        }

        public JsonResultDTO MakePayment(CardDetailDTO cardDetail)
        {
            var isExpiryDateValid = CardValidation.ValidateExpiryDate(cardDetail.ExpiryDate);

            if (isExpiryDateValid)
            {
                var bankResponse = IBankRepo.MakePayment(cardDetail);
                if (bankResponse.Status == "Success")
                {
                    jsonResult.IsSuccess = true;
                    jsonResult.TransactionId = bankResponse.Identifier;
                }
                else
                {
                    jsonResult.IsSuccess = false;
                    jsonResult.Errors.Add("Bank responded payment unsuccessful");
                }
            }
            else
            {
                jsonResult.IsSuccess = false;
                jsonResult.Errors.Add("The credit card is expired");
            }
            return jsonResult;
        }

        public BankPreviousPaymentDetailDTO RetrievePreviousPayment(Guid identifier)
        {
            var paymentInfo = IBankRepo.RetrievePreviousPayment(identifier);

            if (paymentInfo.CardNumber != "")
            {
                paymentInfo.CardNumber = MaskingNumber.MaskingCreditCardNumber(paymentInfo.CardNumber);
            }

            return paymentInfo;
        }
    }
}
