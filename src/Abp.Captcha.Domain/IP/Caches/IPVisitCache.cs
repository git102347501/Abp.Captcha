using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalConch.Abp.Captcha.IP.Caches
{
    public class IPVisitCache
    {
        public List<DateTime> DateTimeList { get; set; }

        public IPVisitCache()
        {

        }

        public IPVisitCache(DateTime date)
        {
            this.DateTimeList = new List<DateTime>()
            {
                date
            };
        }
    }
}
