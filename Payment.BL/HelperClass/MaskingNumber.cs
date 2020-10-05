using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.BL.HelperClass
{
    public static class MaskingNumber
    {
        public static string MaskingCreditCardNumber(string cardNumber)
        {
            string result = cardNumber;
            if (cardNumber.Length > 3)
            {
                result = cardNumber.Substring(cardNumber.Length - 4).PadLeft(cardNumber.Length, '*');
            }

            return result;
        }
    }
}
