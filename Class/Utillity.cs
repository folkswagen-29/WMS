using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace onlineLegalWF.Class
{
    public static class Utillity
    {
        public static bool DateValidateInput(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static string ConvertDateToLongDateTime(DateTime dt, string lang = "th")
        {
            if (lang == "th")
            {

                return DateValidateInput(dt) ? dt.ToString("d MMMM yyyy", new CultureInfo("th-TH")) : "";
            }
            else
            {
                return DateValidateInput(dt) ? dt.ToString("d MMMM yyyy", new CultureInfo("en-US")) : "";
            }
        }

        public static DateTime ConvertStringToDate(string yyyyMMdd)
        {
            DateTime dt;
            if (DateTime.TryParseExact(yyyyMMdd,
                                        "yyyy-MM-dd",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                //valid date

            }
            else
            {
                //invalid date
                dt = DateTime.Now;
            }
            return dt;
        }
    }
}