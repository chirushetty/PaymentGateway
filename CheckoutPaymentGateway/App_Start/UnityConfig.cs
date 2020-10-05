using Payment.BL;
using Payment.IBL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CheckoutPaymentGateway
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IPaymentGateway, PaymentGateway>();
            container.RegisterType<IBankRepository, MockBankRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}