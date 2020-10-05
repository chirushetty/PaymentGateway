using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Payment.BL.HelperClass
{
    public static class CardValidation
    {
        public static bool ValidateExpiryDate(string expiryDate)
        {
            string[] cardExpiryDate = Regex.Split(expiryDate, "/");
            string[] currentDate = Regex.Split(DateTime.Now.ToString("MM/yyyy", CultureInfo.InvariantCulture), "/");
            int compareYears = string.Compare(cardExpiryDate[1], currentDate[1]);
            int compareMonths = string.Compare(cardExpiryDate[0], currentDate[0]);

            //if expiration date is in MM/YYYY format
            if (Regex.Match(expiryDate, @"^\d{2}/\d{4}$").Success)
            {
                //if month is "01-12"
                if (Regex.Match(cardExpiryDate[0], @"^[0][1-9]|[1][0-2]$").Success)
                {
                    //if expiration date is after current date
                    if ((compareYears == 1) || (compareYears == 0 && (compareMonths == 1)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ValidateCvvNumber(int cvv)
        {
            bool isValid = Regex.Match(cvv.ToString(), @"^\d{3}$").Success;
            return isValid;
        }
    }
}
