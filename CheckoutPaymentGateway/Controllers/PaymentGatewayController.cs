using Payment.IBL;
using Payment.Model.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckoutPaymentGateway.Controllers
{
    public class PaymentGatewayController : Controller
    {
        public IPaymentGateway _service;
        public PaymentGatewayController(IPaymentGateway service)
        {
            _service = service;
        }
        // GET: PaymentGateway
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ProcessPayments(CardDetailDTO cardDetail)
        {            
            var result = _service.MakePayment(cardDetail);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RetreivePayments(Guid Identifier)
        {
            var result = _service.RetrievePreviousPayment(Identifier);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}