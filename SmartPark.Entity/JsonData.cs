using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPark.Entity
{
    public enum Method
    {
        ProcessPayment = 1,
        CreateTokenCustomer = 2,
        UpdateTokenCustomer = 3,
        TokenPayment = 4
    }

    public class JsonData
    {
        public class Customer
        {
            private long? _TokenCustomerID;
            public long? TokenCustomerID
            {
                get { return _TokenCustomerID; }
                set { _TokenCustomerID = value; }
            }

            private string _Reference;

            public string Reference
            {
                get { return _Reference; }
                set { _Reference = value; }
            }
            private string _Title;

            public string Title
            {
                get { return _Title; }
                set { _Title = value; }
            }
            private string _FirstName;

            public string FirstName
            {
                get { return _FirstName; }
                set { _FirstName = value; }
            }
            private string _LastName;

            public string LastName
            {
                get { return _LastName; }
                set { _LastName = value; }
            }
            private string _CompanyName;

            public string CompanyName
            {
                get { return _CompanyName; }
                set { _CompanyName = value; }
            }
            private string _JobDescription;

            public string JobDescription
            {
                get { return _JobDescription; }
                set { _JobDescription = value; }
            }
            private string _Street1;

            public string Street1
            {
                get { return _Street1; }
                set { _Street1 = value; }
            }
            private string _Street2;

            public string Street2
            {
                get { return _Street2; }
                set { _Street2 = value; }
            }
            private string _City;

            public string City
            {
                get { return _City; }
                set { _City = value; }
            }
            private string _State;

            public string State
            {
                get { return _State; }
                set { _State = value; }
            }
            private string _PostalCode;

            public string PostalCode
            {
                get { return _PostalCode; }
                set { _PostalCode = value; }
            }
            private string _Country;

            public string Country
            {
                get { return _Country; }
                set { _Country = value; }
            }
            private string _Phone;

            public string Phone
            {
                get { return _Phone; }
                set { _Phone = value; }
            }
            private string _Mobile;

            public string Mobile
            {
                get { return _Mobile; }
                set { _Mobile = value; }
            }
            private string _Email;

            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }
            private string _Url;

            public string Url
            {
                get { return _Url; }
                set { _Url = value; }
            }
        }

        public class ShippingAddress
        {
            private string _ShippingMethod;

            public string ShippingMethod
            {
                get { return _ShippingMethod; }
                set { _ShippingMethod = value; }
            }
            private string _FirstName;

            public string FirstName
            {
                get { return _FirstName; }
                set { _FirstName = value; }
            }
            private string _LastName;

            public string LastName
            {
                get { return _LastName; }
                set { _LastName = value; }
            }
            private string _Street1;

            public string Street1
            {
                get { return _Street1; }
                set { _Street1 = value; }
            }
            private string _Street2;

            public string Street2
            {
                get { return _Street2; }
                set { _Street2 = value; }
            }
            private string _City;

            public string City
            {
                get { return _City; }
                set { _City = value; }
            }
            private string _State;

            public string State
            {
                get { return _State; }
                set { _State = value; }
            }
            private string _Country;

            public string Country
            {
                get { return _Country; }
                set { _Country = value; }
            }
            private string _PostalCode;

            public string PostalCode
            {
                get { return _PostalCode; }
                set { _PostalCode = value; }
            }
            private string _Phone;

            public string Phone
            {
                get { return _Phone; }
                set { _Phone = value; }
            }
        }

        public class LineItem
        {
            public string SKU;
            public string Description;
            public int Quantity;
            public int UnitCost;
            public int Tax;
            public int Total;
        }

        public class Option
        {
            private string _Value;

            public string Value
            {
                get { return _Value; }
                set { _Value = value; }
            }
        }

        public class Payment
        {

            private string _TotalAmount;
            private string _InvoiceNumber;
            private string _InvoiceDescription;
            private string _InvoiceReference;
            private string _CurrencyCode;


            public string TotalAmount
            {
                get { return _TotalAmount; }
                set { _TotalAmount = value; }
            }

            public string InvoiceNumber
            {
                get { return _InvoiceNumber; }
                set { _InvoiceNumber = value; }
            }

            public string InvoiceDescription
            {
                get { return _InvoiceDescription; }
                set { _InvoiceDescription = value; }
            }

            public string InvoiceReference
            {
                get { return _InvoiceReference; }
                set { _InvoiceReference = value; }
            }

            public string CurrencyCode
            {
                get { return _CurrencyCode; }
                set { _CurrencyCode = value; }
            }

        }

        public class Data
        {
            private Customer _Customer = new Customer();
            private ShippingAddress _ShippingAddress;
            private List<LineItem> _Items;
            private List<Option> _Options;
            private Payment _Payment;
            private string _RedirectUrl;
            private string _CancelUrl;
            private Method _Method;

            public Customer Customer
            {
                get { return _Customer; }
                set { _Customer = value; }
            }

            public ShippingAddress ShippingAddress
            {
                get { return _ShippingAddress; }
                set { _ShippingAddress = value; }
            }

            public List<LineItem> Items
            {
                get { return _Items; }
                set { _Items = value; }
            }

            public List<Option> Options
            {
                get { return _Options; }
                set { _Options = value; }
            }

            public Payment Payment
            {
                get { return _Payment; }
                set { _Payment = value; }
            }

            public string RedirectUrl
            {
                get { return _RedirectUrl; }
                set { _RedirectUrl = value; }
            }

            public string CancelUrl
            {
                get { return _CancelUrl; }
                set { _CancelUrl = value; }
            }

            public Method Method
            {
                get { return _Method; }
                set { _Method = value; }
            }

            //public string CancelUrl ;
            //public string DeviceID ;
            //public string CustomerIP ;
            //public string PartnerID ;
            //public string TransactionType ;
            //public string LogoUrl ;
            //public string HeaderText ;
            //public string Language ;
            //public bool CustomerReadOnly ;
            //public string CustomView ;
            //public bool VerifyCustomerPhone ;
            //public bool VerifyCustomerEmail ;

        }
    }
}
