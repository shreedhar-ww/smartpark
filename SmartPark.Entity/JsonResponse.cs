using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{

    
    public class JsonResponse
    {
        public JsonResponse(string error)
        {
            Errors = error;
        }

        public TokenCustomer Customer;

        public Payment Payment;

        public string Errors;

        public string AccessCode;

        public string FormActionURL;

        public string SharedPaymentUrl;

        public long TokenCustomerID;
    }
}
