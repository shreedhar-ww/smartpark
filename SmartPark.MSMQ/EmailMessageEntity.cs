using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartPark.MSMQ
{
    [Serializable]
    public class EmailMessageEntity
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string validUntil { get; set; }
        // public string Message { get; set; }
        public string TemplateName { get; set; }
        public string Logo { get; set; }
        public string Body { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
    } 
}
