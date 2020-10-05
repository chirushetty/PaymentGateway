using System;
using System.Web.Helpers;
using System.Web.Mvc;
using CheckoutPaymentGateway.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Payment.IBL;
using Payment.Model.DTOS;

namespace CheckoutPaymentGateway.Tests.Controllers
{
    [TestClass]
    public class PaymentGatewayControllerTest
    {
        private readonly Mock<IBankRepository> mockBankRepositoryService = new Mock<IBankRepository>();
        private readonly Mock<IPaymentGateway> mockPaymentGateService = new Mock<IPaymentGateway>();
        //private readonly PaymentGatewayController _paymentGatewayController = new PaymentGatewayController(mockPaymentGateService);
        private PaymentGatewayController _paymentGatewayController;

        [TestMethod]
        public void ProcessPayments_ShouldReturnSucessfull_WhenWithProperCardDetail()
        {
            //ExpiryDate expiryDate = new ExpiryDate() { Month = 07, Year = 2022 };
            CardDetailDTO card = new CardDetailDTO()
            {
                Amount = 100,
                CardNumber = "1234567891234567",
                Currency = "Euro",
                Cvv = 123,
                ExpiryDate = "12/2020"
            };

            JsonResultDTO result = new JsonResultDTO()
            {
                IsSuccess = true,
                TransactionId = new Guid(),
            };

            mockPaymentGateService.Setup(x => x.MakePayment(card)).Returns(result);
            _paymentGatewayController = new PaymentGatewayController(mockPaymentGateService.Object);
            JsonResult paymentInfo = _paymentGatewayController.ProcessPayments(card);

            Assert.AreEqual(result, paymentInfo.Data);
        }

        [TestMethod]
        public void RetrievePayments_ShouldReturnSuccessfullPayment_WhenGivenValidIdentifier()
        {
            var Identifier = new Guid();
            BankPreviousPaymentDetailDTO paymentDetail = new BankPreviousPaymentDetailDTO()
            {
                Amount = 100,
                Currency = "Euro",
                CardNumber = "1234567891234567",
                PaymentStatusCode = 200
            };
            mockPaymentGateService.Setup(x => x.RetrievePreviousPayment(Identifier)).Returns(paymentDetail);
            _paymentGatewayController = new PaymentGatewayController(mockPaymentGateService.Object);
            JsonResult paymentInfo = _paymentGatewayController.RetreivePayments(Identifier);

        }
    }
}
