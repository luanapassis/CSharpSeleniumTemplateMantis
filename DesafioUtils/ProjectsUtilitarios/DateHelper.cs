using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioUtils.ProjectsUtilitarios
{
    public static class DateHelper
    {

        public static string GetDateNow()
        {
            DateTime dta = DateTime.Now;
            string dtaStr = dta.ToString("dd/MM/yyyy");

            return dtaStr;

        }

        public static string GetDateTimeNow()
        {
            DateTime dta = DateTime.Now;
            string dtaStr = dta.ToString("dd/MM/yyyy HH:mm:ss");

            return dtaStr;

        }

        public static String GetMonth()
        {
            DateTime dta = DateTime.Now;
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dta.Month);
        }

    }
}
