using System;

namespace propertymanagement.service.Models
{
    public class MessageNotifications
    {
        public String UserName { get; set; }
        public String ContactName { get; set; }
        public String Message { get; set; }
        public String SendDate { get; set; }

    }

    public class StatusResult
    {
        public string STATUS { get; set; }
        public int HEADER_ID { get; set; }
        public string MESSAGE { get; set; }
    }

}
