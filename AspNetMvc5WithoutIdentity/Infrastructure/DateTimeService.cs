using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvc5WithoutIdentity.Infrastructure
{
    public class DateTimeService : IDateTimeService
    {
        public string GetDateTime()
        {
            return DateTime.Now.ToString();
        }
    }
}