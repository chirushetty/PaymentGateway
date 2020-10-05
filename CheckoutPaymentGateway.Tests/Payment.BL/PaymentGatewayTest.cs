using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Payment.BL;
using Payment.IBL;
using Payment.Model.DTOS;

namespace CheckoutPaymentGateway.Tests.Payment.BL
{
    [TestClass]
    public class PaymentGatewayTest
    {
        private readonly Mock<IBankRepository> mockBankRepositoryService = new Mock<IBankRepository>();

        [TestMethod]
        public void MakePayment_ShouldReturnTrue_WhenPassedValidCardDetails()
        {
            //ExpiryDate expiryDate = new ExpiryDate() { Month = 07, Year = 2022 };
            CardDetailDTO card = new CardDetailDTO()
            {
                Amount = 100,
                CardNumber = "1234567891234567",
                Currency = "Euro",
                Cvv = 123,
                ExpiryDate = "07/2022"
            };
            BankPaymentResponseDTO payment = new BankPaymentResponseDTO()
            {
                Identifier = new Guid(),
                Status = "Success"
            };
            mockBankRepositoryService.Setup(x => x.MakePayment(card)).Returns(payment);
            PaymentGateway paymentGateway = new PaymentGateway(mockBankRepositoryService.Object);
            var result = paymentGateway.MakePayment(card);
            Assert.AreEqual(result.IsSuccess, true);
        }

        [TestMethod]
        public void MakePayment_ShouldReturnFalse_WhenPassedInvalidCardExpiryDate()
        {
            CardDetailDTO card = new CardDetailDTO()
            {
                Amount = 100,
                CardNumber = "1234567891234567",
                Currency = "Euro",
                Cvv = 123,
                ExpiryDate = "05/2020"
            };
            BankPaymentResponseDTO payment = new BankPaymentResponseDTO()
            {
                Identifier = new Guid(),
                Status = "Success"
            };
            mockBankRepositoryService.Setup(x => x.MakePayment(card)).Returns(payment);
            PaymentGateway paymentGateway = new PaymentGateway(mockBankRepositoryService.Object);
            var result = paymentGateway.MakePayment(card);
            Assert.AreEqual(result.IsSuccess, false);
        }

        [TestMethod]
        public void MakePayment_ShouldReturnFalse_WhenPassedInvalidCardCvv()
        {
            CardDetailDTO card = new CardDetailDTO()
            {
                Amount = 100,
                CardNumber = "1234567891234567",
                Currency = "Euro",
                Cvv = 1234,
                ExpiryDate = "12/2020"
            };
            BankPaymentResponseDTO payment = new BankPaymentResponseDTO()
            {
                Identifier = new Guid(),
                Status = "Success"
            };
            mockBankRepositoryService.Setup(x => x.MakePayment(card)).Returns(payment);
            PaymentGateway paymentGateway = new PaymentGateway(mockBankRepositoryService.Object);
            var result = paymentGateway.MakePayment(card);
            Assert.AreEqual(result.IsSuccess, false);
        }

        [TestMethod]
        public void RetrievePayment_ShouldReturnPaymentDetail_WhenPassedValidIdentifier()
        {
            Guid identifier = new Guid();
            BankPreviousPaymentDetailDTO paymentDetail = new BankPreviousPaymentDetailDTO()
            {
                Amount = 100,
                CardNumber = "1234567891234567",
                Currency = "Euro",
                PaymentStatusCode = 200
            };
            mockBankRepositoryService.Setup(x => x.RetrievePreviousPayment(identifier)).Returns(paymentDetail);
            PaymentGateway paymentGateway = new PaymentGateway(mockBankRepositoryService.Object);
            var result = paymentGateway.RetrievePreviousPayment(identifier);
            Assert.AreEqual(result.PaymentStatusCode, 200);
        }
    }
}
